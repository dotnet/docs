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
  
       //Read the attributes on the root element.
       reader.MoveToContent();
       if (reader.HasAttributes){
         for (int i=0; i<reader.AttributeCount; i++){
            reader.MoveToAttribute(i);
            Console.WriteLine("{0} = {1}", reader.Name, reader.Value);
         }
         //Return the reader to the book element.
         reader.MoveToElement();
       }

     } 

     finally 
     {
        if (reader != null)
          reader.Close();
      }
  }
  
} // End class
   // </Snippet1>

