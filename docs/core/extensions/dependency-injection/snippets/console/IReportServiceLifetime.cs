using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDI.Example;

public interface IReportServiceLifetime
{
    Guid Id { get; }

    ServiceLifetime Lifetime { get; }
}
