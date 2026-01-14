using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace RecursiveValidation.Example;

// <ApplicationOptionsWithAttribute>
public sealed class ApplicationOptionsWithAttribute
{
    public const string ConfigurationSectionName = "ApplicationWithAttribute";

    [Required]
    public required string ApplicationName { get; set; }

    // Validation recurses into DatabaseOptions.
    [ValidateObjectMembers]
    public DatabaseOptions Database { get; set; } = new();

    // Validation recurses into each ServerOptions in the list.
    [ValidateEnumeratedItems]
    public List<ServerOptions> Servers { get; set; } = [];
}
// </ApplicationOptionsWithAttribute>
