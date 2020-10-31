using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer.Models
{
    public class SpecialSymbolCounterAnalyzer : IAnalyzer
    {
        public string Name { get; } = "SpecialSymbolCounterAnalyzer";
        public string Descripton { get; } = "This analyzer shows the number of all special characters.";

        public Dictionary<string, string> Analyze(string text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string[] subStrings = new string[] { ".", ",", ";", ":", "!", "?", "%", "@", "#", "$", "^", "&", "-", "+", "*", "=", "|", "\\", "/", "<", ">", "[", "]", "{", "}", "(", ")" };
            int totalCount = 0;
            foreach (var subString in subStrings) {
                int subStringCount = GetSubStringCount(subString, text);
                totalCount += subStringCount;
                if (subStringCount > 0) {
                    string key = $"Symbol {subString}";
                    result.Add(key, subStringCount.ToString());
                }
            }
            
            result.Add("Unique Symbols Count", result.Count().ToString());
            result.Add("Symbols Count", totalCount.ToString());
            return result;
        }

       public static int GetSubStringCount(string subString, string text)
        {
            int subStringCount = 0;
            int startPos = 0;
            bool isDone = false;

            do {
                int pos = text.IndexOf(subString, startPos);
                if (pos != -1) {
                    subStringCount++;
                    startPos = pos + 1;
                }
                if (pos == -1) {
                    isDone = true;
                }
            } while (!isDone);


            return subStringCount;
        }
    }
}
