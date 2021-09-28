Class MainWindow
    ' <snippetRtbHandlers>
    Public Sub New()
        InitializeComponent()

        richTextBox1.AddHandler(RichTextBox.DragOverEvent, New DragEventHandler(AddressOf RichTextBox_DragOver), True)
        richTextBox1.AddHandler(RichTextBox.DropEvent, New DragEventHandler(AddressOf RichTextBox_Drop), True)

    End Sub

    Private Sub RichTextBox_DragOver(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effects = DragDropEffects.All
        Else
            e.Effects = DragDropEffects.None
        End If
        e.Handled = False
    End Sub

    Private Sub RichTextBox_Drop(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim docPath As String() = TryCast(e.Data.GetData(DataFormats.FileDrop), String())

            ' By default, open as Rich Text (RTF).
            Dim dataFormat = DataFormats.Rtf

            ' If the Shift key is pressed, open as plain text.
            If e.KeyStates = DragDropKeyStates.ShiftKey Then
                dataFormat = DataFormats.Text
            End If

            Dim range As TextRange
            Dim fStream As IO.FileStream
            If IO.File.Exists(docPath(0)) Then
                Try
                    ' Open the document in the RichTextBox.
                    range = New TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd)
                    fStream = New IO.FileStream(docPath(0), IO.FileMode.OpenOrCreate)
                    range.Load(fStream, dataFormat)
                    fStream.Close()
                Catch generatedExceptionName As System.Exception
                    MessageBox.Show("File could not be opened. Make sure the file is a text file.")
                End Try
            End If
        End If
    End Sub
    ' </snippetRtbHandlers>

    ' <snippetDoDragDrop>
    Private Sub Ellipse_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs)
        Dim ellipse = TryCast(sender, Ellipse)
        If ellipse IsNot Nothing AndAlso e.LeftButton = MouseButtonState.Pressed Then
            DragDrop.DoDragDrop(ellipse, ellipse.Fill.ToString(), DragDropEffects.Copy)
        End If
    End Sub
    ' </snippetDoDragDrop>

    ' <snippetDragEnterLeave>
    ' <snippetDragEnter>
    Private _previousFill As Brush = Nothing
    Private Sub Ellipse_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs)
        Dim ellipse = TryCast(sender, Ellipse)
        If ellipse IsNot Nothing Then
            ' Save the current Fill brush so that you can revert back to this value in DragLeave.
            _previousFill = ellipse.Fill

            ' If the DataObject contains string data, extract it.
            If e.Data.GetDataPresent(DataFormats.StringFormat) Then
                Dim dataString = e.Data.GetData(DataFormats.StringFormat)

                ' If the string can be converted into a Brush, convert it.
                Dim converter As New BrushConverter()
                If converter.IsValid(dataString) Then
                    Dim newFill As Brush = CType(converter.ConvertFromString(dataString), Brush)
                    ellipse.Fill = newFill
                End If
            End If
        End If
    End Sub
    ' </snippetDragEnter>
    ' <snippetDragLeave>
    Private Sub Ellipse_DragLeave(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs)
        Dim ellipse = TryCast(sender, Ellipse)
        If ellipse IsNot Nothing Then
            ellipse.Fill = _previousFill
        End If
    End Sub
    ' </snippetDragLeave>
    ' </snippetDragEnterLeave>

    ' <snippetDragOver>
    Private Sub Ellipse_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs)
        e.Effects = DragDropEffects.None

        ' If the DataObject contains string data, extract it.
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim dataString = e.Data.GetData(DataFormats.StringFormat)

            ' If the string can be converted into a Brush, convert it.
            Dim converter As New BrushConverter()
            If converter.IsValid(dataString) Then
                e.Effects = DragDropEffects.Copy Or DragDropEffects.Move
            End If
        End If
    End Sub
    ' </snippetDragOver>

    ' <snippetDrop>
    Private Sub Ellipse_Drop(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs)
        Dim ellipse = TryCast(sender, Ellipse)
        If ellipse IsNot Nothing Then

            ' If the DataObject contains string data, extract it.
            If e.Data.GetDataPresent(DataFormats.StringFormat) Then
                Dim dataString = e.Data.GetData(DataFormats.StringFormat)

                ' If the string can be converted into a Brush, convert it.
                Dim converter As New BrushConverter()
                If converter.IsValid(dataString) Then
                    Dim newFill As Brush = CType(converter.ConvertFromString(dataString), Brush)
                    ellipse.Fill = newFill
                End If
            End If
        End If
    End Sub
    ' </snippetDrop>

End Class
