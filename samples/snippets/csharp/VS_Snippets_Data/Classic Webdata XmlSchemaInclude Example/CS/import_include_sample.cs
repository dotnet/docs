//<snippet1>
using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Schema;

public class ImportIncludeSample
{

    private static void ValidationCallBack(object sender, ValidationEventArgs args)
    {

        if (args.Severity == XmlSeverityType.Warning)
            Console.Write("WARNING: ");
        else if (args.Severity == XmlSeverityType.Error)
            Console.Write("ERROR: ");

        Console.WriteLine(args.Message);
    }


    public static void Main()
    {


        XmlSchema schema = new XmlSchema();
        schema.ElementFormDefault = XmlSchemaForm.Qualified;
        schema.TargetNamespace = "http://www.w3.org/2001/05/XMLInfoset";

        // <xs:import namespace="http://www.example.com/IPO" />                            
        XmlSchemaImport import = new XmlSchemaImport();
        import.Namespace = "http://www.example.com/IPO";
        schema.Includes.Add(import);

        // <xs:include schemaLocation="example.xsd" />               
        XmlSchemaInclude include = new XmlSchemaInclude();
        include.SchemaLocation = "example.xsd";
        schema.Includes.Add(include);

        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
        schemaSet.Add(schema);
        schemaSet.Compile();

        XmlSchema compiledSchema = null;

        foreach (XmlSchema schema1 in schemaSet.Schemas())
        {
            compiledSchema = schema1;
        }

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
        nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
        compiledSchema.Write(Console.Out, nsmgr);

    }/* Main() */

} //ImportIncludeSample
//</snippet1>

