using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TextAnalyzer.Interfaces;
using TextAnalyzer.Models;

namespace TextAnalyzer.Controllers
{
    public class TextController : Controller
    {
        public IActionResult Analyze()
        {
            TextModel textModel = new TextModel();
            return View(textModel);
        }

        [HttpPost]
        public IActionResult Analyze(TextModel textModel)
        {
            var result = HandleText(textModel);
            ViewBag.Result = result;
            return View(textModel);
        }

        public List<Dictionary<string, string>> HandleText(TextModel textModel)
        {
            string text = textModel.Text;
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();

            foreach (var pair in AnalyzerListModel.AllAnalyzers) {
                Dictionary<string, string> result = pair.Value.Analyze(text);
                results.Add(result);
            }

            return results;
        }
    }
}
