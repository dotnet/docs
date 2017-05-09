// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main()
  {
    XmlTextReader reader = null;

    try
    {
       //Load the reader with the XML file.
       reader = new XmlTextReader("attrs.xml");
  
       //Read the ISBN attribute.
       reader.MoveToContent();
       string isbn = reader.GetAttribute("ISBN");
       Console.WriteLine("The ISBN value: " + isbn);

     } 
     finally 
     {
        if (reader != null)
          reader.Close();
      }
  }
  
} // End class
   // </Snippet1>

