// <Snippet1>
using System;
using System.IO;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

internal class MyObjectSupport
    : IVsDataObjectSupport // inherits from IVsDataSupport
{
    public Stream OpenSupportStream()
    {
        return GetType().Assembly.GetManifestResourceStream(
            "MyObjectSupport.xml");
    }
}
// </Snippet1>