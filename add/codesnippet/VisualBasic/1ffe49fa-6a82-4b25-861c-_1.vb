    Private Function PasteMyBitmap(ByVal Filename As String) As Boolean

        'Open an bitmap from file and copy it to the clipboard.
        Dim MyBitmap As Bitmap
        MyBitmap = Bitmap.FromFile(Filename)

        ' Copy the bitmap to the clipboard.
        Clipboard.SetDataObject(MyBitmap)

        ' Get the format for the object type.
        Dim MyFormat As DataFormats.Format = DataFormats.GetFormat(DataFormats.Bitmap)

        ' After verifying that the data can be pasted, paste it.
        If RichTextBox1.CanPaste(MyFormat) Then

            RichTextBox1.Paste(MyFormat)
            PasteMyBitmap = True

        Else

            MessageBox.Show("The data format that you attempted to paste is not supported by this control.")
            PasteMyBitmap = False

        End If


    End Function