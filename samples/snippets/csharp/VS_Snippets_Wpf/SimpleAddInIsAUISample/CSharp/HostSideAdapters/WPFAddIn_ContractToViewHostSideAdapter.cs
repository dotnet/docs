//<SnippetHostSideAdapterCode>
using System.AddIn.Contract; // INativeHandleContract
using System.AddIn.Pipeline; // HostAdapterAttribute, FrameworkElementAdapters, ContractHandle
using System.Windows; // FrameworkElement

using Contracts; // IWPFAddInContract
using HostViews; // WPFAddInHostView

namespace HostSideAdapters
{
    /// <summary>
    /// Adapts the add-in contract to the host's view of the add-in
    /// </summary>
    [HostAdapter]
    public class WPFAddIn_ContractToViewHostSideAdapter : WPFAddInHostView
    {
        IWPFAddInContract wpfAddInContract;
        ContractHandle wpfAddInContractHandle;

        public WPFAddIn_ContractToViewHostSideAdapter(IWPFAddInContract wpfAddInContract)
        {
            // Adapt the contract (IWPFAddInContract) to the host application's
            // view of the contract (WPFAddInHostView)
            this.wpfAddInContract = wpfAddInContract;

            // Prevent the reference to the contract from being released while the
            // host application uses the add-in
            this.wpfAddInContractHandle = new ContractHandle(wpfAddInContract);

            // Convert the INativeHandleContract for the add-in UI that was passed 
            // from the add-in side of the isolation boundary to a FrameworkElement
            string aqn = typeof(INativeHandleContract).AssemblyQualifiedName;
            INativeHandleContract inhc = (INativeHandleContract)wpfAddInContract.QueryContract(aqn);
            FrameworkElement fe = (FrameworkElement)FrameworkElementAdapters.ContractToViewAdapter(inhc);

            // Add FrameworkElement (which displays the UI provided by the add-in) as
            // content of the view (a UserControl)
            this.Content = fe;
        }
    }
}
//</SnippetHostSideAdapterCode>