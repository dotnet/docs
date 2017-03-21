         ' This will return "True".
         Console.Write("IsPositiveInfinity(4.0 / 0) = ")
         If Double.IsPositiveInfinity(4 / 0) Then
             Console.WriteLine("True.")
         Else
             Console.WriteLine("False.")
         End If