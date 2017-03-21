    public class CreditCardSecurityTokenSerializer : WSSecurityTokenSerializer
    {
        public CreditCardSecurityTokenSerializer(SecurityTokenVersion version) : base() { }

        protected override bool CanReadTokenCore(XmlReader reader)
        {
            XmlDictionaryReader localReader = XmlDictionaryReader.CreateDictionaryReader(reader);
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.IsStartElement(Constants.CreditCardTokenName, Constants.CreditCardTokenNamespace))
            {
                return true;
            }
            return base.CanReadTokenCore(reader);
        }

        protected override SecurityToken ReadTokenCore(XmlReader reader, SecurityTokenResolver tokenResolver)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.IsStartElement(Constants.CreditCardTokenName, Constants.CreditCardTokenNamespace))
            {
                string id = reader.GetAttribute(Constants.Id, Constants.WsUtilityNamespace);

                reader.ReadStartElement();

                // Read the credit card number.
                string creditCardNumber = reader.ReadElementString(Constants.CreditCardNumberElementName, Constants.CreditCardTokenNamespace);

                // Read the expiration date.
                string expirationTimeString = reader.ReadElementString(Constants.CreditCardExpirationElementName, Constants.CreditCardTokenNamespace);
                DateTime expirationTime = XmlConvert.ToDateTime(expirationTimeString, XmlDateTimeSerializationMode.Utc);

                // Read the issuer of the credit card.
                string creditCardIssuer = reader.ReadElementString(Constants.CreditCardIssuerElementName, Constants.CreditCardTokenNamespace);
                reader.ReadEndElement();

                CreditCardInfo cardInfo = new CreditCardInfo(creditCardNumber, creditCardIssuer, expirationTime);

                return new CreditCardToken(cardInfo, id);
            }
            else
            {
                return WSSecurityTokenSerializer.DefaultInstance.ReadToken(reader, tokenResolver);
            }
        }

        protected override bool CanWriteTokenCore(SecurityToken token)
        {
            if (token is CreditCardToken)
            {
                return true;
            }
            else
            {
                return base.CanWriteTokenCore(token);
            }
        }

        protected override void WriteTokenCore(XmlWriter writer, SecurityToken token)
        {
            if (writer == null) 
            { 
                throw new ArgumentNullException("writer"); 
            }
            if (token == null) 
            { 
                throw new ArgumentNullException("token"); 
            }

            CreditCardToken c = token as CreditCardToken;
            if (c != null)
            {
                writer.WriteStartElement(Constants.CreditCardTokenPrefix, Constants.CreditCardTokenName, Constants.CreditCardTokenNamespace);
                writer.WriteAttributeString(Constants.WsUtilityPrefix, Constants.Id, Constants.WsUtilityNamespace, token.Id);
                writer.WriteElementString(Constants.CreditCardNumberElementName, Constants.CreditCardTokenNamespace, c.CardInfo.CardNumber);
                writer.WriteElementString(Constants.CreditCardExpirationElementName, Constants.CreditCardTokenNamespace, XmlConvert.ToString(c.CardInfo.ExpirationDate, XmlDateTimeSerializationMode.Utc));
                writer.WriteElementString(Constants.CreditCardIssuerElementName, Constants.CreditCardTokenNamespace, c.CardInfo.CardIssuer);
                writer.WriteEndElement();
                writer.Flush();
            }
            else
            {
                base.WriteTokenCore(writer, token);
            }
        }
    }