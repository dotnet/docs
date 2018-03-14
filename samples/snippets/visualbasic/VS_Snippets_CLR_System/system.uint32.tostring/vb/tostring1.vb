' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim value As UInteger = 1632490
      ' Display value using default ToString method.
      Console.WriteLine(value.ToString())            
      Console.WriteLine()
      
      ' Define an array of format specifiers.
      Dim formats() As String = { "G", "C", "D", "F", "N", "X" }
      ' Display value using the standard format specifiers.
      For Each format As String In formats
         Console.WriteLine("{0} format specifier: {1,16}", _
                           format, value.ToString(format))         
      Next
   End Sub
End Module
' The example displays the following output:
'       1632490
'       
'       G format specifier:          1632490
'       C format specifier:    $1,632,490.00
'       D format specifier:          1632490
'       F format specifier:       1632490.00
'       N format specifier:     1,632,490.00
'       X format specifier:           18E8EA
' </Snippet1>
