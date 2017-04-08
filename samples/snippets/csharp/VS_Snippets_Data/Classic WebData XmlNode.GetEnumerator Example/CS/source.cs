// <Snippet1>
using System;
using System.Collections;
using System.Xml;

public class Sample {

  public static void Main() {
  
    XmlDocument doc = new XmlDocument();
    doc.Load("books.xml");

    Console.WriteLine("Display all the books...");
    XmlNode root = doc.DocumentElement;
    IEnumerator ienum = root.GetEnumerator();
    XmlNode book;
    while (ienum.MoveNext()) 
    {     
      book = (XmlNode) ienum.Current;
      Console.WriteLine(book.OuterXml);
      Console.WriteLine();
    }

  }
}
   // </Snippet1>

