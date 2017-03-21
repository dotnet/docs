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
