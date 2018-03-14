'This is a list of commonly used namespaces for a pane.
Imports System
Imports System.Windows
Imports System.Windows.Controls

'@ <summary>
'@ Interaction logic for Page1.xaml
'@ </summary>



Partial Public Class Page1
    Inherits Canvas

    '<Snippet4>
    Private Sub OnClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (contCtrl.HasContent = True) Then
            MessageBox.Show("contCtrl has content")
        End If

    End Sub
    '</Snippet4>
End Class

