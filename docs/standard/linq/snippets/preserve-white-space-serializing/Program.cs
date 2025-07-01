using System.Xml;
using System.Xml.Linq;

// Example showing the roundtripping problem
static void DemonstrateRoundtrippingProblem()
{
    string xmlWithCR = """
        <x xml:space="preserve">a&#xD;
        b
        c&#xD;</x>
        """;

    XDocument doc = XDocument.Parse(xmlWithCR);
    Console.WriteLine($"Original parsed value: {string.Join("", doc.Root.Value.Select(c => c == '\r' ? "\\r" : c == '\n' ? "\\n" : c.ToString()))}");
    // Output: a\r\nb\nc\r

    string reserialized = doc.ToString(SaveOptions.DisableFormatting);
    Console.WriteLine($"Reserialized XML: {reserialized}");
    // Output: <x xml:space="preserve">a
    // b
    // c</x>

    XDocument reparsed = XDocument.Parse(reserialized);
    Console.WriteLine($"Reparsed value: {string.Join("", reparsed.Root.Value.Select(c => c == '\r' ? "\\r" : c == '\n' ? "\\n" : c.ToString()))}");
    // Output: a\nb\nc\n
}

// Example showing the roundtripping solution
static void DemonstrateRoundtrippingSolution()
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
    bool valuesMatch = doc.Root.Value == roundtrippedDoc.Root.Value;
    Console.WriteLine($"Values match after roundtripping: {valuesMatch}");
    // Output: True
}

// Run both examples
DemonstrateRoundtrippingProblem();
Console.WriteLine();
DemonstrateRoundtrippingSolution();