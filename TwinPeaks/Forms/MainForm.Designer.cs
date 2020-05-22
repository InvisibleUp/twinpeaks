namespace TwinPeaks
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.htmlContent = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.btnForward = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnHome = new System.Windows.Forms.ToolStripButton();
            this.tbURL = new TwinPeaks.Controls.ToolStripSpringTextBox();
            this.menuOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGo = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 402);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(646, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "Ready";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.Text = "lblStatus";
            // 
            // htmlContent
            // 
            this.htmlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlContent.AutoScroll = true;
            this.htmlContent.AutoScrollMinSize = new System.Drawing.Size(646, 20);
            this.htmlContent.BackColor = System.Drawing.SystemColors.Window;
            this.htmlContent.BaseStylesheet = null;
            this.htmlContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.htmlContent.Location = new System.Drawing.Point(0, 25);
            this.htmlContent.Name = "htmlContent";
            this.htmlContent.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.htmlContent.Size = new System.Drawing.Size(646, 374);
            this.htmlContent.TabIndex = 6;
            this.htmlContent.Text = "htmlPanel1";
            this.htmlContent.UseGdiPlusTextRendering = true;
            this.htmlContent.UseSystemCursors = true;
            this.htmlContent.LinkClicked += new System.EventHandler<TheArtOfDev.HtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs>(this.htmlContent_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack,
            this.btnForward,
            this.btnRefresh,
            this.btnHome,
            this.tbURL,
            this.menuOptions,
            this.btnGo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(646, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Image = global::TwinPeaks.Properties.Resources.icoBack;
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 22);
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForward.Image = global::TwinPeaks.Properties.Resources.icoFwd;
            this.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(23, 22);
            this.btnForward.Text = "Forwards";
            this.btnForward.Click += new System.EventHandler(this.btnFwd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::TwinPeaks.Properties.Resources.icoRefresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHome
            // 
            this.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHome.Image = global::TwinPeaks.Properties.Resources.icoHome;
            this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(23, 22);
            this.btnHome.Text = "Home";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // tbURL
            // 
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(440, 25);
            this.tbURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbURL_KeyPress);
            // 
            // menuOptions
            // 
            this.menuOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings,
            this.btnAbout});
            this.menuOptions.Image = global::TwinPeaks.Properties.Resources.icoOptions;
            this.menuOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(29, 22);
            this.menuOptions.Text = "Options";
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(164, 22);
            this.btnSettings.Text = "Settings...";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(164, 22);
            this.btnAbout.Text = "About TwinPeaks";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnGo
            // 
            this.btnGo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGo.Image = global::TwinPeaks.Properties.Resources.icoFwd;
            this.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(42, 22);
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 424);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.htmlContent);
            this.Controls.Add(this.statusStrip);
            this.Name = "MainForm";
            this.Text = "Twin Peaks";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlContent;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripButton btnForward;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnHome;
        private TwinPeaks.Controls.ToolStripSpringTextBox tbURL;
        private System.Windows.Forms.ToolStripButton btnGo;
        private System.Windows.Forms.ToolStripDropDownButton menuOptions;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
    }
}

