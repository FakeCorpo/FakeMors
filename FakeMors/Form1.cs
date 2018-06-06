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
        private WaveFileWriter writer;
        private WaveInEvent waveIn;
        private bool closing;

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
            writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);
            waveIn.StartRecording();
            buttonRecord.Enabled = false;
            buttonStop.Enabled = true;
            buttonRecord.Visible = false;
            buttonStop.Visible = true;
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
            
            outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio");
            outputFilePath = Path.Combine(outputFolder, "recorded.wav");

            float[] arrL;
            float[] arrR;

            
            WavWykres.readWav(outputFilePath, out arrL, out arrR);
            float[] farr = new float[arrL.Length];
            int[] w = new int[arrL.Length];
           


            farr = WavWykres.filter(arrL);

            WaveFormat waveFormat = new WaveFormat(8000, 1);

            outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio");
            outputFilePath = Path.Combine(outputFolder, "filtered.wav");

            using (WaveFileWriter writer = new WaveFileWriter(outputFilePath, waveFormat))
            {
                writer.WriteSamples(farr, 0, farr.Length);
            }


            short[] arr = WavWykres.SampleIt(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio\\recorded.wav"));

<<<<<<< HEAD
            Wykres wykres = new Wykres(farr);
            Wykres2 wykres2 = new Wykres2(arr);

            using (StreamWriter writetext = new StreamWriter(@"C:\Users\Juan\Desktop\NAudio\write.txt"))
            {

                foreach (var item in arr)
                {
                    writetext.Write(item + " ");
                }
                writetext.Close();
            }

            wykres.Show();
            wykres2.Show();
            richTextBox2.Text = Translator.Translate(arr);
            
=======
            short[] arr2 = WavWykres.SampleIt(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio\\filtered.wav"));

            for(int i = 0; i < arr2.Length; i++)
            {
                if (Math.Abs(arr2[i]) > 400)
                    arr2[i] *= 2;
            }

            Wykres wykres = new Wykres(arr);
            Wykres2 wykres2 = new Wykres2(arr2);
            wykres.Show();
            wykres2.Show();


>>>>>>> b544de1e993310efd0a133dd532d2636d0254e0b
        }


    }
}
