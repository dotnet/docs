' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
<Flags> Enum Colors As Integer
   None = 0
   Red = 1
   Green = 2
   Blue = 4
End Enum

Module Example
   Public Sub Main()
      Dim colorStrings() As String = {"0", "2", "8", "blue", "Blue", "Yellow", "Red, Green"}
      For Each colorString As String In colorStrings
         Dim colorValue As Colors
         If [Enum].TryParse(colorString, colorValue) Then        
            If [Enum].IsDefined(GetType(Colors), colorValue) Or colorValue.ToString().Contains(",") Then 
               Console.WriteLine("Converted '{0}' to {1}.", colorString, colorValue.ToString())
            Else
               Console.WriteLine("{0} is not an underlying value of the Colors enumeration.", colorString)            
            End If                    
         Else
            Console.WriteLine("{0} is not a member of the Colors enumeration.", colorString)
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'    Converted '0' to None.
'    Converted '2' to Green.
'    8 is not an underlying value of the Colors enumeration.
'    blue is not a member of the Colors enumeration.
'    Converted 'Blue' to Blue.
'    Yellow is not a member of the Colors enumeration.
'    Converted 'Red, Green' to Red, Green.
' </Snippet1>
