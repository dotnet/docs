' <Snippet1>
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    'Create the XmlDocument.
    Dim doc as XmlDocument = new XmlDocument()
    doc.Load("booksort.xml")
           
    Dim book as XmlNode
    Dim nodeList as XmlNodeList 
    Dim root as XmlNode = doc.DocumentElement

    nodeList=root.SelectNodes("descendant::book[author/last-name='Austen']")
 
    'Change the price on the books.
    for each book in nodeList      
      book.LastChild.InnerText="15.95"
    next 

    Console.WriteLine("Display the modified XML document....")
    doc.Save(Console.Out)
    
  end sub
end class
   ' </Snippet1>

