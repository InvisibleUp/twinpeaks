namespace TwinPeaks.Forms
{
    partial class Settings
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dlgFontContent = new System.Windows.Forms.FontDialog();
            this.dlgFontMonospace = new System.Windows.Forms.FontDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numH3 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numH2 = new System.Windows.Forms.NumericUpDown();
            this.numH1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFontMonospace = new System.Windows.Forms.Button();
            this.btnFontContent = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnColorLink = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnColorBG = new System.Windows.Forms.Button();
            this.btnColorFG = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbHome = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dlgColorFG = new System.Windows.Forms.ColorDialog();
            this.dlgColorBG = new System.Windows.Forms.ColorDialog();
            this.dlgColorLink = new System.Windows.Forms.ColorDialog();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numH3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(160, 297);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(322, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgFontMonospace
            // 
            this.dlgFontMonospace.FixedPitchOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numH3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numH2);
            this.groupBox1.Controls.Add(this.numH1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnFontMonospace);
            this.groupBox1.Controls.Add(this.btnFontContent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fonts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "###";
            // 
            // numH3
            // 
            this.numH3.Location = new System.Drawing.Point(326, 70);
            this.numH3.Name = "numH3";
            this.numH3.Size = new System.Drawing.Size(50, 20);
            this.numH3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "##";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "#";
            // 
            // numH2
            // 
            this.numH2.Location = new System.Drawing.Point(228, 70);
            this.numH2.Name = "numH2";
            this.numH2.Size = new System.Drawing.Size(50, 20);
            this.numH2.TabIndex = 7;
            // 
            // numH1
            // 
            this.numH1.Location = new System.Drawing.Point(135, 70);
            this.numH1.Name = "numH1";
            this.numH1.Size = new System.Drawing.Size(50, 20);
            this.numH1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Heading Sizes (pt)";
            // 
            // btnFontMonospace
            // 
            this.btnFontMonospace.Location = new System.Drawing.Point(118, 42);
            this.btnFontMonospace.Name = "btnFontMonospace";
            this.btnFontMonospace.Size = new System.Drawing.Size(258, 23);
            this.btnFontMonospace.TabIndex = 3;
            this.btnFontMonospace.Text = "Consolas, 11pt";
            this.btnFontMonospace.UseVisualStyleBackColor = true;
            this.btnFontMonospace.Click += new System.EventHandler(this.btnFontMonospace_Click);
            // 
            // btnFontContent
            // 
            this.btnFontContent.Location = new System.Drawing.Point(118, 15);
            this.btnFontContent.Name = "btnFontContent";
            this.btnFontContent.Size = new System.Drawing.Size(258, 23);
            this.btnFontContent.TabIndex = 2;
            this.btnFontContent.Text = "Arial, 11pt";
            this.btnFontContent.UseVisualStyleBackColor = true;
            this.btnFontContent.Click += new System.EventHandler(this.btnFontContent_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monospace";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Content";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnColorLink);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnColorBG);
            this.groupBox2.Controls.Add(this.btnColorFG);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colors";
            // 
            // btnColorLink
            // 
            this.btnColorLink.Location = new System.Drawing.Point(118, 78);
            this.btnColorLink.Name = "btnColorLink";
            this.btnColorLink.Size = new System.Drawing.Size(258, 23);
            this.btnColorLink.TabIndex = 5;
            this.btnColorLink.Text = "btnColorLink";
            this.btnColorLink.UseVisualStyleBackColor = true;
            this.btnColorLink.Click += new System.EventHandler(this.btnColorLink_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Hyperlink";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Background";
            // 
            // btnColorBG
            // 
            this.btnColorBG.Location = new System.Drawing.Point(118, 45);
            this.btnColorBG.Name = "btnColorBG";
            this.btnColorBG.Size = new System.Drawing.Size(258, 23);
            this.btnColorBG.TabIndex = 2;
            this.btnColorBG.Text = "btnColorBG";
            this.btnColorBG.UseVisualStyleBackColor = true;
            this.btnColorBG.Click += new System.EventHandler(this.btnColorBG_Click);
            // 
            // btnColorFG
            // 
            this.btnColorFG.Location = new System.Drawing.Point(118, 15);
            this.btnColorFG.Name = "btnColorFG";
            this.btnColorFG.Size = new System.Drawing.Size(258, 23);
            this.btnColorFG.TabIndex = 1;
            this.btnColorFG.Text = "btnColorFG";
            this.btnColorFG.UseVisualStyleBackColor = true;
            this.btnColorFG.Click += new System.EventHandler(this.btnColorFG_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Foreground";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbHome);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(13, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 53);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Behaviour";
            // 
            // tbHome
            // 
            this.tbHome.Location = new System.Drawing.Point(117, 17);
            this.tbHome.Name = "tbHome";
            this.tbHome.Size = new System.Drawing.Size(258, 20);
            this.tbHome.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Homepage";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(241, 297);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(413, 332);
            this.ControlBox = false;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numH3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FontDialog dlgFontContent;
        private System.Windows.Forms.FontDialog dlgFontMonospace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numH3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numH2;
        private System.Windows.Forms.NumericUpDown numH1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFontMonospace;
        private System.Windows.Forms.Button btnFontContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnColorBG;
        private System.Windows.Forms.Button btnColorFG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbHome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColorDialog dlgColorFG;
        private System.Windows.Forms.ColorDialog dlgColorBG;
        private System.Windows.Forms.Button btnColorLink;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColorDialog dlgColorLink;
        private System.Windows.Forms.Button btnReset;
    }
}