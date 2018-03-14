'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

      Dim doc as XmlDocument = new XmlDocument()
      doc.Load("booksort.xml")

      'Create an XmlNamespaceManager for resolving namespaces.
      Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(doc.NameTable)
      nsmgr.AddNamespace("bk", "urn:samples")

      'Select the book node with the matching attribute value.
      Dim book as XmlNode 
      Dim root as XmlElement = doc.DocumentElement
      book = root.SelectSingleNode("descendant::book[@bk:ISBN='1-861001-57-6']", nsmgr)

      Console.WriteLine(book.OuterXml)

  end sub
end class
'</snippet1>