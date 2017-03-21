            Dim zero As Single = 0

            ' This condition will return false.
            If (0 / zero) = Single.NaN Then
                Console.WriteLine("0 / 0 can be tested with Single.NaN.")
            Else
                Console.WriteLine("0 / 0 cannot be tested with Single.NaN; use Single.IsNan() instead.")
            End If