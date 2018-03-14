// <Snippet2>
using System;
using System.Threading;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Shell.Interop;

public class DdexHostSvcExample2
{
    public static void UpdateUI(IVsDataHostService hostService)
    {
        if (Thread.CurrentThread == hostService.UIThread)
        {
            // Called on UI thread, directly call method
            ActuallyUpdateUI(hostService);
        }
        else
        {
            // Called from background thread, begin invoke on UI thread
            hostService.BeginInvokeOnUIThread(
                new UpdateUIDelegate(ActuallyUpdateUI),
                hostService);
        }
    }

    private delegate void UpdateUIDelegate(IVsDataHostService hostService);

    private static void ActuallyUpdateUI(IVsDataHostService hostService)
    {
        IVsUIShell uiShell = hostService.GetService<IVsUIShell>();
        uiShell.UpdateCommandUI(0); // fImmediateUpdate == false
    }
}
// </Snippet2>
