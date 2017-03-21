        public static void Constructor5()
        {
            // Create a generic List of types and add the known types
            // to the collection.
            List<Type> knownTypeList = new List<Type>();
            knownTypeList.Add(typeof(PurchaseOrder));
            knownTypeList.Add(typeof(PurchaseOrderV3));

            DataContractSerializer ser =
                new DataContractSerializer(
                typeof(Person),
                "Customer",
                @"http://www.contoso.com",
                knownTypeList);

            // Other code not shown.
        }