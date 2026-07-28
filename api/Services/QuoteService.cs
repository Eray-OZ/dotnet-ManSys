using api.DTOs;
using System.Net.Http.Json;
namespace api.Services;

public class QuoteService : IQuoteService
{


    private readonly IHttpClientFactory _clientFactory;
    public QuoteService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }


    public async Task<QuoteResponseDto> GetBestQuoteAsync()
    {
        var requestBody = new { };

        var openCascoClient = _clientFactory.CreateClient("OpenCasco");
        var trustCascoClient = _clientFactory.CreateClient("TrustCasco");
        var unityCascoClient = _clientFactory.CreateClient("UnityCasco");

        var openCascoTask = openCascoClient.PostAsJsonAsync("/companies/open-casco/quotes", requestBody);
        var trustCascoTask = trustCascoClient.PostAsJsonAsync("/companies/trust-casco/quotes", requestBody);
        var unityCascoTask = unityCascoClient.PostAsJsonAsync("/companies/unity-casco/quotes", requestBody);

        var responses = await Task.WhenAll(openCascoTask, trustCascoTask, unityCascoTask);

        var quoteReadTasks = responses
        .Where(response => response.IsSuccessStatusCode)
        .Select(response => response.Content.ReadFromJsonAsync<QuoteResponseDto>());

        var quotes = await Task.WhenAll(quoteReadTasks);

        var successfulQuotes = quotes
        .Where(q => q is not null)
        .Where(q => q!.ErrorStatus is not null && q.ErrorStatus.IsSuccessful)
        .Where(q => q!.QuoteDetail is not null)
        .ToList();

        if (successfulQuotes.Count == 0)
        {
            throw new InvalidOperationException("No successful quote response was returned from insurance providers.");
        }

        var bestQuote = successfulQuotes
        .OrderBy(q => q!.QuoteDetail.TotalPremium)
        .First()!;

        return bestQuote;
    }
}
