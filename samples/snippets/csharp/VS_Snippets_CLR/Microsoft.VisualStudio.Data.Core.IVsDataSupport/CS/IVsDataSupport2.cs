// <Snippet2>
using System;
using System.IO;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

internal class MyViewSupport
    : IVsDataViewSupport // inherits from IVsDataSupport
{
    public Stream OpenSupportStream()
    {
        return GetType().Assembly.GetManifestResourceStream(
            "MyViewSupport.xml");
    }

    public void Close()
    {
    }

    public void Initialize()
    {
    }
}
// </Snippet2>