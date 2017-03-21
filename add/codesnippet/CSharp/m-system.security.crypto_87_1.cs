        // Expected XML schema:
        //  <CustomCryptoKeyValue>
        //      <ProviderName></ProviderName>
        //      <KeyContainerName></KeyContainerName>
        //      <KeyNumber></KeyNumber>
        //      <ProviderType></ProviderType>
        //  </CustomCryptoKeyValue>
        public override void FromXmlString(string xmlString)
        {
            if (xmlString != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlString);
                XmlNode firstNode = doc.FirstChild;
                XmlNodeList nodeList;

                // Assemble parameters from values in each XML element.
                cspParameters = new CspParameters();

                // KeyContainerName is optional.
                nodeList = doc.GetElementsByTagName("KeyContainerName");
                string keyName = nodeList.Item(0).InnerText;
                if (keyName != null) 
                {
                    cspParameters.KeyContainerName = keyName;
                }

                // KeyNumber is optional.
                nodeList = doc.GetElementsByTagName("KeyNumber");
                string keyNumber = nodeList.Item(0).InnerText;
                if (keyNumber != null) 
                {
                    cspParameters.KeyNumber = Int32.Parse(keyNumber);
                }

                // ProviderName is optional.
                nodeList = doc.GetElementsByTagName("ProviderName");
                string providerName = nodeList.Item(0).InnerText;
                if (providerName != null) 
                {
                    cspParameters.ProviderName = providerName;
                }

                // ProviderType is optional.
                nodeList = doc.GetElementsByTagName("ProviderType");
                string providerType = nodeList.Item(0).InnerText;
                if (providerType != null) 
                {
                    cspParameters.ProviderType = Int32.Parse(providerType);
                }
            }
            else
            {
                throw new ArgumentNullException("xmlString");
            }
        }