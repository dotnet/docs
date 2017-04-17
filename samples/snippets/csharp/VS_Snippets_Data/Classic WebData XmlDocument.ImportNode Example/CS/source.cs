// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    //Create the XmlDocument.
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<bookstore>" +
                "<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>" +
                "</bookstore>");

    //Create another XmlDocument which holds a list of books.
    XmlDocument doc2 = new XmlDocument();
    doc2.Load("books.xml");

    //Import the last book node from doc2 into the original document.
    XmlNode newBook = doc.ImportNode(doc2.DocumentElement.LastChild, true);
    doc.DocumentElement.AppendChild(newBook); 
    
    Console.WriteLine("Display the modified XML...");
    doc.Save(Console.Out);

  }
}
   // </Snippet1>

