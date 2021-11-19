using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsoleJson.Example;

public class ValidationService
{
    private readonly ILogger<ValidationService> _logger;
    private readonly IOptions<SettingsOptions> _config;

    public ValidationService(
        ILogger<ValidationService> logger,
        IOptions<SettingsOptions> config)
    {
        _config = config;
        _logger = logger;

        try
        {
            SettingsOptions options = _config.Value;
        }
        catch (OptionsValidationException ex)
        {
            foreach (string failure in ex.Failures)
            {
                _logger.LogError(failure);
            }
        }
    }
}
