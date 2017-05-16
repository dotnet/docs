// <Snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Data.Core;

public class DDEX_IVsDataSourceManagerExample1
{
    public static void EnumerateDataSources(IServiceProvider serviceProvider)
    {
        IVsDataSourceManager sourceManager =
            serviceProvider.GetService(typeof(IVsDataSourceManager))
                as IVsDataSourceManager;
        foreach (IVsDataSource source in sourceManager.Sources.Values)
        {
            Trace.WriteLine(source.DisplayName);
        }
    }
}
// </Snippet1>