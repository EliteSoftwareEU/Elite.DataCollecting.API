using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Elite.DataCollecting.API.Lib
{
    public class FileImporter
    {
        public static void Import(string fullPath, Action<FileStream, string> action)
        {
            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                action(stream, fullPath);
            }

        }
    }
}
