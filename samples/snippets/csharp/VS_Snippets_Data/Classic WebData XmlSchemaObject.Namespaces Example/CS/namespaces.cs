// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaObject
{
    public static void Main()
    {
        XmlSchema s = new XmlSchema();
        s.TargetNamespace = "myNamespace";
        s.Namespaces.Add("myImpPrefix", "myImportNamespace");

        // Create the <xs:import> element.
        XmlSchemaImport import = new XmlSchemaImport();
        import.Namespace = "myImportNamespace";
        import.SchemaLocation = "http://www.example.com/myImportNamespace";
        s.Includes.Add(import);

        // Create an element and assign a type from imported schema.
        XmlSchemaElement elem = new XmlSchemaElement();
        elem.SchemaTypeName = new XmlQualifiedName("importType", "myImportNamespace");
        elem.Name = "element1";

        s.Items.Add(elem);
        s.Write(Console.Out);

    }
}
// </Snippet1>


