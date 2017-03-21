        public static void Constructor4()
        {
            // Create an XmlDictionary and add values to it.
            XmlDictionary d = new XmlDictionary();
            // Initialize the out variables.
            XmlDictionaryString name_value = d.Add("Customer");
            XmlDictionaryString ns_value = d.Add("http://www.contoso.com");

            // Create the serializer.
            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                name_value,
                ns_value);
            // Other code not shown.
        }