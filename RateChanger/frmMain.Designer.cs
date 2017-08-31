namespace RateChanger
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbxAudio = new System.Windows.Forms.CheckBox();
            this.tbxRate = new wmgCMS.WaterMarkTextBox();
            this.cbxPitch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(12, 11);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.ReadOnly = true;
            this.tbxFile.Size = new System.Drawing.Size(423, 20);
            this.tbxFile.TabIndex = 15;
            this.tbxFile.TabStop = false;
            this.tbxFile.Text = "Please select a file...";
            this.tbxFile.TextChanged += new System.EventHandler(this.tbxFile_TextChanged);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(441, 9);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(129, 23);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "Chose files to convert";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.FindFile);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(441, 120);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(129, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start Conversion";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStartConversion);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rate Changes";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Write \"1.2\" for a 1.2x verison of that beatmap. If you want to make multiple rate" +
    "s, please seperate with \";\" (next to the m key).";
            // 
            // cbxAudio
            // 
            this.cbxAudio.AutoSize = true;
            this.cbxAudio.Checked = true;
            this.cbxAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAudio.Location = new System.Drawing.Point(12, 124);
            this.cbxAudio.Name = "cbxAudio";
            this.cbxAudio.Size = new System.Drawing.Size(280, 17);
            this.cbxAudio.TabIndex = 2;
            this.cbxAudio.Text = "Convert audio files (will take about 1 min per beatmap)";
            this.cbxAudio.UseVisualStyleBackColor = true;
            this.cbxAudio.CheckedChanged += new System.EventHandler(this.cbxAudio_CheckedChanged);
            // 
            // tbxRate
            // 
            this.tbxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxRate.Location = new System.Drawing.Point(335, 46);
            this.tbxRate.Name = "tbxRate";
            this.tbxRate.Size = new System.Drawing.Size(100, 20);
            this.tbxRate.TabIndex = 1;
            this.tbxRate.WaterMarkColor = System.Drawing.Color.Gray;
            this.tbxRate.WaterMarkText = "e.g. \"1.2\"";
            // 
            // cbxPitch
            // 
            this.cbxPitch.AutoSize = true;
            this.cbxPitch.Checked = true;
            this.cbxPitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPitch.Location = new System.Drawing.Point(12, 101);
            this.cbxPitch.Name = "cbxPitch";
            this.cbxPitch.Size = new System.Drawing.Size(313, 17);
            this.cbxPitch.TabIndex = 3;
            this.cbxPitch.Text = "Keep the same pitch (night-/daycore fans should turn this off)";
            this.cbxPitch.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 153);
            this.Controls.Add(this.cbxPitch);
            this.Controls.Add(this.cbxAudio);
            this.Controls.Add(this.tbxRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.tbxFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Trippins Rate Converter (v1.0.0)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private wmgCMS.WaterMarkTextBox tbxRate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbxAudio;
        private System.Windows.Forms.CheckBox cbxPitch;
    }
}

