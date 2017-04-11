// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main()
  {
    XmlNodeReader reader = null;

    try
    {
       //Create and load the XML document.
       XmlDocument doc = new XmlDocument();
       doc.LoadXml("<!-- sample XML -->" +
                   "<book>" +
                   "<title>Pride And Prejudice</title>" +
                   "<price>19.95</price>" +
                   "</book>");

       //Load the XmlNodeReader 
       reader = new XmlNodeReader(doc);

       reader.MoveToContent(); //Move to the book node.
       reader.Read();  //Read the book start tag.
       reader.Skip();   //Skip the title element.

       Console.WriteLine(reader.ReadOuterXml());  //Read the price element.

     } 

     finally 
     {
        if (reader != null)
          reader.Close();
      }
  }
} // End class
   // </Snippet1>

