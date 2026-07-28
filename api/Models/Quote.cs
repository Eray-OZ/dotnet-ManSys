namespace api.Models;

public class Quote
{
    public Guid Id { get; set; }
    public Guid TransactionId { get; set; }
    public DateTimeOffset QueryDate { get; set; }
    public int CompanyCode { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public decimal TotalPremium { get; set; }
    public string Currency { get; set; } = string.Empty;
    public bool IsSuccessful { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Coverage> Coverages { get; set; } = []; // Navigation Property
}
