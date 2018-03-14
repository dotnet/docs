// <Snippet1>
 using System;
 using System.IO;
 using System.Xml;
 
 public class Sample
 {
   public static void Main()
   {

      XmlDocument doc = new XmlDocument();
      doc.Load("books.xml");
 
      // Display the first two book nodes.
      XmlNode book = doc.DocumentElement.FirstChild;
      Console.WriteLine(book.OuterXml);
      Console.WriteLine();
      Console.WriteLine(book.NextSibling.OuterXml);
 
   }
 }
    // </Snippet1>

