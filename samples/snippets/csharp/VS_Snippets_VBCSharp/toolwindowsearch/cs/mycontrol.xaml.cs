using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Walkthrough: Adding Search to a Tool Window
// f78c4892-8060-49c4-8ecd-4360f1b4d133


namespace Microsoft.TestToolWindowSearch
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    //<Snippet1>
    public partial class MyControl : UserControl
    {
        public TextBox SearchResultsTextBox { get; set; }
        public string SearchContent { get; set; }

        public MyControl()
        {
            InitializeComponent();

            this.SearchResultsTextBox = resultsTextBox;
            this.SearchContent = BuildContent();

            this.SearchResultsTextBox.Text = this.SearchContent;
        }

        private string BuildContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1 go");
            sb.AppendLine("2 good");
            sb.AppendLine("3 Go");
            sb.AppendLine("4 Good");
            sb.AppendLine("5 goodbye");
            sb.AppendLine("6 Goodbye");

            return sb.ToString();
        }
    }
    //</Snippet1>
}