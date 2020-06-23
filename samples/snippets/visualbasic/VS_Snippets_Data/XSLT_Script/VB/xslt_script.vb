'<snippet1>
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl

Public class Sample

    Private Const filename As String = "number.xml"
    Private Const stylesheet As String = "calc.xsl"

    Public Shared Sub Main()

        ' Compile the style sheet.
        Dim xslt_settings As XsltSettings = New XsltSettings()
        xslt_settings.EnableScript = true
        Dim xslt As XslCompiledTransform = New XslCompiledTransform()
        xslt.Load(stylesheet, xslt_settings, New XmlUrlResolver())

        ' Load the XML source file.
        Dim doc As XPathDocument = New XPathDocument(filename)

        ' Create an XmlWriter.
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.OmitXmlDeclaration = true
        settings.Indent = true
        Dim writer As XmlWriter = XmlWriter.Create("output.xml", settings)

        ' Execute the transformation.
        xslt.Transform(doc, writer)
        writer.Close()
    End Sub
End Class
'</snippet1>
