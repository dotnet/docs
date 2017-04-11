// <Snippet3>
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Data.Core;

public class DDEX_IVsDataSourceExample3
{
    public static void OutputSupportingProviders(
        IServiceProvider serviceProvider,
        IVsDataSource dataSource)
    {
        IVsDataProviderManager providerManager =
            serviceProvider.GetService(typeof(IVsDataProviderManager))
                as IVsDataProviderManager;
        foreach (Guid providerGuid in dataSource.GetProviders())
        {
            IVsDataProvider provider = providerManager.Providers[providerGuid];
            Trace.WriteLine(provider.Name);
        }
    }
}
// </Snippet3>