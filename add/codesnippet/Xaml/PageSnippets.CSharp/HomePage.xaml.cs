//<SnippetSetPageWindowXxxCODEBEHIND>
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

            this.WindowTitle = "Hello, Page!";
            this.WindowWidth = 500;
            this.WindowHeight = 300;
        }

    }
}
//</SnippetSetPageWindowXxxCODEBEHIND>