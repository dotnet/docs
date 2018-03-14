using System;
using System.Xml;
using System.Xml.Xsl;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
  protected string _price;

 public void Method(XmlReader reader)
 {

// <Snippet1>
if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "price") 
 {
    _price = reader.ReadString();
 }
   // </Snippet1>

 }
}
