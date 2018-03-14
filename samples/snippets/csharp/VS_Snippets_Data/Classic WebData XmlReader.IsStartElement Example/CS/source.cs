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
       reader = new XmlTextReader("elems.xml");
  
       //Parse the XML and display the text content of each of the elements.
       while (reader.Read()){
         if (reader.IsStartElement()){
           if (reader.IsEmptyElement)
              Console.WriteLine("<{0}/>", reader.Name);
           else{
               Console.Write("<{0}> ", reader.Name);
               reader.Read(); //Read the start tag.
               if (reader.IsStartElement())  //Handle nested elements.
                 Console.Write("\r\n<{0}>", reader.Name);
               Console.WriteLine(reader.ReadString());  //Read the text content of the element.
           }
         }
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

