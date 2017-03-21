    Public Overrides Function Layout( _
    ByVal container As Object, _
    ByVal layoutEventArgs As LayoutEventArgs) As Boolean

        Dim parent As Control = container

        ' Use DisplayRectangle so that parent.Padding is honored.
        Dim parentDisplayRectangle As Rectangle = parent.DisplayRectangle
        Dim nextControlLocation As Point = parentDisplayRectangle.Location

        Dim c As Control
        For Each c In parent.Controls

            ' Only apply layout to visible controls.
            If c.Visible <> True Then
                Continue For
            End If

            ' Respect the margin of the control:
            ' shift over the left and the top.
            nextControlLocation.Offset(c.Margin.Left, c.Margin.Top)

            ' Set the location of the control.
            c.Location = nextControlLocation

            ' Set the autosized controls to their 
            ' autosized heights.
            If c.AutoSize Then
                c.Size = c.GetPreferredSize(parentDisplayRectangle.Size)
            End If

            ' Move X back to the display rectangle origin.
            nextControlLocation.X = parentDisplayRectangle.X

            ' Increment Y by the height of the control 
            ' and the bottom margin.
            nextControlLocation.Y += c.Height + c.Margin.Bottom
        Next c

        ' Optional: Return whether or not the container's 
        ' parent should perform layout as a result of this 
        ' layout. Some layout engines return the value of 
        ' the container's AutoSize property.
        Return False

    End Function