//<snippet0>
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace KnownTypeAttributeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Serialize("KnownTypeAttributeExample.xml");
                Deserialize("KnownTypeAttributeExample.xml");
                // Run this twice. The second time, comment out the
                // Serialize call and comment out the 
                // KnownTypeAttribute on the Person class. The
                // deserialization will then fail.
            }
            catch (SerializationException exc)
            {
                Console.WriteLine("{0}: {1}", exc.Message,
                    exc.StackTrace);
            }
            finally
            {
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        }

        public static void Serialize(string path)
        {
            Person p = new Person();
            p.Miscellaneous.Add(DateTime.Now, "Hello");
            p.Miscellaneous.Add(DateTime.Now.AddSeconds(1), "World");
            IDInformation w = new IDInformation();
            w.ID = "1111 00000";
            p.Miscellaneous.Add(DateTime.Now.AddSeconds(2), w);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person));
            FileStream fs = new FileStream(path, FileMode.Create);
            using (fs)
            {
                ser.WriteObject(fs, p);
            }
        }

        public static void Deserialize(string path)
        {
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person));
            FileStream fs = new FileStream(path, FileMode.Open);
            using (fs)
            {
                Person p2 = (Person)ser.ReadObject(fs);
                Console.WriteLine("Count {0}", p2.Miscellaneous.Count);
                foreach (DictionaryEntry de in p2.Miscellaneous)
                {
                    Console.WriteLine("Key {0} Value: {1}", de.Key,
                    de.Value);
                    if (de.Value.GetType() == typeof(IDInformation))
                    {
                        IDInformation www = (IDInformation)de.Value;
                        Console.WriteLine(
                        "\t Found ID Information. ID: {0} \n", www.ID);
                    }
                }
            }
        }

        // Apply the KnownTypeAttribute to the class that 
        // includes a member that returns a Hashtable.
        [KnownType(typeof(IDInformation))]
        [DataContract]
        public class Person : IExtensibleDataObject
        {
            private ExtensionDataObject ExtensionDataObjectValue;

            public ExtensionDataObject ExtensionData
            {
                get { return ExtensionDataObjectValue; }
                set { ExtensionDataObjectValue = value; }
            }

            private Hashtable MiscellaneousValue = new Hashtable();
            [DataMember]
            public Hashtable Miscellaneous
            {
                get { return MiscellaneousValue; }
                set { MiscellaneousValue = value; }
            }
        }

        [DataContract]
        public class IDInformation : IExtensibleDataObject
        {
            private ExtensionDataObject ExtensionDataValue;
            public ExtensionDataObject ExtensionData
            {
                get { return ExtensionDataValue; }
                set { ExtensionDataValue = value; }
            }

            [DataMember]
            public string ID;
        }
    }
}
//</snippet0>