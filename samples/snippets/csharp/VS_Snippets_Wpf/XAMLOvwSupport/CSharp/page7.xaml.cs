using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.IO;
using System.Collections;

//<SnippetNameScopeCode>
namespace MyNamespace
{
    public partial class MyCode : Page
    {
        //<SnippetNameCode>
        void RemoveThis(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            if (buttonContainer.Children.Contains(fe))
            {
                buttonContainer.Children.Remove(fe);
            }
        }
        //</SnippetNameCode>
    }
}

//</SnippetNameScopeCode>
