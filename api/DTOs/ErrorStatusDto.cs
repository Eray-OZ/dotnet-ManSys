namespace api.DTOs;

public class ErrorStatusDto
{
    public bool IsSuccessful { get; set; }
    public string[] ErrorCodes { get; set; } = [];
}
