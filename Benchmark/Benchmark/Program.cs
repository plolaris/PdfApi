using Benchmark;
using BenchmarkDotNet.Running;
using System.Threading.Tasks;
using Grpc.Net.Client;
using SharedLibrary.Grpc;

Console.WriteLine("Hello, World!");

// Benchmark
BenchmarkRunner.Run<BenchmarckHarness>();


// Test single client
/*using var channel = GrpcChannel.ForAddress("https://localhost:7062", new GrpcChannelOptions
{
    MaxReceiveMessageSize = 500 * 1024 * 1024, // 5 MB
    MaxSendMessageSize = 2 * 1024 * 1024 // 2 MB
});
var client = new PDF.PDFClient(channel); 
var reply = await    client.GetAllPdfsAsync(
                  new GetAllPdfsPdfRequestModel ());
Console.WriteLine("Greeting: " + reply.AllPdfs);*/

Console.ReadKey(); 