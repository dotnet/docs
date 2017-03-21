        public static void Constructor5()
        {
            // Create an instance of the StreamingContext to hold
            // context data.
            StreamingContext sc = new StreamingContext
                (StreamingContextStates.CrossAppDomain);

            // Create an instance of a class that implements the 
            // ISurrogateSelector interface. The implementation code
            // is not shown here.
            MySelector mySurrogateSelector = new MySelector();

            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                sc,
                int.MaxValue,
                true,
                FormatterAssemblyStyle.Simple,
                mySurrogateSelector);

            // Other code not shown.
        }