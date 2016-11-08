    Sub computeArea(ByVal length As Double, ByVal width As Double)
        ' Declare local variable.
        Dim area As Double
        If length = 0 Or width = 0 Then
            ' If either argument = 0 then exit Sub immediately.
            Exit Sub
        End If
        ' Calculate area of rectangle.
        area = length * width
        ' Print area to Immediate window.
        Debug.WriteLine(area)
    End Sub