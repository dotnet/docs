     Public Sub ConvertByteSingle(ByVal byteVal As Byte)
         Dim singleVal As Single

         ' Byte to float conversion will not overflow.
         singleVal = System.Convert.ToSingle(byteVal)
         System.Console.WriteLine("The byte as a single is {0}.", _
                                   singleVal)

         ' Single to byte conversion can overflow.
         Try
             byteVal = System.Convert.ToByte(singleVal)
             System.Console.WriteLine("The single as a byte is {0}.", _
                                       byteVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in single-to-byte conversion.")
         End Try
     End Sub