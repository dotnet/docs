Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath

Module Module1

    Sub Main()
        ' Three()
    End Sub

    Public Sub One()
	'<snippet1>
        ' Open books.xml as an XPathDocument.
        Dim doc As XPathDocument = New XPathDocument("books.xml")

        ' Create a writer for writing the transformed file.
        Dim writer As XmlWriter = XmlWriter.Create("books.html")

        ' Create and load the transform with script execution enabled.
        Dim transform As XslCompiledTransform = New XslCompiledTransform()
        Dim settings As XsltSettings = New XsltSettings()
        settings.EnableScript = True
        transform.Load("transform.xsl", settings, Nothing)

        'Execute the transformation.
        transform.Transform(doc, writer)
	'</snippet1>
    End Sub

    Public Sub Two()
	'<snippet2>
        'Create a reader to read books.xml
        Dim reader As XmlReader = XmlReader.Create("books.xml")

        ' Create a writer for writing the transformed file.
        Dim writer As XmlWriter = XmlWriter.Create("books.html")

        ' Create and load the transform with script execution enabled.
        Dim transform As XslCompiledTransform = New XslCompiledTransform()
        Dim settings As XsltSettings = New XsltSettings()
        settings.EnableScript = True
        transform.Load("transform.xsl", settings, Nothing)

        ' Execute the transformation.
        transform.Transform(reader, writer)
	'</snippet2>
    End Sub

    Public Sub Three()
	'<snippet3>
        ' Create and load the transform with script execution enabled.
        Dim transform As XslCompiledTransform = New XslCompiledTransform()
        Dim settings As XsltSettings = New XsltSettings()
        settings.EnableScript = True
        transform.Load("transform.xsl", settings, Nothing)

        ' Execute the transformation.
        transform.Transform("books.xml", "books.html")
	'</snippet3>
    End Sub

End Module
