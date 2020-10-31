using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer.Models
{
    public static class AnalyzerListModel
    {

        public static IAnalyzer GetAnalyzer(string name)
        {
            return AllAnalyzers[name];
        }

        static AnalyzerListModel()
        {
            AllAnalyzers = new Dictionary<string, IAnalyzer> {
                ["SpecialSymbolCounterAnalyzer"] = new SpecialSymbolCounterAnalyzer(),                
                ["WordCounterAnalyzer"] = new WordCounterAnalyzer()
            };
        }
        public static Dictionary<string, IAnalyzer> AllAnalyzers { get; private set; }
    }
}
