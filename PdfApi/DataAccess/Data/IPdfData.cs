using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IPdfData
    {
        Task<PdfModel?> GetPdf(int id);
        Task<IEnumerable<PdfModel>> GetPdfs();
    }
}