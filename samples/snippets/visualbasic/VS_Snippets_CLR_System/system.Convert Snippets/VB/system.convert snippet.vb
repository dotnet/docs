 Class ConvertSnippet
     Overloads Shared Sub Main(ByVal args() As String)

         Dim snippet As New ConvertSnippet()

         Dim doubleVal As Double
         System.Console.WriteLine("Enter the double value: ")
         doubleVal = System.Convert.ToDouble(System.Console.ReadLine())
         snippet.ConvertDoubles(doubleVal)

         Dim longVal As Long
         System.Console.WriteLine("Enter the Int64 value: ")
         longVal = System.Convert.ToInt64(System.Console.ReadLine())
         snippet.ConvertLongs(longVal)

         Dim stringVal As String
         System.Console.WriteLine("Enter the String value: ")
         stringVal = System.Console.ReadLine()
         snippet.ConvertStrings(stringVal)

         Dim charVal As Char
         System.Console.WriteLine("Enter the char value: ")
         charVal = System.Convert.ToChar(System.Console.ReadLine())
         snippet.ConvertChars(charVal)

         Dim byteVal As Byte
         System.Console.WriteLine("Enter the byte value: ")
         byteVal = System.Convert.ToByte(System.Console.ReadLine())
         snippet.ConvertBytes(byteVal)

         snippet.ConvertBoolean()
     End Sub

     '<Snippet20>
     Public Sub ConvertBoolean()
         Const year As Integer = 1979
         Const month As Integer = 7
         Const day As Integer = 28
         Const hour As Integer = 13
         Const minute As Integer = 26
         Const second As Integer = 15
         Const millisecond As Integer = 53

         Dim dateTime As New DateTime(year, month, day, hour, minute, _
                                      second, millisecond)

         Dim boolVal As Boolean

         ' System.InvalidCastException is always thrown.
         Try
             boolVal = System.Convert.ToBoolean(dateTime)
         Catch exception As System.InvalidCastException
             System.Console.WriteLine("Conversion from DateTime to " + _
                     "Boolean is not supported by the .NET Framework.")
         End Try
     End Sub
     '</Snippet20>

     Public Sub ConvertBytes(ByVal byteVal As Byte)
         ConvertByteDecimal(byteVal)
         ConvertByteSingle(byteVal)
     End Sub

     '<Snippet18>
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
     '</Snippet18>

     '<Snippet19>
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
     '</Snippet19>

     Public Sub ConvertChars(ByVal charVal As Char)
         ConvertCharDecimal(charVal)
     End Sub

     '<Snippet17>
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
     '</Snippet17>

     Public Sub ConvertDoubles(ByVal doubleVal As Double)
         ConvertDoubleBool(doubleVal)
         ConvertDoubleByte(doubleVal)
         ConvertDoubleInt(doubleVal)
         ConvertDoubleDecimal(CDec(doubleVal))
         CovertDoubleFloat(doubleVal)
         ConvertDoubleString(doubleVal)
     End Sub 

      '<Snippet1>
     Public Sub ConvertDoubleBool(ByVal doubleVal As Double)
         Dim boolVal As Boolean

         'Double to Boolean conversion cannot overflow.
         boolVal = System.Convert.ToBoolean(doubleVal)
         System.Console.WriteLine("{0} as a Boolean is: {1}.", _
                                   doubleVal, boolVal)

         'Boolean to Double conversion cannot overflow.
         doubleVal = System.Convert.ToDouble(boolVal)
         System.Console.WriteLine("{0} as a Double is: {1}.", _
                                   boolVal, doubleVal)
     End Sub
     '</Snippet1>

     '<Snippet2>
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
     '</Snippet2>

     '<Snippet5>
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
     '</Snippet5>

     '<Snippet6>
     Public Sub CovertDoubleFloat(ByVal doubleVal As Double)
         Dim singleVal As Single = 0

         ' Double to Single conversion cannot overflow.
             singleVal = System.Convert.ToSingle(doubleVal)
             System.Console.WriteLine("{0} as a Single is {1}", _
                                       doubleVal, singleVal)

         ' Conversion from Single to Double cannot overflow.
         doubleVal = System.Convert.ToDouble(singleVal)
         System.Console.WriteLine("{0} as a Double is: {1}", _
                                   singleVal, doubleVal)
     End Sub
     '</Snippet6>

     '<Snippet3>
     Public Sub ConvertDoubleInt(ByVal doubleVal As Double)

         Dim intVal As Integer = 0
         ' Double to Integer conversion can overflow.
         Try
             intVal = System.Convert.ToInt32(doubleVal)
             System.Console.WriteLine("{0} as an Integer is: {1}", _
                                       doubleVal, intVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in Double-to-Byte conversion.")
         End Try

         ' Integer to Double conversion cannot overflow.
         doubleVal = System.Convert.ToDouble(intVal)
         System.Console.WriteLine("{0} as a Double is: {1}", _
                                   intVal, doubleVal)
     End Sub
     '</Snippet3>

     '<Snippet7>
     Public Sub ConvertDoubleString(ByVal doubleVal As Double)

         Dim stringVal As String

         ' A conversion from Double to String cannot overflow.       
         stringVal = System.Convert.ToString(doubleVal)
         System.Console.WriteLine("{0} as a String is: {1}", _
                                   doubleVal, stringVal)

         Try
             doubleVal = System.Convert.ToDouble(stringVal)
             System.Console.WriteLine("{0} as a Double is: {1}", _
                                       stringVal, doubleVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in String-to-Double conversion.")
         Catch exception As System.FormatException
             System.Console.WriteLine( _
                 "The string is not formatted as a Double.")
         Catch exception As System.ArgumentException
             System.Console.WriteLine("The string is null.")
         End Try

     End Sub
     '</Snippet7>

     Public Sub ConvertLongs(ByVal longVal As Long)
         ConvertLongChar(longVal)
         ConvertLongByte(longVal)
         ConvertLongDecimal(longVal)
         ConvertLongFloat(longVal)
     End Sub

     '<Snippet9>
     Public Sub ConvertLongByte(ByVal longVal As Long)

         Dim byteVal As Byte = 0

         ' A conversion from Long to Byte can overflow.
         Try
             byteVal = System.Convert.ToByte(longVal)
             System.Console.WriteLine("{0} as a Byte is {1}", _
                                       longVal, byteVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in Long-to-Byte conversion.")
         End Try

         ' A conversion from Byte to Long cannot overflow.
         longVal = System.Convert.ToInt64(byteVal)
         System.Console.WriteLine("{0} as an Long is {1}", _
                                   byteVal, longVal)
     End Sub
     '</Snippet9>

     '<Snippet8>
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
     '</Snippet8>

     '<Snippet10>
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
     '</Snippet10>

     '<Snippet11>
     Public Sub ConvertLongFloat(ByVal longVal As Long)

         Dim floatVal As Single

         ' A conversion from Long to float cannot overflow.
         floatVal = System.Convert.ToSingle(longVal)
         System.Console.WriteLine("{0} as a float is {1}", _
                                   longVal, floatVal)

         ' A conversion from float to long can overflow.
         Try
             longVal = System.Convert.ToInt64(floatVal)
             System.Console.WriteLine("{0} as a Long is {1}", _
                                       floatVal, longVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in float-to-long conversion.")
         End Try
     End Sub
     '</Snippet11>

     Public Sub ConvertStrings(ByVal stringVal As String)
         ConvertStringBoolean(stringVal)
         ConvertStringByte(stringVal)
         ConvertStringChar(stringVal)
         ConvertStringDecimal(stringVal)
         ConvertStringFloat(stringVal)
     End Sub

     '<Snippet12>
     Public Sub ConvertStringBoolean(ByVal stringVal As String)

         Dim boolVal As Boolean = False

         Try
             boolVal = System.Convert.ToBoolean(stringVal)
             If boolVal Then
                 System.Console.WriteLine( _
                     "String is equal to System.Boolean.TrueString.")
             Else
                 System.Console.WriteLine( _
                     "String is equal to System.Boolean.FalseString.")
             End If
         Catch exception As System.FormatException
             System.Console.WriteLine( _
                 "The string must equal System.Boolean.TrueString " + _
                 "or System.Boolean.FalseString.")
         End Try

         ' A conversion from bool to string will always succeed.
         stringVal = System.Convert.ToString(boolVal)
         System.Console.WriteLine("{0} as a String is {1}", _
                                   boolVal, stringVal)
     End Sub
     '</Snippet12>

     '<Snippet13>
     Public Sub ConvertStringByte(ByVal stringVal As String)
         Dim byteVal As Byte = 0

         Try
             byteVal = System.Convert.ToByte(stringVal)
             System.Console.WriteLine("{0} as a byte is: {1}", _
                                       stringVal, byteVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in string-to-byte conversion.")
         Catch exception As System.FormatException
             System.Console.WriteLine( _
                 "The String is not formatted as a Byte.")
         Catch exception As System.ArgumentException
             System.Console.WriteLine("The String is null.")
         End Try

         'The conversion from byte to string is always valid.
         stringVal = System.Convert.ToString(byteVal)
         System.Console.WriteLine("{0} as a string is {1}", _
                                   byteVal, stringVal)
     End Sub
     '</Snippet13>

     '<Snippet14>
     Public Sub ConvertStringChar(ByVal stringVal As String)
         Dim charVal As Char = "a"c

         ' A string must be one character long to convert to char.
         Try
             charVal = System.Convert.ToChar(stringVal)
             System.Console.WriteLine("{0} as a char is {1}", _
                                       stringVal, charVal)
         Catch exception As System.FormatException
             System.Console.WriteLine( _
              "The string is longer than one character.")
         Catch exception As System.ArgumentNullException
             System.Console.WriteLine("The string is null.")
         End Try

         ' A char to string conversion will always succeed.
         stringVal = System.Convert.ToString(charVal)
         System.Console.WriteLine("The character as a string is {0}", _
                                   stringVal)
     End Sub
     '</Snippet14>

     '<Snippet15>
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
     '</Snippet15>

     '<Snippet16>
     Public Sub ConvertStringFloat(ByVal stringVal As String)
         Dim singleVal As Single = 0

         Try
             singleVal = System.Convert.ToSingle(singleVal)
             System.Console.WriteLine("The string as a single is {0}.", _
                                       singleVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in string-to-single conversion.")
         Catch exception As System.FormatException
             System.Console.WriteLine( _
                 "The string is not formatted as a Single.")
         Catch exception As System.ArgumentException
             System.Console.WriteLine("The string is null.")
         End Try

         ' Single to string conversion will not overflow.
         stringVal = System.Convert.ToString(singleVal)
         System.Console.WriteLine("The single as a string is {0}.", _
                                   stringVal)
     End Sub
     '</Snippet16>

 End Class
