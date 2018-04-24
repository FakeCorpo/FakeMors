using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMors
{
    public partial class SoundData
    {
        private int freq;
        private int dottime;

        /// <summary>
        /// Przypisuje domyślne wartości
        /// freq = 1000Hz
        /// dottime = 100ms
        /// </summary>
        public SoundData()
        {
            freq = 1000;
            dottime = 100;
        }

        /// <summary>
        /// Przypisuje wartości początkowe
        /// dottime = 100ms
        /// </summary>
        /// <param name="freq">Wartość częstotliwości w Hz</param>
        public SoundData(int freq)
        {
            this.freq = freq;
            dottime = 100;
        }

        /// <summary>
        /// Przypisuje wartości początkowe
        /// freq = 1000Hz
        /// </summary>
        /// <param name="dottime">czas trwania kropki w ms</param>
        /// <param name="freq">Częstotliwość dźwięku w Hz. Default 1000</param>
        public SoundData(int dottime, int freq = 1000)
        {
            this.freq = freq;
            this.dottime = dottime;
        }

        public int Freq
        {
            get { return freq; }
            set { freq = value; }
        }
        public int DotTime
        {
            get { return dottime; }
            set { dottime = value; }
        }
    }
}
