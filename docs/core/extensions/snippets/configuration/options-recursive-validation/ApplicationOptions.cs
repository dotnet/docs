using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace RecursiveValidation.Example;

// <ApplicationOptionsWithoutAttribute>
public sealed class ApplicationOptionsWithoutAttribute
{
    public const string ConfigurationSectionName = "ApplicationWithoutAttribute";

    [Required]
    public required string ApplicationName { get; set; }

    // Without [ValidateObjectMembers], validation does not recurse into DatabaseOptions
    public DatabaseOptions Database { get; set; } = new();

    // Without [ValidateEnumeratedItems], validation does not recurse into list items
    public List<ServerOptions> Servers { get; set; } = [];
}
// </ApplicationOptionsWithoutAttribute>

// <ApplicationOptionsWithAttribute>
public sealed class ApplicationOptionsWithAttribute
{
    public const string ConfigurationSectionName = "ApplicationWithAttribute";

    [Required]
    public required string ApplicationName { get; set; }

    // With [ValidateObjectMembers], validation recurses into DatabaseOptions
    [ValidateObjectMembers]
    public DatabaseOptions Database { get; set; } = new();

    // With [ValidateEnumeratedItems], validation recurses into each ServerOptions in the list
    [ValidateEnumeratedItems]
    public List<ServerOptions> Servers { get; set; } = [];
}
// </ApplicationOptionsWithAttribute>
