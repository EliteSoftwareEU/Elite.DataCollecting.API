using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using static Elite.DataCollecting.API.Lib.RegularExpressions;
namespace Elite.DataCollecting.API.Lib.Processors
{
    public class NormalizingTextProcessor : TextProcessor
    {
        public NormalizingTextProcessor(IHostingEnvironment environment, 
                                        string input) : base(environment, input)
        {
            _inputText = input;
        }

        public override void ProcessText()
        {
            OutputText = _inputText.Replace("\t", " ");
            OutputText = OutputText.Replace("(\r\n|\r|\n){1,}", " ");
            OutputText = OutputText.Replace("\n", " ");
            OutputText = Regex.Replace(OutputText, AllExceptDotAndAZ().ToString(), " ");
            OutputText = Regex.Replace(OutputText, MoreThanOneSpace().ToString(), " ");
            OutputText = OutputText.Trim().ToLowerInvariant();
        }
    }
}
