     Public Sub ConvertByteDecimal(ByVal byteVal As Byte)
         Dim decimalVal As Decimal

         ' Byte to decimal conversion will not overflow.
         decimalVal = System.Convert.ToDecimal(byteVal)
         System.Console.WriteLine("The byte as a decimal is {0}.", _
                                   decimalVal)

         ' Decimal to byte conversion can overflow.
         Try
             byteVal = System.Convert.ToByte(decimalVal)
             System.Console.WriteLine("The Decimal as a byte is {0}.", _
                                       byteVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in decimal-to-byte conversion.")
         End Try
     End Sub