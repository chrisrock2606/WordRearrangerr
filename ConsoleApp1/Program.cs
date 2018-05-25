using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        string firstLetter, lastLetter, middle, newMiddle = "";

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            Console.WriteLine("Write a sentence:");
            string sentence = Console.ReadLine();

            string output = ChangeSentence(sentence);
            Console.WriteLine("\n" + output);
            Console.ReadKey();
        }
        private string ChangeSentence(string line)
        {
            StringBuilder builder = new StringBuilder();
            string[] arr = line.Split(' ');

            foreach (var word in arr)
            {
                int wordLength = word.Count();

                if (wordLength > 3)
                {
                    firstLetter = word.Substring(0, 1);
                    lastLetter = word.Substring(wordLength - 1);
                    middle = word.Substring(1, wordLength - 2);

                    if (lastLetter == "." || lastLetter == ",")
                    {
                        lastLetter = word.Substring(wordLength - 2);
                        middle = word.Substring(1, wordLength - 3);
                    }

                    if (!(middle.Contains(".") || middle.Contains(",")))                    
                        newMiddle = Randomize(middle);

                    builder.Append(firstLetter + newMiddle + lastLetter + " ");
                }

                else                
                    builder.Append(word + " ");
                
            }             
            return builder.ToString();
        }

        private string Randomize(string letters)
        {
            Random rnd = new Random();
            char[] lettersRandomized = letters.OrderBy(x => rnd.Next()).ToArray();

            StringBuilder builder = new StringBuilder();
            foreach (var letter in lettersRandomized)
            {
                builder.Append(letter);
            }
            return builder.ToString();
        }
    }
}
