using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

class ValidateSettingsOptions : IValidateOptions<SettingsOptions>
{
    public SettingsOptions _settings { get; private set; }

    public ValidateSettingsOptions(IConfiguration config) =>
        _settings = config.GetSection(SettingsOptions.ConfigurationSectionName)
                          .Get<SettingsOptions>();

    public ValidateOptionsResult Validate(string name, SettingsOptions options)
    {
        StringBuilder failure = new();
        var rx = new Regex(@"^[a-zA-Z''-'\s]{1,40}$");
        Match match = rx.Match(options.SiteTitle);
        if (string.IsNullOrEmpty(match.Value))
        {
            failure.AppendLine($"{options.SiteTitle} doesn't match RegEx");
        }

        if (options.Scale < 0 || options.Scale > 1000)
        {
            failure.AppendLine($"{options.Scale} isn't within Range 0 - 1000");
        }

        if (_settings.Scale is 0 && _settings.VerbosityLevel <= _settings.Scale)
        {
            failure.AppendLine("VerbosityLevel must be > than Scale.");
        }

        return failure.Length > 0
            ? ValidateOptionsResult.Fail(failure.ToString())
            : ValidateOptionsResult.Success;
    }
}
