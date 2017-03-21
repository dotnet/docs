    Public Sub IsStyleAvailable_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Test whether myFontFamily is available in Italic.
        If myFontFamily.IsStyleAvailable(FontStyle.Italic) Then

            ' Create a Font object using myFontFamily.
            Dim familyFont As New Font(myFontFamily, 16, FontStyle.Italic)

            ' Use familyFont to draw text to the screen.
            e.Graphics.DrawString(myFontFamily.Name & _
            " is available in Italic", familyFont, Brushes.Black, _
            New PointF(0, 0))
        End If
    End Sub