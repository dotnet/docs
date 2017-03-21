        public static void Constructor7()
        {
            // Create a generic List of types and add the known types
            // to the collection.
            List<Type> knownTypeList = new List<Type>();
            knownTypeList.Add(typeof(PurchaseOrder));
            knownTypeList.Add(typeof(PurchaseOrderV3));

            // Create an instance of a class that 
            // implements the IDataContractSurrogate interface.
            // The implementation code is not shown here.
            DCSurrogate mySurrogate = new DCSurrogate();

            DataContractSerializer ser =
                new DataContractSerializer(
                typeof(Person),
                knownTypeList,
                64 * 1024,
                true,
                true,
                mySurrogate);
            // Other code not shown.
        }