      Dim numbers() As Integer = { -1, 0, 40, 160, 255, 1028, _
                                 2011, 30001, 207154, Int32.MaxValue }
      Dim result As Char
      For Each number As Integer In numbers
         Try
            result = Convert.ToChar(number)
            Console.WriteLine("{0} converts to '{1}'.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Char data type.", _
                              number)
         End Try
      Next   
   End Sub
   '       -1 is outside the range of the Char data type.
   '       0 converts to ' '.
   '       40 converts to '('.
   '       160 converts to ' '.
   '       255 converts to 'ÿ'.
   '       1028 converts to '?'.
   '       2011 converts to '?'.
   '       30001 converts to '?'.
   '       207154 is outside the range of the Char data type.
   '       2147483647 is outside the range of the Char data type.   