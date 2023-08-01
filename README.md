# PdfApi
.net7  gRPC and Rest comparation

Steps:

1) Unzip the files from Pdfs.7z (SQL folder).
2) Run the "Sql comands.sql" on you SQL Server instance.
3) Go to PdfApi -> gRPCApi/RestApi -> "appsettings.json" -> "ConnectionStrings" -> Change the server and database.
4) Don't run PdfApi solution in "Multiple startup projects" mode. It will affect the performance.
5) Run gRPCApi and RestApi in Release mode when testing
6) Run Benchmark in Release mode and start it without debugging
7) Have fun ヽ(•‿•)ノ

   
Benchmark results (all the components were ran on local machine and the payload was 160pdfs or ~64Mb  )

|                    Method | IterationCount |        Mean |     Error |      StdDev |      Median | Ratio |        Gen0 |        Gen1 |        Gen2 |   Allocated | Alloc Ratio |
|-------------------------- |--------------- |------------:|----------:|------------:|------------:|------:|------------:|------------:|------------:|------------:|------------:|
|      RestGetPdfBytIdAsync |             50 |    119.2 ms |   2.38 ms |     6.20 ms |    118.8 ms |  1.00 |  13666.6667 |  12333.3333 |  12333.3333 |    64.76 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
|      GrpcGetPdfBytIdAsync |             50 |    134.1 ms |   4.29 ms |    12.58 ms |    132.6 ms |  1.00 |   3333.3333 |   3333.3333 |   3333.3333 |     16.3 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
|       GrpcGetAllPdfsAsync |             50 | 10,873.9 ms | 206.63 ms |   172.55 ms | 10,839.1 ms |  1.00 |  13000.0000 |   3000.0000 |   2000.0000 |  2548.89 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
| GrpcGetAllPdfsStreamAsync |             50 | 10,304.1 ms | 204.36 ms |   170.65 ms | 10,256.6 ms |  1.00 |  51000.0000 |  39000.0000 |  39000.0000 |  2552.92 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
|       RestGetAllPdfsAsync |             50 | 12,274.2 ms | 124.43 ms |    97.15 ms | 12,235.6 ms |  1.00 | 124000.0000 | 122000.0000 | 122000.0000 | 15063.43 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
|      RestGetPdfBytIdAsync |            100 |    220.2 ms |   4.30 ms |     4.78 ms |    220.1 ms |  1.00 |  28666.6667 |  25666.6667 |  25666.6667 |    129.5 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
|      GrpcGetPdfBytIdAsync |            100 |    299.2 ms |   9.41 ms |    27.45 ms |    295.1 ms |  1.00 |   7000.0000 |   7000.0000 |   7000.0000 |    32.58 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
|       GrpcGetAllPdfsAsync |            100 | 22,891.7 ms | 587.48 ms | 1,732.19 ms | 21,793.9 ms |  1.00 |  29000.0000 |   9000.0000 |   6000.0000 |  5098.98 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
| GrpcGetAllPdfsStreamAsync |            100 | 21,235.6 ms | 585.73 ms | 1,717.84 ms | 20,479.0 ms |  1.00 | 127000.0000 | 101000.0000 | 101000.0000 |  5107.86 MB |        1.00 |
|                           |                |             |           |             |             |       |             |             |             |             |             |
|       RestGetAllPdfsAsync |            100 | 25,084.0 ms | 513.06 ms | 1,512.78 ms | 24,166.7 ms |  1.00 | 251000.0000 | 247000.0000 | 247000.0000 |  30126.4 MB |        1.00 |
