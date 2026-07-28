namespace api.DTOs;

public class QuoteDetailDto
{
    public int CompanyCode { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public decimal TotalPremium { get; set; }
    public string Currency { get; set; } = string.Empty;

}
