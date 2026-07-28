using api.DTOs;
using api.Models;

namespace api.Mappers;

public static class QuoteMapper
{
    public static Quote ToQuoteFromQuoteResponseDto(this QuoteResponseDto responseDto)
    {
        return new Quote
        {
          TransactionId = responseDto.TransactionId,
          QueryDate = responseDto.QueryDate,
          CompanyCode = responseDto.QuoteDetail.CompanyCode,
          CompanyName = responseDto.QuoteDetail.CompanyName,
          TotalPremium = responseDto.QuoteDetail.TotalPremium,
          Currency = responseDto.QuoteDetail.Currency,
          IsSuccessful = responseDto.ErrorStatus.IsSuccessful,
          Coverages = responseDto.Coverages.Select(c => c.ToCoverageFromCoverageDto()).ToList(),
          CreatedAt = DateTime.UtcNow
        };
    }

}
