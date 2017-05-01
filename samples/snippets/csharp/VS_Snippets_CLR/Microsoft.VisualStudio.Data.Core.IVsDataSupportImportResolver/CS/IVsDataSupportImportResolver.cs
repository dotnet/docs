// <Snippet1>
using System;
using System.IO;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

internal class MyObjectSupport
    : IVsDataObjectSupport, // inherits from IVsDataSupport
      IVsDataSupportImportResolver
{
    public Stream OpenSupportStream()
    {
        return GetType().Assembly.GetManifestResourceStream(
            "MyObjectSupport.xml");
    }

    public Stream ImportSupportStream(string name)
    {
        if (String.Equals(name, "MyObjectDefines"))
        {
            return GetType().Assembly.GetManifestResourceStream(
                "MyObjectDefines.xml");
        }
        return null;
    }
}
// </Snippet1>