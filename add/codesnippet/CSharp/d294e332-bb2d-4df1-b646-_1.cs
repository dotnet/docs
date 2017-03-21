        public static void Constructor7()
        {
            // Create an instance of the StreamingContext to hold
            // context data.
            StreamingContext sc = new StreamingContext
                (StreamingContextStates.CrossAppDomain);

            // Create an XmlDictionary and add values to it.
            XmlDictionary d = new XmlDictionary();
            XmlDictionaryString name_value = d.Add("Customer");
            XmlDictionaryString ns_value = d.Add("http://www.contoso.com");

            // Create an instance of a class that implements the 
            // ISurrogateSelector interface. The implementation code
            // is not shown here.
            MySelector mySurrogateSelector = new MySelector();

            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                name_value,
                ns_value,
                sc,
                int.MaxValue,
                true,
                FormatterAssemblyStyle.Simple,
                mySurrogateSelector);

            // Other code not shown.
        }