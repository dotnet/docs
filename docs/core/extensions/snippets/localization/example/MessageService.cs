using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Localization;

namespace Localization.Example;

public class MessageService
{
    private readonly IStringLocalizer<MessageService> _localizer = null!;

    public MessageService(IStringLocalizer<MessageService> localizer) =>
        _localizer = localizer;

    [return: NotNullIfNotNull("_localizer")]
    public string? GetGreetingMessage()
    {
        LocalizedString localizedString = _localizer["GreetingMessage"];
        return localizedString;
    }
}
