        public static void Constructor4()
        {
            // Create an instance of the DataContractSerializer
            // specifying the type, and name and 
            // namespace as XmlDictionaryString objects.

            // Create an XmlDictionary and add values to it.
            XmlDictionary d = new XmlDictionary();
            XmlDictionaryString name_value = d.Add("Customer");
            XmlDictionaryString ns_value = d.Add("http://www.contoso.com");

            // Create the serializer.
            DataContractSerializer ser =
                new DataContractSerializer(
                typeof(Person),
                name_value,
                ns_value);
            // Other code not shown.
        }