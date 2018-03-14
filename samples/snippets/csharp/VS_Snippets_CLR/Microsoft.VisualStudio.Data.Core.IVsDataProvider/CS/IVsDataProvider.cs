// <Snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

public class DDEX_IVsDataProviderExample1
{
    public static void UseDataProvider(
        IServiceProvider serviceProvider,
        Guid providerGuid)
    {
        IVsDataProviderManager providerManager =
            serviceProvider.GetService(typeof(IVsDataProviderManager))
                as IVsDataProviderManager;
        IVsDataProvider provider = providerManager.Providers[providerGuid];
        Trace.WriteLine(provider.DisplayName);
        Trace.WriteLine(provider.Description);
        IVsDataConnectionProperties connectionProperties =
            provider.CreateObject<IVsDataConnectionProperties>();
        connectionProperties.Parse("Test connection string");
    }
}
// </Snippet1>