            SyndicationFeed feed = new SyndicationFeed();

            // Add several different types of element extensions
            feed.ElementExtensions.Add("simpleString", "", "hello, world!");
            feed.ElementExtensions.Add("simpleString", "", "another simple string");

            // DataContractExtension is a user-defined type marked with the DataContractAttribute
            feed.ElementExtensions.Add( new DataContractExtension() {Key = "X", Value = 4});

            // XmlSerializerExtension is a user-defined type that defines a ToString() method
            feed.ElementExtensions.Add( new XmlSerializerExtension() {Key = "Y", Value = 8}, new XmlSerializer(typeof(XmlSerializerExtension)));

            feed.ElementExtensions.Add(new XElement("xElementExtension", new XElement("Key", new XAttribute("attr1", "someValue"), "Z"),
                new XElement("Value", new XAttribute("attr1", "someValue"), "15")).CreateReader());