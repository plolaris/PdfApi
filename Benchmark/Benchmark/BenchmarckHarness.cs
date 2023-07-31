using Benchmark.Clients;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using SharedLibrary.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{ 
    [SimpleJob(RuntimeMoniker.Net70,baseline: true)]
    [MemoryDiagnoser]
    public class BenchmarckHarness
    {
        [Params(50, 100)]
        public int IterationCount;

        private readonly RestClient _restClient = new RestClient();
        private readonly GrpcClient _grpcClient = new GrpcClient();

        [Benchmark]
        public async Task RestGetPdfBytIdAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _restClient.RestGetPdfBytIdAsync();
            }
        }
        [Benchmark]
        public async Task GrpcGetPdfBytIdAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _grpcClient.GrpcGetPdfBytIdAsync();
            }
        }

        [Benchmark]
        public async Task GrpcGetAllPdfsAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
             var a =   await _grpcClient.GrpcGetAllPdfsAsync();
            }
        }
        [Benchmark]
        public async Task GrpcGetAllPdfsStreamAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                var a = await _grpcClient.GrpcGetAllPdfsStreamAsync();
            }
        }
        [Benchmark]
        public async Task RestGetAllPdfsAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _restClient.RestGetAllPdfsAsync();
            }
        }
    }
}
