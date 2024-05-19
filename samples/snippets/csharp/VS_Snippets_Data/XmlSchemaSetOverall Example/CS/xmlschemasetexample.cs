//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaSetExample
{
    static void Main()
    {
        XmlReaderSettings booksSettings = new XmlReaderSettings();
        booksSettings.Schemas.Add("http://www.contoso.com/books", "books.xsd");
        booksSettings.ValidationType = ValidationType.Schema;
        booksSettings.ValidationEventHandler += booksSettingsValidationEventHandler;

        XmlReader books = XmlReader.Create("books.xml", booksSettings);

        while (books.Read()) { }
    }

    static void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("WARNING: ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Console.Write("ERROR: ");
            Console.WriteLine(e.Message);
        }
    }
}
//</snippet1>
