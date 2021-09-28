using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SDKSample
{
//<SnippetDPDeclarationCODE>
public partial class RetainedStateDPPage : System.Windows.Controls.Page
{
    // Journalable dependency property
    public static readonly DependencyProperty RetainedStateDP;

    static RetainedStateDPPage()
    {
        // Register the local property with the journalable dependency property
        RetainedStateDPPage.RetainedStateDP =
            DependencyProperty.Register(
                "RetainedState",
                typeof(string),
                typeof(RetainedStateDPPage),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.Journal));
    }

    public RetainedStateDPPage()
    {
        InitializeComponent();
    }

    // Property to register with the journalable dependency property
    public string RetainedState
    {
        get
        {
            return (string)base.GetValue(RetainedStateDPPage.RetainedStateDP);
        }
        set
        {
            base.SetValue(RetainedStateDPPage.RetainedStateDP, value);
        }
    }
}
    //</SnippetDPDeclarationCODE>
}