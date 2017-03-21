        // Performs encryption.
        public override XmlNode Encrypt(XmlNode node)
        {
            string encryptedData = EncryptString(node.OuterXml);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml("<EncryptedData>" +
                encryptedData + "</EncryptedData>");

            return xmlDoc.DocumentElement;
        }