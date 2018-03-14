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

      'Select and display the value of all the ISBN attributes.
      Dim nodeList as XmlNodeList 
      Dim root as XmlElement = doc.DocumentElement
      nodeList = root.SelectNodes("/bookstore/book/@bk:ISBN", nsmgr)
      Dim isbn as XmlNode
      for each isbn in nodeList
        Console.WriteLine(isbn.Value)
      next

  end sub
end class
'</snippet1>