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
using TheArtOfDev.HtmlRenderer.Core.Entities;

namespace TwinPeaks
{
    public partial class MainForm : Form
    {
        List<Uri> history = new List<Uri>();
        int historyPos = -1;
        Uri home = new Uri("gemini://gemini.circumlunar.space/");

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Ready";

            // Navigate to homepage
            await Navigate(home);
            UpdateHistory(home);
        }

        // Add page to history
        private void UpdateHistory(Uri target)
        {
            historyPos += 1;
            history = history.Take(historyPos).ToList();
            history.Add(target);
        }

        private async Task<bool> Navigate(Uri target)
        {
            Protocols.IResponse resp;
            lblStatus.Text = "Loading...";
            
            try {
                switch(target.Scheme) {
                case "gemini":
                    resp = await Protocols.Gemini.Fetch(target);
                    break;
                default:
                    Log.Error("Unknown URI scheme '{scheme}'", target.Scheme);
                    lblStatus.Text = string.Format("Unknown URI scheme '{0}'", target.Scheme);
                    return false;
                }
            } catch (Exception e) {
                lblStatus.Text = "Error loading page";//e.ToString();
                htmlContent.Text = e.ToString();
                return false;
            }

            htmlContent.Text = "";
            switch (resp.mime) {
            case "text/gemini": {
                var fmt = new FileHandlers.TextGemini();
                htmlContent.Text = fmt.Format(resp.pyld.ToArray());
                break;
            }
            default: // interpet as plain text by default
                htmlContent.Text = FileHandlers.TextPlain.Format(resp.pyld.ToArray());
                break; 
            }

            lblStatus.Text = "Ready";
            tbURL.Text = target.AbsoluteUri;
            return true;
        }

        private async void btnGo_Click(object sender, EventArgs evt)
        {
            Uri target = new Uri(tbURL.Text);
            if (await Navigate(target)) {
                UpdateHistory(target);
            }
        }

        private async void btnBack_Click(object sender, EventArgs e)
        {
            if (historyPos <= 0) { return; }
            historyPos -= 1;
            await Navigate(history[historyPos]);
        }

        private async void btnFwd_Click(object sender, EventArgs e)
        {
            if (historyPos+1 >= history.Count()) { return; }
            historyPos += 1;
            await Navigate(history[historyPos]);
        }

        private async void htmlContent_LinkClicked(object sender, HtmlLinkClickedEventArgs evt)
        {
            Uri newUri;
            Log.Debug(evt.Link);

            if (evt.Link.StartsWith("gemini://")) {
                evt.Handled = true;
            }

            try {
                newUri = new Uri(evt.Link);
            } catch (Exception e) {
                try {
                    newUri = new Uri(history[historyPos], evt.Link);
                } catch (Exception e2) {
                    Log.Error(e2, "Invalid URL");
                    lblStatus.Text = "Error loading page";
                    htmlContent.Text = string.Format("Could not load page {0}", evt.Link);
                    return;
                }
            }

            if (await Navigate(newUri)) {
                UpdateHistory(newUri);
            }
        }
    }
}
