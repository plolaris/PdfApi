using CommandLine;
using Grpc.Core;
using Grpc.Net.Client; 
using SharedLibrary.Data;
using SharedLibrary.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Clients
{
    public class GrpcClient
    {
        private readonly GrpcChannel _channel;
        private readonly PDF.PDFClient _client;

        public GrpcClient()
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            _channel = GrpcChannel.ForAddress("https://localhost:7062", new GrpcChannelOptions
            {
                //HttpHandler = new SocketsHttpHandler
                //{
                //    EnableMultipleHttp2Connections = true,

                //    // ...configure other handler settings
                //},
                MaxReceiveMessageSize =  500 * 1024 * 1024, // 5 MB
                MaxSendMessageSize = 200 * 1024 * 1024, // 2 MB
                
            });
            _client = new PDF.PDFClient(_channel);
        }

        public async Task<PdfResponseModel> GrpcGetPdfBytIdAsync()
        {
            return   (await _client.GetPdfByIdAsync(
                    new PdfRequestpModel() { Id = new Random().Next(1, 10) }
                ));
        }
        public async Task<AllPdfResponseModel> GrpcGetAllPdfsAsync()
        {
            return await _client.GetAllPdfsAsync(new GetAllPdfsPdfRequestModel ());
        }

        public async Task<AllPdfResponseModel> GrpcGetAllPdfsStreamAsync()
        {
            AllPdfResponseModel allPdfResponseModel = new AllPdfResponseModel();
            using var call = _client.GetAllPdfsStream(new GetAllPdfsPdfRequestModelStream()/*, deadline: DateTime.UtcNow.AddMinutes(10)*/);
            await foreach (var each in call.ResponseStream.ReadAllAsync())
            {
                allPdfResponseModel.AllPdfs.Add(each);
            }
            return allPdfResponseModel;
        }


    }
}
