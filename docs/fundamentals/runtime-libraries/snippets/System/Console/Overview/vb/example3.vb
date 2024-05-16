
' dump a range of Unicode characters as a 16x16 array
' <Snippet4>
Imports System.IO
Imports System.Globalization
Imports System.Text

Public Module DisplayChars
   Public Sub Main(args() As String)
      Dim rangeStart As UInteger = 0
      Dim rangeEnd As UInteger = 0
      Dim setOutputEncodingToUnicode As Boolean = True
      ' Get the current encoding so we can restore it.
      Dim originalOutputEncoding As Encoding = Console.OutputEncoding

   	Try
         Select Case args.Length
            Case 2
               rangeStart = UInt32.Parse(args(0), NumberStyles.HexNumber)
               rangeEnd = UInt32.Parse(args(1), NumberStyles.HexNumber)
               setOutputEncodingToUnicode = True
            Case 3
               If Not UInt32.TryParse(args(0), NumberStyles.HexNumber, Nothing, rangeStart) Then
                  Throw New ArgumentException(String.Format("{0} is not a valid hexadecimal number.", args(0)))
               End If
               
               If Not UInt32.TryParse(args(1), NumberStyles.HexNumber, Nothing, rangeEnd) Then
                  Throw New ArgumentException(String.Format("{0} is not a valid hexadecimal number.", args(1)))
               End If
               
               Boolean.TryParse(args(2), setOutputEncodingToUnicode)
            Case Else
               Console.WriteLine("Usage: {0} <{1}> <{2}> [{3}]", 
                                 Environment.GetCommandLineArgs()(0), 
                                 "startingCodePointInHex", 
                                 "endingCodePointInHex", 
                                 "<setOutputEncodingToUnicode?{true|false, default:false}>")
               Exit Sub
         End Select
   
         If setOutputEncodingToUnicode Then
            ' This won't work before .NET Framework 4.5.
            Try 
               ' Set encoding Imports endianness of this system.
               ' We're interested in displaying individual Char objects, so 
               ' we don't want a Unicode BOM or exceptions to be thrown on
               ' invalid Char values.
               Console.OutputEncoding = New UnicodeEncoding(Not BitConverter.IsLittleEndian, False) 
               Console.WriteLine("{0}Output encoding set to UTF-16", vbCrLf)
            Catch e As IOException
               Console.OutputEncoding = New UTF8Encoding()
               Console.WriteLine("Output encoding set to UTF-8")
            End Try
         Else
            Console.WriteLine("The console encoding is {0} (code page {1})", 
                              Console.OutputEncoding.EncodingName,
                              Console.OutputEncoding.CodePage)
         End If
         DisplayRange(rangeStart, rangeEnd)
      Catch ex As ArgumentException
         Console.WriteLine(ex.Message)
      Finally
         ' Restore console environment.
         Console.OutputEncoding = originalOutputEncoding
      End Try
   End Sub

   Public Sub DisplayRange(rangeStart As UInteger, rangeEnd As UInteger)
      Const upperRange As UInteger = &h10FFFF
      Const surrogateStart As UInteger = &hD800
      Const surrogateEnd As UInteger = &hDFFF
       
      If rangeEnd <= rangeStart Then
         Dim t As UInteger = rangeStart
         rangeStart = rangeEnd
         rangeEnd = t
      End If

      ' Check whether the start or end range is outside of last plane.
      If rangeStart > upperRange Then
         Throw New ArgumentException(String.Format("0x{0:X5} is outside the upper range of Unicode code points (0x{1:X5})",
                                                   rangeStart, upperRange))                                   
      End If
      If rangeEnd > upperRange Then
         Throw New ArgumentException(String.Format("0x{0:X5} is outside the upper range of Unicode code points (0x{0:X5})",
                                                   rangeEnd, upperRange))
      End If
      ' Since we're using 21-bit code points, we can't use U+D800 to U+DFFF.
      If (rangeStart < surrogateStart And rangeEnd > surrogateStart) OrElse (rangeStart >= surrogateStart And rangeStart <= surrogateEnd )
         Throw New ArgumentException(String.Format("0x{0:X5}-0x{1:X5} includes the surrogate pair range 0x{2:X5}-0x{3:X5}", 
                                                   rangeStart, rangeEnd, surrogateStart, surrogateEnd))         
      End If
      
      Dim last As UInteger = RoundUpToMultipleOf(&h10, rangeEnd)
      Dim first As UInteger = RoundDownToMultipleOf(&h10, rangeStart)

      Dim rows As UInteger = (last - first) \ &h10

      For r As UInteger = 0 To rows - 1
         ' Display the row header.
         Console.Write("{0:x5} ", first + &h10 * r)

         For c As UInteger = 1 To &h10
            Dim cur As UInteger = first + &h10 * r + c
            If cur  < rangeStart Then
               Console.Write(" {0} ", Convert.ToChar(&h20))
            Else If rangeEnd < cur Then
               Console.Write(" {0} ", Convert.ToChar(&h20))
            Else 
               ' the cast to int is safe, since we know that val <= upperRange.
               Dim chars As String = Char.ConvertFromUtf32(CInt(cur))
               ' Display a space for code points that are not valid characters.
               If CharUnicodeInfo.GetUnicodeCategory(chars(0)) = 
                                   UnicodeCategory.OtherNotAssigned Then
                  Console.Write(" {0} ", Convert.ToChar(&h20))
               ' Display a space for code points in the private use area.
               Else If CharUnicodeInfo.GetUnicodeCategory(chars(0)) =
                                        UnicodeCategory.PrivateUse Then
                 Console.Write(" {0} ", Convert.ToChar(&h20))
               ' Is surrogate pair a valid character?
               ' Note that the console will interpret the high and low surrogate
               ' as separate (and unrecognizable) characters.
               Else If chars.Length > 1 AndAlso CharUnicodeInfo.GetUnicodeCategory(chars, 0) = 
                                            UnicodeCategory.OtherNotAssigned Then
                  Console.Write(" {0} ", Convert.ToChar(&h20))
               Else
                  Console.Write(" {0} ", chars) 
               End If   
            End If
            
            Select Case c
               Case 3, 11
                  Console.Write("-")
               Case 7
                  Console.Write("--")
            End Select
         Next

         Console.WriteLine()
         If 0 < r AndAlso r Mod &h10 = 0
            Console.WriteLine()
         End If
      Next
   End Sub

   Private Function RoundUpToMultipleOf(b As UInteger, u As UInteger) As UInteger
      Return RoundDownToMultipleOf(b, u) + b
   End Function

   Private Function RoundDownToMultipleOf(b As UInteger, u As UInteger) As UInteger
      Return u - (u Mod b)
   End Function
