using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elite.DataCollecting.API.Models
{
    public class DocumentData
    {
        public Guid ID { get; set; }
        public string FileName { get; set; }
        [Column(TypeName = "text")]
        public string DocumentText { get; set; }
        public DateTime ImportedDate { get; set; }
        public string DocumentImportedPath { get; set; }
        [Column(TypeName = "jsonb")]
        public string Sentences { get; set; }
    }
}