namespace api.DTOs;

public class CoverageDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal? Limit { get; set; }
}
