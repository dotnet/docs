using System;
using System.Xml;
using System.Xml.Xsl;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{

// <Snippet1>
public static void WriteXml( XmlDocument doc )
 {
    XmlTextWriter writer = new XmlTextWriter(Console.Out);
    writer.Formatting = Formatting.Indented;
    doc.WriteTo( writer );
    writer.Flush();
    Console.WriteLine();
 }
   // </Snippet1>

}
