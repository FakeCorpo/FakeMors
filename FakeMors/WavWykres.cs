using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMors
{
    class WavWykres
    {
        public static short[] SampleIt()
        {
            using (WaveFileReader reader = new WaveFileReader(@"C:\Users\Prezes\Desktop\NAudio\recorded.wav"))
            {
                Assert.AreEqual(16, reader.WaveFormat.BitsPerSample, "Only works with 16 bit audio");
                byte[] buffer = new byte[reader.Length];
                int read = reader.Read(buffer, 0, buffer.Length);
                short[] sampleBuffer = new short[read / 2];
                Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);
                return sampleBuffer;
            }
            return null;
        }

    }
}
