Imports System
Imports System.Net



Public Class Class1
    
    Private Sub Method1()
        Dim UserName As String = Console.ReadLine()
        Dim SecurelyStoredPassword As String = Console.ReadLine()
        Dim Domain As String = Console.ReadLine()
        Dim wReq As WebRequest = WebRequest.Create("http://www.contoso.com")
        ' <Snippet1>
        Dim myCache As New CredentialCache()
        
        myCache.Add(New Uri("http://www.contoso.com/"), "Basic", New NetworkCredential(UserName, SecurelyStoredPassword))
        myCache.Add(New Uri("http://www.contoso.com/"), "Digest", New NetworkCredential(UserName, SecurelyStoredPassword, Domain))
        
        wReq.Credentials = myCache
        ' </Snippet1>
    End Sub 'Method1 
End Class 'Class
