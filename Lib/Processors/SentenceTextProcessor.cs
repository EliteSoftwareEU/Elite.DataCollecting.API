using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        }

        public override void ProcessText()
        {
            var sentenceDetector = new EnglishMaximumEntropySentenceDetector(_modelPath);
            Sentences = sentenceDetector.SentenceDetect(_inputText).Select(s => s.Trim().Replace(".", "")
                                                                                        .Replace(@"\s+", " "))
                                        .ToList();
            OutputText = string.Join("", Sentences);
        }
    }
}