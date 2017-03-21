        public static void Constructor3()
        {
            // Create an instance of the NetDataContractSerializer
            // specifying the name and namespace as strings.
            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                "Customer",
                "http://www.contoso.com");
            // Other code not shown.
        }