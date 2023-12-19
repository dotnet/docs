using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Localization;

namespace Localization.Example;

public sealed class MessageService(IStringLocalizer<MessageService> _localizer)
{
    [return: NotNullIfNotNull(nameof(_localizer))]
    public string? GetGreetingMessage()
    {
        LocalizedString localizedString = _localizer["GreetingMessage"];
        return localizedString;
    }
}
