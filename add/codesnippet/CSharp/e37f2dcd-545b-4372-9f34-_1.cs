            XmlSchemaCollection sc = new XmlSchemaCollection();
            sc.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            // Create a resolver with the necessary credentials.
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

            // Add the new schema to the collection.
            sc.Add("", new XmlTextReader("sample.xsd"), resolver);