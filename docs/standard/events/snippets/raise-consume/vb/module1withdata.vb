Namespace Module3Example
    ' <snippet6>
    Module Module3

        Sub Main()
            Dim c As New Counter(New Random().Next(10))
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
        Private ReadOnly _threshold As Integer
        Private _total As Integer

        Public Sub New(passedThreshold As Integer)
            _threshold = passedThreshold
        End Sub

        Public Sub Add(x As Integer)
            _total += x
            If (_total >= _threshold) Then
                Dim args As New ThresholdReachedEventArgs With {
                    .Threshold = _threshold,
                    .TimeReached = Date.Now
                }
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
        Public Property TimeReached As Date
    End Class
    ' </snippet6>
End Namespace

