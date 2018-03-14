' <Snippet1>

 Imports System
 Imports System.IO
 Imports System.Xml
 
 public class Sample
 
   public shared sub Main()
   
       Dim doc as XmlDocument = new XmlDocument()
       doc.Load("books.xml")

       '  Display the first two book nodes
       Dim book as XmlNode = doc.DocumentElement.FirstChild
       Console.WriteLine(book.OuterXml)
       Console.WriteLine()
       Console.WriteLine(book.NextSibling.OuterXml)

   end sub
 end class
    ' </Snippet1>

