using System;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace Transform
{
    class Program
    {
        static void Main(string[] args)
        {
            //Three();
        }

        public static void One()
        {
	    //<snippet1>
            // Open books.xml as an XPathDocument.
            XPathDocument doc = new XPathDocument("books.xml");

            // Create a writer for writing the transformed file.
            XmlWriter writer = XmlWriter.Create("books.html");

            // Create and load the transform with script execution enabled.
            XslCompiledTransform transform = new XslCompiledTransform();
            XsltSettings settings = new XsltSettings();
            settings.EnableScript = true;
            transform.Load("transform.xsl", settings, null);

            // Execute the transformation.
            transform.Transform(doc, writer);
            //</snippet1>
        }

        public static void Two()
        {
	    //<snippet2>
            // Create a reader to read books.xml
            XmlReader reader = XmlReader.Create("books.xml");

            // Create a writer for writing the transformed file.
            XmlWriter writer = XmlWriter.Create("books.html");

            // Create and load the transform with script execution enabled.
            XslCompiledTransform transform = new XslCompiledTransform();
            XsltSettings settings = new XsltSettings();
            settings.EnableScript = true;
            transform.Load("transform.xsl", settings, null);

            // Execute the transformation.
            transform.Transform(reader, writer);
            //</snippet2>
        }

        public static void Three()
        {
	    //<snippet3>
            // Create and load the transform with script execution enabled.
            XslCompiledTransform transform = new XslCompiledTransform();
            XsltSettings settings = new XsltSettings();
            settings.EnableScript = true;
            transform.Load("transform.xsl", settings, null);

            // Execute the transformation.
            transform.Transform("books.xml", "books.html");
            //</snippet3>
        }
    }
}
