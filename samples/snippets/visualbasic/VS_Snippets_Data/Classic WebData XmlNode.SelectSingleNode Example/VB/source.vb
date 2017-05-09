' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    'Create the XmlDocument.
    Dim doc as XmlDocument = new XmlDocument()
    doc.Load("booksort.xml")
           
    Dim book as XmlNode
    Dim root as XmlNode = doc.DocumentElement

    book=root.SelectSingleNode("descendant::book[author/last-name='Austen']")
 
    'Change the price on the book.
    book.LastChild.InnerText="15.95"

    Console.WriteLine("Display the modified XML document....")
    doc.Save(Console.Out)
    
  end sub
end class
   ' </Snippet1>

