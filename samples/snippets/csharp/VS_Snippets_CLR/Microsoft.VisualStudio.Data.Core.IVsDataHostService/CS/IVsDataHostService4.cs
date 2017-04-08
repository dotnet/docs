// <Snippet4>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Shell.Interop;

public class DdexHostSvcExample4
{
    public static IVsUIShell GetIVsUIShell(IVsDataHostService hostService)
    {
        return hostService.GetService<IVsUIShell>();
    }
}
// </Snippet4>