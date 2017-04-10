// <Snippet4>
using System;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.Data.Core;

public class DDEX_IVsDataProviderExample4
{
    public static DbConnection CreateAdoDotNetConnection(
        IVsDataProvider provider)
    {
        string invariantName = provider.GetProperty("InvariantName") as string;
        if (invariantName != null)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(
                invariantName);
            if (factory != null)
            {
                return factory.CreateConnection();
            }
        }
        return null;
    }
}
// </Snippet4>