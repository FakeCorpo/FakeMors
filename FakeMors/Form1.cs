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



        PictureBox Play = new PictureBox();
        PictureBox Playclick = new PictureBox();
        PictureBox Record = new PictureBox();
        PictureBox Recordclick = new PictureBox();
        PictureBox Stop = new PictureBox();
        PictureBox Stopclick = new PictureBox();
        PictureBox Right = new PictureBox();
        PictureBox Rightclick = new PictureBox();
        PictureBox Left = new PictureBox();
        PictureBox Leftclick = new PictureBox();

        public Form1()
        {

            Play.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\maleplays3x.png");
            Playclick.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\maleplays4x.png");
            Record.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\recordb.png");
            Recordclick.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\recordclick.png");
            Stop.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\stop.png");
            Stopclick.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\stopclick.png");
            Right.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\right.png");
            Rightclick.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\rightclick.png");
            Left.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\left.png");
            Leftclick.Image = Image.FromFile(@"D:\Studia\Semestr 6\Sm\leftclick.png");

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


        public void ButtonRecordClick()
        {
            writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);
            waveIn.StartRecording();
            buttonRecord.Enabled = false;
            buttonStop.Enabled = true;

        }
        public void ButtonStopClick()
        {
            waveIn.StopRecording();
        }

        private void ButtonPlayBeep_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPlayBeep.Image = Playclick.Image;
        }

        private void ButtonPlayBeep_Mouseup(object sender, MouseEventArgs e)
        {
            ButtonPlayBeep.Image = Play.Image;
        }

        private void buttonRecord_MouseDown(object sender, MouseEventArgs e)
        {          
            buttonRecord.Image = Recordclick.Image;
        }

        private void buttonRecord_MouseUp(object sender, MouseEventArgs e)
        {
            buttonRecord.Image = Record.Image;
        }

        private void buttonStop_MouseDown(object sender, MouseEventArgs e)
        {
            buttonStop.Image = Stopclick.Image;
        }

        private void buttonStop_MouseUp(object sender, MouseEventArgs e)
        {
            buttonStop.Image = Stop.Image;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.Image = Rightclick.Image;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.Image = Right.Image;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Image = Leftclick.Image;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.Image = Left.Image;
        }
    }
}
