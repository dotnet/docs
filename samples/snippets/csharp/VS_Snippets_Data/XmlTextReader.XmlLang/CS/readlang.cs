//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample{

  public static void Main(){

    //Create the XML fragment to be parsed.
    string xmlFrag  = "<book xml:lang='en-US'> " +
                           "  <title xml:lang='en-GB'>Colour Analysis</title>" +
                           "  <title>Color Analysis</title>" +
                           "</book>"; 

    //Create the XmlNamespaceManager.
    NameTable nt = new NameTable();
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);

    //Create the XmlParserContext.
    XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

    //Create the reader.
    XmlTextReader reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);
    reader.WhitespaceHandling = WhitespaceHandling.None;

    //Parse the XML and display each of the nodes, including the xml:lang setting.
    while (reader.Read()){
       switch (reader.NodeType){
         case XmlNodeType.Element:
           Console.WriteLine("{0}: <{1}>", reader.XmlLang, reader.Name);
           break;
         case XmlNodeType.Text:
           Console.WriteLine("{0}: {1}", reader.XmlLang, reader.Value);
           break;
         case XmlNodeType.EndElement:
           Console.WriteLine("{0}: </{1}>", reader.XmlLang, reader.Name);
           break;
       }       
    }           
  
    //Close the reader.
    reader.Close();     
  
  }
}
//</snippet1>


