using System;
using System.Windows;
using System.Windows.Documents;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
         private void WindowLoaded(object sender, EventArgs e)
         {
             SetMarkerStyle01();
         }

        // Use the default font values for the strikethrough text decoration.
        private void SetMarkerStyle01()
        {
            // <SnippetTextMarkerStyleSnippet1>
            List list = new List();
            list.MarkerStyle = TextMarkerStyle.Box;
            // </SnippetTextMarkerStyleSnippet1>
        }

    }
}