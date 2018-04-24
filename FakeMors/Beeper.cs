using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FakeMors
{
    static class Beeper
    {
        /// <summary>
        /// Asynchroniczne odtwarzanie kodu Morse'a
        /// </summary>
        /// <param name="inputMorseCode">Kod Morse'a</param>
        /// <param name="freq">Częstotliwość dźwięku w Hz</param>
        /// <param name="dottime">Czas trwania kropki w ms</param>
        /// <returns></returns>
        public static async Task MorseConsoleBeepAsync(string inputMorseCode, int freq, int dottime)
        {
            await Task.Run(() => SystemBeeper(inputMorseCode, freq, dottime));            
        }
        

        /// <summary>
        /// Generuje beepy przez Console.Beep()
        /// </summary>
        /// <param name="inputMorseCode">Kod Morse'a</param>
        /// <param name="freq">Częstotliwość dźwięku w Hz</param>
        /// <param name="dottime">Czas trwania kropki w ms</param>
        private static void SystemBeeper(string inputMorseCode,int freq, int dottime)
        {
            foreach (char c in inputMorseCode)
            {
                switch (c)
                {
                    case '.':
                        Console.Beep(freq, dottime);
                        Thread.Sleep(dottime);
                        break;
                    case '-':
                        Console.Beep(freq, 3*dottime);
                        Thread.Sleep(dottime);
                        break;
                    default:
                        Thread.Sleep(dottime);
                        break;
                }
            }
        }
    }
}
