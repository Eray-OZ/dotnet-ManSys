namespace api.DTOs;

public class QuoteResponseDto
{
    public Guid TransactionId { get; set; }
    public DateTimeOffset QueryDate { get; set; }
    public required QuoteDetailDto QuoteDetail { get; set; }
    public List<CoverageDto> Coverages { get; set; } = [];
    public required ErrorStatusDto ErrorStatus { get; set; }
}
