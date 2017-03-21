     Public Sub ConvertLongDecimal(ByVal longVal As Long)

         Dim decimalVal As Decimal

         'Long to Decimal conversion cannot overflow.
         decimalVal = System.Convert.ToDecimal(longVal)
         System.Console.WriteLine("{0} as a Decimal is {1}", _
                                   longVal, decimalVal)

         'Decimal to Long conversion can overflow.
         Try
             longVal = System.Convert.ToInt64(decimalVal)
             System.Console.WriteLine("{0} as a Long is {1}", _
                                       decimalVal, longVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in decimal-to-long conversion.")
         End Try
     End Sub