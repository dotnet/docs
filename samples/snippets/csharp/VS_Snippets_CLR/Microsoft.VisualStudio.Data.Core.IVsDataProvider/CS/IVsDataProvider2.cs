// <Snippet2>
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Data.Core;

public class DDEX_IVsDataProviderExample2
{
    private static readonly Guid MSSqlServerDataSource =
        new Guid("067EA0D9-BA62-43f7-9106-34930C60C528");
    private static readonly Guid MSAccessDBFileDataSource =
        new Guid("466CE797-67A4-4495-B75C-A3FD282E7FC3");

    public static void Example(
        IVsDataProvider provider)
    {
        Guid source1 = provider.DeriveSource("Provider=SQLOLEDB.1");
        Trace.WriteLine(source1); // MSSqlServerDataSource
        Guid source2 = provider.DeriveSource(
            "Provider=Microsoft.Jet.OLEDB.4.0");
        Trace.WriteLine(source2); // MSAccessDBFileDataSource
    }
}
// </Snippet2>