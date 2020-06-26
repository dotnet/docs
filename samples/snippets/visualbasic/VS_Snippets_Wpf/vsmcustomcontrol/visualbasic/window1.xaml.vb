Class Window1 

    Private Sub nud_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)

        Dim n As NumericUpDown = TryCast(sender, NumericUpDown)

        If n Is Nothing Then
            MessageBox.Show("no sender")
            Exit Sub
        End If

        'e.Value;
        lb1.Content = n.Value
    End Sub

    '<SnippetGoToElementState>
    Private Sub rect_MouseEvent(ByVal sender As Object, ByVal e As MouseEventArgs)
        If rect.IsMouseOver Then
            VisualStateManager.GoToElementState(rect, "MouseEnter", True)
        Else
            VisualStateManager.GoToElementState(rect, "MouseLeave", True)
        End If
    End Sub
    '</SnippetGoToElementState>

    '<SnippetVSMEasingFunctionLogic>
    Private isMouseDown As Boolean

    Private Sub Canvas_MouseEvent(ByVal sender As Object, ByVal e As MouseEventArgs)

        isMouseDown = Not isMouseDown

        If isMouseDown Then
            VisualStateManager.GoToElementState(canvasRoot, "CanvasButtonDown", True)
        Else

            VisualStateManager.GoToElementState(canvasRoot, "CanvasButtonUp", True)
        End If
    End Sub
    '</SnippetVSMEasingFunctionLogic>

End Class
