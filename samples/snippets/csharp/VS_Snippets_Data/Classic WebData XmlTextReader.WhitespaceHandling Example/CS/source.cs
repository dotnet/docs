// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main(){

    //Create the XML fragment to be parsed.
    string xmlFrag ="<book> " +
                    "  <title>Pride And Prejudice</title>" +
                    "  <genre>novel</genre>" +
                    "</book>"; 

    //Create the XmlNamespaceManager.
    NameTable nt = new NameTable();
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);

    //Create the XmlParserContext.
    XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.Default);

    Console.WriteLine("Read the XML and ignore all white space...");
    ReadXML(context, xmlFrag, WhitespaceHandling.None);

    Console.WriteLine("\r\nRead the XML including white space nodes...");
    ReadXML(context, xmlFrag, WhitespaceHandling.All);

  }
  
  public static void ReadXML(XmlParserContext context, string xmlFrag, WhitespaceHandling ws){

    //Create the reader and specify the WhitespaceHandling setting.
    XmlTextReader reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);
    reader.WhitespaceHandling = ws;

      //Parse the XML and display each of the nodes.
      while (reader.Read())
      {
         switch (reader.NodeType)
         {
           case XmlNodeType.Element:
             Console.WriteLine("{0}: <{1}>", reader.NodeType, reader.Name);
             break;
           case XmlNodeType.Text:
             Console.WriteLine("{0}: {1}", reader.NodeType, reader.Value);
             break;
           case XmlNodeType.EndElement:
             Console.WriteLine("{0}: </{1}>", reader.NodeType, reader.Name);
             break;
           case XmlNodeType.Whitespace:
             Console.WriteLine("{0}:", reader.NodeType);
             break;
           case XmlNodeType.SignificantWhitespace:
             Console.WriteLine("{0}:", reader.NodeType);
             break;
         }       
      }           
  
    //Close the reader.
    reader.Close();     
  
  }
} // End class

// </Snippet1>

