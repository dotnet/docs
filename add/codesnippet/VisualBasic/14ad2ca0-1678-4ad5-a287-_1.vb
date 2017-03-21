    Private Sub SetData4()
        ' Creates a new data object.
        Dim myDataObject As New DataObject()

        ' Adds UnicodeText string to the object, and set the autoConvert
        ' parameter to false.
        myDataObject.SetData(DataFormats.UnicodeText, False, "My text string")

        ' Gets the data format(s) in the data object.
        Dim arrayOfFormats As [String]() = myDataObject.GetFormats()

        ' Stores the results in a string.
        Dim theResult As String = "The format(s) associated with the data are:" + _
                ControlChars.Cr
        Dim i As Integer
        For i = 0 To arrayOfFormats.Length - 1
            theResult += arrayOfFormats(i) + ControlChars.Cr
        Next i
        ' Show the results in a message box. 
        MessageBox.Show(theResult)
    End Sub 'SetData4 