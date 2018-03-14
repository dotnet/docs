// <Snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Data.Core;

public class DDEX_IVsDataProviderExample1
{
    public static void EnumerateProviders(IServiceProvider serviceProvider)
    {
        IVsDataProviderManager providerManager =
            serviceProvider.GetService(typeof(IVsDataProviderManager))
                as IVsDataProviderManager;
        foreach (IVsDataProvider provider in providerManager.Providers.Values)
        {
            Trace.WriteLine(provider.Name);
        }
    }
}
// </Snippet1>