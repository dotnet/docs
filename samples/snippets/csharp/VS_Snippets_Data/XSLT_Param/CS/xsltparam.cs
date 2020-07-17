//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

public class Sample {

   public static void Main() {

      // Create the XslCompiledTransform and load the style sheet.
      XslCompiledTransform xslt = new XslCompiledTransform();
      xslt.Load("discount.xsl");

      // Create the XsltArgumentList.
      XsltArgumentList argList = new XsltArgumentList();

      // Calculate the discount date.
      DateTime orderDate = new DateTime(2004, 01, 15);
      DateTime discountDate = orderDate.AddDays(20);
      argList.AddParam("discount", "", discountDate.ToString());

      // Create an XmlWriter to write the output.
     XmlWriter writer = XmlWriter.Create("orderOut.xml");

     // Transform the file.
     xslt.Transform(new XPathDocument("order.xml"), argList, writer);
     writer.Close();
  }
}
//</snippet1>