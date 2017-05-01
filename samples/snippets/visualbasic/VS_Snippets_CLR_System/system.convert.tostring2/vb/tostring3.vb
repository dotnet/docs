' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ConvertDateTimeWithProvider()
      Console.WriteLine("-----")
      ConvertDecimalWithProvider()
      Console.WriteLine("-----")
      ConvertDoubleWithProvider()
      Console.WriteLine("-----")
      ConvertByteWithProvider()
      Console.WriteLine("-----")
      ConvertSByteWithProvider()
      Console.WriteLine("-----")
      ConvertSingleWithProvider()
      Console.WriteLine("-----")
      ConvertInt16WithProvider()
      Console.WriteLine("-----")
      ConvertInt32WithProvider()
      Console.WriteLine("-----")
      ConvertInt64WithProvider()
      Console.WriteLine("-----")
      ConvertUInt16WithProvider()
      Console.WriteLine("-----")
      ConvertUInt32WithProvider()
      Console.WriteLine("-----")
      ConvertUInt64WithProvider()
   End Sub
   
   Private Sub ConvertDateTimeWithProvider()
      ' <Snippet13>
      ' Specify the date to be formatted using various cultures.
      Dim tDate As New Date(2010, 4, 15, 20, 30, 40, 333)
      ' Specify the cultures.
      Dim cultureNames() As String = { "en-US", "es-AR", "fr-FR", "hi-IN", _
                                       "ja-JP", "nl-NL", "ru-RU", "ur-PK" }
      
      Console.WriteLine("Converting the date {0}: ", _
                        Convert.ToString(tDate, _
                                System.Globalization.CultureInfo.InvariantCulture))

      For Each cultureName As String In CultureNames
         Dim culture As New System.Globalization.CultureInfo(cultureName)
         Dim dateString As String = Convert.ToString(tDate, culture)
         Console.WriteLine("   {0}:  {1,-12}", _
                           culture.Name, dateString)
      Next             
      ' The example displays the following output:
      '       Converting the date 04/15/2010 20:30:40:
      '          en-US:  4/15/2010 8:30:40 PM
      '          es-AR:  15/04/2010 08:30:40 p.m.
      '          fr-FR:  15/04/2010 20:30:40
      '          hi-IN:  15-04-2010 20:30:40
      '          ja-JP:  2010/04/15 20:30:40
      '          nl-NL:  15-4-2010 20:30:40
      '          ru-RU:  15.04.2010 20:30:40
      '          ur-PK:  15/04/2010 8:30:40 PM      
      ' </Snippet13>
    End Sub 

   Private Sub ConvertDecimalWithProvider()
      ' <Snippet14>
      ' Define an array of numbers to display.
      Dim numbers() As Decimal = { 1734231911290.16d, -17394.32921d, _
                                   3193.23d, 98012368321.684d }
      ' Define the culture names used to display them.
      Dim cultureNames() As String = { "en-US", "fr-FR", "ja-JP", "ru-RU" }
      
      For Each number As Decimal In numbers
         Console.WriteLine("{0}:", Convert.ToString(number, _
                                   System.Globalization.CultureInfo.InvariantCulture))
         For Each cultureName As String In cultureNames
            Dim culture As New System.Globalization.CultureInfo(cultureName)
            Console.WriteLine("   {0}: {1,20}", _
                              culture.Name, Convert.ToString(number, culture))
         Next
         Console.WriteLine()
      Next   
      ' The example displays the following output:
      '    1734231911290.16:
      '       en-US:     1734231911290.16
      '       fr-FR:     1734231911290,16
      '       ja-JP:     1734231911290.16
      '       ru-RU:     1734231911290,16
      '    
      '    -17394.32921:
      '       en-US:         -17394.32921
      '       fr-FR:         -17394,32921
      '       ja-JP:         -17394.32921
      '       ru-RU:         -17394,32921
      '    
      '    3193.23:
      '       en-US:              3193.23
      '       fr-FR:              3193,23
      '       ja-JP:              3193.23
      '       ru-RU:              3193,23
      '    
      '    98012368321.684:
      '       en-US:      98012368321.684
      '       fr-FR:      98012368321,684
      '       ja-JP:      98012368321.684
      '       ru-RU:      98012368321,684
      ' </Snippet14>
   End Sub
   
   Private Sub ConvertDoubleWithProvider()
      ' <Snippet15>
      ' Define an array of numbers to display.
      Dim numbers() As Double = { -1.5345e16, -123.4321, 19092.123, _
                                  1.1734231911290e16 }
      ' Define the culture names used to display them.
      Dim cultureNames() As String = { "en-US", "fr-FR", "ja-JP", "ru-RU" }
      
      For Each number As Double In numbers
         Console.WriteLine("{0}:", Convert.ToString(number, _
                                   System.Globalization.CultureInfo.InvariantCulture))
         For Each cultureName As String In cultureNames
            Dim culture As New System.Globalization.CultureInfo(cultureName)
            Console.WriteLine("   {0}: {1,20}", _
                              culture.Name, Convert.ToString(number, culture))
         Next
         Console.WriteLine()
      Next   
      ' The example displays the following output:
      '    -1.5345E+16:
      '       en-US:          -1.5345E+16
      '       fr-FR:          -1,5345E+16
      '       ja-JP:          -1.5345E+16
      '       ru-RU:          -1,5345E+16
      '    
      '    -123.4321:
      '       en-US:            -123.4321
      '       fr-FR:            -123,4321
      '       ja-JP:            -123.4321
      '       ru-RU:            -123,4321
      '    
      '    19092.123:
      '       en-US:            19092.123
      '       fr-FR:            19092,123
      '       ja-JP:            19092.123
      '       ru-RU:            19092,123
      '    
      '    1.173423191129E+16:
      '       en-US:   1.173423191129E+16
      '       fr-FR:   1,173423191129E+16
      '       ja-JP:   1.173423191129E+16
      '       ru-RU:   1,173423191129E+16
      ' </Snippet15>
   End Sub
   
   Private Sub ConvertByteWithProvider()
      ' <Snippet16>
      ' Define an array of numbers to display.
      Dim numbers() As Byte = { 12, 100, Byte.MaxValue }
      ' Define the culture names used to display them.
      Dim cultureNames() As String = { "en-US", "fr-FR" }
      
      For Each number As Byte In numbers
         Console.WriteLine("{0}:", Convert.ToString(number, _
                                   System.Globalization.CultureInfo.InvariantCulture))
         For Each cultureName As String In cultureNames
            Dim culture As New System.Globalization.CultureInfo(cultureName)
            Console.WriteLine("   {0}: {1,20}", _
                              culture.Name, Convert.ToString(number, culture))
         Next
         Console.WriteLine()
      Next   
      ' The example displays the following output:
      '       12:
      '          en-US:                   12
      '          fr-FR:                   12
      '       
      '       100:
      '          en-US:                  100
      '          fr-FR:                  100
      '       
      '       255:
      '          en-US:                  255
      '          fr-FR:                  255      
      ' </Snippet16>
   End Sub   
   
   Private Sub ConvertSByteWithProvider()
      ' <Snippet17>
      Dim numbers() As SByte = { SByte.MinValue, -12, 17, SByte.MaxValue}
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      For Each number As SByte In numbers
         Console.WriteLine(Convert.ToString(number, nfi))
      Next
      ' The example displays the following output:
      '       ~128
      '       ~12
      '       17
      '       127          
      ' </Snippet17>
   End Sub   

   Private Sub ConvertSingleWithProvider()
      ' <Snippet18>
      ' Define an array of numbers to display.
      Dim numbers() As Single = { -1.5345e16, -123.4321, 19092.123, _
                                  1.1734231911290e16 }
      ' Define the culture names used to display them.
      Dim cultureNames() As String = { "en-US", "fr-FR", "ja-JP", "ru-RU" }
      
      For Each number As Single In numbers
         Console.WriteLine("{0}:", Convert.ToString(number, _
                                   System.Globalization.CultureInfo.InvariantCulture))
         For Each cultureName As String In cultureNames
            Dim culture As New System.Globalization.CultureInfo(cultureName)
            Console.WriteLine("   {0}: {1,20}", _
                              culture.Name, Convert.ToString(number, culture))
         Next
         Console.WriteLine()
      Next   
      ' The example displays the following output:
      '    -1.5345E+16:
      '       en-US:          -1.5345E+16
      '       fr-FR:          -1,5345E+16
      '       ja-JP:          -1.5345E+16
      '       ru-RU:          -1,5345E+16
      '    
      '    -123.4321:
      '       en-US:            -123.4321
      '       fr-FR:            -123,4321
      '       ja-JP:            -123.4321
      '       ru-RU:            -123,4321
      '    
      '    19092.123:
      '       en-US:            19092.123
      '       fr-FR:            19092,123
      '       ja-JP:            19092.123
      '       ru-RU:            19092,123
      '    
      '    1.173423191129E+16:
      '       en-US:   1.173423191129E+16
      '       fr-FR:   1,173423191129E+16
      '       ja-JP:   1.173423191129E+16
      '       ru-RU:   1,173423191129E+16
      ' </Snippet18>
   End Sub

   Private Sub ConvertInt16WithProvider()
      ' <Snippet19>
      Dim numbers() As Short = { Int16.MinValue, Int16.MaxValue}
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      For Each number As Short In numbers
         Console.WriteLine("{0,-8}  -->  {1,8}", _
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                           Convert.ToString(number, nfi))
      Next
      ' The example displays the following output:
      '       -32768    -->    ~32768
      '       32767     -->     32767
      ' </Snippet19>
   End Sub   

   Private Sub ConvertInt32WithProvider()
      ' <Snippet20>
      Dim numbers() As Integer = { Int32.MinValue, Int32.MaxValue}
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      For Each number As Integer In numbers
         Console.WriteLine("{0,-12}  -->  {1,12}", _
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                           Convert.ToString(number, nfi))
      Next
      ' The example displays the following output:
      '       -2147483648  -->  ~2147483648
      '       2147483647   -->  2147483647
      ' </Snippet20>
   End Sub   


   Private Sub ConvertInt64WithProvider()
      ' <Snippet21>
      Dim numbers() As Long = { CLng(Int32.MinValue) * 2, CLng(Int32.MaxValue) * 2 }
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      For Each number As Long In numbers
         Console.WriteLine("{0,-12}  -->  {1,12}", _
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                           Convert.ToString(number, nfi))
      Next
      ' The example displays the following output:
      '       -4294967296  -->  ~4294967296
      '       4294967294   -->  4294967294
      ' </Snippet21>
   End Sub 
   
   Private Sub ConvertUInt16WithProvider()
      ' <Snippet22>
      Dim number As UShort = UInt16.MaxValue
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      Console.WriteLine("{0,-6}  -->  {1,6}", _
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                        Convert.ToString(number, nfi))
      ' The example displays the following output:
      '       65535   -->   65535
      ' </Snippet22>
   End Sub   
   
   Private Sub ConvertUInt32WithProvider()
      ' <Snippet23>
      Dim number As UInteger = UInt32.MaxValue
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      Console.WriteLine("{0,-8}  -->  {1,8}", _
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                        Convert.ToString(number, nfi))
      ' The example displays the following output:
      '       4294967295  -->  4294967295
      ' </Snippet23>
   End Sub   
   
   Private Sub ConvertUInt64WithProvider()
      ' <Snippet24>
      Dim number As ULong = UInt64.MaxValue
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      Console.WriteLine("{0,-12}  -->  {1,12}", _
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                        Convert.ToString(number, nfi))
      ' The example displays the following output:
      '    18446744073709551615  -->  18446744073709551615
      ' </Snippet24>
   End Sub   
End Module 

