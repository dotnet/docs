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
       doc.LoadXml("<book genre='novel' ISBN='1-861003-78' publicationdate='1987'> " +
                   "</book>"); 

       //Load the XmlNodeReader 
       reader = new XmlNodeReader(doc);
  
       //Read the genre attribute.
       reader.MoveToContent();
       reader.MoveToFirstAttribute();
       string genre=reader.Value;
       Console.WriteLine("The genre value: " + genre);

     } 
     finally 
     {
        if (reader != null)
          reader.Close();
      }
  }
  
} // End class
   // </Snippet1>

