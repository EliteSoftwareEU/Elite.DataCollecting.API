using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Elite.DataCollecting.API.Data;
using Elite.DataCollecting.API.Lib.Pipelines;
using Elite.DataCollecting.API.Lib.Processors;
using Elite.DataCollecting.API.Models;
using Elite.DataCollecting.API.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Elite.DataCollecting.API.Lib
{
    public class PdfContentImporter
    {
        private string _dataDirectory;
        private string _importFiles;
        private readonly AppDbContext _context;
        private Importer _importer;
        private ImporterResolver _importerResolver;
        private IHostingEnvironment _hostingEnv;
        private bool _deleteImported = false;

        public PdfContentImporter(IConfiguration configuration, 
                                  AppDbContext appDbContext,
                                  IHostingEnvironment hostingEnvironment,
                                  bool deleteImportedFile = false)
        {
            _dataDirectory = configuration.GetSection("DataImport:DataDirectory").Value;
            _importFiles = configuration.GetSection("DataImport:ImportFiles").Value;
            _context = appDbContext;
            _importerResolver = new ImporterResolver();
            _deleteImported = deleteImportedFile;
            _hostingEnv = hostingEnvironment;
        }

        public void Run()
        {
            foreach(string fileToImportPath in FilesToImport())
            {
                var ms = new MemoryStream(File.ReadAllBytes(fileToImportPath));
                Action<FileStream, string> readAndSaveFileAction = (stream, fullPath) =>
                {
                    _importer = _importerResolver.Resolve("PdfFileImporter",
                                                          new object[] { stream, fullPath, _context });

                    string fileContent = _importer.ReadFile();
                    var pipeline = NLPTextProcessingPipeline.Build(_hostingEnv, fileContent);

                    pipeline.Run();

                    var sentenceProc = (SentenceTextProcessor)
                                        pipeline.GetPipelineByName("SentenceTextProcessor");

                    var documentData = new DocumentData()
                    {
                        DocumentText = pipeline.Result,
                        FileName = Path.GetFileName(fileToImportPath),
                        ImportedDate = DateTime.Now,
                        DocumentImportedPath = fileToImportPath,
                        Sentences = JsonConvert.SerializeObject(sentenceProc.Sentences)
                    };
                    _context.Add(documentData);
                    _context.SaveChanges();
                    if (_deleteImported) File.Delete(fileToImportPath);
                };
                FileImporter.Import(fileToImportPath, readAndSaveFileAction);              
            }
        }

        private List<string> FilesToImport()
        {
            var filesToImport = new List<string>();
            var contents = _dataDirectory.FileTypes(".pdf");
            foreach(var item in contents)
            {
                if (item.Contains(Extension()))
                {
                    filesToImport.Add(item);
                }
            }
            return filesToImport;
        }

        private string Extension()
        {
            return _importFiles.Replace("*.", String.Empty);
        }
    }
}
