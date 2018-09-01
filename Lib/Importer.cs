using System;
using System.Collections.Generic;
using System.IO;
using Elite.DataCollecting.API.Data;
using Microsoft.AspNetCore.Http;

namespace Elite.DataCollecting.API.Lib
{
    public abstract class Importer
    {
        protected FileStream _stream;
        protected AppDbContext _context;
        protected string _fullPath { get; set; }
        public abstract string ReadFile();
    }
}
