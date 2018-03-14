
Imports System
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Net



Class Sample
    
    Shared Sub Main() 
    
    End Sub 'Main
    
    
    
    ' Default credentials
    Shared Sub XmlUrlResolver_Credentials1() 
        '<snippet1>
        ' Create an XmlUrlResolver with default credentials.
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials
        
        ' Create the reader.
        Dim settings As New XmlReaderSettings()
        settings.XmlResolver = resolver
        Dim reader As XmlReader = _
           XmlReader.Create("http://serverName/data/books.xml", settings)

            '</snippet1>

    End Sub 'XmlUrlResolver_Credentials1
    

    
    
    ' Resolver with specific credentials
    Shared Sub XmlUrlResolver_Credentials2() 
        
        Dim UserName As String = "username"
        Dim SecurelyStoredPassword As String = "psswd"
        Dim Domain As String = "domain"
        
        '<snippet2>
        ' Create a resolver and specify the necessary credentials.
        Dim resolver As New XmlUrlResolver()
        Dim myCred As System.Net.NetworkCredential
        myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
        resolver.Credentials = myCred
    
       '</snippet2>
    End Sub 'XmlUrlResolver_Credentials2 
End Class 'Sample 


