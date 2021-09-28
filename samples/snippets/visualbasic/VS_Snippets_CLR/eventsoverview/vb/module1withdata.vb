' <snippet6>
Module Module1

    Sub Main()
        Dim c As Counter = New Counter(New Random().Next(10))
        AddHandler c.ThresholdReached, AddressOf c_ThresholdReached

        Console.WriteLine("press 'a' key to increase total")
        While Console.ReadKey(True).KeyChar = "a"
            Console.WriteLine("adding one")
            c.Add(1)
        End While
    End Sub

    Sub c_ThresholdReached(sender As Object, e As ThresholdReachedEventArgs)
        Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached)
        Environment.Exit(0)
    End Sub
End Module

Class Counter
    Private threshold As Integer
    Private total As Integer

    Public Sub New(passedThreshold As Integer)
        threshold = passedThreshold
    End Sub

    Public Sub Add(x As Integer)
        total = total + x
        If (total >= threshold) Then
            Dim args As ThresholdReachedEventArgs = New ThresholdReachedEventArgs()
            args.Threshold = threshold
            args.TimeReached = DateTime.Now
            OnThresholdReached(args)
        End If
    End Sub

    Protected Overridable Sub OnThresholdReached(e As ThresholdReachedEventArgs)
        RaiseEvent ThresholdReached(Me, e)
    End Sub

    Public Event ThresholdReached As EventHandler(Of ThresholdReachedEventArgs)
End Class

Class ThresholdReachedEventArgs
    Inherits EventArgs

    Public Property Threshold As Integer
    Public Property TimeReached As DateTime
End Class
' </snippet6>

