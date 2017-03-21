    Public Sub SetBrushRemapTableExample(ByVal e As PaintEventArgs)

        ' Create a color map.
        Dim myColorMap(0) As ColorMap
        myColorMap(0) = New ColorMap
        myColorMap(0).OldColor = Color.Red
        myColorMap(0).NewColor = Color.Green

        ' Create an ImageAttributes object, passing it to the myColorMap

        ' array.
        Dim imageAttr As New System.Drawing.Imaging.ImageAttributes
        imageAttr.SetBrushRemapTable(myColorMap)
    End Sub