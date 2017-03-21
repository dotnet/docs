    Public Sub ToArgbToStringExample1(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Color structure used for temporary storage.
        Dim someColor As Color = Color.FromArgb(0)

        ' Array to store KnownColor values that match the criteria.
        Dim colorMatches(167) As KnownColor

        ' Number of matches found.
        Dim count As Integer = 0

        ' Iterate through KnownColor enums to find all corresponding colors
        ' that have a non-zero green component and zero-valued red
        ' component and that are not system colors.
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            someColor = Color.FromKnownColor(enumValue)
            If someColor.G <> 0 And someColor.R = 0 And _
            Not someColor.IsSystemColor Then
                colorMatches(count) = enumValue
                count += 1
            End If
        Next enumValue
        Dim myBrush1 As New SolidBrush(someColor)
        Dim myFont As New Font("Arial", 9)
        Dim x As Integer = 40
        Dim y As Integer = 40

        ' Iterate through the matches found and display each color that
        ' corresponds with the enum value in the array. Also display the
        ' name of the KnownColor and the ARGB components.
        Dim i As Integer
        For i = 0 To count - 1

            ' Display the color.
            someColor = Color.FromKnownColor(colorMatches(i))
            myBrush1.Color = someColor
            g.FillRectangle(myBrush1, x, y, 50, 30)

            ' Display KnownColor name and four component values. To display
            ' component values:  Use the ToArgb method to get the 32-bit
            ' ARGB value of someColor (created from a KnownColor). Create
            ' a Color structure from the 32-bit ARGB value and set someColor
            ' equal to this new Color structure. Then use the ToString method
            ' to convert it to a string.
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 55, y)
            someColor = Color.FromArgb(someColor.ToArgb())
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 55, y + 15)
            y += 40
        Next i
    End Sub