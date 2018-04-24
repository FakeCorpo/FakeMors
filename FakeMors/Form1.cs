using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeMors
{
    public partial class Form1 : Form
    {
        SoundData soundData;
        MorseDictionary MorseDictionary;

        public Form1()
        {
            InitializeComponent();
            MorseDictionary = new MorseDictionary();
            soundData = new SoundData();
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
    }
}
