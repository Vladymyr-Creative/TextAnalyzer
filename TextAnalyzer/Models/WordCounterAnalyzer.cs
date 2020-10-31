using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer.Models
{
    public class WordCounterAnalyzer : IAnalyzer
    {
        public string Name { get; } = "WordCounterAnalyzer";
        public string Descripton { get; } = "This analyzer shows the number of all words, the number of unique words, as well as the 10 most used words.";

        public Dictionary<string, string> Analyze(string text)
        {
            string pattern = @"[^\w]+";
            string replacement = " ";

            var clearText = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);
            var stringArray = clearText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> totalResult = CountAllWords(stringArray);
            Dictionary<string, string> result = totalResult.Take(10).ToDictionary(s=>s.Key, s=>s.Value);
            result.Add("Wolds Count", stringArray.Count().ToString());
            result.Add("Unique Wolds Count", totalResult.Count().ToString());

            return result;
        }

        public static Dictionary<string, string> CountAllWords(string[] stringArray)
        {
            var result = stringArray
                .AsParallel()
                .GroupBy(word => word)
                .OrderByDescending(word => word.Count())                
                .ToDictionary(word => word.Key, word => word.Count().ToString());
            return result;
        }
    }
}
