// <Snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Shell.Interop;

public class DdexHostSvcExample1
{
    public static IVsUIShell GetIVsUIShell(IServiceProvider serviceProvider)
    {
        IVsDataHostService hostService = serviceProvider.GetService(
            typeof(IVsDataHostService)) as IVsDataHostService;
        return hostService.GetService<IVsUIShell>();
    }
}
// </Snippet1>
