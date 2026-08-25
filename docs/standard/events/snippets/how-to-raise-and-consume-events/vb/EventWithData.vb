' <ThresholdReachedWithData>
Module EventWithData

    Sub Main()
        Dim c As New CounterWithData(New Random().Next(10))
        ' <SubscribeEvent2>
        AddHandler c.ThresholdReached, AddressOf c_ThresholdReached
        ' </SubscribeEvent2>

        Console.WriteLine("press 'a' key to increase total")
        While Console.ReadKey(True).KeyChar = "a"
            Console.WriteLine("adding one")
            c.Add(1)
        End While
    End Sub

    ' <HandleEvent2>
    Sub c_ThresholdReached(sender As Object, e As ThresholdReachedEventArgs)
        Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached)
        Environment.Exit(0)
    End Sub
    ' </HandleEvent2>
End Module

Class CounterWithData
    Private ReadOnly _threshold As Integer
    Private _total As Integer

    Public Sub New(passedThreshold As Integer)
        _threshold = passedThreshold
    End Sub

    Public Sub Add(x As Integer)
        _total += x
        ' <RaiseEvent2>
        If (_total >= _threshold) Then
            Dim args As New ThresholdReachedEventArgs With {
                .Threshold = _threshold,
                .TimeReached = Date.Now
            }
            OnThresholdReached(args)
        End If
        ' </RaiseEvent2>
    End Sub

    ' <RaiseEventMethod2>
    Protected Overridable Sub OnThresholdReached(e As ThresholdReachedEventArgs)
        RaiseEvent ThresholdReached(Me, e)
    End Sub
    ' </RaiseEventMethod2>

    ' <DeclareEvent2>
    Public Event ThresholdReached As EventHandler(Of ThresholdReachedEventArgs)
    ' </DeclareEvent2>
End Class

' <EventDataClass2>
Class ThresholdReachedEventArgs
    Inherits EventArgs

    Public Property Threshold As Integer
    Public Property TimeReached As Date
End Class
' </EventDataClass2>
' </ThresholdReachedWithData>
