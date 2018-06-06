using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAudio.Wave;
using NAudio.Dsp;
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
        private static float sampleRate;
        public static short[] SampleIt()
        {
            float kupa = 16415;
            using (WaveFileReader reader = new WaveFileReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio\\recorded.wav")))
            {
                Assert.AreEqual(16, reader.WaveFormat.BitsPerSample, "Only works with 16 bit audio");
                byte[] buffer = new byte[reader.Length];
                int read = reader.Read(buffer, 0, buffer.Length);
                short[] sampleBuffer = new short[read / 2];
                Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);
                sampleRate = kupa;
 
                return sampleBuffer;
            }
            return null;
        }

        //--------------------------------------------------------------------------
        // This function returns the data filtered. Converted to C# 2 July 2014.
        // Original source written in VBA for Microsoft Excel, 2000 by Sam Van
        // Wassenbergh (University of Antwerp), 6 june 2007.
        //--------------------------------------------------------------------------
        public static double[] Butterworth(double[] indata, double CutOff)
        {
            if (indata == null) return null;
            if (CutOff == 0) return indata;

            double deltaTimeinsec = 1 / sampleRate;

            double Samplingrate = 1 / deltaTimeinsec;
            long dF2 = indata.Length - 1;        // The data range is set with dF2
            double[] Dat2 = new double[dF2 + 4]; // Array with 4 extra points front and back
            double[] data = indata; // Ptr., changes passed data

            // Copy indata to Dat2
            for (long r = 0; r < dF2; r++)
            {
                Dat2[2 + r] = indata[r];
            }
            Dat2[1] = Dat2[0] = indata[0];
            Dat2[dF2 + 3] = Dat2[dF2 + 2] = indata[dF2];

            const double pi = 3.14159265358979;
            double wc = Math.Tan(CutOff * pi / Samplingrate);
            double k1 = 1.414213562 * wc; // Sqrt(2) * wc
            double k2 = wc * wc;
            double a = k2 / (1 + k1 + k2);
            double b = 2 * a;
            double c = a;
            double k3 = b / k2;
            double d = -2 * a + k3;
            double e = 1 - (2 * a) - k3;

            // RECURSIVE TRIGGERS - ENABLE filter is performed (first, last points constant)
            double[] DatYt = new double[dF2 + 4];
            DatYt[1] = DatYt[0] = indata[0];
            for (long s = 2; s < dF2 + 2; s++)
            {
                DatYt[s] = a * Dat2[s] + b * Dat2[s - 1] + c * Dat2[s - 2]
                           + d * DatYt[s - 1] + e * DatYt[s - 2];
            }
            DatYt[dF2 + 3] = DatYt[dF2 + 2] = DatYt[dF2 + 1];

            // FORWARD filter
            double[] DatZt = new double[dF2 + 2];
            DatZt[dF2] = DatYt[dF2 + 2];
            DatZt[dF2 + 1] = DatYt[dF2 + 3];
            for (long t = -dF2 + 1; t <= 0; t++)
            {
                DatZt[-t] = a * DatYt[-t + 2] + b * DatYt[-t + 3] + c * DatYt[-t + 4]
                            + d * DatZt[-t + 1] + e * DatZt[-t + 2];
            }

            // Calculated points copied for return
            for (long p = 0; p < dF2; p++)
            {
                data[p] = DatZt[p];
            }

            return data;
        }

        public static float[] filter(short[] data)
        {
            var filter = new BiQuadFilter[1];

            filter[0] = BiQuadFilter.HighPassFilter(sampleRate, 50, 1);

            float[] fdata = new float[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                fdata[i] = filter[0].Transform(data[i]);
            }

            return fdata;
        }

    }
}
