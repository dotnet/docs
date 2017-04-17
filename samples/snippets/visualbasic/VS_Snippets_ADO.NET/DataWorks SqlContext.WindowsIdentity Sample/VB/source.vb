Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports Microsoft.SqlServer.Server
Imports System.Data.SqlTypes
Imports System.Security.Principal

Partial Public Class StoredProcedures

Public Shared Sub GetWinID()

' <Snippet1>
Dim clientId As WindowsIdentity
Dim impersonatedUser As WindowsImpersonationContext

clientId = SqlContext.WindowsIdentity

Try 
   Try
   
      impersonatedUser = clientId.Impersonate()

      If impersonatedUser IsNot Nothing Then
         ' Perform some action using impersonation.
      End If

   Finally

     If impersonatedUser IsNot Nothing Then
         impersonatedUser.Undo
     End If

   End Try

Catch e As Exception

   throw e

End Try

' </Snippet1>
End Sub

End Class