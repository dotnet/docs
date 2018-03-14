// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    //Load XML data which includes white space, but ignore
    //any white space in the file.
    XmlDocument doc = new XmlDocument();
    doc.PreserveWhitespace = false;
    doc.Load("book.xml");

    //Save the document as is (no white space).
    Console.WriteLine("Display the modified XML...");
    doc.PreserveWhitespace = true;
    doc.Save(Console.Out);

   }
}
   // </Snippet1>

