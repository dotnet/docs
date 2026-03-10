using System.ComponentModel.DataAnnotations;

namespace RecursiveValidation.Example;

// <ServerOptions>
public sealed class ServerOptions
{
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9\-\.]+$")]
    public string HostName { get; set; } = string.Empty;

    [Required]
    [Range(1, 65535)]
    public int Port { get; set; }
}
// </ServerOptions>
