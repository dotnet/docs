' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module Example
   Public Sub Main()
      PadInteger()
      Console.WriteLine("-----")
      PadIntegerWithNZeroes()
      Console.WriteLine("-----")
      PadNumber()
      Console.WriteLine("-----")
      PadNumberWithNZeroes()
   End Sub
   
   Private Sub PadInteger()
      ' <Snippet1>
      Dim byteValue As Byte = 254
      Dim shortValue As Short = 10342
      Dim intValue As Integer = 1023983
      Dim lngValue As Long = 6985321               
      Dim ulngValue As ULong = UInt64.MaxValue
      
      ' Display integer values by calling the ToString method.
      Console.WriteLine("{0,22} {1,22}", byteValue.ToString("D8"), byteValue.ToString("X8"))
      Console.WriteLine("{0,22} {1,22}", shortValue.ToString("D8"), shortValue.ToString("X8"))
      Console.WriteLine("{0,22} {1,22}", intValue.ToString("D8"), intValue.ToString("X8"))
      Console.WriteLine("{0,22} {1,22}", lngValue.ToString("D8"), lngValue.ToString("X8"))
      Console.WriteLine("{0,22} {1,22}", ulngValue.ToString("D8"), ulngValue.ToString("X8"))
      Console.WriteLine()
      
      ' Display the same integer values by using composite formatting.
      Console.WriteLine("{0,22:D8} {0,22:X8}", byteValue)
      Console.WriteLine("{0,22:D8} {0,22:X8}", shortValue)
      Console.WriteLine("{0,22:D8} {0,22:X8}", intValue)
      Console.WriteLine("{0,22:D8} {0,22:X8}", lngValue)
      Console.WriteLine("{0,22:D8} {0,22:X8}", ulngValue)
      ' The example displays the following output:
      '                     00000254               000000FE
      '                     00010342               00002866
      '                     01023983               000F9FEF
      '                     06985321               006A9669
      '         18446744073709551615       FFFFFFFFFFFFFFFF
      '       
      '                     00000254               000000FE
      '                     00010342               00002866
      '                     01023983               000F9FEF
      '                     06985321               006A9669
      '         18446744073709551615       FFFFFFFFFFFFFFFF
        ' </Snippet1>
   End Sub
   
   Private Sub PadIntegerWithNZeroes()
      ' <Snippet2>
      Dim value As Integer = 160934
      Dim decimalLength As Integer = value.ToString("D").Length + 5
      Dim hexLength As Integer = value.ToString("X").Length + 5
      Console.WriteLine(value.ToString("D" + decimalLength.ToString()))
      Console.WriteLine(value.ToString("X" + hexLength.ToString()))
      ' The example displays the following output:
      '       00000160934
      '       00000274A6      
      ' </Snippet2>
   End Sub

   Private Sub PadNumber()
      ' <Snippet3>
      Dim fmt As String = "00000000.##"
      Dim intValue As Integer = 1053240
      Dim decValue As Decimal = 103932.52d
      Dim sngValue As Single = 1549230.10873992
      Dim dblValue As Double = 9034521202.93217412
      
      ' Display the numbers using the ToString method.
      Console.WriteLine(intValue.ToString(fmt))
      Console.WriteLine(decValue.ToString(fmt))            
      Console.WriteLine(sngValue.ToString(fmt))
      Console.WriteLine(dblValue.ToString(fmt))            
      Console.WriteLine()
      
      ' Display the numbers using composite formatting.
      Dim formatString As String = " {0,15:" + fmt + "}"
      Console.WriteLine(formatString, intValue)      
      Console.WriteLine(formatString, decValue)      
      Console.WriteLine(formatString, sngValue)      
      Console.WriteLine(formatString, dblValue)      
      ' The example displays the following output:
      '       01053240
      '       00103932.52
      '       01549230
      '       9034521202.93
      '       
      '               01053240
      '            00103932.52
      '               01549230
      '          9034521202.93      
      ' </Snippet3>
   End Sub
   
   Private Sub PadNumberWithNZeroes()
      ' <Snippet4>
      Dim dblValues() As Double = { 9034521202.93217412, 9034521202 }
      For Each dblValue As Double In dblValues
         Dim decSeparator As String = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator
         Dim fmt, formatString As String
         
         If dblValue.ToString.Contains(decSeparator) Then
            Dim digits As Integer = dblValue.ToString().IndexOf(decSeparator)
            fmt = New String("0"c, 5) + New String("#"c, digits) + ".##"
         Else
            fmt = New String("0"c, dblValue.ToString.Length)   
         End If
         formatString = "{0,20:" + fmt + "}"

         Console.WriteLine(dblValue.ToString(fmt))
         Console.WriteLine(formatString, dblValue)
      Next
      ' The example displays the following output:
      '       000009034521202.93
      '         000009034521202.93
      '       9034521202
      '                 9034521202            
      ' </Snippet4>
   End Sub
End Module

