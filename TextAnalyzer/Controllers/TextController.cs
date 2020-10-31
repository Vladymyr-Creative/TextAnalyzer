using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        [RequestSizeLimit(100_000_000)]
        public IActionResult Analyze(TextModel textModel)
        {
            if (textModel == null) {
                textModel.Text = "Too large text >> TextModel is null";
                ViewBag.Eror = textModel.Text;
                textModel = new TextModel();
            }
            else {
                if (ModelState.IsValid) {
                    var result = HandleText(textModel);
                    ViewBag.Result = result;
                }
            }

            return View(textModel);
        }

        public List<Dictionary<string, string>> HandleText(TextModel textModel)
        {
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
            var analyzerList = textModel.AnalyzerList.Select(s => s).OfType<string>();
            if (analyzerList.Count() == 0) {
                return results;
            }

             string text = textModel.Text.Trim();
             ParallelLoopResult parallelLoopResult = Parallel.ForEach(analyzerList, (analyzerName) =>
             {
                 var analyzer = AnalyzerListModel.GetAnalyzer(analyzerName);
             if (analyzer != null) {
                     var result = analyzer.Analyze(text);
                     result["Name"] = analyzerName;
                     results.Add(result);
                 }                
             });

            return results;
        }
    }
}
