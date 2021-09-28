Class MainWindow 
    ' <snippetPanelDragOver>
    Private Sub panel_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs)
        If e.Data.GetDataPresent("Object") Then
            ' These Effects values are used in the drag source's
            ' GiveFeedback event handler to determine which cursor to display.
            If e.KeyStates = DragDropKeyStates.ControlKey Then
                e.Effects = DragDropEffects.Copy
            Else
                e.Effects = DragDropEffects.Move
            End If
        End If
    End Sub
    ' </snippetPanelDragOver>

    ' <snippetPanelDrop>
    Private Sub panel_Drop(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs)
        ' If an element in the panel has already handled the drop,
        ' the panel should not also handle it.
        If e.Handled = False Then
            Dim _panel As Panel = sender
            Dim _element As UIElement = e.Data.GetData("Object")

            If _panel IsNot Nothing And _element IsNot Nothing Then
                ' Get the panel that the element currently belongs to,
                ' then remove it from that panel and add it the Children of
                ' the panel that its been dropped on.

                Dim _parent As Panel = VisualTreeHelper.GetParent(_element)
                If _parent IsNot Nothing Then
                    If e.KeyStates = DragDropKeyStates.ControlKey And _
                        e.AllowedEffects.HasFlag(DragDropEffects.Copy) Then
                        Dim _circle As New Circle(_element)
                        _panel.Children.Add(_circle)
                        ' set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Copy
                    ElseIf e.AllowedEffects.HasFlag(DragDropEffects.Move) Then
                        _parent.Children.Remove(_element)
                        _panel.Children.Add(_element)
                        ' set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Move
                    End If
                End If
            End If
        End If
    End Sub
    ' </snippetPanelDrop>
End Class
