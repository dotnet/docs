Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Net

Class XslCompiledTransformLoad
    
    Shared Sub Main() 
    
    End Sub
    
' Load with XPathDocument.
Shared Sub XslCompiledTransform_Load1() 
'<snippet1>
Dim xslt As New XslCompiledTransform()
xslt.Load(New XPathDocument("http://serverName/data/xsl/sort.xsl"))
'</snippet1>
End Sub

    
'==============================//
' Load URI with XmlResolver
Shared Sub XslCompiledTransform_Load2() 
'<snippet2>
' Create the XslCompiledTransform object.
Dim xslt As New XslCompiledTransform()
        
' Create a resolver and set the credentials to use.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
resolver.Credentials = CredentialCache.DefaultCredentials
        
' Load the style sheet.
xslt.Load("http://serverName/data/xsl/sort.xsl", Nothing, resolver)
'</snippet2>    
End Sub
     
'==============================//
' Load reader with resolver & settings
Shared Sub XslCompiledTransform_Load3() 
'<snippet3>
' Create the XslCompiledTransform object.
Dim xslt As New XslCompiledTransform()
        
' Create a resolver and set the credentials to use.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
resolver.Credentials = CredentialCache.DefaultCredentials
        
Dim reader As XmlReader = XmlReader.Create("http://serverName/data/xsl/sort.xsl")
        
' Create the XsltSettings object with script enabled.
Dim settings As New XsltSettings(False, True)
        
' Load the style sheet.
xslt.Load(reader, settings, resolver)
'</snippet3>    
End Sub
     
'==============================//
' Load with XPathDocument and credentials
Shared Sub XslCompiledTransform_Load4() 
        
        Dim UserName As String = "username"
        Dim SecurelyStoredPassword As String = "psswd"
        Dim Domain As String = "domain"
        
'<snippet4>
' Create a resolver and specify the necessary credentials.
Dim resolver As New XmlUrlResolver()
Dim myCred As System.Net.NetworkCredential
myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
resolver.Credentials = myCred
        
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load(New XPathDocument("http://serverName/data/xsl/sort.xsl"), XsltSettings.Default, resolver)
'</snippet4>    
End Sub
    
'==============================//
' Load with XmlReader
Shared Sub XslCompiledTransform_Load5() 
'<snippet5>
' Create a reader that contains the style sheet.
Dim reader As XmlReader = XmlReader.Create("titles.xsl")
reader.ReadToDescendant("xsl:stylesheet")
        
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load(reader)
'</snippet5>    
End Sub
       
'==============================//
' Load with script enabled.
Shared Sub XslCompiledTransform_Load6() 
'<snippet6>
' Create the XsltSettings object with script enabled.
Dim settings As New XsltSettings(False, True)
        
' Create the XslCompiledTransform object and load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("sort.xsl", settings, New XmlUrlResolver())
'</snippet6>    
End Sub
     
'==============================//
' Load with default XSLT settings.
Shared Sub XslCompiledTransform_Load7() 
'<snippet7>
' Create the XslCompiledTransform object and load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("sort.xsl", XsltSettings.Default, New XmlUrlResolver())
'</snippet7>    
End Sub
     
'==============================//
' Load with trusted XSLT settings.
Shared Sub XslCompiledTransform_Load8() 
        
        Dim UserName As String = "username"
        Dim SecurelyStoredPassword As String = "psswd"
        Dim Domain As String = "domain"
        
'<snippet8>
' Create a resolver and specify the necessary credentials.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
Dim myCred As System.Net.NetworkCredential
myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
resolver.Credentials = myCred
        
' Create the XslCompiledTransform object and load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("http://serverName/data/script.xsl", XsltSettings.TrustedXslt, resolver)
'</snippet8>    
End Sub
     
'==============================//
' Load with script enabled.
Shared Sub XslCompiledTransform_Load9() 
'<snippet9>
' Create the XsltSettings object with script enabled.
Dim settings As New XsltSettings()
settings.EnableScript = True
        
' Create a resolver that will be used to resolve the style sheet.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
        
' Create the XslCompiledTransform object and load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("http://serverName/data/sort.xsl", settings, resolver)
'</snippet9>    
End Sub

'==============================//
' 
Shared Sub XslCompiledTransform_Debug() 
'<snippet10>
' Enable XSLT debugging.
Dim xslt As New XslCompiledTransform(true)

' Load the style sheet.
xslt.Load("output.xsl")

' Create the writer.
Dim settings As New XmlWriterSettings()
settings.Indent=true
Dim writer As XmlWriter = XmlWriter.Create("output.xml", settings)

' Execute the transformation.
xslt.Transform("books.xml", writer)
writer.Close()
'</snippet10>    
End Sub

'==============================//
' Load w/ cache
Shared Sub Cache() 
        
        Dim UserName As String = "username"
        Dim SecurelyStoredPassword As String = "psswd"
        Dim Domain As String = "domain"
        
'<snippet11>
' Create the credentials.
Dim myCred As NetworkCredential = New NetworkCredential(UserName,SecurelyStoredPassword,Domain)
Dim myCache As CredentialCache = New CredentialCache()
myCache.Add(new Uri("http://www.contoso.com/"), "Basic", myCred)
myCache.Add(new Uri("http://app.contoso.com/"), "Basic", myCred)

' Set the credentials on the XmlUrlResolver object.
Dim resolver As XmlUrlResolver = New XmlUrlResolver()
resolver.Credentials = myCache

' Compile the style sheet.
Dim xslt As XslCompiledTransform = New XslCompiledTransform()
xslt.Load("http://serverName/data/xsl/order.xsl", XsltSettings.Default, resolver)

'</snippet11>    
End Sub

End Class