Imports System     
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     

namespace ScrollChangedEventArgs_layout

	'@ <summary>
	'@ Interaction logic for Window1.xaml
	'@ </summary>

    Partial Public Class Window1
        Inherits Window
        
        ' <Snippet4>
        Private Sub scrollTrue(ByVal sender As Object, ByVal args As RoutedEventArgs)
            sv1.CanContentScroll = True
            sv1.Height = 600
            myStackPanel.Visibility = Visibility.Visible
            btn1.Visibility = Visibility.Collapsed
        End Sub
        ' </Snippet4>

        ' <Snippet3>
        Private Sub sChanged(ByVal sender As Object, ByVal args As ScrollChangedEventArgs)


            If (sv1.CanContentScroll = True) Then
                tBlock1.Foreground = System.Windows.Media.Brushes.Red
                tBlock1.Text = "ScrollChangedEvent just Occurred"
                tBlock3.Text = "ExtentWidth is now " + args.ExtentWidth.ToString()
                tBlock4.Text = "ExtentHeightChange was " + args.ExtentHeightChange.ToString()
                tBlock5.Text = "ExtentWidthChange was " + args.ExtentWidthChange.ToString()
                tBlock6.Text = "HorizontalOffset is now " + args.HorizontalOffset.ToString()
                tBlock7.Text = "VerticalOffset is now " + args.VerticalOffset.ToString()
                tBlock8.Text = "HorizontalChange was " + args.HorizontalChange.ToString()
                tBlock9.Text = "VerticalChange was " + args.VerticalChange.ToString()
                tBlock10.Text = "ViewportHeight is now " + args.ViewportHeight.ToString()
                tBlock11.Text = "ViewportWidth is now " + args.ViewportWidth.ToString()
                tBlock12.Text = "ViewportHeightChange was " + args.ViewportHeightChange.ToString()
                tBlock13.Text = "ViewportWidthChange was " + args.ViewportWidthChange.ToString()

            Else
                tBlock1.Text = ""

            End If
            ' </Snippet3>
        End Sub
    End Class
    End Namespace
