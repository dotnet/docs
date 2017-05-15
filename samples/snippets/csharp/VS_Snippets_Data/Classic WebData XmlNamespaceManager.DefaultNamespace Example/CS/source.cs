using System;
using System.Xml;
using System.Xml.Xsl;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet dataset;

 public void Method(XmlNamespaceManager nsmgr)
 {

// <Snippet1>
if (nsmgr.HasNamespace(String.Empty))
  Console.WriteLine(nsmgr.DefaultNamespace);
   // </Snippet1>

 }
}
