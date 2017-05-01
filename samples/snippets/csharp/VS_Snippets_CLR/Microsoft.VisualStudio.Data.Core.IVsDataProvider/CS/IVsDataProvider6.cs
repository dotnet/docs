// <Snippet6>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

public class DDEX_IVsDataProviderExample6
{
    public static IVsDataObjectSelector CreateObjectSelector(
        IVsDataProvider provider, string objectSelectorTypeName)
    {
        Type objectSelectorType = provider.GetType(objectSelectorTypeName);
        return Activator.CreateInstance(objectSelectorType)
            as IVsDataObjectSelector;
    }
}
// </Snippet6>