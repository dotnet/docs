//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

namespace GetBuiltInSimpleType
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSchema schema = new XmlSchema();
            XmlSchemaSimpleType stringType = new XmlSchemaSimpleType();
            stringType.Name = "myString";
            schema.Items.Add(stringType);
            XmlSchemaSimpleTypeRestriction stringRestriction = 
                                 new XmlSchemaSimpleTypeRestriction();
            stringRestriction.BaseTypeName = 
                                 new XmlQualifiedName("string",
                         "http://www.w3.org/2001/XMLSchema");
            stringType.Content = stringRestriction;
            schema.Write(Console.Out);
        }
    }
}

//</snippet1>