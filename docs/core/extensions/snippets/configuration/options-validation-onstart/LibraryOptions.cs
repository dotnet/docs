using System.ComponentModel.DataAnnotations;
using System.Net;

public sealed class LibraryOptions
{
    [Url]
    public string? SupportUrl { get; set; }

    [Required, EmailAddress]
    public required string SupportEmail { get; set; }

    [Required, DataType(DataType.PhoneNumber)]
    public required string SupportPhoneNumber { get; set; }
}
