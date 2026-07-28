using api.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Polly;
using Polly.Extensions.Http;
using api.Services;
var builder = WebApplication.CreateBuilder(args);



static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(
            retryCount: 3,
            sleepDurationProvider: retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
        );
}



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



builder.Services.AddOpenApi();
builder.Services.AddControllers();



var baseUrl = builder.Configuration["InsuranceClients:BaseUrl"];
builder.Services.AddHttpClient("OpenCasco", client =>
{
    client.BaseAddress = new Uri(baseUrl!);
    client.Timeout = TimeSpan.FromSeconds(10);
})
.AddPolicyHandler(GetRetryPolicy());

builder.Services.AddHttpClient("TrustCasco", client =>
{
    client.BaseAddress = new Uri(baseUrl!);
    client.Timeout = TimeSpan.FromSeconds(10);
})
.AddPolicyHandler(GetRetryPolicy());

builder.Services.AddHttpClient("UnityCasco", client =>
{
    client.BaseAddress = new Uri(baseUrl!);
    client.Timeout = TimeSpan.FromSeconds(10);
})
.AddPolicyHandler(GetRetryPolicy());



builder.Services.AddScoped<IQuoteService, QuoteService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}



app.MapControllers();
app.UseHttpsRedirection();
app.Run();