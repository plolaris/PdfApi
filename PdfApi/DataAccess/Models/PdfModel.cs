using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PdfModel
    {
        public int pdf_ID { get; set; }
        public string pdf_Name { get; set; }
        public byte[] pdf_Content { get; set; }
    }
}
