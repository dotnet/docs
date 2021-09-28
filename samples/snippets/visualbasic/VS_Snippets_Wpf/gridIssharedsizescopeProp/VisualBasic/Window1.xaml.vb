Imports System     
Imports System.Windows     
Imports System.Windows.Controls     

namespace grid_issharedsizescope_prop

	'@ <summary>
	'@ Interaction logic for Window1.xaml
	'@ </summary>

    Partial Public Class Window1
        Inherits Window

        ' <Snippet3>
        Private Sub setTrue(ByVal sender As Object, ByVal args As RoutedEventArgs)

            Grid.SetIsSharedSizeScope(dp1, True)
            txt1.Text = "IsSharedSizeScope Property is set to " + Grid.GetIsSharedSizeScope(dp1).ToString()
        End Sub

        Private Sub setFalse(ByVal sender As Object, ByVal args As RoutedEventArgs)

            Grid.SetIsSharedSizeScope(dp1, False)
            txt1.Text = "IsSharedSizeScope Property is set to " + Grid.GetIsSharedSizeScope(dp1).ToString()
        End Sub
        ' </Snippet3>        
    End Class
    End Namespace
