// <Snippet3>
using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

public class DDEX_IVsDataProviderExample3
{
    public static Stream GetProviderString(IVsDataProvider provider,
        string resourceName, string assemblyString)
    {
        Assembly assembly = provider.GetAssembly(assemblyString);
        return assembly.GetManifestResourceStream(resourceName);
    }
}
// </Snippet3>