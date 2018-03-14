using System;
using System.Xml;
using System.Xml.Schema;

namespace Microsoft.Samples.Xml.Schema
{
    sealed public class Sample
    {
        private Sample() { }

        public static void Main()
        {
            //<snippet1>
            XmlSchemaCollection sc = new XmlSchemaCollection();
            sc.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            // Create a resolver with the necessary credentials.
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

            // Add the new schema to the collection.
            sc.Add("", new XmlTextReader("sample.xsd"), resolver);
            //</snippet1>

            if (sc.Count > 0)
            {
                XmlTextReader tr = new XmlTextReader("notValidXSD.xml");
                XmlValidatingReader rdr = new XmlValidatingReader(tr);

                rdr.ValidationType = ValidationType.Schema;
                rdr.Schemas.Add(sc);
                rdr.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                while (rdr.Read()) ;
            }

        }

        // Display any errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }
}