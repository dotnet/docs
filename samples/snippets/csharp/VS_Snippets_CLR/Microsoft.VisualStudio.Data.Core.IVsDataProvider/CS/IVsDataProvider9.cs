// <Snippet9>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

public class DDEX_IVsDataProviderExample9
{
    public static bool HasSpecialConnectForUI(
        IVsDataProvider provider, Guid source)
    {
        return provider.SupportsObject(
            source, typeof(IVsDataConnectionUIConnector));
    }
}
// </Snippet9>