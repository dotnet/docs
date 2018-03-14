Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Collections.ObjectModel

Namespace ListBox_vb

    '<Snippet6> 
    Public Class myColors
        Inherits ObservableCollection(Of String)

        Public Sub New()

            Add("LightBlue")
            Add("Pink")
            Add("Red")
            Add("Purple")
            Add("Blue")
            Add("Green")

        End Sub
    End Class
    '</Snippet6>

    Partial Class Pane1
        '<Snippet2>
        Private Sub PrintText(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

            Dim lbsender As ListBox
            Dim li As ListBoxItem

            lbsender = CType(sender, ListBox)
            li = CType(lbsender.SelectedItem, ListBoxItem)
            tb.Text = "   You selected " & li.Content.ToString & "."
        End Sub
        '</Snippet2>

        '<Snippet9>
        Private Sub myListBox_SelectionChanged(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim converter As BrushConverter = New BrushConverter()
            Dim color As String

            ' Show Rectangles that are the selected colors.
            For Each color In args.AddedItems

                If GetRectangle(color) Is Nothing Then
                    Dim aRect As Rectangle = New Rectangle()
                    aRect.Fill = CType(converter.ConvertFrom(color), Brush)
                    aRect.Tag = color
                    rectanglesPanel.Children.Add(aRect)
                End If

            Next

            ' Remove the Rectangles that are the unselected colors.
            For Each color In args.RemovedItems

                Dim removedItem As FrameworkElement = GetRectangle(color)
                If Not removedItem Is Nothing Then
                    rectanglesPanel.Children.Remove(removedItem)
                End If

            Next

        End Sub

        Private Function GetRectangle(ByVal color As String) As FrameworkElement
            Dim rect As FrameworkElement
            For Each rect In rectanglesPanel.Children
                If rect.Tag.ToString() = color Then
                    Return rect
                End If
            Next

            Return Nothing
        End Function
        '</Snippet9>

        Private Sub selectAll_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myListBox.SelectAll()
        End Sub

        Private Sub unselectAll_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myListBox.UnselectAll()
        End Sub


    End Class


End Namespace