using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_Generic
{
    public class Statistics
    {
        public void StatisticOfText()
        {
            string text = "Вот дом, Который построил Джек. А это пшеница, Кото­рая в темном  чулане хранится В доме, Который построил Джек. А это веселая птица­ синица, Которая часто вору­ет пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";
            var counter = CountWords(text);

            var sortedByWord = counter.OrderBy(x => x.Key);
            var sortedByFrequency = sortedByWord.OrderBy(x => x.Value);
            int i = 1;
            Console.WriteLine("\t\tКол-во: \t\tСлово:");
            foreach (KeyValuePair<string, int> kvp in sortedByFrequency)
                Console.WriteLine($"{i++}. \t\t{kvp.Value}  \t\t\t{kvp.Key}");

            Console.ReadKey();
        }

        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            if (String.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("\nЗдесь нет ни одного повторяющегося слова.");
                return counter;
            }

            string[] wordArray = text.Split(new Char[] { ' ', ',', '.', ':', '-', '(', ')', '“', '”', '\t', '\n' });

            foreach (string word in wordArray)
            {
                if (word.Trim() != "")
                {
                    try
                    {
                        if (counter.ContainsKey(word) == false)
                            counter.Add(word, 1);
                        else
                            counter[word]++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0}", e.Message);
                    }
                }
            }
            return counter;
        }
    }
}
