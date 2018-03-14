using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Schema;

public class Class1
{
    // <Snippet1>
    public void DisplaySchemas(XmlSchemaCollection xsc)
    {
      XmlSchemaCollectionEnumerator ienum = xsc.GetEnumerator();
      while (ienum.MoveNext())
      {
        XmlSchema schema = ienum.Current;
        StringWriter sw = new StringWriter();
        XmlTextWriter writer = new XmlTextWriter(sw);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 2;
        schema.Write(writer);
        Console.WriteLine(sw.ToString());  

      }
    }
    // </Snippet1>
}
