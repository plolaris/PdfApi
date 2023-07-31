using DataAccess.Data;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRPCApi;
using System.Buffers.Text;
using System.Collections;
using System.Text;
using Google.Protobuf.Collections;

namespace gRPCApi.Services
{
    public class PDFService : PDF.PDFBase
    {
        #region Constructor
        private readonly IPdfData _repository;
        
        private readonly ILogger<PDFService> _logger;
        public PDFService(IPdfData repository, ILogger<PDFService> logger)
        {
            _logger = logger;
            _repository = repository;
        }
        #endregion
        public override async Task<PdfResponseModel> GetPdfById(PdfRequestpModel request, ServerCallContext context)
        {
            _logger.LogInformation("GetPdfById:  " + request.Id);
            PdfResponseModel response = new PdfResponseModel();
            var pdf = await _repository.GetPdf(request.Id);
            
            if (pdf != null)
            {
                response.PdfId = pdf.pdf_ID;
                response.PdfName = pdf.pdf_Name; 
                response.PdfContent = Google.Protobuf.ByteString.CopyFrom(pdf.pdf_Content).ToBase64();
                return response;
            }
            return response;
        }

        public override async Task<AllPdfResponseModel> GetAllPdfs(GetAllPdfsPdfRequestModel request, ServerCallContext context)
        {
            _logger.LogInformation("GetAllPdfs:  " );
            AllPdfResponseModel response = new AllPdfResponseModel();
             var pdfList = await _repository.GetPdfs();
            foreach (var pdf in pdfList)
            {
                PdfResponseModel pdfResponseModel = new PdfResponseModel();
                pdfResponseModel.PdfId = pdf.pdf_ID;
                pdfResponseModel.PdfName = pdf.pdf_Name;
                pdfResponseModel.PdfContent = Google.Protobuf.ByteString.CopyFrom(pdf.pdf_Content).ToBase64();
                response.AllPdfs.Add(pdfResponseModel);
            }
            return response; 
        }


        public override async Task GetAllPdfsStream(GetAllPdfsPdfRequestModelStream request, IServerStreamWriter<PdfResponseModel> responseStream, ServerCallContext context)
        {
            _logger.LogInformation("GetAllPdfs:  ");
            AllPdfResponseModelStream response = new AllPdfResponseModelStream();
            var pdfList = await _repository.GetPdfs();
            foreach (var pdf in pdfList)
            {
                try
                {
                PdfResponseModel pdfResponseModel = new PdfResponseModel();
                pdfResponseModel.PdfId = pdf.pdf_ID;
                pdfResponseModel.PdfName = pdf.pdf_Name;
                pdfResponseModel.PdfContent = Google.Protobuf.ByteString.CopyFrom(pdf.pdf_Content).ToBase64(); 
                await    responseStream.WriteAsync(pdfResponseModel);
                }

                catch (Exception ex)
                {
                    throw new RpcException(new Status(StatusCode.Internal, ex.ToString()));
                }
            }
            
        }
    }
}
