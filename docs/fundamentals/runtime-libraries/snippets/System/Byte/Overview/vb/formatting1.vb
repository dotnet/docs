﻿' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      CallToString()
      Console.WriteLine("-----")
      CallConvert()
   End Sub
   
   Private Sub CallToString()
      ' <Snippet1>
      Dim numbers() As Byte = { 0, 16, 104, 213 }
      For Each number As Byte In numbers
         ' Display value using default formatting.
         Console.Write("{0,-3}  -->   ", number.ToString())
         ' Display value with 3 digits and leading zeros.
         Console.Write(number.ToString("D3") + "   ")
         ' Display value with hexadecimal.
         Console.Write(number.ToString("X2") + "   ")
         ' Display value with four hexadecimal digits.
         Console.WriteLine(number.ToString("X4"))
      Next   
      ' The example displays the following output:
      '       0    -->   000   00   0000
      '       16   -->   016   10   0010
      '       104  -->   104   68   0068
      '       213  -->   213   D5   00D5      
      ' </Snippet1>
   End Sub
   
   Private Sub CallConvert()
      ' <Snippet2>
      Dim numbers() As Byte = { 0, 16, 104, 213 }
      Console.WriteLine("{0}   {1,8}   {2,5}   {3,5}", _
                        "Value", "Binary", "Octal", "Hex")
      For Each number As Byte In numbers
         Console.WriteLine("{0,5}   {1,8}   {2,5}   {3,5}", _
                           number, Convert.ToString(number, 2), _
                           Convert.ToString(number, 8), _
                           Convert.ToString(number, 16))
      Next      
      ' The example displays the following output:
      '       Value     Binary   Octal     Hex
      '           0          0       0       0
      '          16      10000      20      10
      '         104    1101000     150      68
      '         213   11010101     325      d5      
      ' </Snippet2>
   End Sub
End Module

