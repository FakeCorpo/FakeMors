using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMors
{
    class Translator
    {
        public static string Translate(short[] arr)
        {
            char LastChar = ' ';
            string MorseMessage = "";
            int counter1 = 0;
            int counter2 = 0;
            int LastSample = 0;

            foreach (var item in arr)
            {
                if (item > 100 || item < -100)
                {
                    counter1++;
                    LastSample = item;

                    if (counter2 > 100)
                    {
                        if (LastChar == '-')
                        {
                            if (counter2 > 8000)
                            {
                                MorseMessage += "   ";
                            }
                            else if (counter2 > 5000)
                            {
                                MorseMessage += " ";
                            }
                        }
                        if (LastChar == '.')
                        {
                            if (counter2 > 3500)
                            {
                                MorseMessage += " ";
                            }
                        }

                        counter2 = 0;
                    }
                }
                else if (LastSample > 100 || LastSample < -100)
                {


                    counter1++;
                    LastSample = item;

                    if (counter2 > 100)
                    {
                        if (LastChar == '-')
                        {
                            if (counter2 > 8000)
                            {
                                MorseMessage += "   ";
                            }
                            else if (counter2 > 5000)
                            {
                                MorseMessage += " ";
                            }
                        }
                        if (LastChar == '.')
                        {
                            if (counter2 > 3500)
                            {
                                MorseMessage += " ";
                            }
                        }

                        counter2 = 0;
                    }



                }
                else
                {
                    counter2++;


                    if (counter1 > 100)
                    {
                        if (counter1 < 1000)
                        {
                            MorseMessage += ".";
                            LastChar = '.';
                        }
                        else if (counter1 > 1000)
                        {
                            MorseMessage += "-";
                            LastChar = '-';
                        }
                        counter1 = 0;
                    }

                }
            }
            return MorseMessage;
        }
    }
}
