         ' This will return "True".
         Console.Write("IsNegativeInfinity(-5.0 / 0) = ")
         If Double.IsNegativeInfinity(-5 / 0) Then
             Console.WriteLine("True.")
         Else
             Console.WriteLine("False.")
         End If