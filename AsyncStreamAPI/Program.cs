using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/data", async (HttpContext context) =>
{
    context.Response.ContentType = "text/plain";    

    var responseStream = context.Response.Body;
    using var streamWriter = new HttpResponseStreamWriter(responseStream,Encoding.UTF8);

    for (int i = 1; i <= 10; i++)
    {
        await streamWriter.WriteLineAsync($"Data {i}");
        await streamWriter.FlushAsync();
        await Task.Delay(1000); // Simulate a delay between sending data.
    }
});

app.Run();
