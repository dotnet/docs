//<snippet0>
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.IO;

[assembly: SecurityPermission(
SecurityAction.RequestMinimum, Execution = true)]
namespace ISerializableExample
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Run();
            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}: {1}", exc.Message, exc.StackTrace);
            }
            finally
            {
                Console.WriteLine("Press Enter to exit....");
                Console.ReadLine();
            }
        }

        static void Run()
        {            
            BinaryFormatter binaryFmt = new BinaryFormatter();
            Person p = new Person();
            p.IdNumber = 1010;
            p.Name = "AAAAA";
            FileStream fs = new FileStream
                ("Person.xml", FileMode.OpenOrCreate);
            binaryFmt.Serialize(fs, p);
            fs.Close();
            Console.WriteLine
                ("Original Name: {0}, Original ID: {1}", p.Name, p.IdNumber);

            // Deserialize.
            fs = new FileStream
                ("Person.xml", FileMode.OpenOrCreate);
            Person p2 = (Person)binaryFmt.Deserialize(fs);
                Console.WriteLine("New Name: {0}, New ID: {1}", p2.Name, p2.IdNumber);
            fs.Close();
            }
        }
    [Serializable]
    public class Person : ISerializable
    {
        private string name_value;
        private int ID_value;

        public Person() { }
        protected Person(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            name_value = (string)info.GetValue("AltName", typeof(string));
            ID_value = (int)info.GetValue("AltID", typeof(int));
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(
        SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("AltName", "XXX");
            info.AddValue("AltID", 9999);
        }

        public string Name
        {
            get { return name_value; }
            set { name_value = value; }
        }

        public int IdNumber
        {
            get { return ID_value; }
            set { ID_value = value; }
        }
    }
}
//</snippet0>