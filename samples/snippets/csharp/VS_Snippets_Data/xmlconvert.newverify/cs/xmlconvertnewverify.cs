using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace VerifyNames
{
    class Program
    {
        static void Main(string[] args)
        {
            //<snippet5>
            XmlTextWriter writer5 = new XmlTextWriter("outFile.xml", null);
            char illegalWhiteSpaceChar = '_';

            try
            {
                // Write the root element.
                writer5.WriteStartElement("root");

                writer5.WriteStartElement("legalElement");
                // Throw an exception due illegal white space character.
                writer5.WriteString("ValueText" + 
                    XmlConvert.VerifyWhitespace("\t" + illegalWhiteSpaceChar));

                // Write the end tag for the legal element.
                writer5.WriteEndElement();
                // Write the end tag for the root element.
                writer5.WriteEndElement();
                writer5.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                writer5.Close();
            }

            //</snippet5>
            //<snippet4>
            XmlTextWriter writer4 = new XmlTextWriter("outFile.xml", null);
            char illegalPubIdChar = '^';

            try
            {
                // Write document type Declaration.
                // Throw an exception due illegal public id character.
                writer4.WriteDocType("testPublic", 
                    XmlConvert.VerifyPublicId("pubId" + illegalPubIdChar),
                    null, null);

                // Write the root element.
                writer4.WriteStartElement("root");               
                
                writer4.WriteStartElement("legalElement");
                writer4.WriteString("ValueText");
                writer4.WriteEndElement();

                // Write the end tag for the root element.
                writer4.WriteEndElement();

                writer4.Close();
            }

            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
                writer4.Close();
            }

            //</snippet4>
            //<snippet3>
            XmlTextWriter writer3 = new XmlTextWriter("outFile.xml", null);
            char illegalChar = '\uFFFE';
            string charsToVerify = "Test String "; 

            try
            {
                // Write the root element.
                writer3.WriteStartElement("root");

                // Throw an exception due illegal character.
                writer3.WriteStartElement(
                    XmlConvert.VerifyXmlChars(charsToVerify + illegalChar));

                writer3.WriteString("ValueText");
                writer3.WriteEndElement();

                // Write the end tag for the root element.
                writer3.WriteEndElement();

                writer3.Close();

            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
                writer3.Close();
            }

            //</snippet3>
            //<snippet2>
            XmlTextWriter writer2 = new XmlTextWriter("outFile.xml", null);
            string illegalNMToken = "item^name";

            try
            {
                // Write the root element.
                writer2.WriteStartElement("root");

                // Throw exception due illegal name token.
                writer2.WriteStartElement(
                    XmlConvert.VerifyNMTOKEN(illegalNMToken));

                writer2.WriteString("ValueText");
                writer2.WriteEndElement();

                // Write the end tag for the root element.
                writer2.WriteEndElement();

                writer2.Close();

            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
                writer2.Close();
            }

            //</snippet2>

            //<snippet1>
            XmlTextWriter writer = new XmlTextWriter("outFile.xml", null);
            string illegalNCName = "item:name";

            try
            {
                writer.WriteStartElement("root");
                // Throw an exception due name that contains colon.
                writer.WriteStartElement(
                    XmlConvert.VerifyNCName(illegalNCName));

                writer.WriteString("ValueText");
                writer.WriteEndElement();

                // Write the end tag for the root element.
                writer.WriteEndElement();

                writer.Close();

            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
                writer.Close();
            }

            //</snippet1>

        }
    }
}
