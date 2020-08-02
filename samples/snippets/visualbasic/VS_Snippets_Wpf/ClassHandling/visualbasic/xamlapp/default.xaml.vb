Imports System.Collections
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace SDKSample
    Partial Public Class XAMLAPP
        Private Sub InstanceHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MessageBox.Show("This should never be invoked....")
        End Sub
    End Class
End Namespace
