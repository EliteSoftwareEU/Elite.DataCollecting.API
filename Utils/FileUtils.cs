using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Elite.DataCollecting.API.Utils
{
    public static class FileUtils
    {
        public static List<string> FileTypes(this string path, string extension)
        {
            var dirInfo = new DirectoryInfo(path);
            var docFiles = dirInfo.EnumerateFiles().Where(fi => Path.GetExtension(fi.FullName) == extension);
            return docFiles.Select(fi => fi.FullName).ToList();
        }
    }
}