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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Ready";

            // Navigate to homepage
            tbURL.Text = home.ToString();
            btnGo_Click(null, null);
        }

        private void btnGo_Click(object sender, EventArgs evt)
        {
            Uri target = new Uri(tbURL.Text);
            string content;
            
            try {
                switch(target.Scheme) {
                case "gemini":
                    content = GeminiClient.Fetch(target);
                    break;
                default:
                    //System.Launcher.LaunchUriAsync(target);
                    Log.Error("Unknown URI scheme {scheme}", target.Scheme);
                    lblStatus.Text = string.Format("Unknown URI scheme {0}", target.Scheme);
                    return;
                }
            } catch (Exception e) {
                lblStatus.Text = "Error loading page";//e.ToString();
                rtbContent.Text = e.ToString();
                return;
                //throw e;
            }

            rtbContent.Text = content;
            lblStatus.Text = "Ready";
        }
    }
}
