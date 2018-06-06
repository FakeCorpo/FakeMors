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

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);
            waveIn.StartRecording();
            buttonRecord.Enabled = false;
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            waveIn.StopRecording();
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
            buttonRecord.Image = Properties.Resources.recordb;
        }

        private void buttonStop_MouseDown(object sender, MouseEventArgs e)
        {
            buttonStop.Image = Properties.Resources.stopclick;
        }

        private void buttonStop_MouseUp(object sender, MouseEventArgs e)
        {
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
            short[] arr = WavWykres.SampleIt();
            //arr = WavWykres.Butterworth(arr, 5000);
            Wykres wykres = new Wykres(arr);
            wykres.Show();
        }
    }
}
