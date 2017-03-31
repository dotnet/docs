Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl

Public class Sample

   Public Shared Sub Main() 
   
'<snippet1>
' Load an XPathDocument.
Dim doc As XPathDocument = New XPathDocument("books.xml")

' Locate the node fragment.
Dim nav As XPathNavigator = doc.CreateNavigator()
Dim myBook As XPathNavigator = nav.SelectSingleNode("descendant::book[@ISBN = '0-201-63361-2']")

' Create a new object with just the node fragment.
Dim reader As XmlReader = myBook.ReadSubtree()
reader.MoveToContent()

' Load the style sheet.
Dim xslt As XslCompiledTransform = New XslCompiledTransform()
xslt.Load("single.xsl")

' Transform the node fragment.
xslt.Transform(reader, XmlWriter.Create(Console.Out, xslt.OutputSettings))
'</snippet1>
End Sub
End Class