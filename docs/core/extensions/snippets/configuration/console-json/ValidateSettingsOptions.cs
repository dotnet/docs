using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

sealed partial class ValidateSettingsOptions(
    IConfiguration config)
    : IValidateOptions<SettingsOptions>
{
    public SettingsOptions? Settings { get; private set; } =
        config.GetSection(SettingsOptions.ConfigurationSectionName)
              .Get<SettingsOptions>();

    public ValidateOptionsResult Validate(string? name, SettingsOptions options)
    {
        StringBuilder? failure = null;
    
        if (!ValidationRegex().IsMatch(options.SiteTitle))
        {
            (failure ??= new()).AppendLine($"{options.SiteTitle} doesn't match RegEx");
        }

        if (options.Scale is < 0 or > 1_000)
        {
            (failure ??= new()).AppendLine($"{options.Scale} isn't within Range 0 - 1000");
        }

        if (Settings is { Scale: 0 } && Settings.VerbosityLevel <= Settings.Scale)
        {
            (failure ??= new()).AppendLine("VerbosityLevel must be > than Scale.");
        }

        return failure is not null
            ? ValidateOptionsResult.Fail(failure.ToString())
            : ValidateOptionsResult.Success;
    }

    [GeneratedRegex("^[a-zA-Z''-'\\s]{1,40}$")]
    private static partial Regex ValidationRegex();
}
