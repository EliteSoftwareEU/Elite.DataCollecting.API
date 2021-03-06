﻿using System;
using System.Collections.Generic;
using System.Linq;
using Elite.DataCollecting.API.Lib.Processors;
using Microsoft.AspNetCore.Hosting;

namespace Elite.DataCollecting.API.Lib.Pipelines
{
    public class NLPTextProcessingPipeline
    {
        private string _inputText;
        private List<string> _processors { get; set; }
        public List<TextProcessor> Processors { get; set; }
        private IHostingEnvironment _hostingEnvironment { get; set; }
        public string Result;

        public NLPTextProcessingPipeline(string inputText,
                                         IHostingEnvironment hostingEnvironment,
                                         List<string> processors)
        {
            _inputText = inputText;
            _processors = processors;
            _hostingEnvironment = hostingEnvironment;
            Processors = new List<TextProcessor>();
        }

        public static NLPTextProcessingPipeline Build(IHostingEnvironment hostingEnv,
                                                      string inputText)
        {
            var items = new List<string>();
            items.Add("NormalizingTextProcessor");
            items.Add("SentenceTextProcessor");
            return new NLPTextProcessingPipeline(inputText, hostingEnv, items);
        }

        public TextProcessor GetPipelineByName(string pipelineName)
        {
            return Processors.FirstOrDefault(p => p.GetType().Name == pipelineName);

        }

        public void Run()
        {
            foreach(var procKlass in _processors)
            {
                var processorType = Type.GetType("Elite.DataCollecting.API.Lib.Processors." + procKlass);
                var processor = (TextProcessor) Activator
                                                .CreateInstance(processorType, 
                                                                new object[] {  _hostingEnvironment, _inputText });
                Processors.Add(processor);
                processor.ProcessText();
                _inputText = processor.OutputText;
            }
            Result = _inputText;
        }
    }
}
