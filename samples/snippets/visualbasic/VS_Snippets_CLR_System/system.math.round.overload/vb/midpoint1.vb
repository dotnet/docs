' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example
   Public Sub Main()
      Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15}", "Value", "Default", 
                        "ToEven", "AwayFromZero")
      For value As Decimal = 12.0d To 13.0d Step .1d
         Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15}",
                           value, Math.Round(value), 
                           Math.Round(value, MidpointRounding.ToEven),
                           Math.Round(value, MidpointRounding.AwayFromZero))
      Next
   End Sub
End Module
' The example displays the following output:
'       Value      Default    ToEven     AwayFromZero
'       12         12         12         12
'       12.1       12         12         12
'       12.2       12         12         12
'       12.3       12         12         12
'       12.4       12         12         12
'       12.5       12         12         13
'       12.6       13         13         13
'       12.7       13         13         13
'       12.8       13         13         13
'       12.9       13         13         13
'       13.0       13         13         13
' </Snippet5>
