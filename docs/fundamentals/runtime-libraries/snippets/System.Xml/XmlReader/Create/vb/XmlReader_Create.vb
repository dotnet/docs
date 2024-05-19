Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Net


Class XmlReaderSettings_Examples
    
    Shared Sub Main() 
    
    End Sub
    
    ' 
    Shared Sub String_Fragment() 
        '<snippet1>
        Dim xmlFrag As String = "<item rk:ID='abc-23'>hammer</item> " & _
                                             "<item rk:ID='r2-435'>paint</item>" & _
                                             "<item rk:ID='abc-39'>saw</item>"
        
        ' Create the XmlNamespaceManager.
        Dim nt As New NameTable()
        Dim nsmgr As New XmlNamespaceManager(nt)
        nsmgr.AddNamespace("rk", "urn:store-items")
        
        ' Create the XmlParserContext.
        Dim context As New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.None)
        
        ' Create the reader. 
        Dim settings As New XmlReaderSettings()
        settings.ConformanceLevel = ConformanceLevel.Fragment
        Dim reader As XmlReader = XmlReader.Create(New StringReader(xmlFrag), settings, context)
      '</snippet1>
    End Sub
  
    
    ' Load URI with XmlResolver
    Shared Sub Settings_Resolver() 
        Dim UserName As String = "username"
        Dim SecurelyStoredPassword As String = "psswd"
        Dim Domain As String = "domain"
        
        '<snippet2>
        ' Create an XmlUrlResolver with the credentials necessary to access the Web server.
        Dim resolver As New XmlUrlResolver()
        Dim myCred As System.Net.NetworkCredential
        myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
        resolver.Credentials = myCred
        
        Dim settings As New XmlReaderSettings()
        settings.XmlResolver = resolver
        
        ' Create the reader.
        Dim reader As XmlReader = XmlReader.Create("http://serverName/data/books.xml", settings)
         '</snippet2>
    End Sub

    
    ' DTD Validation
    Shared Sub Settings_ProhibitDtd() 
        '<snippet3>
        ' Set the validation settings.
        Dim settings As New XmlReaderSettings()
        settings.DtdProcessing = DtdProcessing.Parse
        settings.ValidationType = ValidationType.DTD
        AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
        
        ' Create the XmlReader object.
        Dim reader As XmlReader = XmlReader.Create("itemDTD.xml", settings)
        
        ' Parse the file. 
        While reader.Read()
        End While
     '</snippet3>
    End Sub
    
    
    ' <snippet4>
    ' Display any validation errors.
    Private Shared Sub ValidationCallBack(ByVal sender As Object, ByVal e As ValidationEventArgs) 
        Console.WriteLine("Validation Error: {0}", e.Message)
    
    End Sub
    
    '</snippet4>
    
    ' Wrapped Reader
    Shared Sub WrappedReader_Settings() 
        ' <snippet5>
        ' Create the XmlNodeReader object.
        Dim doc As New XmlDocument()
        doc.Load("books.xml")
        Dim nodeReader As New XmlNodeReader(doc)
        
        ' Set the validation settings.
        Dim settings As New XmlReaderSettings()
        settings.ValidationType = ValidationType.Schema
        settings.Schemas.Add("urn:bookstore-schema", "books.xsd")
        AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
        
        ' Create a validating reader that wraps the XmlNodeReader object.
        Dim reader As XmlReader = XmlReader.Create(nodeReader, settings)
        ' Parse the XML file.
        While reader.Read()
        End While
       '</snippet5>
    End Sub
   
    
    Shared Sub URI() 
        ' <snippet6>
        ' Create the XmlReader object.
        Dim reader As XmlReader = XmlReader.Create("books.xml")
    '</snippet6>
    End Sub
     
    
    Shared Sub XML_String() 
        ' <snippet7>
        Dim xmlData As String = "<item productID='124390'>" & _ 
                                             "<price>5.95</price>" & _ 
                                             "</item>"
        
        ' Create the XmlReader object.
        Dim reader As XmlReader = XmlReader.Create(New StringReader(xmlData))
    '</snippet7>
    End Sub
     
    
    Shared Sub FileStream() 
        ' <snippet8>
        Dim fs As New FileStream("C:\data\books.xml", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
        
        ' Create the XmlReader object.
        Dim reader As XmlReader = XmlReader.Create(fs)
    
    End Sub
     '</snippet8>
    
    Shared Sub FileStream_Settings() 
        ' <snippet9>
        Dim fs As New FileStream("C:\data\books.xml", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
        
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials
        Dim settings As New XmlReaderSettings()
        settings.XmlResolver = resolver
        
        ' Create the XmlReader object.
        Dim reader As XmlReader = XmlReader.Create(fs, settings)
     '</snippet9> 
    End Sub

    ' Secure Resolver
    Shared Sub Settings_SecureResolver() 
        '<snippet10>
' Create an XmlSecureResolver with default credentials.
Dim myResolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
myResolver.Credentials = CredentialCache.DefaultCredentials

Dim settings As New XmlReaderSettings()
settings.XmlResolver = myResolver

' Create the reader.
Dim reader As XmlReader = XmlReader.Create("http://serverName/data/books.xml", settings)

     '</snippet10>
    End Sub

    ' 
    Shared Sub GeneralSettings() 
        '<snippet11>
Dim settings As New XmlReaderSettings()
settings.ConformanceLevel = ConformanceLevel.Fragment
settings.IgnoreWhitespace = true
settings.IgnoreComments = true
Dim reader As XmlReader = XmlReader.Create("books.xml", settings)
     '</snippet11>
    End Sub

    Shared Sub ChainReaders() 
        '<snippet12>
Dim settings As New XmlReaderSettings()
settings.ValidationType = ValidationType.DTD
Dim inner As XmlReader = XmlReader.Create("book.xml", settings) ' DTD Validation
settings.Schemas.Add("urn:book-schema", "book.xsd")
settings.ValidationType = ValidationType.Schema
Dim outer As XmlReader = XmlReader.Create(inner, settings)  ' XML Schema Validation
     '</snippet12>
    End Sub

    Shared Sub WrapTextReader() 
        '<snippet13>
Dim txtReader As XmlTextReader = New XmlTextReader("bookOrder.xml")
Dim settings As New XmlReaderSettings()
settings.Schemas.Add("urn:po-schema", "PO.xsd")
settings.ValidationType = ValidationType.Schema
Dim reader As XmlReader = XmlReader.Create(txtReader, settings)
     '</snippet13>
    End Sub
    
End Class
