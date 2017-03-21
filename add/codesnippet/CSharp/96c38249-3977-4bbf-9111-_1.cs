        public static void ReadObjectData(string path)
        {
            // Create the reader.
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            // Create the DataContractSerializer specifying the type, 
            // root and namespace to use. The root value corresponds
            // to the DataContract.Name value, and the namespace value
            // corresponds to the DataContract.Namespace value.
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person),
                "Customer", @"http://www.contoso.com");

            // Test if the serializer is on the start of the 
            // object data. If so, read the data and write it 
            // to the console.
            while (reader.Read())
            {
                if (ser.IsStartObject(reader))
                {
                    Console.WriteLine("Found the element");
                    Person p = (Person)ser.ReadObject(reader);
                    Console.WriteLine("{0} {1}    id:{2}",
                        p.FirstName, p.LastName, p.ID);
                }

                Console.WriteLine(reader.Name);
                break;
            }
            fs.Flush();
            fs.Close();
        }