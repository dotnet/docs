     Public Sub ConvertDoubleDecimal(ByVal decimalVal As Decimal)

         Dim doubleVal As Double

         ' Decimal to Double conversion cannot overflow.
         doubleVal = System.Convert.ToDouble(decimalVal)
         System.Console.WriteLine("{0} as a Double is: {1}", _
                                  decimalVal, doubleVal)
         
         ' Conversion from Double to Decimal can overflow.
         Try
            decimalVal = System.Convert.ToDecimal(doubleVal)
            System.Console.WriteLine("{0} as a Decimal is: {1}", _
                                     doubleVal, decimalVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in Double-to-Decimal conversion.")
         End Try

     End Sub