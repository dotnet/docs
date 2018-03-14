'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath

public class Sample

  public shared sub Main()

     Dim doc as XmlDocument = new XmlDocument()
     doc.Load("books.xml")
                         
     ' Create an XPathNavigator and select all books by Plato.
     Dim nav as XPathNavigator = doc.CreateNavigator()
     Dim ni as XPathNodeIterator = nav.Select("descendant::book[author/name='Plato']")
     ni.MoveNext()

     ' Get the first matching node and change the book price.
     Dim book as XmlNode = CType(ni.Current, IHasXmlNode).GetNode()
     book.LastChild.InnerText = "12.95"
     Console.WriteLine(book.OuterXml)
    
  end sub
end class
'</snippet1>