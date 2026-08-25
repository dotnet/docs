' <DefineEvent>
Public Class Counter
    Public Event ThresholdReached As EventHandler

    Protected Overridable Sub OnThresholdReached(e As EventArgs)
        RaiseEvent ThresholdReached(Me, e)
    End Sub

    ' Provide remaining implementation for the class...
End Class
' </DefineEvent>

' <EventDataClass>
Public Class ThresholdReachedEventArgs
    Inherits EventArgs

    Public Property Threshold As Integer
    Public Property TimeReached As Date
End Class
' </EventDataClass>

' <CustomDelegate>
Public Delegate Sub ThresholdReachedEventHandler(sender As Object, e As ThresholdReachedEventArgs)
' </CustomDelegate>
