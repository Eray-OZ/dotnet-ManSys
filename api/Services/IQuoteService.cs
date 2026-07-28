using api.DTOs;

namespace api.Services;

public interface IQuoteService
{
    public Task<QuoteResponseDto> GetBestQuoteAsync();
}
