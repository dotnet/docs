using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Localization;

namespace Localization.Example;

public class ParameterizedMessageService
{
    private readonly IStringLocalizer _localizer = null!;

    public ParameterizedMessageService(IStringLocalizerFactory factory) =>
        _localizer = factory.Create(typeof(ParameterizedMessageService));

    [return: NotNullIfNotNull("_localizer")]
    public string? GetFormattedMessage(DateTime dateTime, double dinnerPrice)
    {
        LocalizedString localizedString = _localizer["DinnerPriceFormat", dateTime, dinnerPrice];
        return localizedString;
    }
}
