        public override string ToXmlString(bool includePrivateParameters)
        {
            string keyContainerName = "";
            string keyNumber = "";
            string providerName = "";
            string providerType = "";

            if (cspParameters != null)
            {
                keyContainerName = cspParameters.KeyContainerName;
                keyNumber = cspParameters.KeyNumber.ToString();
                providerName = cspParameters.ProviderName;
                providerType = cspParameters.ProviderType.ToString();
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<CustomCryptoKeyValue>");

            sb.Append("<KeyContainerName>");
            sb.Append(keyContainerName);
            sb.Append("</KeyContainerName>");

            sb.Append("<KeyNumber>");
            sb.Append(keyNumber);
            sb.Append("</KeyNumber>");

            sb.Append("<ProviderName>");
            sb.Append(providerName);
            sb.Append("</ProviderName>");

            sb.Append("<ProviderType>");
            sb.Append(providerType);
            sb.Append("</ProviderType>");

            sb.Append("</CustomCryptoKeyValue>");
            return(sb.ToString());
        }