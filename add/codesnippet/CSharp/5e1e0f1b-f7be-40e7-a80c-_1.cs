        public static void Constructor2()
        {
            // Create a generic List of types and add the known types
            // to the collection.
            List<Type> knownTypeList = new List<Type>();
            knownTypeList.Add(typeof(PurchaseOrder));
            knownTypeList.Add(typeof(PurchaseOrderV3));

            // Create a DatatContractSerializer with the collection.
            DataContractSerializer ser2 = new DataContractSerializer(
                typeof(Orders), knownTypeList);

            // Other code not shown.
        }