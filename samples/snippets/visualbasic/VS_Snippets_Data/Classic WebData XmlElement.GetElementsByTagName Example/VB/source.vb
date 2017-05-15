' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.Load("2books.xml")
                         
     ' Get and display all the book titles.
     Dim root as XmlElement = doc.DocumentElement
     Dim elemList as XmlNodeList = root.GetElementsByTagName("title")
     Dim i as integer
     for i=0  to elemList.Count-1
        Console.WriteLine(elemList.ItemOf(i).InnerXml)
     next
    
  end sub
end class
   ' </Snippet1>

