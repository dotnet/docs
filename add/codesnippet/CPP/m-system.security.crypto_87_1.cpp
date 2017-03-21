            // Expected XML schema:
            //  <CustomCryptoKeyValue>
            //      <ProviderName></ProviderName>
            //      <KeyContainerName></KeyContainerName>
            //      <KeyNumber></KeyNumber>
            //      <ProviderType></ProviderType>
            //  </CustomCryptoKeyValue>
        public:
            virtual void FromXmlString(String^ xmlString) override 
            {
                if (xmlString != nullptr)
                {
                    XmlDocument^ document = gcnew XmlDocument();
                    document->LoadXml(xmlString);
                    XmlNode^ firstNode = document->FirstChild;
                    XmlNodeList^ nodeList;

                    // Assemble parameters from values in each XML element.
                    cryptoServiceParameters = gcnew CspParameters();

                    // KeyContainerName is optional.
                    nodeList = 
                        document->GetElementsByTagName("KeyContainerName");
                    if (nodeList->Count > 0)
                    {
                        cryptoServiceParameters->KeyContainerName =
                            nodeList->Item(0)->InnerText;
                    }

                    // KeyNumber is optional.
                    nodeList = document->GetElementsByTagName("KeyNumber");
                    if (nodeList->Count > 0)
                    {
                        cryptoServiceParameters->KeyNumber =
                            Int32::Parse(nodeList->Item(0)->InnerText);
                    }

                    // ProviderName is optional.
                    nodeList = document->GetElementsByTagName("ProviderName");
                    if (nodeList->Count > 0)
                    {
                        cryptoServiceParameters->ProviderName =
                            nodeList->Item(0)->InnerText;
                    }

                    // ProviderType is optional.
                    nodeList = document->GetElementsByTagName("ProviderType");
                    if (nodeList->Count > 0)
                    {
                        cryptoServiceParameters->ProviderType =
                            Int32::Parse(nodeList->Item(0)->InnerText);
                    }
                }
                else
                {
                    throw gcnew ArgumentNullException("xmlString");
                }
            }