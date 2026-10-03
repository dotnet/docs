using Orleans;
using Orleans.Serialization.Activators;
using Microsoft.Extensions.Logging;

namespace CustomActivators;

// <DiType>
[GenerateSerializer]
[UseActivator]
public class AuditEntry
{
    [NonSerialized]
    private readonly ILogger<AuditEntry> _logger;

    [Id(0)]
    public string? Action { get; set; }

    [Id(1)]
    public DateTime Timestamp { get; set; }

    public AuditEntry(ILogger<AuditEntry> logger)
    {
        _logger = logger;
    }

    public void Log() =>
        _logger.LogInformation(
            "Audit: {Action} at {Timestamp}", Action, Timestamp);
}
// </DiType>

// <DiActivator>
[RegisterActivator]
public class AuditEntryActivator : IActivator<AuditEntry>
{
    private readonly ILogger<AuditEntry> _logger;

    public AuditEntryActivator(ILogger<AuditEntry> logger)
    {
        _logger = logger;
    }

    public AuditEntry Create() => new AuditEntry(_logger);
}
// </DiActivator>
