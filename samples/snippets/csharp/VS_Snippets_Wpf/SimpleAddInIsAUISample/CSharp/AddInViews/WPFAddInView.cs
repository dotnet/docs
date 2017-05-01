//<SnippetAddInViewCode>
using System.AddIn.Pipeline; // AddInBaseAttribute
using System.Windows.Controls; // UserControl

namespace AddInViews
{
    /// <summary>
    /// Defines the add-in's view of the contract.
    /// </summary>
    [AddInBase]
    public class WPFAddInView : UserControl { }
}
//</SnippetAddInViewCode>