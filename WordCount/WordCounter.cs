using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class WordCounter
    {
        public static Dictionary<string, int> CalculateWordsOccurence(string text)
        {
            var lowercaseText = text.ToLowerInvariant();
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

            return wordsOccurence;
        }

        private static string RemovePunctuation(string source)
        {
            var result = new StringBuilder();

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var character in source)
            {
                var charToAppend = Char.IsLetter(character) ? character : ' ';
                result.Append(charToAppend);
            }

            return result.ToString();
        }
    }
}
