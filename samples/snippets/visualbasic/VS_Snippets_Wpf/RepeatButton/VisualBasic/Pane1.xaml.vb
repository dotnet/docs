Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data

Namespace RepeatButton_vb

    '@ <summary>
    '@ Interaction logic for Pane1_xaml.xaml
    '@ </summary>
    Partial Class Pane1
        Dim Num As Integer
        '<Snippet2>
        Private Sub Increase(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Num = CInt(valueText.Text)

            valueText.Text = ((Num + 1).ToString())
        End Sub

        Private Sub Decrease(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Num = CInt(valueText.Text)

            valueText.Text = ((Num - 1).ToString())
        End Sub
        '</Snippet2>
    End Class
End Namespace