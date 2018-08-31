using System;
using Microsoft.AspNetCore.Hosting;

namespace Elite.DataCollecting.API.Lib.Processors
{
    public abstract class TextProcessor
    {
        protected string _inputText;
        public string OutputText;

        public TextProcessor(IHostingEnvironment hostingEnvironment, 
                             string input)
        {
            _inputText = input;
        }

        public abstract void ProcessText();
 
    }
}
