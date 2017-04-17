' <Snippet1>
Imports System
Imports System.Collections
Imports System.Xml

public class Sample

  public shared sub Main()
  
    Dim doc as XmlDocument = new XmlDocument()
    doc.Load("books.xml")

    Console.WriteLine("Display all the books...")
    Dim root as XmlNode = doc.DocumentElement
    Dim ienum as IEnumerator = root.GetEnumerator()
    Dim book as XmlNode
    while (ienum.MoveNext())      
      book = CType(ienum.Current, XmlNode)
      Console.WriteLine(book.OuterXml)
      Console.WriteLine()
    end while

  end sub
end class
   ' </Snippet1>

