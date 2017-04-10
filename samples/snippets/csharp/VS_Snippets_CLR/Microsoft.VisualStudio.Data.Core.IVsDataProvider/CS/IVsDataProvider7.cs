// <Snippet7>
using System;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services;

public class DDEX_IVsDataProviderExample7
{
    public static bool AllowDelete(IVsDataProvider provider,
        IVsDataExplorerNode node)
    {
        if (!provider.IsOperationSupported(StandardCommands.Delete, node))
        {
            MessageBox.Show(provider.GetUnsupportedReason(
                StandardCommands.Delete, node));
            return false;
        }
        return true;
    }
}
// </Snippet7>