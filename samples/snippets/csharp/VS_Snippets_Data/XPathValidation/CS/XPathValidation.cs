//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

class XPathValidation
{
    static void Main()
    {
        try
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd");
            settings.ValidationType = ValidationType.Schema;

            XmlReader reader = XmlReader.Create("contosoBooks.xml", settings);
            XmlDocument document = new XmlDocument();
            document.Load(reader);

            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

            // the following call to Validate succeeds.
            document.Validate(eventHandler);

            // add a node so that the document is no longer valid
            XPathNavigator navigator = document.CreateNavigator();
            navigator.MoveToFollowing("price", "http://www.contoso.com/books");
            XmlWriter writer = navigator.InsertAfter();
            writer.WriteStartElement("anotherNode", "http://www.contoso.com/books");
            writer.WriteEndElement();
            writer.Close();

            // the document will now fail to successfully validate
            document.Validate(eventHandler);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        switch (e.Severity)
        {
            case XmlSeverityType.Error:
                Console.WriteLine("Error: {0}", e.Message);
                break;
            case XmlSeverityType.Warning:
                Console.WriteLine("Warning {0}", e.Message);
                break;
        }

    }
}
//</snippet1>