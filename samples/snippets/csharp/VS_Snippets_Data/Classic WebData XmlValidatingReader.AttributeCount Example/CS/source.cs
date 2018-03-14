// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main()
  {
    XmlValidatingReader reader = null;

    try
    {
       //Create the string to parse.
       string xmlFrag="<book genre='novel' ISBN='1-861003-78' pubdate='1987'></book> ";

       //Create the XmlNamespaceManager.
       NameTable nt = new NameTable();
       XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);

       //Create the XmlParserContext.
       XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

       //Create the XmlValidatingReader .
       reader = new XmlValidatingReader(xmlFrag, XmlNodeType.Element, context);
  
       //Read the attributes on the root element.
       reader.MoveToContent();
       if (reader.HasAttributes){
         for (int i=0; i<reader.AttributeCount; i++){
            reader.MoveToAttribute(i);
            Console.WriteLine("{0} = {1}", reader.Name, reader.Value);
         }
         //Move the reader back to the node that owns the attribute.
         reader.MoveToElement();
       }

     } 

     finally 
     {
        if (reader != null)
          reader.Close();
      }
  }
} // End class
   // </Snippet1>

