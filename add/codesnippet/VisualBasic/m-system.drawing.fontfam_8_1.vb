    Public Sub GetHashCode_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Get the hash code for myFontFamily.
        Dim hashCode As Integer = myFontFamily.GetHashCode()

        ' Draw the value of hashCode to the screen as a string.
        e.Graphics.DrawString("hashCode = " & hashCode.ToString(), _
        New Font(myFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub