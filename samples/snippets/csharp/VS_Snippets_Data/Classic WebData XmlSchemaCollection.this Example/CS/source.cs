using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Windows.Forms;

public class Form1: Form
{
 public void Method(XmlSchemaCollection xsc)
 {

// <Snippet1>
if (xsc.Contains("urn:bookstore-schema"))
{
  XmlSchema schema = xsc["urn:bookstore-schema"];
  StringWriter sw = new StringWriter();
  XmlTextWriter xmlWriter = new XmlTextWriter(sw);
  xmlWriter.Formatting = Formatting.Indented;
  xmlWriter.Indentation = 2;
  schema.Write(xmlWriter);
  Console.WriteLine(sw.ToString());
}
   // </Snippet1>

 }
}
