//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

namespace Microsoft.Samples.Xml
{
    sealed class XmlDocumentSample
    {
        private XmlDocumentSample() { }

        static XmlReader reader;
        static String filename = "bookdtd.xml";

        public static void Main()
        {

            ValidationEventHandler eventHandler = new ValidationEventHandler(XmlDocumentSample.ValidationCallback);

            try
            {
                // Create the validating reader and specify DTD validation.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.ValidationType = ValidationType.DTD;
                settings.ValidationEventHandler += eventHandler;

                reader = XmlReader.Create(filename, settings);

                // Pass the validating reader to the XML document.
                // Validation fails due to an undefined attribute, but the 
                // data is still loaded into the document.
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                Console.WriteLine(doc.OuterXml);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        // Display the validation error.
        private static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            Console.WriteLine("Validation error loading: {0}", filename);
            Console.WriteLine(args.Message);
        }
    }
}
//</snippet1>