using System.ComponentModel.DataAnnotations;

namespace ConsoleJson.Example;

public sealed class SettingsOptions
{
    public const string ConfigurationSectionName = "MyCustomSettingsSection";

    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
    public required string SiteTitle { get; set; } = null!;

    [Range(0, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public required int Scale { get; set; }

    public required int VerbosityLevel { get; set; }
}
