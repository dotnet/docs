' <snippetBrush>
Public Class Circle
    Private _previousFill As Brush = Nothing
    ' </snippetBrush>

    ' <snippetCopyCtor>
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal c As Circle)
        InitializeComponent()
        Me.circleUI.Height = c.circleUI.Height
        Me.circleUI.Width = c.circleUI.Height
        Me.circleUI.Fill = c.circleUI.Fill
    End Sub
    ' </snippetCopyCtor>

    ' <snippetOnMouseMove>
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Input.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If e.LeftButton = MouseButtonState.Pressed Then
            ' Package the data.
            Dim data As New DataObject
            data.SetData(DataFormats.StringFormat, circleUI.Fill.ToString())
            data.SetData("Double", circleUI.Height)
            data.SetData("Object", Me)

            ' Inititate the drag-and-drop operation.
            DragDrop.DoDragDrop(Me, data, DragDropEffects.Copy Or DragDropEffects.Move)
        End If
    End Sub
    ' </snippetOnMouseMove>

    ' <snippetOnGiveFeedback>
    Protected Overrides Sub OnGiveFeedback(ByVal e As System.Windows.GiveFeedbackEventArgs)
        MyBase.OnGiveFeedback(e)
        ' These Effects values are set in the drop target's
        ' DragOver event handler.
        If e.Effects.HasFlag(DragDropEffects.Copy) Then
            Mouse.SetCursor(Cursors.Cross)
        ElseIf e.Effects.HasFlag(DragDropEffects.Move) Then
            Mouse.SetCursor(Cursors.Pen)
        Else
            Mouse.SetCursor(Cursors.No)
        End If
        e.Handled = True
    End Sub
    ' </snippetOnGiveFeedback>

    ' <snippetOnDrop>
    Protected Overrides Sub OnDrop(ByVal e As System.Windows.DragEventArgs)
        MyBase.OnDrop(e)
        ' If the DataObject contains string data, extract it.
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim dataString As String = e.Data.GetData(DataFormats.StringFormat)

            ' If the string can be converted into a Brush, 
            ' convert it and apply it to the ellipse.
            Dim converter As New BrushConverter
            If converter.IsValid(dataString) Then
                Dim newFill As Brush = converter.ConvertFromString(dataString)
                circleUI.Fill = newFill

                ' Set Effects to notify the drag source what effect
                ' the drag-and-drop operation had.
                ' (Copy if CTRL is pressed; otherwise, move.)
                If e.KeyStates.HasFlag(DragDropKeyStates.ControlKey) Then
                    e.Effects = DragDropEffects.Copy
                Else
                    e.Effects = DragDropEffects.Move
                End If
            End If
        End If
        e.Handled = True
    End Sub
    ' </snippetOnDrop>

    ' <snippetOnDragOver>
    Protected Overrides Sub OnDragOver(ByVal e As System.Windows.DragEventArgs)
        MyBase.OnDragOver(e)
        e.Effects = DragDropEffects.None

        ' If the DataObject contains string data, extract it.
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim dataString As String = e.Data.GetData(DataFormats.StringFormat)

            ' If the string can be converted into a Brush, allow copying or moving.
            Dim converter As New BrushConverter
            If converter.IsValid(dataString) Then
                ' Set Effects to notify the drag source what effect
                ' the drag-and-drop operation will have. These values are 
                ' used by the drag source's GiveFeedback event handler.
                ' (Copy if CTRL is pressed; otherwise, move.)
                If e.KeyStates.HasFlag(DragDropKeyStates.ControlKey) Then
                    e.Effects = DragDropEffects.Copy
                Else
                    e.Effects = DragDropEffects.Move
                End If
            End If
        End If
        e.Handled = True
    End Sub
    ' </snippetOnDragOver>

    ' <snippetOnDragEnter>
    Protected Overrides Sub OnDragEnter(ByVal e As System.Windows.DragEventArgs)
        MyBase.OnDragEnter(e)
        _previousFill = circleUI.Fill

        ' If the DataObject contains string data, extract it.
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim dataString As String = e.Data.GetData(DataFormats.StringFormat)

            ' If the string can be converted into a Brush, convert it.
            Dim converter As New BrushConverter
            If converter.IsValid(dataString) Then
                Dim newFill As Brush = converter.ConvertFromString(dataString)
                circleUI.Fill = newFill
            End If
        End If
        e.Handled = True
    End Sub
    ' </snippetOnDragEnter>

    ' <snippetOnDragLeave>
    Protected Overrides Sub OnDragLeave(ByVal e As System.Windows.DragEventArgs)
        MyBase.OnDragLeave(e)
        ' Undo the preview that was applied in OnDragEnter.
        circleUI.Fill = _previousFill
    End Sub
    ' </snippetOnDragLeave>


End Class
