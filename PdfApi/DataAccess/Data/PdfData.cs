using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class PdfData : IPdfData
    {
        private readonly ISqlDataAccess _db;

        public PdfData(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<IEnumerable<PdfModel>> GetPdfs() =>
     await _db.LoadData<PdfModel, dynamic>("dbo.sp_PDF_GetAll", new { });

        public async Task<PdfModel?> GetPdf(int id)
        {
            var results = await _db.LoadData<PdfModel, dynamic>(
                "dbo.sp_PDF_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

    }
}
