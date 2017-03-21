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
