Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     

Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1.xaml
    '@ </summary>

    Partial Public Class Window1
        Inherits Window

        '<Snippet2>
        Private Sub changeOrientation(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)
            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            If (li.Content.ToString() = "Horizontal") Then
                sp1.Orientation = System.Windows.Controls.Orientation.Horizontal
            ElseIf li.Content.ToString() = "Vertical" Then
                sp1.Orientation = System.Windows.Controls.Orientation.Vertical
            End If
        End Sub
        Private Sub changeHorAlign(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)
            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            If (li.Content.ToString() = "Left") Then
                sp1.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            ElseIf (li.Content.ToString() = "Right") Then
                sp1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right
            ElseIf (li.Content.ToString() = "Center") Then
                sp1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            ElseIf (li.Content.ToString() = "Stretch") Then
                sp1.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch
            End If
        End Sub
        Private Sub changeVertAlign(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)
            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            If (li.Content.ToString() = "Top") Then
                sp1.VerticalAlignment = System.Windows.VerticalAlignment.Top
            ElseIf (li.Content.ToString() = "Bottom") Then
                sp1.VerticalAlignment = System.Windows.VerticalAlignment.Bottom
            ElseIf (li.Content.ToString() = "Center") Then
                sp1.VerticalAlignment = System.Windows.VerticalAlignment.Center
            ElseIf (li.Content.ToString() = "Stretch") Then
                sp1.VerticalAlignment = System.Windows.VerticalAlignment.Stretch
            End If
        End Sub
        '</Snippet2>

    End Class
End Namespace
