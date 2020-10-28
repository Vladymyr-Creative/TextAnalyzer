using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer.Models
{
    public class SymbolFrequencyAnalyzer : IAnalyzer
    {
        public string Name { get; } = "SymbolFrequencyAnalyzer";

        public Dictionary<string, string> Analyze(string text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result["charA"] = (text.Split('a').Length - 1).ToString();
            return result;
        }
    }
}
