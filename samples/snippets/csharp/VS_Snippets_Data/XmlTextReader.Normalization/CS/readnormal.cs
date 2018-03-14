//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample{

  public static void Main(){

    // Create the XML fragment to be parsed.
    string xmlFrag  = 
    @"<item attr1='  test A B C
        1 2 3'/>
      <item attr2='&#01;'/>";                         

    // Create the XmlNamespaceManager.
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());

    // Create the XmlParserContext.
    XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.Preserve);

    // Create the reader.
    XmlTextReader reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);

    // Show attribute value normalization.
    reader.Read();
    reader.Normalization = false;
    Console.WriteLine("Attribute value:{0}", reader.GetAttribute("attr1"));
    reader.Normalization = true;
    Console.WriteLine("Attribute value:{0}", reader.GetAttribute("attr1"));

    // Set Normalization back to false.  This allows the reader to accept
    // character entities in the &#00; to &#20; range.  If Normalization had
    // been set to true, character entities in this range throw an exception.
    reader.Normalization = false;
    reader.Read();
    reader.MoveToContent();
    Console.WriteLine("Attribute value:{0}", reader.GetAttribute("attr2"));
  
    // Close the reader.
    reader.Close();     
  
  }
}
//</snippet1>


