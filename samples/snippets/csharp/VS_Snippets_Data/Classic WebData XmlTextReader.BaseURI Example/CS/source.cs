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
        reader = new XmlTextReader("http://localhost/baseuri.xml");

        //Parse the file and display the base URI for each node.
        while (reader.Read())
        {
            Console.WriteLine("({0}) {1}", reader.NodeType, reader.BaseURI);
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

