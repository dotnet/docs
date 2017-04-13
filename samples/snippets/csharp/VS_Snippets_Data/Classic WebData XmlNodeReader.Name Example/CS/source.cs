// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  private const String filename = "items.xml";

  public static void Main()
  {
    XmlNodeReader reader = null;

    try
    {           
        //Create an XmlNodeReader to read the XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.Load(filename);
        reader = new XmlNodeReader(doc);

        //Parse the file and display each of the nodes.
        while (reader.Read())
        {
           switch (reader.NodeType)
           {
             case XmlNodeType.Element:
               Console.Write("<{0}>", reader.Name);
               break;
             case XmlNodeType.Text:
               Console.Write(reader.Value);
               break;
             case XmlNodeType.CDATA:
               Console.Write(reader.Value);
               break;
             case XmlNodeType.ProcessingInstruction:
               Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
               break;
             case XmlNodeType.Comment:
               Console.Write("<!--{0}-->", reader.Value);
               break;
             case XmlNodeType.XmlDeclaration:
               Console.Write("<?xml version='1.0'?>");
               break;
             case XmlNodeType.Document:
               break;
             case XmlNodeType.EndElement:
               Console.Write("</{0}>", reader.Name);
               break;
           }       
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

