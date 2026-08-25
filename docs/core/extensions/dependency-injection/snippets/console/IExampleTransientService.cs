using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDI.Example;

public interface IExampleTransientService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
}
