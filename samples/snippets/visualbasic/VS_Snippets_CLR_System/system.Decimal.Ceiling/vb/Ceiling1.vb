' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As Decimal = {12.6d, 12.1d, 9.5d, 8.16d, .1d, -.1d,  
                                 -1.1d, -1.9d, -3.9d}
      Console.WriteLine("{0,-8} {1,10} {2,10}", 
                        "Value", "Ceiling", "Floor")
      Console.WriteLine()
      For Each value As Decimal In values
      Console.WriteLine("{0,-8} {1,10} {2,10}", value,
                        Decimal.Ceiling(value), Decimal.Floor(value))
      Next                                     
   End Sub
End Module
' The example displays the following output:
'       Value       Ceiling      Floor
'       
'       12.6             13         12
'       12.1             13         12
'       9.5              10          9
'       8.16              9          8
'       0.1               1          0
'       -0.1              0         -1
'       -1.1             -1         -2
'       -1.9             -1         -2
'       -3.9             -3         -4      
' </Snippet1>

