using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDI.Example;

public interface IExampleSingletonService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
}
