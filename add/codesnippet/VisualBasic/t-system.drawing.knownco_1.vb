    Private Sub DisplayKnownColors(ByVal e As PaintEventArgs)
        Me.Size = New Size(650, 550)
        Dim i As Integer

        ' Get all the values from the KnownColor enumeration.
        Dim colorsArray As System.Array = _
            [Enum].GetValues(GetType(KnownColor))
        Dim allColors(colorsArray.length) As KnownColor

        Array.Copy(colorsArray, allColors, colorsArray.Length)

        ' Loop through printing out the value's name in the colors 
        ' they represent.
        Dim y As Single
        Dim x As Single = 10.0F

        For i = 0 To allColors.Length - 1

            ' If x is a multiple of 30, start a new column.
            If (i > 0 And i Mod 30 = 0) Then
                x += 105.0F
                y = 15.0F
            Else
                ' Otherwise increment y by 15.
                y += 15.0F
            End If

            ' Create a custom brush from the color and use it to draw
            ' the brush's name.
            Dim aBrush As New SolidBrush(Color.FromName( _
                allColors(i).ToString()))
            e.Graphics.DrawString(allColors(i).ToString(), _
                Me.Font, aBrush, x, y)

            ' Dispose of the custom brush.
            aBrush.Dispose()
        Next

    End Sub