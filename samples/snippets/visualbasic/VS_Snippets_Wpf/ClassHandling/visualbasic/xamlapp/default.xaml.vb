Imports System.Windows
Imports System.Collections
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Text

Namespace SDKSample
    Partial Public Class XAMLAPP
        Private Sub InstanceHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MessageBox.Show("This should never be invoked....")
        End Sub
    End Class
End Namespace
