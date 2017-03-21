        public static void Constructor3()
        {
            // Create an instance of the DataContractSerializer
            // specifying the type, and name and 
            // namespace as strings.
            DataContractSerializer ser =
                new DataContractSerializer(
                typeof(Person),
                "Customer",
                "http://www.contoso.com");

            // Other code not shown.
        }