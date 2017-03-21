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
