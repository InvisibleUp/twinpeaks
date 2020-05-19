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
        Uri home = new Uri("gemini://gemini.circumlunar.space/");
        //Uri home = new Uri("gemini://gemini.conman.org/test/torture/");

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Ready";

            // Navigate to homepage
            Navigate(home);
        }

        private async void Navigate(Uri target)
        {
            byte[] data;
            lblStatus.Text = "Loading...";
            
            try {
                switch(target.Scheme) {
                case "gemini":
                    data = await Protocols.Gemini.Fetch(target);
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
                //throw e;
            }

            // be lazy, assume gemini
            rtbContent.Rtf = FileHandlers.Gemini.Format(data);
            lblStatus.Text = "Ready";
            tbURL.Text = target.AbsoluteUri;
            history.Add(target);
        }

        private void btnGo_Click(object sender, EventArgs evt)
        {
            Uri target = new Uri(tbURL.Text);
            Navigate(target);
        }

        private void rtbContent_LinkClicked(object sender, LinkClickedEventArgs evt)
        {
            Uri newUri;
            Log.Debug(evt.LinkText);

            try {
                newUri = new Uri(evt.LinkText);
            } catch (Exception e) {
                Uri oldUri = new Uri(tbURL.Text);
                newUri = new Uri(oldUri, evt.LinkText);
            }

            Navigate(newUri);
        }
    }
}
