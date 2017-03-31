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
        reader = new XmlTextReader("book1.xml");
        reader.WhitespaceHandling = WhitespaceHandling.None;

        //Parse the file and display each node.
        while (reader.Read())
        {
           if (reader.HasValue)
             Console.WriteLine("({0})  {1}={2}", reader.NodeType, reader.Name, reader.Value);
           else
             Console.WriteLine("({0}) {1}", reader.NodeType, reader.Name);
         }           
     }

     finally
     {
       if (reader!=null)
         reader.Close();
     }
  }
} // End class
   // </Snippet1>

