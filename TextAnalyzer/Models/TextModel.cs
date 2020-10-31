using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer.Models
{
    public class TextModel
    {
        [Display(Name = "Enter your text to analyze")]
        [Required(ErrorMessage = "Enter your text")]
        public string Text { get; set; }

        public List<string> AnalyzerList { get; set; }
    }
}
