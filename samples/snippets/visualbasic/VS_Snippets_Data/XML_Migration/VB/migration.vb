Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports System.Net


Class XML_Migration_Samples


    Shared Sub Main()

    End Sub


    Public Sub XmlReader_Creation_Old()
        '<snippet1>
        ' Supply the credentials necessary to access the Web server.
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials

        ' Create the XmlTextReader.
        Dim reader As New XmlTextReader("http://serverName/data/books.xml")
        reader.WhitespaceHandling = WhitespaceHandling.None
        reader.XmlResolver = resolver
        '</snippet1>    
    End Sub


    '==============================
    ' 
    Shared Sub XmlReader_Creation_New()
        '<snippet2>
        ' Supply the credentials necessary to access the Web server.
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials

        ' Create the XmlReader.
        Dim settings As New XmlReaderSettings()
        settings.IgnoreWhitespace = True
        settings.XmlResolver = resolver
        Dim reader As XmlReader = XmlReader.Create("http://serverName/data/books.xml", settings)
        '</snippet2>    
    End Sub

    '==============================
    ' 
    Shared Sub XML_Validation_Old()
        '<snippet3a>
        Dim reader As New XmlValidatingReader(New XmlTextReader("books.xml"))
        reader.ValidationType = ValidationType.Schema
        reader.Schemas.Add("urn:books", "books.xsd")
        AddHandler reader.ValidationEventHandler, AddressOf ValidationCallBack
        While reader.Read()
        End While
        '</snippet3a>
    End Sub
    '<snippet3b>
    Private Shared Sub ValidationCallBack(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Console.WriteLine("Validation Error: {0}", e.Message)
    End Sub
    '</snippet3b>        

    '==============================
    ' 
    Shared Sub XML_Validation_New()
        '<snippet4a>
        Dim settings As New XmlReaderSettings()
        settings.ValidationType = ValidationType.Schema
        settings.Schemas.Add("urn:books", "books.xsd")
        AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
        Dim reader As XmlReader = XmlReader.Create("books.xml", settings)
        While reader.Read()
        End While
        '</snippet4a>
    End Sub
    '<snippet4b>
    Private Shared Sub ValidationCallBack1(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Console.WriteLine("Validation Error: {0}", e.Message)
    End Sub
    '</snippet4b>     


    '==============================
    ' 
    Shared Sub XmlWriter_Creation_Old()
        '<snippet5>
        Dim writer As New XmlTextWriter("books.xml", Encoding.Unicode)
        writer.Formatting = Formatting.Indented
        '</snippet5>    
    End Sub


    '==============================
    ' 
    Shared Sub XmlWriter_Creation_New()
        '<snippet6>
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        settings.Encoding = Encoding.Unicode
        Dim writer As XmlWriter = XmlWriter.Create("books.xml", settings)
        '</snippet6>    
    End Sub


    '==============================
    ' 
    Shared Sub XSLT_Old()
        Dim filename As String = "books.xml"
        '<snippet7>
        ' Create the XslTransform.
        Dim xslt As New XslTransform()

        ' Create a resolver and set the credentials to use.
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials

        ' Load the style sheet.
        xslt.Load("http://serverName/data/xsl/sort.xsl", resolver)

        ' Transform the file.
        Dim doc As New XPathDocument(filename)
        Dim writer As New XmlTextWriter("output.xml", Nothing)
        xslt.Transform(doc, Nothing, writer, Nothing)
        '</snippet7>    
    End Sub


    '==============================
    ' 
    Shared Sub XSLT_New()
        '<snippet8>
        ' Create the XslCompiledTransform object.
        Dim xslt As New XslCompiledTransform()

        ' Create a resolver and set the credentials to use.
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials

        ' Load the style sheet.
        xslt.Load("http://serverName/data/xsl/sort.xsl", XsltSettings.Default, resolver)

        ' Transform the file.
        Dim writer As XmlWriter = XmlWriter.Create("output.xml")
        xslt.Transform("books.xml", writer)
        '</snippet8>    
    End Sub


    '==============================
    ' 
    Shared Sub XSLT_URI_Old()
        '<snippet9>
        Dim xslt As New XslTransform()
        xslt.Load("output.xsl")
        xslt.Transform("books.xml", "books.html")
        '</snippet9>    
    End Sub


    '==============================
    ' 
    Shared Sub XSLT_URI_New()
        '<snippet10>
        Dim xslt As New XslCompiledTransform()
        xslt.Load("output.xsl")
        xslt.Transform("books.xml", "books.html")
        '</snippet10>    
    End Sub


    '==============================
    ' 
    Shared Sub Stylesheet_Credentials_Old()
        '<snippet11>
        Dim xslt As New XslTransform()
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials
        xslt.Load("sort.xsl", resolver)
        '</snippet11>    
    End Sub


    '==============================
    ' 
    Shared Sub Stylesheet_Credentials_New()
        '<snippet12>
        Dim xslt As New XslCompiledTransform()
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials
        xslt.Load("sort.xsl", XsltSettings.Default, resolver)
        '</snippet12>    
    End Sub


    '==============================
    ' 
    Shared Sub XSLT_Param_Old()
        Dim filename As String = "books.xml"
        '<snippet13>
        Dim xslt As New XslTransform()
        xslt.Load("order.xsl")

        'Create the XsltArgumentList.
        Dim argList As New XsltArgumentList()

        'Create a parameter which represents the current date and time.
        Dim d As DateTime = DateTime.Now
        argList.AddParam("date", "", d.ToString())

        'Create the XmlTextWriter.
        Dim writer As New XmlTextWriter("output.xml", Nothing)

        'Transform the file.
        xslt.Transform(New XPathDocument(filename), argList, writer, Nothing)
        '</snippet13>    
    End Sub


    '==============================
    ' 
    Shared Sub XSLT_Param_New()
        Dim filename As String = "books.xml"
        '<snippet14>
        Dim xslt As New XslCompiledTransform()
        xslt.Load("order.xsl")

        ' Create the XsltArgumentList.
        Dim argList As New XsltArgumentList()

        ' Create a parameter which represents the current date and time.
        Dim d As DateTime = DateTime.Now
        argList.AddParam("date", "", d.ToString())

        ' Create the XmlWriter. 
        Dim writer As XmlWriter = XmlWriter.Create("output.xml", Nothing)

        ' Transform the file.
        xslt.Transform(New XPathDocument(filename), argList, writer)
        '</snippet14>    
    End Sub


    '==============================
    ' 
    Shared Sub XSLT_Script_Old()
        '<snippet15>
        Dim xslt As New XslTransform()
        xslt.Load("output.xsl")
        xslt.Transform("books.xml", "books.html")
        '</snippet15>    
    End Sub


    '==============================
    ' 
    Shared Sub XSLT_Script_New()
        '<snippet16>
        ' Create the XsltSettings object with script enabled.
        Dim settings As New XsltSettings(False, True)

        ' Execute the transform.
        Dim xslt As New XslCompiledTransform()
        xslt.Load("calc.xsl", settings, New XmlUrlResolver())
        xslt.Transform("books.xml", "books.html")
        '</snippet16>    
    End Sub

    '==============================
    ' 
    Shared Sub XSLT_Roundtrip_Old()
        '<snippet17>
        ' Execute the transformation.
        Dim xslt As New XslTransform()
        xslt.Load("output.xsl")
        Dim reader As XmlReader = xslt.Transform(New XPathDocument("books.xml"), Nothing, New XmlUrlResolver())

        ' Load the results into an XPathDocument object.
        Dim doc As XPathDocument = New XPathDocument(reader)
        '</snippet17>
    End Sub

    '==============================
    ' 
    Shared Sub XSLT_Roundtrip_New()
        '<snippet18>
        ' Execute the transformation.
        Dim xslt As New XslCompiledTransform()
        xslt.Load("output.xsl")
        Dim ms As MemoryStream = New MemoryStream()
        xslt.Transform(New XPathDocument("books.xml"), Nothing, ms)

        ' Load the results into an XPathDocument object.
        ms.Seek(0, SeekOrigin.Begin)
        Dim doc As XPathDocument = New XPathDocument(ms)
        '</snippet18>
    End Sub

    '==============================
    ' 
    Shared Sub XSLT_DOM_Old()
        '<snippet19>
        ' Execute the transformation.
        Dim xslt As New XslTransform()
        xslt.Load("output.xsl")
        Dim reader As XmlReader = xslt.Transform(New XPathDocument("books.xml"), Nothing, New XmlUrlResolver())

        ' Load the results into a DOM object.
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load(reader)
        '</snippet19>
    End Sub

    '==============================
    ' 
    Shared Sub XSLT_DOM_New()
        '<snippet20>
        ' Execute the transformation.
        Dim xslt As New XslCompiledTransform()
        xslt.Load("output.xsl")
        xslt.Transform("books.xml", "output.xml")

        ' Load the results into a DOM object.
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("output.xml")
        '</snippet20>
    End Sub

End Class
