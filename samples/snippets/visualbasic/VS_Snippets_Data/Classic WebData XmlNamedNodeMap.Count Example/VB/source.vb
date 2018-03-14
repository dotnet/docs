' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<book genre='novel' publicationdate='1997'> " & _
                "  <title>Pride And Prejudice</title>" & _
                "</book>")
                         
    Dim attrColl as XmlAttributeCollection = doc.DocumentElement.Attributes

    Console.WriteLine("Display all the attributes for this book...")
    Dim i As Integer
    For i = 0 To attrColl.Count - 1
       Console.WriteLine("{0} = {1}", attrColl.Item(i).Name,attrColl.Item(i).Value)
    Next
    
  end sub
end class
' </Snippet1>
