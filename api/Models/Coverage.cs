namespace api.Models;

public class Coverage
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal? Limit { get; set; }
    public Guid QuoteId { get; set; }
    public Quote? Quote { get; set; } // Navigation Property
}
