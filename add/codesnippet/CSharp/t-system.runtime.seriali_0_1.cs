    [DataContract]
    public enum Position
    {
        [EnumMember(Value = "Emp")]
        Employee,
        [EnumMember(Value = "Mgr")]
        Manager,
        [EnumMember(Value = "Ctr")]
        Contractor,
        NotASerializableEnumeration
    }

    [DataContract]
    public class Person : IExtensibleDataObject
    {
        public Person(string firstNameValue, string lastNameValue)
        {
            LastName = firstNameValue;
            FirstName = lastNameValue;
        }

        private ExtensionDataObject extensioDataValue;
        public ExtensionDataObject ExtensionData
        {
            get { return extensioDataValue; }
            set { extensioDataValue = value; }
        }

        [DataMember]
        internal string FirstName;
        [DataMember]
        internal string LastName;
        [DataMember]
        internal Position Description;
    }

    public sealed class Test
    {
        private Test() { }
        static void Main()
        {

            try
            {

                Test t = new Test();
                t.Serialize("Enum.xml");
                Console.WriteLine("Done");
                Console.ReadLine();
            }
            catch (SerializationException  exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();

            }

        }



        private void Serialize(string path)
        {
            Console.WriteLine("Serializing...");
            Person p = new Person("Denise", "Smith");
            p.Description = Position.Manager;

            FileStream fs = new FileStream(path, FileMode.Create);

            try
            {
                DataContractSerializer ser =
                    new DataContractSerializer(typeof(Person));
                ser.WriteObject(fs, p);
                Console.WriteLine("Done");
            }
            catch (SerializationException exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.StackTrace);
            }
            finally
            {
                fs.Close();
            }
        }
    }