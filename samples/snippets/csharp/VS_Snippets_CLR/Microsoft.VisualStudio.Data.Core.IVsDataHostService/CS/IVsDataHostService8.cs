// <Snippet8>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Shell.Interop;

public class DdexHostSvcExample8
{
    public static IVsUIShell GetIVsUIShell(IVsDataHostService hostService)
    {
        return hostService.TryGetService<IVsUIShell>();
    }
}
// </Snippet8>