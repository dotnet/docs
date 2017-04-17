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
        //Create and load an XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.Load("http://localhost/uri.xml");

        reader = new XmlNodeReader(doc);

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

