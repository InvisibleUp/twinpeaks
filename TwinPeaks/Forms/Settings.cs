using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwinPeaks.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Font font;
            Color color;

            // FontContent
            font = Properties.Settings.Default.fontContent;
            dlgFontContent.Font = font;
            btnFontContent.Font = font;
            btnFontContent.Text = font.Name + " " + font.SizeInPoints + "pt";
            // FontMonospace
            font = Properties.Settings.Default.fontMonospace;
            dlgFontMonospace.Font = font;
            btnFontMonospace.Font = font;
            btnFontMonospace.Text = font.Name + " " + font.SizeInPoints + "pt";

            // Font sizes
            numH1.Value = Properties.Settings.Default.fontSizeH1;
            numH2.Value = Properties.Settings.Default.fontSizeH2;
            numH3.Value = Properties.Settings.Default.fontSizeH3;

            // ColorBG
            color = Properties.Settings.Default.colorBG;
            dlgColorBG.Color = color;
            btnColorBG.BackColor = color;
            btnColorBG.ForeColor = Color.FromArgb(color.ToArgb() ^ 0xffffff);
            btnColorBG.Text = color.ToString();
            // ColorFG
            color = Properties.Settings.Default.colorFG;
            dlgColorFG.Color = color;
            btnColorFG.BackColor = color;
            btnColorFG.ForeColor = Color.FromArgb(color.ToArgb() ^ 0xffffff);
            btnColorFG.Text = color.ToString();
            // ColorLink
            color = Properties.Settings.Default.colorLink;
            dlgColorLink.Color = color;
            btnColorLink.BackColor = color;
            btnColorLink.ForeColor = Color.FromArgb(color.ToArgb() ^ 0xffffff);
            btnColorLink.Text = color.ToString();

            // Homepage
            tbHome.Text = Properties.Settings.Default.uriHome.ToString();
        }

        private void btnFontContent_Click(object sender, EventArgs e)
        {
            var result = dlgFontContent.ShowDialog();
            if (result == DialogResult.OK) {
                Font font = dlgFontContent.Font;
                Properties.Settings.Default.fontContent = font;
                btnFontContent.Font = font;
                btnFontContent.Text = font.Name + " " + font.SizeInPoints + "pt";
            }
        }

        private void btnFontMonospace_Click(object sender, EventArgs e)
        {
            var result = dlgFontMonospace.ShowDialog();
            if (result == DialogResult.OK) {
                Font font = dlgFontMonospace.Font;
                Properties.Settings.Default.fontMonospace = font;
                btnFontMonospace.Font = font;
                btnFontMonospace.Text = font.Name + " " + font.SizeInPoints + "pt";
            }
        }

        private void btnColorFG_Click(object sender, EventArgs e)
        {
            var result = dlgColorFG.ShowDialog();
            if (result == DialogResult.OK) {
                Color color = dlgColorFG.Color;
                Properties.Settings.Default.colorFG = color;
                btnColorFG.BackColor = color;
                btnColorFG.ForeColor = Color.FromArgb(color.ToArgb() ^ 0xffffff);
                btnColorFG.Text = color.ToString();
            }
        }

        private void btnColorBG_Click(object sender, EventArgs e)
        {
            var result = dlgColorBG.ShowDialog();
            if (result == DialogResult.OK) {
                Color color = dlgColorBG.Color;
                Properties.Settings.Default.colorBG = color;
                btnColorBG.BackColor = color;
                btnColorBG.ForeColor = Color.FromArgb(color.ToArgb() ^ 0xffffff);
                btnColorBG.Text = color.ToString();
            }
        }

        private void btnColorLink_Click(object sender, EventArgs e)
        {
            var result = dlgColorLink.ShowDialog();
            if (result == DialogResult.OK) {
                Color color = dlgColorLink.Color;
                Properties.Settings.Default.colorLink = color;
                btnColorLink.BackColor = color;
                btnColorLink.ForeColor = Color.FromArgb(color.ToArgb() ^ 0xffffff);
                btnColorLink.Text = color.ToString();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // slurp up everything else
            try {
                Properties.Settings.Default.uriHome = new Uri(tbHome.Text);
            } catch (Exception) {
                MessageBox.Show(
                    "The homepage value is not a URL.",
                    "Settings Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }

            Properties.Settings.Default.fontSizeH1 = (short)numH1.Value;
            Properties.Settings.Default.fontSizeH2 = (short)numH2.Value;
            Properties.Settings.Default.fontSizeH3 = (short)numH3.Value;

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            this.Close();
        }

        // TODO: this probably isn't the way to handle this...
        private void btnRegHandler_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("TwinPeaksGemini");
            string appPath = Environment.GetCommandLineArgs()[0];

            if (key == null)
            {
                key = Registry.ClassesRoot.CreateSubKey("TwinPeaksGemini");
            }

            key.SetValue(string.Empty, "URL: Gemini");
            key.SetValue("URL Protocol", string.Empty);

            key = key.CreateSubKey(@"shell\open\command");
            key.SetValue(string.Empty, appPath + " " + "%1");

            key.Close();
        }
        private void btnUnregHandler_Click(object sender, EventArgs e)
        {
            Registry.ClassesRoot.DeleteSubKeyTree("TwinPeaksGemini");
        }
    }
}
