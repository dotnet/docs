     Public Sub ConvertCharDecimal(ByVal charVal As Char)
         Dim decimalVal As [Decimal] = 0

         ' Char to decimal conversion is not supported and will always
         ' throw an InvalidCastException.
         Try
             decimalVal = System.Convert.ToDecimal(charVal)
         Catch exception As System.InvalidCastException
             System.Console.WriteLine( _
                  "Char-to-Decimal conversion is not supported " + _
                  "by the .NET Framework.")
         End Try

         'Decimal to char conversion is also not supported.
         Try
             charVal = System.Convert.ToChar(decimalVal)
         Catch exception As System.InvalidCastException
             System.Console.WriteLine( _
                 "Decimal-to-Char conversion is not supported " + _
                 "by the .NET Framework.")
         End Try
     End Sub