     Public Sub ConvertDoubleByte(ByVal doubleVal As Double)
         Dim byteVal As Byte = 0

         ' Double to Byte conversion can overflow.
         Try
             byteVal = System.Convert.ToByte(doubleVal)
             System.Console.WriteLine("{0} as a Byte is: {1}.", _
                 doubleVal, byteVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in Double-to-Byte conversion.")
         End Try

         ' Byte to Double conversion cannot overflow.
         doubleVal = System.Convert.ToDouble(byteVal)
         System.Console.WriteLine("{0} as a Double is: {1}.", _
                                   byteVal, doubleVal)
     End Sub