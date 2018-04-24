using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeMors
{
    public class MorseDictionary
    {
        private Dictionary<string, string> dictionary;
        /// <summary>
        /// Inicjacja słownika
        /// </summary>
        public MorseDictionary()
        {
            dictionary = new Dictionary<string, string>();
            //
            // litery
            //
            dictionary.Add("a", ".-");
            dictionary.Add("b", "-...");
            dictionary.Add("c", "-.-.");
            dictionary.Add("d", "-..");
            dictionary.Add("e", ".");
            dictionary.Add("f", "..-.");
            dictionary.Add("g", "--.");
            dictionary.Add("h", "....");
            dictionary.Add("i", "..");
            dictionary.Add("j", ".---");
            dictionary.Add("k", "-.-");
            dictionary.Add("l", ".-..");
            dictionary.Add("m", "--");
            dictionary.Add("n", "-.");
            dictionary.Add("o", "---");
            dictionary.Add("p", ".--.");
            dictionary.Add("q", "--.-");
            dictionary.Add("r", ".-.");
            dictionary.Add("s", "...");
            dictionary.Add("t", "-");
            dictionary.Add("u", "..-");
            dictionary.Add("v", "...-");
            dictionary.Add("w", ".--");
            dictionary.Add("x", "-..-");
            dictionary.Add("y", "-.--");
            dictionary.Add("z", "--..");
            dictionary.Add("ą", ".-.-");
            dictionary.Add("ć", "-.-..");
            dictionary.Add("ę", "..-..");
            dictionary.Add("ł", ".-..-");
            dictionary.Add("ń", "--.--");
            dictionary.Add("ó", "---.");
            dictionary.Add("ś", "...-...");
            dictionary.Add("ż", "--..-.");
            dictionary.Add("ź", "--..-");

            //
            // cyfry
            //
            dictionary.Add("1", ".----");
            dictionary.Add("2", "..---");
            dictionary.Add("3", "...--");
            dictionary.Add("4", "....-");
            dictionary.Add("5", ".....");
            dictionary.Add("6", "-....");
            dictionary.Add("7", "--...");
            dictionary.Add("8", "---..");
            dictionary.Add("9", "----.");
            dictionary.Add("0", "-----");

            //
            // znaki interpunkcyjne i symbole
            //
            dictionary.Add(".", ".-.-.-");
            dictionary.Add(",", "--..--");
            dictionary.Add("'", ".----.");
            dictionary.Add('"'.ToString(), ".-..-.");
            dictionary.Add("_", "..--.-");
            dictionary.Add(":", "---...");
            dictionary.Add(";", "-.-.-.");
            dictionary.Add("?", "..--..");
            dictionary.Add("!", "-.-.--");
            dictionary.Add("-", "-....-");
            dictionary.Add("+", ".-.-.");
            dictionary.Add("/", "-..-.");
            dictionary.Add("(", "-.--.");
            dictionary.Add(")", "-.--.-");
            dictionary.Add("=", "-...-");
            dictionary.Add("@", ".--.-.");
        }// end Constructor

        /// <summary>
        /// Zamienia ciąg znaków na alfabet Morse'a
        /// </summary>
        /// <param name="inputText">Text wejściowy</param>
        /// <returns>Zwraca ciąg znaków ' -.- ' </returns>
        public string ToMorse(string inputText)
        {
            string outputText = "";
            int i = 0;
            inputText = inputText.ToLower();

            while(i<inputText.Length)
            {

                switch (inputText[i])
                {
                    case ' ':
                        outputText += "  ";
                        break;
                    case '\n':
                        outputText += "      ";
                        break;
                    default:
                        try
                        {
                            outputText += dictionary[inputText[i].ToString()] + " ";
                        }
                        catch
                        {
                            MessageBox.Show(string.Format("| Translate error at char {0} | ", i));
                        }
                        break;
                }
                i++;
            }// end while

            return outputText;
        }//end ToMorse()

        /// <summary>
        /// Znajduje początek kodu Morse'a
        /// </summary>
        /// <param name="startIndex">Index od którego szuka</param>
        /// <param name="inputText">Tekst wejściowy</param>
        /// <returns>Index pierwszego znaku ciągu Morse'a</returns>
        private int StartMorseIndex(int startIndex, string inputText)
        {
            int index = -1;
            
            while(true)
            {
                if (startIndex >= inputText.Length)
                    break;
                if (inputText[startIndex] == '-' || inputText[startIndex] == '.')
                {
                    index = startIndex;
                    break;
                }
                startIndex++;
                
            }

            return index;
        } // end startMorseIndex

        /// <summary>
        /// Znajduje długość sumbolu kodu Morse'a
        /// </summary>
        /// <param name="startIndex">Index pierwszego znaku kodu Morse'a</param>
        /// <param name="inputText">Tekst wejścowy</param>
        /// <returns>Długość symbolu kodu Morse'a</returns>
        private int LenghtMorseSymbol(int startIndex, string inputText)
        {
            int lenght = 0;

            while(true)
            {
                if (startIndex >= inputText.Length)
                    return lenght;
                if (inputText[startIndex] != '-' && inputText[startIndex] != '.')
                        break;
                startIndex++;
                lenght++;
            }

            return lenght;
        }


        /// <summary>
        /// Zmienia Morse'a w ASCI na tekst
        /// </summary>
        /// <param name="inputText">Tekst wejściowy</param>
        /// <returns>Przetłumaczony tekst</returns>
        public string ToText(string inputText)
        {
           
            string outputText = "";
            string substring = "";
            int start = 0;
            int lenght = 0;
            int currentIndex = 0;

            while (true)
            {
                start = this.StartMorseIndex(currentIndex, inputText);
                if (start != -1)
                {
                    lenght = this.LenghtMorseSymbol(start, inputText);
                    if (lenght != 0)
                    {
                        currentIndex = start + lenght;
                        substring = inputText.Substring(start, lenght);
                        try
                        {
                            outputText += dictionary.FirstOrDefault(x => x.Value == substring).Key;                            
                        }
                        catch
                        {
                            MessageBox.Show(string.Format("| Translate error at {0} | ", currentIndex));                            
                        }

                        if (currentIndex + 7 < inputText.Length)
                        {

                            if (inputText.Substring(currentIndex, 7) == "       ")
                                outputText += "\n";
                            else if (inputText.Substring(currentIndex, 3) == "   ")
                                outputText += " ";
                           
                        }
                        else if (currentIndex + 3 < inputText.Length)
                        {
                            if (inputText.Substring(currentIndex, 3) == "   ")
                                outputText += " ";
                        }




                    }
                    else
                        break;
                }
                else                
                    break;
            }
            
            return outputText;
        }


    }
}
