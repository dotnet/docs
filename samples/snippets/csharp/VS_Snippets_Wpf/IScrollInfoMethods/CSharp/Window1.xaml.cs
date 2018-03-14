using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Text;

namespace ScrollViewer_Methods
{
    public partial class Window1 : Window
    {
        // <Snippet4>
        private void onLoad(object sender, System.EventArgs e)
        {
            ((IScrollInfo)sp1).CanVerticallyScroll = true;
            ((IScrollInfo)sp1).CanHorizontallyScroll = true;
            ((IScrollInfo)sp1).ScrollOwner = sv1;
        }
        //</Snippet4>

        // <Snippet3>
        private void spLineUp(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).LineUp();
        }
        private void spLineDown(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).LineDown();
        }
        //</Snippet3>

        // <Snippet5>
        private void spLineRight(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).LineRight();
        }
        //</Snippet5>

        // <Snippet6>
        private void spLineLeft(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).LineLeft();
        }
        //</Snippet6>

        // <Snippet7>
        private void spPageUp(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).PageUp();
        }
        //</Snippet7>

        // <Snippet8>
        private void spPageDown(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).PageDown();
        }
        //</Snippet8>

        // <Snippet9>
        private void spPageRight(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).PageRight();
        }
        //</Snippet9>

        // <Snippet10>
        private void spPageLeft(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).PageLeft();
        }
        //</Snippet10>

        // <Snippet11>
        private void spMouseWheelDown(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).MouseWheelDown();
        }
        //</Snippet11>

        // <Snippet12>
        private void spMouseWheelUp(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).MouseWheelUp();
        }
        //</Snippet12>

        // <Snippet13>
        private void spMouseWheelLeft(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).MouseWheelLeft();
        }
        //</Snippet13>

        // <Snippet14>
        private void spMouseWheelRight(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)sp1).MouseWheelRight();
        }
        //</Snippet14>
    }
}