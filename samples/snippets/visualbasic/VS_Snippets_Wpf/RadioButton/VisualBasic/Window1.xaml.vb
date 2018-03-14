Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Collections.ObjectModel
Imports System.Collections.Generic


Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1_xaml.xaml
    '@ </summary>
    Partial Class Window1
        Inherits Window

        '<Snippet2>
        Private Sub WriteText(ByVal Sender As Object, ByVal e As RoutedEventArgs)
            rb.Content = "You followed directions."

        End Sub

        '</Snippet2>

        '<Snippet5> 
        Private Sub WriteText2(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            Dim li As RadioButton = CType(Sender, RadioButton)
            txtb.Text = "You clicked " + li.Content.ToString() + "."

        End Sub
        '</Snippet5>

    End Class


End Namespace
