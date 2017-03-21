        public:
            virtual String^ ToXmlString(bool includePrivateParameters) override
            {
                String^ keyContainerName = "";
                String^ keyNumber = "";
                String^ providerName = "";
                String^ providerType = "";

                if (cryptoServiceParameters != nullptr)
                {
                    keyContainerName = 
                        cryptoServiceParameters->KeyContainerName;
                    keyNumber = cryptoServiceParameters->KeyNumber.ToString();
                    providerName = cryptoServiceParameters->ProviderName;
                    providerType = 
                        cryptoServiceParameters->ProviderType.ToString();
                }

                StringBuilder^ sb = gcnew StringBuilder();
                sb->Append("<CustomCryptoKeyValue>");

                sb->Append("<KeyContainerName>");
                sb->Append(keyContainerName);
                sb->Append("</KeyContainerName>");

                sb->Append("<KeyNumber>");
                sb->Append(keyNumber);
                sb->Append("</KeyNumber>");

                sb->Append("<ProviderName>");
                sb->Append(providerName);
                sb->Append("</ProviderName>");

                sb->Append("<ProviderType>");
                sb->Append(providerType);
                sb->Append("</ProviderType>");

                sb->Append("</CustomCryptoKeyValue>");
                return(sb->ToString());
            }