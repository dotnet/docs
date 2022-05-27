using System.ComponentModel.DataAnnotations;

namespace ConsoleJson.Example;

public class SettingsOptions
{
    public const string ConfigurationSectionName = "MyCustomSettingsSection";

    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
    public string SiteTitle { get; set; } = null!;

    [Range(0, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Scale { get; set; }

    public int VerbosityLevel { get; set; }
}
