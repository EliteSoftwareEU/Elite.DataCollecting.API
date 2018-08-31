using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Elite.DataCollecting.API.Data;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Http;
namespace Elite.DataCollecting.API.Lib.Importers
{
    public class PdfFileImporter : Importer
    {
        public List<string> Lines;
        private string _text;

        public PdfFileImporter(FileStream stream,
                               string fullPath, 
                               AppDbContext context)
        {
            _stream = stream;
            _fullPath = fullPath;
            Imported = new List<dynamic>();
            _context = context;
        }

        public override string ReadFile()
        {
            _stream.Position = 0;
            _text = ReadPDFText();
            Lines = _text.Split("\n").ToList();
            return _text;
        }

        private string ReadPDFText()
        {
            using (PdfReader reader = new PdfReader(_stream))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                return text.ToString();
            }
        }

    }
}
