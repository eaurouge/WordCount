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
            var lowercaseText = rawText.ToLowerInvariant();
            var textWithoutPunctuation = RemovePunctuation(lowercaseText);
            var words = textWithoutPunctuation.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var wordsOccurence = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordsOccurence.ContainsKey(word))
                {
                    wordsOccurence[word]++;
                }
                else
                {
                    wordsOccurence.Add(word, 1);
                }
            }

            var orderedWords = wordsOccurence.OrderByDescending(x => x.Value).ToList();

            foreach (var orderedWord in orderedWords)
            {
                Console.WriteLine("{0} - {1}", orderedWord.Key, orderedWord.Value);
            }
        }

        private static string RemovePunctuation(string source)
        {
            var result = new StringBuilder();

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var character in source)
            {
                var charToAppend = char.IsLetter(character) ? character : ' ';
                result.Append(charToAppend);
            }

            return result.ToString();
        }
    }
}
