Imports System.Runtime.CompilerServices

' <Snippet3>
<assembly:InternalsVisibleTo("Friend1a")>
<assembly:InternalsVisibleTo("Friend1b")>
' </Snippet3>
Public Class StringUtilities
   Friend Function ToTitleCase(value As String) As String
      Dim retval As String = Nothing
      For ctr As Integer = 0 To value.Length - 1
         If ctr = 0 Then     
            retval += Char.ToUpper(value(ctr))
         ElseIf ctr > 0 AndAlso Char.IsWhiteSpace(value(ctr - 1))
            retval += Char.ToUpper(value(ctr))
         Else
            retval += value(ctr)     
         End If      
      Next
      Return retval            
   End Function
End Class
