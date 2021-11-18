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
        string result = "";
        var rx = new Regex(@"^[a-zA-Z''-'\s]{1,40}$");
        Match match = rx.Match(options.SiteTitle);
        if (string.IsNullOrEmpty(match.Value))
        {
            result += $"{options.SiteTitle} doesn't match RegEx\n";
        }

        if (options.Scale < 0 || options.Scale > 1000)
        {
            result += $"{options.Scale} isn't within Range 0 - 1000\n";
        }

        if (_settings.Scale is 0 && _settings.VerbosityLevel <= _settings.Scale)
        {
            result += "VerbosityLevel must be > than Scale.";
        }

        return result != null
            ? ValidateOptionsResult.Fail(result)
            : ValidateOptionsResult.Success;
    }
}
