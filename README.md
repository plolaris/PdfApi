# PdfApi
.net7  gRPC and Rest comparation

Steps:

1) Unzip the files from Pdfs.7z (SQL folder).
2) Run the "Sql comands.sql" on you SQL Server instance.
3) Go to PdfApi -> gRPCApi/RestApi -> "appsettings.json" -> "ConnectionStrings" -> Change the server and database.
4) Don't run PdfApi solution in "Multiple startup projects" mode. It will affect the performance.
5) Run gRPCApi and RestApi in Release mode when testing
6) Run Benchmark in Release mode and start it without debugging
7) Have fun :)
