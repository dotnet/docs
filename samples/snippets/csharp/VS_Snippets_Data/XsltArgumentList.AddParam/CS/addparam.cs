//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

public class Sample
{

    public static void Main()
    {

        // Create the XslCompiledTransform and load the stylesheet.
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("order.xsl");

        // Create the XsltArgumentList.
        XsltArgumentList xslArg = new XsltArgumentList();

        // Create a parameter which represents the current date and time.
        DateTime d = DateTime.Now;
        xslArg.AddParam("date", "", d.ToString());

        // Transform the file.
        using (XmlWriter w = XmlWriter.Create("output.xml"))
        {
            xslt.Transform("order.xml", xslArg, w);
        }
    }
}
//</snippet1>
