using DataAccess.Data;
using DataAccess.DbAccess;
using gRPCApi.Services;

var builder = WebApplication.CreateBuilder(args);
 

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    //options.EnableDetailedErrors = true; 
    options.MaxReceiveMessageSize = 2 * 1024 * 1024; // 2 MB
    options.MaxSendMessageSize = null; // 5 MB 
}); ;
builder.Services.AddGrpcReflection();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IPdfData, PdfData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<PDFService>();
app.MapGrpcReflectionService();


app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
