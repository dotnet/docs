// <Snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Data.Core;

public class DDEX_IVsDataSourceExample1
{
    public static void OutputDataSource(
        IServiceProvider serviceProvider,
        Guid dataSourceGuid)
    {
        IVsDataSourceManager sourceManager =
            serviceProvider.GetService(typeof(IVsDataSourceManager))
                as IVsDataSourceManager;
        IVsDataSource source = sourceManager.Sources[dataSourceGuid];
        Trace.WriteLine(source.DisplayName);
        Trace.WriteLine(source.Description);
        IVsDataProviderManager providerManager =
            serviceProvider.GetService(typeof(IVsDataProviderManager))
                as IVsDataProviderManager;
        foreach (Guid providerGuid in source.GetProviders())
        {
            IVsDataProvider provider = providerManager.Providers[providerGuid];
            Trace.WriteLine(provider.Name);
        }
    }
}
// </Snippet1>