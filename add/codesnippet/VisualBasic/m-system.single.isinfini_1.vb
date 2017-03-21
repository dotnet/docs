            ' This will return "True".
            Console.Write("IsInfinity(3.0 / 0) = ")
            If Single.IsPositiveInfinity(3 / 0) Then
                Console.WriteLine("True.")
            Else
                Console.WriteLine("False.")
            End If