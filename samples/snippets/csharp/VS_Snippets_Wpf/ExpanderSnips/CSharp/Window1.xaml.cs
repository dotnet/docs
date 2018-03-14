using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace ExpanderSnips
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void InitializeExpander(object sender, EventArgs e)
        {
        //<SnippetCollapsed>
         myExpander.Collapsed += new RoutedEventHandler(expanderHasCollapsed);            
        //</SnippetCollapsed>

         //<SnippetExpanded>
         yourExpander.Expanded += new RoutedEventHandler(expanderHasExpanded);
         //</SnippetExpanded>

         //<SnippetExpandDirection>
         myExpanderOpensUp.ExpandDirection = ExpandDirection.Up;
         //</SnippetExpandDirection>


         //<SnippetIsExpanded>
         myExpanderIsExpanded.IsExpanded = true;
         //</SnippetIsExpanded>
     }
        //<SnippetCollapsedHandler>
        private void expanderHasCollapsed(object sender, RoutedEventArgs args)
        {
            //Do something when the Expander control collapses
        }
        //</SnippetCollapsedHandler>

        //<SnippetExpandedHandler>
        private void expanderHasExpanded(object sender, RoutedEventArgs args)
        {
            //Do something when the Expander control expands
        }
        //</SnippetExpandedHandler>
    }
}