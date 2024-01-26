Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Security.Policy
Imports System.Security
Imports System.Security.Permissions
Imports System.Net
Imports System.Reflection

Class XmlSecureResolver_Samples

    Shared Sub Main()

    End Sub

    Public Sub Assembly_Evidence()
        '<snippet1>
        Dim myEvidence As Evidence = Me.GetType().Assembly.Evidence
        Dim myResolver As XmlSecureResolver
        myResolver = New XmlSecureResolver(New XmlUrlResolver(), myEvidence)
        '</snippet1>
    End Sub

    '==============================
    ' 
    Shared Sub URI_Evidence()
        Dim sourceURI As String = "http://serverName/data"
        '<snippet2>
        Dim myEvidence As Evidence = XmlSecureResolver.CreateEvidenceForUrl(sourceURI)
        Dim myResolver As New XmlSecureResolver(New XmlUrlResolver(), myEvidence)
        '</snippet2>
    End Sub

    '==============================
    ' 
    Shared Sub Use_URL()
        '<snippet3>
        Dim myResolver As New XmlSecureResolver(New XmlUrlResolver(), "http://myLocalSite/")
        '</snippet3>
    End Sub

    '==============================
    ' 
    Shared Sub Use_PermissionSet()
        '<snippet4a>
        Dim myWebPermission As New WebPermission(PermissionState.None)
        '</snippet4a>
        '<snippet4b>
        myWebPermission.AddPermission(NetworkAccess.Connect, "http://www.contoso.com/")
        myWebPermission.AddPermission(NetworkAccess.Connect, "http://litwareinc.com/data/")
        '</snippet4b>
        '<snippet4c>
        Dim myPermissions As New PermissionSet(PermissionState.None)
        myPermissions.AddPermission(myWebPermission)
        '</snippet4c>
        '<snippet4d>
        Dim myResolver As New XmlSecureResolver(New XmlUrlResolver(), myPermissions)
        '</snippet4d>
    End Sub

    '==============================
    ' 
    Shared Sub Reader_Resolver()
        Dim myResolver As New XmlSecureResolver(New XmlUrlResolver(), "http://myLocalSite/")
        '<snippet5a>
        Dim settings As New XmlReaderSettings()
        settings.XmlResolver = myResolver
        '</snippet5a>
        '<snippet5b>
        Dim reader As XmlReader = XmlReader.Create("books.xml", settings)
        '</snippet5b>
    End Sub

    '==============================
    ' 
    Shared Sub XSLT_Resolver()
        Dim myResolver As New XmlSecureResolver(New XmlUrlResolver(), "http://myLocalSite/")
        '<snippet6>
        Dim xslt As New XslCompiledTransform()
        xslt.Load("http://serverName/data/xsl/sort.xsl", Nothing, myResolver)
        '</snippet6>
    End Sub

End Class


