    Public Sub startWidget(ByVal aWidget As widget,
        ByVal clockwise As Boolean, ByVal revolutions As Integer)
        Dim counter As Integer
        If clockwise = True Then
            For counter = 1 To revolutions
                aWidget.spinClockwise()
            Next counter
        Else
            For counter = 1 To revolutions
                aWidget.spinCounterClockwise()
            Next counter
        End If
    End Sub