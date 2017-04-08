//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample{

  public static void Main(){

    // Create the XML fragment to be parsed.
    string xmlFrag  = 
    @"<book> 
         <misc>
           <style>paperback</style> 
           <pages>240</pages>
         </misc> 
        </book>";

    // Create the XmlNamespaceManager.
    NameTable nt = new NameTable();
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);

    // Create the XmlParserContext.
    XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

    // Create the reader.
    XmlTextReader reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);

    // Parse the XML and display each node.
    while (reader.Read()){
       switch (reader.NodeType){
         case XmlNodeType.Element:
           Console.Write("{0} {1},{2}  ", reader.Depth, reader.LineNumber, reader.LinePosition);
           Console.WriteLine("<{0}>", reader.Name);
           break;
         case XmlNodeType.Text:
           Console.Write("{0} {1},{2}  ", reader.Depth, reader.LineNumber, reader.LinePosition);
           Console.WriteLine("  {0}", reader.Value);
           break;
         case XmlNodeType.EndElement:
           Console.Write("{0} {1},{2}  ", reader.Depth, reader.LineNumber, reader.LinePosition);
           Console.WriteLine("</{0}>", reader.Name);
           break;
       }       
    }           

    // Close the reader.
    reader.Close();      
  }
}
//</snippet1>

