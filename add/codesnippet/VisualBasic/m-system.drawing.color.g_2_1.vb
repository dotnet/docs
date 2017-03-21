    Public Sub GetSatExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Color structures. One is used for temporary storage. The other
        ' is a constant used for comparisons.
        Dim someColor As Color = Color.FromArgb(0)
        Dim redShade As Color = Color.FromArgb(255, 200, 0, 100)

        ' Array to store KnownColor values that match the saturation of the
        ' redShade color.
        Dim colorMatches(15) As KnownColor

        ' Number of matches found.
        Dim count As Integer = 0

        ' Iterate through the KnownColor enums until 15 matches are found
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            someColor = Color.FromKnownColor(enumValue)
            If (someColor.GetSaturation()) = (redShade.GetSaturation()) Then
                colorMatches(count) = enumValue
                count += 1
                If count > 15 Then
                    Exit For
                End If
            End If
        Next enumValue

        ' Display the redShade color and its argb value.
        Dim myBrush1 As New SolidBrush(redShade)
        Dim myFont As New Font("Arial", 12)
        Dim x As Integer = 20
        Dim y As Integer = 20
        someColor = redShade
        g.FillRectangle(myBrush1, x, y, 100, 30)
        g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
        x + 120, y)

        ' Iterate through the matches that were found and display each
        ' color that corresponds with the enum value in the array. also
        ' display the name of the KnownColor.
        Dim i As Integer
        For i = 0 To count - 1
            y += 40
            someColor = Color.FromKnownColor(colorMatches(i))
            myBrush1.Color = someColor
            g.FillRectangle(myBrush1, x, y, 100, 30)
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 120, y)
        Next i
    End Sub