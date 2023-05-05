
var httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7230/data");

using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
response.EnsureSuccessStatusCode();

using var responseStream = await response.Content.ReadAsStreamAsync();
using var streamReader = new StreamReader(responseStream);

await foreach (var line in ReadLinesAsync(streamReader))
{
    Console.WriteLine(line);
}

Console.ReadLine();


static async IAsyncEnumerable<string> ReadLinesAsync(StreamReader streamReader)
{
    string? line;
    while ((line = await streamReader.ReadLineAsync()) != null)
    {
        yield return line;
    }
}


