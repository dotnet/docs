// <Snippet10>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Shell.Interop;

public class DdexHostSvcExample10
{
    public static IVsUIShell GetIVsUIShell(IVsDataHostService hostService)
    {
        return hostService.TryGetService<SVsUIShell, IVsUIShell>();
    }
}
// </Snippet10>