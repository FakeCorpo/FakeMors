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
        private static float sampleRate = 8000;
        /// <summary>
        /// Wav Sampler
        /// </summary>
        /// <param name="path">Folder path</param>
        /// <param name="filtered"></param>
        /// <returns>Sample array</returns>
        public static short[] SampleIt(string path, bool filtered = false)
        {
            float kupa = 8000;
            if(filtered)
                using (WaveFileReader reader = new WaveFileReader(path + "\\filtered.wav"))
                {
                    Assert.AreEqual(16, reader.WaveFormat.BitsPerSample, "Only works with 16 bit audio");
                    byte[] buffer = new byte[reader.Length];
                    int read = reader.Read(buffer, 0, buffer.Length);
                    short[] sampleBuffer = new short[read / 2];
                    Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);
                    sampleRate = kupa;

                    return sampleBuffer;
                }
            else
                using (WaveFileReader reader = new WaveFileReader(path + "\\recorded.wav"))
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
        /// <summary>
        /// Wav sampler
        /// </summary>
        /// <param name="filename">File path</param>
        /// <param name="L">Left channel samples</param>
        /// <param name="R">Right channel samples</param>
        /// <returns></returns>
        public static bool readWav(string filename, out float[] L, out float[] R)
        {
            L = R = null;
            //float [] left = new float[1];

            //float [] right;
            try
            {
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    BinaryReader reader = new BinaryReader(fs);

                    // chunk 0
                    int chunkID = reader.ReadInt32();
                    int fileSize = reader.ReadInt32();
                    int riffType = reader.ReadInt32();


                    // chunk 1
                    int fmtID = reader.ReadInt32();
                    int fmtSize = reader.ReadInt32(); // bytes for this chunk
                    int fmtCode = reader.ReadInt16();
                    int channels = reader.ReadInt16();
                    int sampleRate = reader.ReadInt32();
                    int byteRate = reader.ReadInt32();
                    int fmtBlockAlign = reader.ReadInt16();
                    int bitDepth = reader.ReadInt16();

                    if (fmtSize == 18)
                    {
                        // Read any extra values
                        int fmtExtraSize = reader.ReadInt16();
                        reader.ReadBytes(fmtExtraSize);
                    }

                    // chunk 2
                    int dataID = reader.ReadInt32();
                    int bytes = reader.ReadInt32();

                    // DATA!
                    byte[] byteArray = reader.ReadBytes(bytes);

                    int bytesForSamp = bitDepth / 8;
                    int samps = bytes / bytesForSamp;


                    float[] asFloat = null;
                    switch (bitDepth)
                    {
                        case 64:
                            double[]
                            asDouble = new double[samps];
                            Buffer.BlockCopy(byteArray, 0, asDouble, 0, bytes);
                            asFloat = Array.ConvertAll(asDouble, e => (float)e);
                            break;
                        case 32:
                            asFloat = new float[samps];
                            Buffer.BlockCopy(byteArray, 0, asFloat, 0, bytes);
                            break;
                        case 16:
                            Int16[]
                            asInt16 = new Int16[samps];
                            Buffer.BlockCopy(byteArray, 0, asInt16, 0, bytes);
                            asFloat = Array.ConvertAll(asInt16, e => e / (float)Int16.MaxValue);
                            break;
                        default:
                            return false;
                    }

                    switch (channels)
                    {
                        case 1:
                            L = asFloat;
                            R = null;
                            return true;
                        case 2:
                            L = new float[samps];
                            R = new float[samps];
                            for (int i = 0, s = 0; i < samps; i++)
                            {
                                L[i] = asFloat[s++];
                                R[i] = asFloat[s++];
                            }
                            return true;
                        default:
                            return false;
                    }
                }
            }
            catch
            {                
                return false;
                //left = new float[ 1 ]{ 0f };
            }

            return false;
        }
        /// <summary>
        /// Sample filter
        /// </summary>
        /// <param name="data">samples</param>
        /// <returns></returns>
        public static float[] filter(float[] data)
        {
            var filter = new BiQuadFilter[3];
            filter[2] = BiQuadFilter.BandPassFilterConstantPeakGain(sampleRate, 2000, 1);
            filter[0] = BiQuadFilter.HighPassFilter(sampleRate, 1800, 1);
            filter[1] = BiQuadFilter.LowPassFilter(sampleRate, 2200, 1);

            float[] fdata = new float[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                 fdata[i] = filter[0].Transform(data[i]);
                 fdata[i] = filter[1].Transform(fdata[i]);
            }

            return fdata;
        }

    }
}
