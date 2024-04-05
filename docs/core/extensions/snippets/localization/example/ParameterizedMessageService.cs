using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Localization;

namespace Localization.Example;

public class ParameterizedMessageService(IStringLocalizerFactory factory)
{
    private readonly IStringLocalizer _localizer =
        factory.Create(typeof(ParameterizedMessageService));

    [return: NotNullIfNotNull(nameof(_localizer))]
    public string? GetFormattedMessage(DateTime dateTime, double dinnerPrice)
    {
        LocalizedString localizedString = _localizer["DinnerPriceFormat", dateTime, dinnerPrice];

        return localizedString;
    }
}
