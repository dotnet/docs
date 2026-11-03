' <ThresholdReachedNoData>
Module EventNoData

    Sub Main()
        Dim c As New Counter(New Random().Next(10))
        ' <SubscribeEvent>
        AddHandler c.ThresholdReached, AddressOf c_ThresholdReached
        ' </SubscribeEvent>

        Console.WriteLine("press 'a' key to increase total")
        While Console.ReadKey(True).KeyChar = "a"
            Console.WriteLine("adding one")
            c.Add(1)
        End While
    End Sub

    ' <HandleEvent>
    Sub c_ThresholdReached(sender As Object, e As EventArgs)
        Console.WriteLine("The threshold was reached.")
        Environment.Exit(0)
    End Sub
    ' </HandleEvent>
End Module

Class Counter
    Private ReadOnly _threshold As Integer
    Private _total As Integer

    Public Sub New(passedThreshold As Integer)
        _threshold = passedThreshold
    End Sub

    Public Sub Add(x As Integer)
        _total += x
        ' <RaiseEvent>
        If (_total >= _threshold) Then
            OnThresholdReached(EventArgs.Empty)
        End If
        ' </RaiseEvent>
    End Sub

    ' <RaiseEventMethod>
    Protected Overridable Sub OnThresholdReached(e As EventArgs)
        RaiseEvent ThresholdReached(Me, e)
    End Sub
    ' </RaiseEventMethod>

    ' <DeclareEvent>
    Public Event ThresholdReached As EventHandler
    ' </DeclareEvent>
End Class
' </ThresholdReachedNoData>
