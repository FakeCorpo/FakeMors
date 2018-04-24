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
    public partial class SoundControl : Form
    {
        SoundData SoundData;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public SoundControl(SoundData soundData)
        {
            InitializeComponent();
            this.SoundData = soundData;
            trackBar1.Value = SoundData.Freq;
            label1.Text = string.Format("Częstotliwość {0} Hz", trackBar1.Value);

            trackBar2.Value = SoundData.DotTime;
            label2.Text = string.Format("Czas kropki {0} ms", trackBar2.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = string.Format("Częstotliwość {0} Hz", trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = string.Format("Czas kropki {0} ms", trackBar2.Value);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SoundData.Freq = trackBar1.Value;
            SoundData.DotTime = trackBar2.Value;
            this.Close();
        }
    }
}
