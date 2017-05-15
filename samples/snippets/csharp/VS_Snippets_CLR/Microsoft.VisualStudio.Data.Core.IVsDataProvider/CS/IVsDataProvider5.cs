// <Snippet5>
using System;
using Microsoft.VisualStudio.Data.Core;

public class DDEX_IVsDataProviderExample5
{
    public static string GetDisplayName(
        IVsDataProvider provider)
    {
        string displayName = String.Empty;
        string resourceId = provider.GetProperty("DisplayName") as string;
        if (resourceId != null)
        {
            displayName = provider.GetString(resourceId);
        }
        return displayName;
    }
}
// </Snippet5>