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

