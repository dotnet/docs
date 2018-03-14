Imports Microsoft.VisualBasic
Imports System

Namespace Samples.AspNet.Security
  Public Class MyIDClass
    Public Shared Function GetAnonymousId() As String
      Return "(" & Guid.NewGuid().ToString() & ")" & DateTime.UtcNow.ToString()
    End Function

    Public Shared Sub LogAnonymousId(ByVal anonymousID As String)
      Throw New NotImplementedException(anonymousID)
    End Sub
  End Class
End Namespace
