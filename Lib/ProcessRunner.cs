using System;
using System.Diagnostics;
using Elite.DataCollecting.API.Exceptions;

namespace Elite.DataCollecting.API.Lib
{
    public static class ProcessRunner
    {
        public static void Run(string binaryPath, string arguments)
        {
           
            ProcessStartInfo procStartInfo = new ProcessStartInfo(binaryPath, arguments);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            procStartInfo.WorkingDirectory = Environment.CurrentDirectory;

            Process process = new Process() { StartInfo = procStartInfo, };
            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new ProcessException(process.ExitCode);
            }
        }
    }
}
