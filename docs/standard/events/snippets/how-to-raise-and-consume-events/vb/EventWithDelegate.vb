' <ThresholdReachedWithDelegate>
Module EventWithDelegate

    Sub Main()
        Dim c As New CounterWithDelegate(New Random().Next(10))
        ' <SubscribeEventDelegate>
        AddHandler c.ThresholdReached, AddressOf c_ThresholdReached
        ' </SubscribeEventDelegate>

        Console.WriteLine("press 'a' key to increase total")
        While Console.ReadKey(True).KeyChar = "a"
            Console.WriteLine("adding one")
            c.Add(1)
        End While
    End Sub

    ' <HandleEventDelegate>
    Sub c_ThresholdReached(sender As Object, e As ThresholdReachedEventArgs)
        Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached)
        Environment.Exit(0)
    End Sub
    ' </HandleEventDelegate>
End Module

Class CounterWithDelegate
    Private ReadOnly _threshold As Integer
    Private _total As Integer

    Public Sub New(passedThreshold As Integer)
        _threshold = passedThreshold
    End Sub

    Public Sub Add(x As Integer)
        _total += x
        ' <RaiseEventDelegate>
        If (_total >= _threshold) Then
            Dim args As New ThresholdReachedEventArgs With {
                .Threshold = _threshold,
                .TimeReached = Date.Now
            }
            OnThresholdReached(args)
        End If
        ' </RaiseEventDelegate>
    End Sub

    ' <RaiseEventMethodDelegate>
    Protected Overridable Sub OnThresholdReached(e As ThresholdReachedEventArgs)
        RaiseEvent ThresholdReached(Me, e)
    End Sub
    ' </RaiseEventMethodDelegate>

    ' <DeclareEventWithDelegate>
    Public Event ThresholdReached As ThresholdReachedEventHandler
    ' </DeclareEventWithDelegate>
End Class

' <DeclareDelegateType>
Delegate Sub ThresholdReachedEventHandler(sender As Object, e As ThresholdReachedEventArgs)
' </DeclareDelegateType>
' </ThresholdReachedWithDelegate>
