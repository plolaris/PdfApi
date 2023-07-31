using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        #region Constructor
        private readonly IPdfData _repository;
        private readonly ILogger<PdfController> _logger;
        public PdfController(IPdfData repository, ILogger<PdfController> logger)
        {
            _repository = repository;
            _logger = logger;   
        }
        #endregion


        #region Api End Points
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<PdfModel>> Get()
        {
            _logger.LogInformation("GetAllPdfs");
            return await _repository.GetPdfs();

        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            _logger.LogInformation("GetPdfById:  " + id);
            var pdf = await _repository.GetPdf(id);
            if (pdf != null)
            {
                return Ok(pdf);
            }
            return NotFound();
        }

        #endregion

        #region Internal Methods


        #endregion
    }
}
