        public static void Constructor9()
        {
            // Create a generic List of types and add the known types
            // to the collection.
            List<Type> knownTypeList = new List<Type>();
            knownTypeList.Add(typeof(PurchaseOrder));
            knownTypeList.Add(typeof(PurchaseOrderV3));


            // Create an XmlDictionary and add values to it.
            XmlDictionary d = new XmlDictionary();
            XmlDictionaryString name_value = d.Add("Customer");
            XmlDictionaryString ns_value = d.Add("http://www.contoso.com");

            // Create an instance of a class that 
            // implements the IDataContractSurrogate interface.
            // The implementation code is not shown here.
            DCSurrogate mySurrogate = new DCSurrogate();

            DataContractSerializer ser =
                new DataContractSerializer(
                typeof(Person),
                name_value,
                ns_value,
                knownTypeList,
                64 * 1024,
                true,
                true,
                mySurrogate);

            // Other code not shown.
        }