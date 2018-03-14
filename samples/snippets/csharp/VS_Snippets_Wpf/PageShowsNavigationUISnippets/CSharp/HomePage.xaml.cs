//<SnippetSetPageShowsNavigationUICODEBEHIND>
using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharp
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            // Hide host's navigation UI
            this.ShowsNavigationUI = false;
        }
    }
}
//</SnippetSetPageShowsNavigationUICODEBEHIND>