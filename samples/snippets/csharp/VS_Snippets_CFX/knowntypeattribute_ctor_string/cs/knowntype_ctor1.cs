
using System.Security.Permissions;

[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
//<snippet1>
namespace KnownTypeAttributeExample
{
    using System;
    using System.Xml;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.IO;
    // The constructor names the method that returns an array 
    // of types that can be used during deserialization.
    [KnownTypeAttribute("KnownTypes")]
    [DataContract]
    public class Employee
    {
        public Employee(string newFName, string newLName)
        {
            FirstName = newFName;
            LastName = newLName;
        }
        [DataMember]
        internal string FirstName;
        [DataMember]
        internal string LastName;
        [DataMember]
        internal int id;
        [DataMember]
        internal Manager Boss;

        // This method returns the array of known types.
        static Type[] KnownTypes()
        {
            return new Type[]{typeof(Manager), typeof(Employee)};
        }
    }

    [DataContract]
    public class Manager : Employee
    {
        // Call the base class's constructor.
        public Manager(string newFName, string newLName)
            : base(newFName, newLName)
        { }
        
        [DataMember]
        internal Employee[] Reports;
        
    }

    class Program
    {
        public static void Main()
        {
            try
            {
                Serialize("person1.xml");
                Deserialize("person1.xml");
            }
            catch (SerializationException se)
            {
                Console.WriteLine("{0}: {1}",
                se.Message, se.StackTrace);
            }
            finally
            {
                Console.WriteLine("Press Enter to exit....");
                Console.ReadLine();
            }
        }

        static void Serialize(string path)
        {
            Employee emp = new Employee("John", "Peoples");
            emp.id = 3001;
            Manager theBoss = new Manager("Michiyo", "Sato");
            theBoss.id = 41;
            emp.Boss = theBoss;
            
            DataContractSerializer ser = 
                new DataContractSerializer(typeof(Employee));

            FileStream fs =
                new FileStream(path, FileMode.OpenOrCreate);
            ser.WriteObject(fs, emp);
            fs.Close();
        }
        static void Deserialize(string path)
        {
            DataContractSerializer ser = 
                new DataContractSerializer(typeof(Employee));
            FileStream fs = new FileStream(path,
            FileMode.Open);
            Employee p = (Employee)ser.ReadObject(fs);

            Console.WriteLine("{0} {1}, id:{2}", p.FirstName,
                p.LastName, p.id);
            fs.Close();
        }
    }
}
//</snippet1>