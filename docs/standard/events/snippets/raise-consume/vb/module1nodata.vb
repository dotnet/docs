'<snippet5>
Module Module1

    Sub Main()
        Dim c As New Counter(New Random().Next(10))
        AddHandler c.ThresholdReached, AddressOf c_ThresholdReached

        Console.WriteLine("press 'a' key to increase total")
        While Console.ReadKey(True).KeyChar = "a"
            Console.WriteLine("adding one")
            c.Add(1)
        End While
    End Sub

    Sub c_ThresholdReached(sender As Object, e As EventArgs)
        Console.WriteLine("The threshold was reached.")
        Environment.Exit(0)
    End Sub
End Module

Class Counter
    Private ReadOnly _threshold As Integer
    Private _total As Integer

    Public Sub New(passedThreshold As Integer)
        _threshold = passedThreshold
    End Sub

    Public Sub Add(x As Integer)
        _total += x
        If (_total >= _threshold) Then
            RaiseEvent ThresholdReached(Me, EventArgs.Empty)
        End If
    End Sub

    Public Event ThresholdReached As EventHandler
End Class
'</snippet5>

