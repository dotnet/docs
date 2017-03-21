        // Performs decryption.
        public override XmlNode Decrypt(XmlNode encryptedNode)
        {
            string decryptedData =
                DecryptString(encryptedNode.InnerText);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(decryptedData);

            return xmlDoc.DocumentElement;
        }