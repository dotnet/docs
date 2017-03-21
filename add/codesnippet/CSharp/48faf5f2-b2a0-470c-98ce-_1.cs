        public static void Constructor2()
        {
            // Create an instance of the StreamingContext to hold
            // context data.
            StreamingContext sc = new StreamingContext
                (StreamingContextStates.CrossAppDomain);
            // Create a DatatContractSerializer with the collection.
            NetDataContractSerializer ser2 = new NetDataContractSerializer(sc);

            // Other code not shown.
        }