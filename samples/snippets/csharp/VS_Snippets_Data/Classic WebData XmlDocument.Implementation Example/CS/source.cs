using System;
using System.Xml;
using System.Xml.Xsl;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet dataset;

 public void Method()
 {

// <Snippet1>
XmlDocument doc1 = new XmlDocument();
 doc1.Load("books.xml");
 XmlDocument doc2 = doc1.Implementation.CreateDocument();
// </Snippet1>

 }
}
