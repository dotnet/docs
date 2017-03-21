         Dim zero As Double = 0

         ' This condition will return false.
         If (0 / zero) = Double.NaN Then
             Console.WriteLine("0 / 0 can be tested with Double.NaN.")
         Else
             Console.WriteLine("0 / 0 cannot be tested with Double.NaN; use Double.IsNan() instead.")
         End If