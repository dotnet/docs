' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Namespace Utilities
   Public Class StringLibrary
      Public Shared ReadOnly Property Version As New Version("2.0")
      
      Public Shared Function GetEndOfLineCharacter() As String
         Return Environment.Newline
      End Function
   End Class
End Namespace
' </Snippet3>

