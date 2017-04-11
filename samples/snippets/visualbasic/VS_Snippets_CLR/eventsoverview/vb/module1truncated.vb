'<snippet2>
Module Module1

    Sub Main()
        Dim c As Counter = New Counter()
        AddHandler c.ThresholdReached, AddressOf c_ThresholdReached

        ' provide remaining implementation for the class
    End Sub

    Sub c_ThresholdReached(sender As Object, e As EventArgs)
        Console.WriteLine("The threshold was reached.")
    End Sub
End Module
'</snippet2>

'<snippet1>
Public Class Counter
    Public Event ThresholdReached As EventHandler

    Protected Overridable Sub OnThresholdReached(e As EventArgs)
        RaiseEvent ThresholdReached(Me, e)
    End Sub

    ' provide remaining implementation for the class
End Class
'</snippet1>

'<snippet3>
Public Class ThresholdReachedEventArgs
    Inherits EventArgs

    Public Property Threshold As Integer
    Public Property TimeReached As DateTime
End Class
'</snippet3>

'<snippet4>
Public Delegate Sub ThresholdReachedEventHandler(e As ThresholdReachedEventArgs)
'</snippet4>