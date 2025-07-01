using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string xmlWithCR = """
            <x xml:space="preserve">a&#xD;
            b
            c&#xD;</x>
            """;

        XDocument doc = XDocument.Parse(xmlWithCR);

        // Create XmlWriter settings with NewLineHandling.Entitize
        XmlWriterSettings settings = new XmlWriterSettings
        {
            NewLineHandling = NewLineHandling.Entitize,
            OmitXmlDeclaration = true
        };

        // Serialize using XmlWriter
        using StringWriter stringWriter = new StringWriter();
        using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
        {
            doc.WriteTo(writer);
        }

        string roundtrippedXml = stringWriter.ToString();
        Console.WriteLine($"Roundtripped XML: {roundtrippedXml}");
        // Output: <x xml:space="preserve">a&#xD;
        // b
        // c&#xD;</x>

        // Verify roundtripping preserves the original value
        XDocument roundtrippedDoc = XDocument.Parse(roundtrippedXml);
        bool valuesMatch = doc.Root!.Value == roundtrippedDoc.Root!.Value;
        Console.WriteLine($"Values match after roundtripping: {valuesMatch}");
        // Output: True
    }
}