//<snippet0>
using System;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Schema;

public class Program
{
    public static void Main()
    {
        try
        {
            ExportXSD();
        }
        catch (Exception exc)
        {
            Console.WriteLine("Message: {0} StackTrace:{1}", exc.Message, exc.StackTrace);
        }
        finally
        {
            Console.ReadLine();
        }
    }

    //<snippet1>
    static void ExportXSD()
    {
        XsdDataContractExporter exporter = new XsdDataContractExporter();
        if (exporter.CanExport(typeof(Employee)))
        {
            exporter.Export(typeof(Employee));
            Console.WriteLine("number of schemas: {0}", exporter.Schemas.Count);
            Console.WriteLine();
            XmlSchemaSet mySchemas = exporter.Schemas;

            XmlQualifiedName XmlNameValue = exporter.GetRootElementName(typeof(Employee));
            string EmployeeNameSpace = XmlNameValue.Namespace;

            foreach (XmlSchema schema in mySchemas.Schemas(EmployeeNameSpace))
            {
                schema.Write(Console.Out);
            }
        }
    }
    //</snippet1>

    //<snippet2>
    static void GetXmlElementName()
    {
        XsdDataContractExporter myExporter = new XsdDataContractExporter();
        XmlQualifiedName xmlElementName =myExporter.GetRootElementName(typeof(Employee));
        Console.WriteLine("Namespace: {0}", xmlElementName.Namespace);
        Console.WriteLine("Name: {0}", xmlElementName.Name);
        Console.WriteLine("IsEmpty: {0}", xmlElementName.IsEmpty);
    }
    //</snippet2>

    [DataContract(Namespace = "www.Contoso.com/Examples/")]
    public class Employee
    {
        [DataMember]
        public string EmployeeName;
        [DataMember]
        private string ID;
    }
}
//</snippet0>
