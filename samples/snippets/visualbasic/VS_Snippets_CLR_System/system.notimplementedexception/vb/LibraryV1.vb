' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Namespace Utilities
   Public Class StringLibrary
      Public Shared ReadOnly Property Version As New Version("1.0")
      
      Public Shared Function GetEndOfLineCharacter() As String
         Throw New NotSupportedException("This functionality will be provided in a later version.")
      End Function
   End Class
End Namespace
' </Snippet2>

