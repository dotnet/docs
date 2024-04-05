using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

[OptionsValidator]
public partial class ValidateSettingsOptions : IValidateOptions<SettingsOptions>
{
}
