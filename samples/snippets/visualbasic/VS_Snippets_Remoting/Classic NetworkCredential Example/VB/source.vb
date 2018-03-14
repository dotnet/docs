Imports System
Imports System.Net

Public Class Sample
        
    Public Sub Method()
dim SecurelyStoredUserName as String = ""
dim SecurelyStoredPassword as String = ""
dim SecurelyStoredDomain as String = ""
        
' <Snippet1>
 Dim myCred As New NetworkCredential(SecurelyStoredUserName,SecurelyStoredPassword,SecurelyStoredDomain )
        
 Dim myCache As New CredentialCache()
        
 myCache.Add(New Uri("www.contoso.com"), "Basic", myCred)
 myCache.Add(New Uri("app.contoso.com"), "Basic", myCred)
        
 Dim wr As WebRequest = WebRequest.Create("www.contoso.com")
 wr.Credentials = myCache

' </Snippet1>
    End Sub
End Class
