using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace TwinPeaks
{
    public partial class MainForm : Form
    {
        List<Uri> history = new List<Uri>();
        int historyPos = -1;
        Uri home = new Uri("gemini://gemini.conman.org/test/torture/");

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Ready";

            // Navigate to homepage
            Navigate(home);
            UpdateHistory(home);
        }

        // Add page to history
        private void UpdateHistory(Uri target)
        {
            historyPos += 1;
            history = history.Take(historyPos).ToList();
            history.Add(target);
        }

        private async void Navigate(Uri target)
        {
            Protocols.IResponse resp;
            lblStatus.Text = "Loading...";
            
            try {
                switch(target.Scheme) {
                case "gemini":
                    resp = await Protocols.Gemini.Fetch(target);
                    break;
                default:
                    //System.Launcher.LaunchUriAsync(target);
                    Log.Error("Unknown URI scheme '{scheme}'", target.Scheme);
                    lblStatus.Text = string.Format("Unknown URI scheme '{0}'", target.Scheme);
                    return;
                }
            } catch (Exception e) {
                lblStatus.Text = "Error loading page";//e.ToString();
                rtbContent.Text = e.ToString();
                return;
            }

            rtbContent.Text = "";
            switch (resp.mime) {
            case "text/gemini":
                rtbContent.Rtf = FileHandlers.TextGemini.Format(resp.pyld.ToArray());
                break;
            default: // interpet as plain text by default
                rtbContent.Rtf = FileHandlers.TextPlain.Format(resp.pyld.ToArray());
                break; 
            }

            lblStatus.Text = "Ready";
            tbURL.Text = target.AbsoluteUri;
        }

        private void btnGo_Click(object sender, EventArgs evt)
        {
            Uri target = new Uri(tbURL.Text);
            Navigate(target);
            UpdateHistory(target);
        }

        private void rtbContent_LinkClicked(object sender, LinkClickedEventArgs evt)
        {
            Uri newUri;
            Log.Debug(evt.LinkText);

            try {
                newUri = new Uri(evt.LinkText);
            } catch (Exception e) {
                try {
                    newUri = new Uri(history[historyPos], evt.LinkText);
                } catch (Exception e2) {
                    Log.Error(e2, "Invalid URL");
                    lblStatus.Text = "Error loading page";
                    rtbContent.Text = string.Format("Could not load page {0}", evt.LinkText);
                    return;
                }
            }

            Navigate(newUri);
            UpdateHistory(newUri);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (historyPos <= 0) { return; }
            historyPos -= 1;
            Navigate(history[historyPos]);
        }

        private void btnFwd_Click(object sender, EventArgs e)
        {
            if (historyPos+1 >= history.Count()) { return; }
            historyPos += 1;
            Navigate(history[historyPos]);
        }
    }
}
