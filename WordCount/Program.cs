using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCount
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    Console.WriteLine("Please use path to file as an argument");
                    return;
                }

                var path = args[0];

                if (!File.Exists(path))
                {
                    Console.WriteLine("File {0} doesn't exist", path);
                    return;
                }

                var rawText = File.ReadAllText(path);
                var wordsOccurence = WordCounter.CalculateWordsOccurence(rawText);
                var orderedWords = wordsOccurence.OrderByDescending(x => x.Value).ToList();

                foreach (var orderedWord in orderedWords)
                {
                    Console.WriteLine("{0} - {1}", orderedWord.Key, orderedWord.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops, something went wrong: " + ex.Message);
            }
        }
    }
}
