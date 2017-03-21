    Public Sub GetName_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Get the name of myFontFamily.
        Dim familyName As String = myFontFamily.GetName(0)

        ' Draw the name of the myFontFamily to the screen as a string.
        e.Graphics.DrawString("The family name is " & familyName, _
        New Font(myFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub