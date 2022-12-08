using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Localization;

namespace Localization.Example;

public sealed class MessageService
{
    private readonly IStringLocalizer<MessageService> _localizer = null!;

    public MessageService(IStringLocalizer<MessageService> localizer) =>
        _localizer = localizer;

    [return: NotNullIfNotNull(nameof(_localizer))]
    public string? GetGreetingMessage()
    {
        LocalizedString localizedString = _localizer["GreetingMessage"];
        return localizedString;
    }
}
