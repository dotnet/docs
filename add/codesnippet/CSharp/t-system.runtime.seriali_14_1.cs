namespace DataContractAttributeExample
{
    // Set the Name and Namespace properties to new values.
    [DataContract(Name = "Customer", Namespace = "http://www.contoso.com")]
    class Person : IExtensibleDataObject
    {
        // To implement the IExtensibleDataObject interface, you must also
        // implement the ExtensionData property.
        private ExtensionDataObject extensionDataObjectValue;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObjectValue;
            }
            set
            {
                extensionDataObjectValue = value;
            }
        }

        [DataMember(Name = "CustName")]
        internal string Name;

        [DataMember(Name = "CustID")]
        internal int ID;

        public Person(string newName, int newID)
        {
            Name = newName;
            ID = newID;
        }

    }

    class Test
    {
        public static void Main()
        {
            try
            {
                WriteObject("DataContractExample.xml");
                ReadObject("DataContractExample.xml");
                Console.WriteLine("Press Enter to end");
                Console.ReadLine();
            }
            catch (SerializationException se)
            {
                Console.WriteLine
                ("The serialization operation failed. Reason: {0}",
                  se.Message);
                Console.WriteLine(se.Data);
                Console.ReadLine();
            }
        }

        public static void WriteObject(string path)
        {
            // Create a new instance of the Person class and 
            // serialize it to an XML file.
            Person p1 = new Person("Mary", 1);
            // Create a new instance of a StreamWriter
            // to read and write the data.
            FileStream fs = new FileStream(path,
            FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person));
            ser.WriteObject(writer, p1);
            Console.WriteLine("Finished writing object.");
            writer.Close();
            fs.Close();
        }
        public static void ReadObject(string path)
        {
            // Deserialize an instance of the Person class 
            // from an XML file. First create an instance of the 
            // XmlDictionaryReader.
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            // Create the DataContractSerializer instance.
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person));

            // Deserialize the data and read it from the instance.
            Person newPerson = (Person)ser.ReadObject(reader);
            Console.WriteLine("Reading this object:");
            Console.WriteLine(String.Format("{0}, ID: {1}",
            newPerson.Name, newPerson.ID));
            fs.Close();
        }

    }
}