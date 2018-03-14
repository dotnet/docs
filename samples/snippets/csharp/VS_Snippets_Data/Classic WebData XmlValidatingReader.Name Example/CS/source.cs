// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  private const String filename = "items.xml";

  public static void Main()
  {
     XmlTextReader txtreader = null;
     XmlValidatingReader reader = null;

     try
     {  
        //Load the reader with the data file and ignore all white space nodes.         
        txtreader = new XmlTextReader(filename);
        txtreader.WhitespaceHandling = WhitespaceHandling.None;

        //Implement the validating reader over the text reader. 
        reader = new XmlValidatingReader(txtreader);
        reader.ValidationType = ValidationType.None;

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
               Console.Write("<![CDATA[{0}]]>", reader.Value);
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
             case XmlNodeType.DocumentType:
               Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
               break;
             case XmlNodeType.EntityReference:
               Console.Write(reader.Name);
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

