using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer.Models
{
    public class SymbolCounterAnalyzer : IAnalyzer
    {
        public string Name { get; } = "SymbolCounterAnalyzer";

        public Dictionary<string, string> Analyze(string text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result["length"] = text.Trim().Length.ToString();
            return result;
        }
    }
}
