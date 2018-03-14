' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Collections

public class Sample

  public shared sub Main()

     Dim doc as XmlDocument = new XmlDocument()
     doc.Load("2books.xml")
                         
     'Get and display all the book titles.
     Dim root as XmlElement = doc.DocumentElement
     Dim elemList as XmlNodeList = root.GetElementsByTagName("title")
     Dim ienum as IEnumerator = elemList.GetEnumerator()          
     while (ienum.MoveNext())
        Dim title as XmlNode
        title = CType(ienum.Current, XmlNode)
        Console.WriteLine(title.InnerText)
     end while    
    
  end sub
end class
 ' </Snippet1>

