//<SnippetSetPageKeepAliveCODEBEHIND>
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

            // Keep this page in navigation history
            this.KeepAlive = true;
        }

    }
}
//</SnippetSetPageKeepAliveCODEBEHIND>