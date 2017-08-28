using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Lame;
using NAudio.Wave;
using RateChanger.AudioConvert;
using System.Globalization;

namespace RateChanger
{
    public partial class FrmMain : Form
    {
        static double[] rates;
        string[] osuFilePaths;
        string[] osuFileNames;

        public FrmMain()
        {
            InitializeComponent();
        }

        // Opens a window so that the user can select an .osu file
        private void FindFile(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFile = new OpenFileDialog();

            string[] stringPath = { Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "osu!", "Songs" };
            string path = Path.Combine(stringPath);

            openFile.Title = "Select diffs you want to convert";
            openFile.Multiselect = true;
            openFile.InitialDirectory = path;
            openFile.Filter = "Osu files (*.osu)|*.osu";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myStream = openFile.OpenFile();
                    osuFilePaths = openFile.FileNames;
                    osuFileNames = openFile.SafeFileNames;
                    if (osuFileNames.Length == 1)
                    {
                        tbxFile.Text = osuFilePaths[0];
                    }
                    else
                    {
                        tbxFile.Text = osuFilePaths.Length + " different files selected";
                    }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not find file on disk. Original error: " + ex.Message);
                    return;
                }
            }
        }

        private bool ValidateInputs()
        {
            string[] rs = tbxRate.Text.Split(';');
            rates = new double[rs.Length];
            CultureInfo usCulture = CultureInfo.CreateSpecificCulture("en-US");

            for (int i = 0; i < rs.Length; i++)
            {
                if (!double.TryParse(rs[i], NumberStyles.Float, usCulture, out rates[i]))
                {
                    MessageBox.Show("You have not inputted the rate field correctly, you should use '.'", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private void btnStartConversion(object sender, EventArgs e)
        {
            OsuFileConverter converter = new OsuFileConverter();
            btnStart.Text = "Loading...";
            btnStart.Enabled = false;

            if (ValidateInputs())
            {
                // For every file
                for (int i = 0; i < osuFilePaths.Length; i++)
                {
                    // For every convert
                    foreach (var rate in rates)
                    {
                        string audioFilePath;

                        // Convert the .osu file
                        string audioFileName = converter.Start(osuFilePaths[i], osuFileNames[i], tbxAudio.Text, rate, cbxOffset.Checked);

                        // Reset start button
                        btnStart.Text = "Start Conversion";
                        btnStart.Enabled = true;

                        if (audioFileName == "error")
                        {
                            MessageBox.Show("Could not read the .osu file correctly.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (audioFileName == "fileError")
                        {
                            return;
                        }
                        else
                        {
                            DirectoryInfo songDir = Directory.GetParent(osuFilePaths[i]);
                            audioFilePath = Path.Combine(songDir.FullName, audioFileName);
                            audioFilePath = audioFilePath.Substring(0, audioFilePath.Length - 4);
                        }

                        if (cbxAudio.Checked == true)
                        {
                            if (!File.Exists(audioFilePath + ".mp3"))
                            {
                                MessageBox.Show("Could not find the audio file.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Convert .mp3 file to .wav
                            Codec.MP3ToWave(audioFilePath + ".mp3", audioFilePath + ".wav");

                            // Change the tempo of the .wav
                            string[] args = new string[] { audioFilePath + ".wav", audioFilePath + rate * 100 + ".wav" };
                            float rateDeltaInProcent = ((float)rate * 100) - 100;
                            bool keepPitch = cbxPitch.Checked;
                            AudioStrech.Start(args, rateDeltaInProcent, keepPitch);

                            // Convert .wav file to .mp3
                            Codec.WaveToMP3(audioFilePath + rate * 100 + ".wav", audioFilePath + rate * 100 + ".mp3");

                            // Remove the .wav files
                            File.Delete(audioFilePath + ".wav");
                            File.Delete(audioFilePath + rate * 100 + ".wav");
                        }
                    }
                }
                
                DialogResult exit = MessageBox.Show("Convertions successful! Do you want to exit the application?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (exit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }

            // Reset start button
            btnStart.Text = "Start Conversion";
            btnStart.Enabled = true;
        }

        private void tbxFile_TextChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void cbxAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAudio.Checked)
            {
                cbxOffset.Checked = true;
            }
            else
            {
                cbxOffset.Checked = false;
            }
            if (cbxPitch.Enabled == true)
            {
                cbxPitch.Enabled = false;
                cbxOffset.Enabled = true;
            }
            else
            {
                cbxPitch.Enabled = true;
                cbxOffset.Enabled = false;

            }
        }

        private void cbxOffset_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
