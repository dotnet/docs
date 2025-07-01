using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("XML Roundtripping Examples");
        Console.WriteLine("==========================");
        
        Console.WriteLine("\n1. Roundtripping Problem:");
        RoundtrippingProblem.Example();
        
        Console.WriteLine("\n2. Roundtripping Solution:");
        RoundtrippingSolution.Example();
    }
}

public static class RoundtrippingProblem
{
    public static void Example()
    {
        // <XmlRoundTrip>
        string xmlWithCR = """
            <x xml:space="preserve">a&#xD;
            b
            c&#xD;</x>
            """;

        XDocument doc = XDocument.Parse(xmlWithCR);
        Console.WriteLine($"Original parsed value: {string.Join("", doc.Root!.Value.Select(c => c == '\r' ? "\\r" : c == '\n' ? "\\n" : c.ToString()))}");
        // Output: a\r\nb\nc\r

        string reserialized = doc.ToString(SaveOptions.DisableFormatting);
        Console.WriteLine($"Reserialized XML: {reserialized}");
        // Output: <x xml:space="preserve">a
        // b
        // c</x>

        XDocument reparsed = XDocument.Parse(reserialized);
        Console.WriteLine($"Reparsed value: {string.Join("", reparsed.Root!.Value.Select(c => c == '\r' ? "\\r" : c == '\n' ? "\\n" : c.ToString()))}");
        // Output: a\nb\nc\n
        // </XmlRoundTrip>
    }
}