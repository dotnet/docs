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
        Dim button As Button
        Dim tt As ToolTip

        Private Sub OnClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)
            '<Snippet2>
            button = New Button()
            button.Content = "Hover over me."
            tt = New ToolTip()
            tt.Content = "Created with Visual Basic"
            button.ToolTip = tt
            cv2.Children.Add(button)
            '</Snippet2>
        End Sub

    End Class





End Namespace
