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
       doc.LoadXml("<book genre='novel' ISBN='1-861003-78'> " +
                   "<title>Pride And Prejudice</title>" +
                   "<price>19.95</price>" +
                   "</book>"); 

       //Load the XmlNodeReader 
       reader = new XmlNodeReader(doc);
  
       //Read the attributes on the book element.
       reader.MoveToContent();
       while (reader.MoveToNextAttribute())
       {
         Console.WriteLine("{0} = {1}", reader.Name, reader.Value);
       }

       //Move the reader to the title element.
       reader.Read();

       //Read the title and price elements.
       Console.WriteLine(reader.ReadElementString());
       Console.WriteLine(reader.ReadElementString());

     } 

     finally 
     {
        if (reader != null)
          reader.Close();
      }
  }
} // End class
   // </Snippet1>

