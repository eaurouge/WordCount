using System;
using System.Linq;
using Xunit;

namespace WordCount.Tests
{
    public class WordCounterTests
    {
        [Fact]
        public void CalculateWordsOccurence_Punctuation()
        {
            const string text = "  - \t \r\n .,?!:;~";

            var wordsOccurence = WordCounter.CalculateWordsOccurence(text);

            Assert.True(wordsOccurence.Keys.Count == 0, "punctuation characters were found");
        }

        [Fact]
        public void CalculateWordsOccurence_Text()
        {
            const string text = @"Peter Piper picked a peck of pickled peppers.
                                  A peck of pickled peppers Peter Piper picked.
                                  If Peter Piper picked a peck of pickled peppers,
                                  Where's the peck of pickled peppers Peter Piper picked?";

            var wordsOccurence = WordCounter.CalculateWordsOccurence(text);

            Assert.True(wordsOccurence.ContainsKey("peppers"), "expected to find \"peppers\", but it wasn't found");
            Assert.True(wordsOccurence["peppers"] == 4, string.Format("\"peppers\" expected to occur 4 times, but was found {0} times", wordsOccurence["peppers"]));
            Assert.True(wordsOccurence.Keys.All(x => x.All(char.IsLower)), "all words expected to be lowercase, but uppercase letter(s) were found");
            Assert.True(wordsOccurence.Count == 12, string.Format("expected to find 12 words, but found {0} words", wordsOccurence.Count));
            Assert.True(wordsOccurence.Keys.All(x => x.IndexOf(' ') == -1), "expected to have no whitespaces in words, but whitespace(s) were found");
            Assert.True(wordsOccurence.Values.Sum() == 35, string.Format("expected to find 35 words, but found {0} words", wordsOccurence.Values.Sum()));
        }
    }
}
