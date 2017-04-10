// <Snippet2>
using System;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.Data.Core;

public class DDEX_IVsDataSourceExample2
{
    public static string GetSourceDisplayName(
        IServiceProvider serviceProvider,
        IVsDataSource dataSource)
    {
        string displayName = null;
        string resourceId = null;
        Guid provider = dataSource.DefaultProvider;
        if (provider != Guid.Empty)
        {
            resourceId = dataSource.GetProperty(provider, "DisplayName") as string;
        }
        if (resourceId == null)
        {
            foreach (Guid providerId in dataSource.GetProviders())
            {
                resourceId = dataSource.GetProperty(
                    providerId, "DisplayName") as string;
                if (resourceId != null)
                {
                    provider = providerId;
                    break;
                }
            }
        }
        if (provider != Guid.Empty && resourceId != null)
        {
            IVsDataProviderManager providerManager = serviceProvider.GetService(
                typeof(IVsDataProviderManager)) as IVsDataProviderManager;
            IVsDataProvider dataProvider = providerManager.Providers[provider];
            displayName = dataProvider.GetString(resourceId);
        }
        return displayName;
    }
}
// </Snippet2>