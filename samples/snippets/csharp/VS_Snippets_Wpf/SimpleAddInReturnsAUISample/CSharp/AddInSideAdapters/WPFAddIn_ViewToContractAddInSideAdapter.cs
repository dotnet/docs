//<SnippetAddInSideAdapterCode>
using System.AddIn.Contract; // INativeHandleContract
using System.AddIn.Pipeline; // AddInAdapterAttribute, FrameworkElementAdapters, ContractBase
using System.Windows; // FrameworkElement

using AddInViews; // IWPFAddInView
using Contracts; // IWPFAddInContract

namespace AddInSideAdapters
{
    /// <summary>
    /// Adapts the add-in's view of the contract to the add-in contract
    /// </summary>
    [AddInAdapter]
    public class WPFAddIn_ViewToContractAddInSideAdapter : ContractBase, IWPFAddInContract
    {
        IWPFAddInView wpfAddInView;

        public WPFAddIn_ViewToContractAddInSideAdapter(IWPFAddInView wpfAddInView)
        {
            // Adapt the add-in view of the contract (IWPFAddInView) 
            // to the contract (IWPFAddInContract)
            this.wpfAddInView = wpfAddInView;
        }

        public INativeHandleContract GetAddInUI()
        {
            // Convert the FrameworkElement from the add-in to an INativeHandleContract 
            // that will be passed across the isolation boundary to the host application.
            FrameworkElement fe = this.wpfAddInView.GetAddInUI();
            INativeHandleContract inhc = FrameworkElementAdapters.ViewToContractAdapter(fe);
            return inhc;
        }
    }
}
//</SnippetAddInSideAdapterCode>