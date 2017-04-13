//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

public class Sample {

   public static void Main() {

    // Create the XslCompiledTransform and load the stylesheet.
    XslCompiledTransform xslt = new XslCompiledTransform();
    xslt.Load("prices.xsl");

    // Create an XsltArgumentList.
    XsltArgumentList xslArg = new XsltArgumentList();
         
    // Add an object to calculate the new book price.
    BookPrice obj = new BookPrice();
    xslArg.AddExtensionObject("urn:price-conv", obj);

    using (XmlWriter w = XmlWriter.Create("output.xml"))
    {
        // Transform the file.
        xslt.Transform("books.xml", xslArg, w);
    }
  }

  // Convert the book price to a new price using the conversion factor.
  public class BookPrice{

    private decimal newprice = 0;
		
    public decimal NewPriceFunc(decimal price, decimal conv){
       decimal tmp = price*conv;
       newprice = decimal.Round(tmp, 2);
       return newprice;
    }
  }
}
//</snippet1>