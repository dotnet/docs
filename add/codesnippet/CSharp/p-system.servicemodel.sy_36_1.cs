            SyndicationItem item = new SyndicationItem();

            // Add several different types of element extensions
            item.ElementExtensions.Add("simpleString", "", "hello, world!");
            item.ElementExtensions.Add("simpleString", "", "another simple string");

            // DataContractExtension is a user-defined type marked with the DataContractAttribute
            item.ElementExtensions.Add(new DataContractExtension() { Key = "X", Value = 4 });

            // XmlSerializerExtension is a user-defined type that defines a ToString() method
            item.ElementExtensions.Add(new XmlSerializerExtension() { Key = "Y", Value = 8 }, new XmlSerializer(typeof(XmlSerializerExtension)));

            item.ElementExtensions.Add(new XElement("xElementExtension", new XElement("Key", new XAttribute("attr1", "someValue"), "Z"),
                new XElement("Value", new XAttribute("attr1", "someValue"), "15")).CreateReader());