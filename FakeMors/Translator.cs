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
            int index = 0;
            char LastChar = ' ';
            string MorseMessage = "";
            int counter1 = 0;
            int counter2 = 0;
            int LastSample = 0;

            foreach (var item in arr)
            {
                if (index > 80)
                {
                    if (item > 500 || item < -500)
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
                    else if (arr[index - 1] > 500 || arr[index - 2] > 500 || arr[index - 3] > 500 ||
                             arr[index - 4] > 500 || arr[index - 5] > 500
                             || arr[index - 6] > 500 || arr[index - 7] > 500 || arr[index - 8] > 500 ||
                             arr[index - 9] > 500 || arr[index - 10] > 500
                             || arr[index - 1] < -500 || arr[index - 2] < -500 || arr[index - 3] < -500 ||
                             arr[index - 4] < -500 || arr[index - 5] < -500 ||
                             arr[index - 6] < -500 || arr[index - 7] < -500 || arr[index - 8] < -500 ||
                             arr[index - 9] < -500 || arr[index - 10] < -500)
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

                index++;
            }
            return MorseMessage;
        }
    }
}
