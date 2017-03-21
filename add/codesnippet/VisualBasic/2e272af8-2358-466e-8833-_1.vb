    Public Sub SetDigitSubExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim blueBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))
        Dim myFont As New Font("Courier New", 12)
        Dim myStringFormat As New StringFormat
        Dim myString As String = "0 1 2 3 4 5 6 7 8 9"

        ' Arabic (0x0C01) digits.

        ' Use National substitution method.
        myStringFormat.SetDigitSubstitution(&HC01, _
        StringDigitSubstitute.National)
        g.DrawString("Arabic:" & ControlChars.Cr & _
        "Method of substitution = National:     " & myString, _
        myFont, blueBrush, New PointF(10.0F, 20.0F), myStringFormat)

        ' Use Traditional substitution method.
        myStringFormat.SetDigitSubstitution(&HC01, _
        StringDigitSubstitute.Traditional)
        g.DrawString("Method of substitution = Traditional:  " _
        & myString, myFont, blueBrush, New PointF(10.0F, 55.0F), _
        myStringFormat)

        ' Thai (0x041E) digits.

        ' Use National substitution method.
        myStringFormat.SetDigitSubstitution(&H41E, _
        StringDigitSubstitute.National)
        g.DrawString("Thai:" & ControlChars.Cr & _
        "Method of substitution = National:     " & myString, _
        myFont, blueBrush, New PointF(10.0F, 85.0F), myStringFormat)

        ' Use Traditional substitution method.
        myStringFormat.SetDigitSubstitution(&H41E, _
        StringDigitSubstitute.Traditional)
        g.DrawString("Method of substitution = Traditional:  " _
        & myString, myFont, blueBrush, New PointF(10.0F, 120.0F), _
        myStringFormat)
    End Sub