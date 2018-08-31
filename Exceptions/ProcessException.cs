using System;
namespace Elite.DataCollecting.API.Exceptions
{
    public class ProcessException : Exception
    {
        public ProcessException(int exitCode)
            : base(string.Format("Process has failed with code: {0}", exitCode))
        { }
    }
}
