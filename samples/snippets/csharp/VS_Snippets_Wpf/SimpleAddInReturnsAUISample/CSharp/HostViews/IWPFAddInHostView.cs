//<SnippetHostViewCode>
using System.Windows; // FrameworkElement

namespace HostViews
{
    /// <summary>
    /// Defines the host's view of the add-in
    /// </summary>
    public interface IWPFAddInHostView
    {
        // The view returns as a class that directly or indirectly derives from 
        // FrameworkElement and can subsequently be displayed by the host 
        // application by embedding it as content or sub-content of a UI that is 
        // implemented by the host application.
        FrameworkElement GetAddInUI();
    }
}
//</SnippetHostViewCode>