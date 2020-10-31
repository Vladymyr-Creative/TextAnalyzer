using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAnalyzer.Interfaces
{
    public interface IAnalyzer
    {
        public string Name { get; }
        public string Descripton { get; }

        public Dictionary<string, string> Analyze(string text);
    }
}
