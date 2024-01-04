Imports System.Runtime.CompilerServices

' <Snippet4>
<Assembly:InternalsVisibleTo("Friend2a"), _
 Assembly:InternalsVisibleTo("Friend2b")>
' </Snippet4>
Namespace Utilities
   Public Class StringUtilities
      Shared Friend Function ToTitleCase(value As String) As String
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
End Namespace