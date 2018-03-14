'<Snippet7>
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web
Imports System.Web.SessionState


Namespace Samples.AspNet.Session

  Public Class GuidSessionIDManager
    Inherits SessionIDManager

    Public Overrides Function CreateSessionID(context As HttpContext) As String
      Return Guid.NewGuid().ToString()
    End Function

    Public Overrides Function Validate(id As String) As Boolean
      Try
        Dim testGuid As Guid = New Guid(id)

        If id = testGuid.ToString() Then _
          Return True
      Catch
      
      End Try

      Return False
    End Function

  End Class

End Namespace
'</Snippet7>

