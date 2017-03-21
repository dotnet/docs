     Public Sub ConvertLongChar(ByVal longVal As Long)

         Dim charVal As Char = "a"c

         Try
             charVal = System.Convert.ToChar(longVal)
             System.Console.WriteLine("{0} as a char is {1}", _
                                       longVal, charVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in Long-to-Char conversion.")
         End Try

         ' A conversion from Char to Long cannot overflow.
         longVal = System.Convert.ToInt64(charVal)
         System.Console.WriteLine("{0} as a Long is {1}", _
                                   charVal, longVal)
     End Sub