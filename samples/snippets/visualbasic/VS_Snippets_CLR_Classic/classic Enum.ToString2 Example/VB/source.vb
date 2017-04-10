' <Snippet1>
Imports System

Public Class EnumSample    
    Enum Colors
        Red = 1
        Blue = 2
    End Enum
    
    Public Shared Sub Main()
        Dim myColors As Colors = Colors.Red
        Console.WriteLine("The value of this instance is '{0}'", _
           myColors.ToString())
    End Sub
End Class

'Output.
'The value of this instance is 'Red'.
' </Snippet1>