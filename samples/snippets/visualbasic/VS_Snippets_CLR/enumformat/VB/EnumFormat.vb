' <Snippet1>
 Enum Colors
     Red
     Green
     Blue
     Yellow    
 End Enum
    
Public Class FormatTest
    Public Shared Sub Main()
        Dim myColor As Colors = Colors.Blue
        
        Console.WriteLine("My favorite color is {0}.", myColor)
        Console.WriteLine("The value of my favorite color is {0}.", [Enum].Format(GetType(Colors), myColor, "d"))
        Console.WriteLine("The hex value of my favorite color is {0}.", [Enum].Format(GetType(Colors), myColor, "x"))
    End Sub 
End Class 
' The example displays the following output:
'    My favorite color is Blue.
'    The value of my favorite color is 2.
'    The hex value of my favorite color is 00000002.
' </Snippet1>
