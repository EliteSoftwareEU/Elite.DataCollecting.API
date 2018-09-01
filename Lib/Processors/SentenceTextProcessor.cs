using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using OpenNLP.Tools.SentenceDetect;
namespace Elite.DataCollecting.API.Lib.Processors
{
    public class SentenceTextProcessor : TextProcessor
    {
        static string ENGLISH_SD_MODEL = Path.Combine("Data", "EnglishSD.nbin");
        string _modelPath;
        public List<string> Sentences { get; set; }

        public SentenceTextProcessor(IHostingEnvironment hostingEnvironment,
                                     string input) : base(hostingEnvironment, input)
        {
            _inputText = input;
            _modelPath = Path.Combine(hostingEnvironment.ContentRootPath, ENGLISH_SD_MODEL);
            Sentences = new List<string>();
        }

        public override void ProcessText()
        {
            var sentenceDetector = new EnglishMaximumEntropySentenceDetector(_modelPath);
            var detectedSentences = sentenceDetector.SentenceDetect(_inputText).ToList();
            foreach(string sentence in detectedSentences) 
            {
                string sentenceClean = sentence.Replace(".", "")
                                               .Replace(@"\s+", " ")
                                               .Trim();
                sentenceClean = Regex.Replace(sentenceClean, @"\s+", " ");
                Sentences.Add(sentenceClean.Trim());
            }
            OutputText = string.Join("", Sentences);
        }
    }
}