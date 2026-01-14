using System.ComponentModel.DataAnnotations;

namespace RecursiveValidation.Example;

// <DatabaseOptions>
public sealed class DatabaseOptions
{
    [Required]
    [MinLength(1)]
    public string ConnectionString { get; set; } = string.Empty;

    [Range(1, 100)]
    public int MaxRetries { get; set; } = 3;

    [Range(1, 300)]
    public int TimeoutSeconds { get; set; } = 30;
}
// </DatabaseOptions>
