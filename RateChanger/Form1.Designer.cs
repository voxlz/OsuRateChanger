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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxAudio = new wmgCMS.WaterMarkTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbxAudio = new System.Windows.Forms.CheckBox();
            this.tbxRate = new wmgCMS.WaterMarkTextBox();
            this.cbxPitch = new System.Windows.Forms.CheckBox();
            this.cbxOffset = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(12, 11);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.ReadOnly = true;
            this.tbxFile.Size = new System.Drawing.Size(423, 20);
            this.tbxFile.TabIndex = 0;
            this.tbxFile.TextChanged += new System.EventHandler(this.tbxFile_TextChanged);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(441, 9);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(129, 23);
            this.btnFile.TabIndex = 1;
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
            this.btnStart.TabIndex = 11;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Audio File Prefix";
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
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "If you make an 0.9x rate of the beatmap it will look for an audio file called \"yo" +
    "ur_prefix90.mp3\" in the same folder. ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(420, 195);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(150, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.Text = "Manually create audio files";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxAudio);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 57);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audio";
            // 
            // tbxAudio
            // 
            this.tbxAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxAudio.Location = new System.Drawing.Point(332, 13);
            this.tbxAudio.Name = "tbxAudio";
            this.tbxAudio.Size = new System.Drawing.Size(100, 20);
            this.tbxAudio.TabIndex = 10;
            this.tbxAudio.WaterMarkColor = System.Drawing.Color.Gray;
            this.tbxAudio.WaterMarkText = "e.g. \"audio\"";
            // 
            // cbxAudio
            // 
            this.cbxAudio.AutoSize = true;
            this.cbxAudio.Checked = true;
            this.cbxAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAudio.Location = new System.Drawing.Point(12, 124);
            this.cbxAudio.Name = "cbxAudio";
            this.cbxAudio.Size = new System.Drawing.Size(423, 17);
            this.cbxAudio.TabIndex = 14;
            this.cbxAudio.Text = "Automatically convert audio files (note: this will take some time. About 1 min pe" +
    "r map)";
            this.cbxAudio.UseVisualStyleBackColor = true;
            this.cbxAudio.CheckedChanged += new System.EventHandler(this.cbxAudio_CheckedChanged);
            // 
            // tbxRate
            // 
            this.tbxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxRate.Location = new System.Drawing.Point(335, 46);
            this.tbxRate.Name = "tbxRate";
            this.tbxRate.Size = new System.Drawing.Size(100, 20);
            this.tbxRate.TabIndex = 9;
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
            this.cbxPitch.Size = new System.Drawing.Size(311, 17);
            this.cbxPitch.TabIndex = 15;
            this.cbxPitch.Text = "Use pitch correction (night-/daycore fans should turn this off)";
            this.cbxPitch.UseVisualStyleBackColor = true;
            // 
            // cbxOffset
            // 
            this.cbxOffset.AutoSize = true;
            this.cbxOffset.Checked = true;
            this.cbxOffset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxOffset.Enabled = false;
            this.cbxOffset.Location = new System.Drawing.Point(12, 78);
            this.cbxOffset.Name = "cbxOffset";
            this.cbxOffset.Size = new System.Drawing.Size(168, 17);
            this.cbxOffset.TabIndex = 16;
            this.cbxOffset.Text = "Use offset (not recommended)";
            this.cbxOffset.UseVisualStyleBackColor = true;
            this.cbxOffset.CheckedChanged += new System.EventHandler(this.cbxOffset_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 153);
            this.Controls.Add(this.cbxOffset);
            this.Controls.Add(this.cbxPitch);
            this.Controls.Add(this.cbxAudio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.tbxRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.tbxFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Trippins Rate Converter (v0.5.2)";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private wmgCMS.WaterMarkTextBox tbxRate;
        private wmgCMS.WaterMarkTextBox tbxAudio;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbxAudio;
        private System.Windows.Forms.CheckBox cbxPitch;
        private System.Windows.Forms.CheckBox cbxOffset;
    }
}

