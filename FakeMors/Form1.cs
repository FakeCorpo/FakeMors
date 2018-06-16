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
using NAudio.Wave;


namespace FakeMors
{
    public partial class Form1 : Form
    {
        SoundData soundData;
        MorseDictionary MorseDictionary;

        // TODO zrobić osobną klasę na nagrywanie
        // ----------------------------------------------------------------------------------------------------------
        private string outputFolder;
        private string outputFilePath;
        private string outputFilteredFilePath;
        private WaveFileWriter writer;
        private WaveInEvent waveIn;
        private bool closing;
        private FolderBrowserDialog fdb = new FolderBrowserDialog();
        private bool path = false;
        // ----------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Main form
        /// </summary>
        public Form1()
        {


            InitializeComponent();
                        
            MorseDictionary = new MorseDictionary();
            soundData = new SoundData();


            outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio");
            Directory.CreateDirectory(outputFolder);
            outputFilePath = Path.Combine(outputFolder, "recorded.wav");
            outputFilteredFilePath = Path.Combine(outputFolder, "filtered.wav");
            writer = null;
            closing = false;
            waveIn = new WaveInEvent();

            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
                if (writer.Position > waveIn.WaveFormat.AverageBytesPerSecond * 30)
                {
                    waveIn.StopRecording();
                }
            };

            waveIn.RecordingStopped += (s, a) =>
            {
                writer?.Dispose();
                writer = null;
                buttonRecord.Enabled = true;
                buttonStop.Enabled = false;
                buttonRecord.Visible = true;
                buttonStop.Visible = false;
                if (closing)
                {
                    waveIn.Dispose();
                }
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = MorseDictionary.ToMorse(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = MorseDictionary.ToText(richTextBox2.Text).ToUpper();
        }

        private async void ButtonPlayBeep_Click(object sender, EventArgs e)
        {
            await Beeper.MorseConsoleBeepAsync(richTextBox2.Text, soundData.Freq, soundData.DotTime);

        }

        private void dźwiękToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundControl soundControl = new SoundControl(soundData);
            soundControl.ShowDialog(this);
        }

        private void ButtonPlayBeep_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPlayBeep.Image = Properties.Resources.maleplays4x;
        }

        private void ButtonPlayBeep_Mouseup(object sender, MouseEventArgs e)
        {
            ButtonPlayBeep.Image = Properties.Resources.maleplays3x;
        }

        private void buttonRecord_MouseDown(object sender, MouseEventArgs e)
        {
            buttonRecord.Image = Properties.Resources.recordclick;
        }

        private void buttonRecord_MouseUp(object sender, MouseEventArgs e)
        {
            if (path)
            {
                writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);
                waveIn.StartRecording();
                buttonRecord.Enabled = false;
                buttonStop.Enabled = true;
                buttonRecord.Visible = false;
                buttonStop.Visible = true;
                wykresikToolStripMenuItem.Enabled = true;
                tłumaczToolStripMenuItem.Enabled = true;
            }
            else
                MessageBox.Show("Wybierz ścieżkę zapisu!");
            buttonRecord.Image = Properties.Resources.recordb;
        }

        private void buttonStop_MouseDown(object sender, MouseEventArgs e)
        {
            buttonStop.Image = Properties.Resources.stopclick;
        }

        private void buttonStop_MouseUp(object sender, MouseEventArgs e)
        {
            waveIn.StopRecording();
            buttonStop.Image = Properties.Resources.stop;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.Image = Properties.Resources.rightclick;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.Image = Properties.Resources.right;

        }

        private void wybierzŚcieżkęZapisuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fdb.ShowDialog() == DialogResult.OK)
            {
                outputFolder = fdb.SelectedPath;
                outputFilePath = Path.Combine(outputFolder, "recorded.wav");
                outputFilteredFilePath = Path.Combine(outputFolder, "filtered.wav");
                path = true;
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Image = Properties.Resources.leftclick;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.Image = Properties.Resources.left;
        }

        private void wykresikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[] arrL;
            float[] arrR;

            
            WavWykres.readWav(outputFilePath, out arrL, out arrR);
            float[] farr = new float[arrL.Length];
            int[] w = new int[arrL.Length];
           


            farr = WavWykres.filter(arrL);

            WaveFormat waveFormat = new WaveFormat(8000, 1);

            using (WaveFileWriter writer = new WaveFileWriter(outputFilteredFilePath, waveFormat))
            {
                writer.WriteSamples(farr, 0, farr.Length);
            }


            short[] arr = WavWykres.SampleIt(outputFolder);
            short[] arr2 = WavWykres.SampleIt(outputFolder, true);

            for(int i = 0; i < arr2.Length; i++)
            {
                if (Math.Abs(arr2[i]) > 400)
                    arr2[i] *= 2;
            }

            Wykres wykres = new Wykres(arr);
            Wykres2 wykres2 = new Wykres2(arr2);
            wykres.Show();
            wykres2.Show();


        }

        private void tłumaczToolStripMenuItem_Click(object sender, EventArgs e)
        {
                float[] arrL;
                float[] arrR;


                WavWykres.readWav(outputFilePath, out arrL, out arrR);
                float[] farr = new float[arrL.Length];
                int[] w = new int[arrL.Length];



                farr = WavWykres.filter(arrL);

                WaveFormat waveFormat = new WaveFormat(8000, 1);

                using (WaveFileWriter writer = new WaveFileWriter(outputFilePath, waveFormat))
                {
                    writer.WriteSamples(farr, 0, farr.Length);
                }


                short[] arr = WavWykres.SampleIt(outputFolder);
                short[] arr2 = WavWykres.SampleIt(outputFolder, true);

                for (int i = 0; i < arr2.Length; i++)
                {
                    if (Math.Abs(arr2[i]) > 400)
                        arr2[i] *= 2;
                }

                richTextBox2.Text = Translator.Translate(arr2);

        }
    }
}
