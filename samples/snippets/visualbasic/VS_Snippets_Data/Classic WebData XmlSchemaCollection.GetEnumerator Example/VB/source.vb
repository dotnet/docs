Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema



Public Class Class1
    
    ' <Snippet1>
    Public Shared Sub Main ()
	Dim xsc As XmlSchemaCollection
        Dim ienum As XmlSchemaCollectionEnumerator = xsc.GetEnumerator()
        While ienum.MoveNext()
            Dim schema As XmlSchema = ienum.Current
            Dim sw As New StringWriter()
            Dim writer As New XmlTextWriter(sw)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            schema.Write(writer)
            Console.WriteLine(sw.ToString())
        End While 
    End Sub 
    ' </Snippet1>
End Class 'Class1

