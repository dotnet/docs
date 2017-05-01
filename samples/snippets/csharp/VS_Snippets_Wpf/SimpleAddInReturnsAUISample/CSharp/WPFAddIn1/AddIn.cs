//<SnippetAddInCode>
using System.AddIn; // AddInAttribute
using System.Windows; // FrameworkElement

using AddInViews; // IWPFAddInView

namespace WPFAddIn1
{
    /// <summary>
    /// Add-In implementation
    /// </summary>
    [AddIn("WPF Add-In 1")]
    public class WPFAddIn : IWPFAddInView
    {
        public FrameworkElement GetAddInUI()
        {
            // Return add-in UI
            return new AddInUI();
        }
    }
}
//</SnippetAddInCode>