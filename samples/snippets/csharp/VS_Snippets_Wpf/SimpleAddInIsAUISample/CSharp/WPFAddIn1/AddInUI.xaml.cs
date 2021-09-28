﻿//<SnippetAddInCodeBehind>
using System.AddIn;
using System.Windows;

using AddInViews;

namespace WPFAddIn1
{
    /// <summary>
    /// Implements the add-in by deriving from WPFAddInView
    /// </summary>
    [AddIn("WPF Add-In 1")]
    public partial class AddInUI : WPFAddInView
    {
        public AddInUI()
        {
            InitializeComponent();
        }

        void clickMeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello from WPFAddIn1");
        }
    }
}
//</SnippetAddInCodeBehind>