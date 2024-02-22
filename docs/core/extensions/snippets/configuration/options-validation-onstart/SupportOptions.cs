using System.ComponentModel.DataAnnotations;

public sealed class SupportOptions
{
    [Url]
    public string? Url { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required, DataType(DataType.PhoneNumber)]
    public required string PhoneNumber { get; set; }
}
