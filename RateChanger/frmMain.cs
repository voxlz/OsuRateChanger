using System;
using System.IO;
using System.Windows.Forms;
using RateChanger.AudioConvert;
using System.Globalization;
using System.Drawing;
using System.Linq;
using Microsoft.Win32;
using System.Collections.Generic;

namespace RateChanger
{
    public partial class FrmMain : Form
    {
        CultureInfo usCulture = CultureInfo.CreateSpecificCulture("en-US");
        ImageList imageListLarge;

        List<double> fileRates;
        List<string> filePaths;
        List<string> fileNames;

        string osupath;
        string songspath;

        public FrmMain()
        {
            InitializeComponent();

            // Save the osu path directory
            using (RegistryKey osureg = Registry.ClassesRoot.OpenSubKey("osu\\DefaultIcon"))
            {
                if (osureg != null)
                {
                    string osukey = osureg.GetValue(null).ToString();
                    osupath = osukey.Remove(0, 1);
                    osupath = osupath.Remove(osupath.Length - 11);
                }
            }

            // Create song path
            songspath = Path.Combine(osupath, "songs");

            // Create ImageList object.
            imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(64, 34);
            imageListLarge.ColorDepth = ColorDepth.Depth32Bit;

            fileRates = new List<double>();
            fileNames = new List<string>();
            filePaths = new List<string>();
        }

        // Opens a window so that the user can select an .osu file
        private void AddFileToQueue(object sender, EventArgs e)
        {
            OpenFileDialog filesDialog = new OpenFileDialog();

            filesDialog.Title = "Select diffs you want to convert";
            filesDialog.Multiselect = true;
            filesDialog.InitialDirectory = songspath;
            filesDialog.Filter = "Osu files (*.osu)|*.osu";
            filesDialog.FilterIndex = 2;
            filesDialog.RestoreDirectory = true;

            if (filesDialog.ShowDialog() == DialogResult.OK)
            {
                if (ValidateInputs())
                {
                    try
                    {
                        AddToList(filesDialog);

                        filePaths.AddRange(filesDialog.FileNames);
                        fileNames.AddRange(filesDialog.SafeFileNames);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not find file on disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void AddToList(OpenFileDialog files)
        {
            string[] rates = tbxRate.Text.Split(';');

            for (int i = 0; i < files.FileNames.Length; i++)
            {
                for (int I = 0; I < rates.Length; I++)
                {
                    // Add to the list
                    ListViewItem item = new ListViewItem(files.SafeFileNames[i], imageListLarge.Images.Count);
                    item.SubItems.Add(rates[I] + "x");
                    listView1.Items.Add(item);

                    // Initialize the ImageList objects with bitmaps.
                    string mapPath = Directory.GetParent(files.FileNames[i]).FullName;
                    string[] backgroundImages = Directory.EnumerateFiles(mapPath, "*.*").Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToArray();
                    imageListLarge.Images.Add(Bitmap.FromFile(backgroundImages[0]));
                }
            }

            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListLarge;
        }

        private bool ValidateInputs()
        {
            string[] rs = tbxRate.Text.Split(';');
            double[] rates = new double[rs.Length];

            for (int i = 0; i < rs.Length; i++)
            {
                if (!double.TryParse(rs[i], NumberStyles.Float, usCulture, out rates[i]))
                {
                    MessageBox.Show("You have not inputted the rate field correctly, you should use '.' and ';' when writing the rates. Letters are not allowed.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (rates[i] == 0)
                {
                    MessageBox.Show("Zero is obviously not allowed as a rate. Please do not try to break this program.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            fileRates.AddRange(rates.ToList());
            return true;
        }

        private void ConvertAudio(string audioFilePath, double rate)
        {
            // Convert .mp3 file to .wav
            Codec.MP3ToWave(audioFilePath + ".mp3", audioFilePath + ".wav");

            // Change either the tempo or the rate of the .wav
            string[] args = new string[] { audioFilePath + ".wav", audioFilePath + rate * 100 + ".wav" };
            float rateDeltaInProcent = ((float)rate * 100) - 100;
            bool keepPitch = cbxPitch.Checked;
            AudioStrech.Start(args, rateDeltaInProcent, keepPitch);

            // Convert .wav file to .mp3
            try
            {
                Codec.WaveToMP3(audioFilePath + rate * 100 + ".wav", audioFilePath + rate * 100 + ".mp3");
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not convert the modified .wav file to the .mp3 file.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Remove the .wav files
            File.Delete(audioFilePath + ".wav");
            File.Delete(audioFilePath + rate * 100 + ".wav");
        }

        private void btnStartConversion(object sender, EventArgs e)
        {
            OsuFileConverter converter = new OsuFileConverter();
            bool success = false;

            // Visual
            btnStart.Text = "Loading...";
            btnStart.Enabled = false;

            // For every file
            for (int i = 0; i < filePaths.Count; i++)
            {
                // For every convert
                foreach (var rate in fileRates)
                {
                    string audioFilePath;
                    string audioFileName = converter.getAudioName(filePaths[i], rate);

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
                        DirectoryInfo songDir = Directory.GetParent(filePaths[i]);
                        audioFilePath = Path.Combine(songDir.FullName, audioFileName);
                        audioFilePath = audioFilePath.Substring(0, audioFilePath.Length - 4);
                    }

                    // Convert the .mp3 file
                    if (cbxAudio.Checked == true)
                    {
                        if (!File.Exists(audioFilePath + ".mp3"))
                        {
                            MessageBox.Show("Could not find the .mp3 file for the .osu file you selected. Make sure they are in the same folder!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Reset start button
                            btnStart.Text = "Start Conversion";
                            btnStart.Enabled = true;

                            return;
                        }
                        else if (File.Exists(audioFilePath + rate * 100 + ".mp3"))
                        {
                            DialogResult answer = MessageBox.Show("There already excists an audio file called " + (audioFileName.Remove(audioFileName.Length - 4) + rate * 100 + ".mp3") + " here. Do you want to OVERWRITE the file?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                            if (answer == DialogResult.Yes)
                            {
                                ConvertAudio(audioFilePath, rate);
                            }
                            else if (answer == DialogResult.No)
                            {
                                // No nothing
                            }
                            else if (answer == DialogResult.Cancel)
                            {
                                // Stop converting

                                // Reset start button
                                btnStart.Text = "Start Conversion";
                                btnStart.Enabled = true;

                                return;
                            }
                        }
                        else
                        {
                            ConvertAudio(audioFilePath, rate);
                        }
                    }

                    // Convert the .osu file
                    success = converter.Start(filePaths[i], fileNames[i], rate, cbxAudio.Checked);
                }
            }

            if (success)
            {
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

        // FORMS STUFF
        private void tbxFile_TextChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
        }
        private void cbxAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPitch.Enabled == true)
            {
                cbxPitch.Enabled = false;
            }
            else
            {
                cbxPitch.Enabled = true;

            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
