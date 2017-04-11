// <Snippet5>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Shell.Interop;

public class DdexHostSvcExample5
{
    private static readonly Guid SID_IVsUIShell =
        new Guid("B61FC35B-EEBF-4dec-BFF1-28A2DD43C38F");

    public static IVsUIShell GetIVsUIShell(IVsDataHostService hostService)
    {
        return hostService.GetService<IVsUIShell>(SID_IVsUIShell);
    }
}
// </Snippet5>