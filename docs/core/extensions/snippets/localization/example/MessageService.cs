using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Localization;

namespace Localization.Example;

public sealed class MessageService(IStringLocalizer<MessageService> localizer)
{
    [return: NotNullIfNotNull(nameof(localizer))]
    public string? GetGreetingMessage()
    {
        LocalizedString localizedString = localizer["GreetingMessage"];

        return localizedString;
    }
}
