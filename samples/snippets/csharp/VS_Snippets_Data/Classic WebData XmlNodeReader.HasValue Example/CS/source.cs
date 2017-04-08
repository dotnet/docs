// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
  
    XmlNodeReader reader = null;

    try {
               
        // Create and load an XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<?xml version='1.0' ?>" +
                    "<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" +
                    "<book>" +
                    "<title>Pride And Prejudice</title>" +
                    "<misc>&h;</misc>" +
                    "</book>");

        reader = new XmlNodeReader(doc);

        // Parse the file and display each node.
        while (reader.Read()) {
           if (reader.HasValue)
             Console.WriteLine("({0})  {1}={2}", reader.NodeType, reader.Name, reader.Value);
           else
             Console.WriteLine("({0}) {1}", reader.NodeType, reader.Name);
         }           
     }

     finally {
       if (reader!=null)
         reader.Close();
     }
  }
} // End class
   // </Snippet1>

