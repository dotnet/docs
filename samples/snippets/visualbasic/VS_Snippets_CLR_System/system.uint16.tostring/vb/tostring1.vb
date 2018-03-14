' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim value As UInt16 = 16324
      ' Display value using default ToString method.
      Console.WriteLine(value.ToString())            
      Console.WriteLine()
      
      ' Define an array of format specifiers.
      Dim formats() As String = { "G", "C", "D", "F", "N", "X" }
      ' Display value using the standard format specifiers.
      For Each format As String In formats
         Console.WriteLine("{0} format specifier: {1,12}", _
                           format, value.ToString(format))         
      Next
   End Sub
End Module
' The example displays the following output:
'       16324
'       
'       G format specifier:        16324
'       C format specifier:   $16,324.00
'       D format specifier:        16324
'       F format specifier:     16324.00
'       N format specifier:    16,324.00
'       X format specifier:         3FC4
' </Snippet1>
