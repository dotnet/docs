 ' <snippet30>
Imports System



Public Class CrmClient
    
    
    Public Shared Sub Main() 
        
        ' Create a new account object. The object is created in a COM+ server application.
        Dim account As New Account()
        
        ' Transactionally debit the account.
        Try
            account.Filenam = System.IO.Path.GetFullPath("JohnDoe")
            account.AllowCommit = True
            account.DebitAccount(3)
        Finally
            account.Dispose()
        End Try
    
    End Sub 'Main 
End Class 'CrmClient

' </snippet30>