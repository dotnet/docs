     Public Sub ConvertStringDecimal(ByVal stringVal As String)
         Dim decimalVal As Decimal = 0

         Try
             decimalVal = System.Convert.ToDecimal(stringVal)
             System.Console.WriteLine("The string as a decimal is {0}.", _
                                       decimalVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in string-to-decimal conversion.")
         Catch exception As System.FormatException
             System.Console.WriteLine( _
                 "The string is not formatted as a decimal.")
         Catch exception As System.ArgumentException
             System.Console.WriteLine("The string is null.")
         End Try

         ' Decimal to string conversion will not overflow.
         stringVal = System.Convert.ToString(decimalVal)
         System.Console.WriteLine("The decimal as a string is {0}.", _
                                   stringVal)
     End Sub