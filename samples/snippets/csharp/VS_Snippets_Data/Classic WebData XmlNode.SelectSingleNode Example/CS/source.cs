// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
  
    XmlDocument doc = new XmlDocument();
    doc.Load("booksort.xml");

    XmlNode book;
    XmlNode root = doc.DocumentElement;

    book=root.SelectSingleNode("descendant::book[author/last-name='Austen']");
 
    //Change the price on the book.
    book.LastChild.InnerText="15.95";

    Console.WriteLine("Display the modified XML document....");
    doc.Save(Console.Out);    
  }
}
   // </Snippet1>

