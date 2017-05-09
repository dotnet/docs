// <Snippet1>
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Data.Core;

[DataClientObject("1520C77F-09AF-40b4-B1FE-53C30A177C59")]
public interface IVsDataSupportEntity
{
    void DoSomething();
}

[Guid("1520C77F-09AF-40b4-B1FE-53C30A177C59")]
internal class ClientSupportEntity : IVsDataSupportEntity,
    IVsDataClientObject<IVsDataSupportEntity>
{
    private IVsDataSupportEntity _providerObj;

    public void Initialize(IVsDataSupportEntity providerObj)
    {
        if (providerObj == null)
        {
            throw new ArgumentNullException("providerObj");
        }
        _providerObj = providerObj;
    }

    public void DoSomething()
    {
        Trace.WriteLine("DoSomething started.");
        _providerObj.DoSomething();
        Trace.WriteLine("DoSomething finished.");
    }
}
// </Snippet1>