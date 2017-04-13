// <Snippet10>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

public class DDEX_IVsDataProviderExample10
{
    public static IVsDataConnectionProperties CreateConnectionProperties(
        IVsDataProvider provider)
    {
        return provider.TryCreateObject<IVsDataConnectionProperties>();
    }
}
// </Snippet10>