End Module
' If the example is run with the command line
'       DisplayChars 0400 04FF true
' the example displays the Cyrillic character set as follows:
'       Output encoding set to UTF-16
'       00400  Ѐ  Ё  Ђ  Ѓ - Є  Ѕ  І  Ї -- Ј  Љ  Њ  Ћ - Ќ  Ѝ  Ў  Џ
'       00410  А  Б  В  Г - Д  Е  Ж  З -- И  Й  К  Л - М  Н  О  П
'       00420  Р  С  Т  У - Ф  Х  Ц  Ч -- Ш  Щ  Ъ  Ы - Ь  Э  Ю  Я
'       00430  а  б  в  г - д  е  ж  з -- и  й  к  л - м  н  о  п
'       00440  р  с  т  у - ф  х  ц  ч -- ш  щ  ъ  ы - ь  э  ю  я
'       00450  ѐ  ё  ђ  ѓ - є  ѕ  і  ї -- ј  љ  њ  ћ - ќ  ѝ  ў  џ
'       00460  Ѡ  ѡ  Ѣ  ѣ - Ѥ  ѥ  Ѧ  ѧ -- Ѩ  ѩ  Ѫ  ѫ - Ѭ  ѭ  Ѯ  ѯ
'       00470  Ѱ  ѱ  Ѳ  ѳ - Ѵ  ѵ  Ѷ  ѷ -- Ѹ  ѹ  Ѻ  ѻ - Ѽ  ѽ  Ѿ  ѿ
'       00480  Ҁ  ҁ  ҂  ҃ - ҄  ҅  ҆  ҇ -- ҈  ҉  Ҋ  ҋ - Ҍ  ҍ  Ҏ  ҏ
'       00490  Ґ  ґ  Ғ  ғ - Ҕ  ҕ  Җ  җ -- Ҙ  ҙ  Қ  қ - Ҝ  ҝ  Ҟ  ҟ
'       004a0  Ҡ  ҡ  Ң  ң - Ҥ  ҥ  Ҧ  ҧ -- Ҩ  ҩ  Ҫ  ҫ - Ҭ  ҭ  Ү  ү
'       004b0  Ұ  ұ  Ҳ  ҳ - Ҵ  ҵ  Ҷ  ҷ -- Ҹ  ҹ  Һ  һ - Ҽ  ҽ  Ҿ  ҿ
'       004c0  Ӏ  Ӂ  ӂ  Ӄ - ӄ  Ӆ  ӆ  Ӈ -- ӈ  Ӊ  ӊ  Ӌ - ӌ  Ӎ  ӎ  ӏ
'       004d0  Ӑ  ӑ  Ӓ  ӓ - Ӕ  ӕ  Ӗ  ӗ -- Ә  ә  Ӛ  ӛ - Ӝ  ӝ  Ӟ  ӟ
'       004e0  Ӡ  ӡ  Ӣ  ӣ - Ӥ  ӥ  Ӧ  ӧ -- Ө  ө  Ӫ  ӫ - Ӭ  ӭ  Ӯ  ӯ
'       004f0  Ӱ  ӱ  Ӳ  ӳ - Ӵ  ӵ  Ӷ  ӷ -- Ӹ  ӹ  Ӻ  ӻ - Ӽ  ӽ  Ӿ  ӿ
' </Snippet4>
