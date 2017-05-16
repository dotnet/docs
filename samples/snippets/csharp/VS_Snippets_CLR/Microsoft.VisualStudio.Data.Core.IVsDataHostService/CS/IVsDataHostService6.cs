// <Snippet6>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Shell.Interop;

public class DdexHostSvcExample6
{
    public static IVsUIShell GetIVsUIShell(IVsDataHostService hostService)
    {
        return hostService.GetService<SVsUIShell, IVsUIShell>();
    }
}
// </Snippet6>