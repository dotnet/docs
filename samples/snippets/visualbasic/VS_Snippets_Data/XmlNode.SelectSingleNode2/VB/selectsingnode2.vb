'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample

  Public Shared Sub Main()

      Dim doc As XmlDocument = New XmlDocument()
      doc.Load("newbooks.xml")

      'Create an XmlNamespaceManager for resolving namespaces.
      Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
      nsmgr.AddNamespace("bk", "urn:newbooks-schema")

      'Select the book written by an author whose last name is Atwood.
      Dim book As XmlNode 
      Dim root As XmlElement = doc.DocumentElement
      book = root.SelectSingleNode("descendant::bk:book[bk:author/bk:last-name='Atwood']", nsmgr)

      Console.WriteLine(book.OuterXml)

  End Sub
End Class
'</snippet1>