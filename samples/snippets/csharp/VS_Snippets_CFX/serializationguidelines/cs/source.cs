using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace MiscCodeExamples
{

    public class Test
    {
        static void Main()
        {
            Person p = new Person("John", "Lennon");
            Person2 p2 = new Person2("John", "Lennon");
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }

    //<snippet1>
    [DataContract]
    class Person
    {

        [DataMember]
        string LastName { get; set; }
        [DataMember]
        string FirstName { get; set; }

        public Person(string firstNameValue, string lastNameValue)
        {
            FirstName = firstNameValue;
            LastName = lastNameValue;
        }
    }

    //</snippet1>

    //<snippet2>
    [DataContract]
    class Person2
    {

        string lastName;
        string firstName;

        public Person2(string firstName, string lastName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
        }

        [DataMember]
        public string LastName
        {
            // Implement get and set.
            get { return lastName; }
            private set { lastName = value; }
        }

        [DataMember]
        public string FirstName
        {
            // Implement get and set.
            get { return firstName; }
            private set { firstName = value; }
        }
    }
    //</snippet2>

    //<snippet3>
    [DataContract]
    class Person3
    {
        [DataMember]
        string lastName;
        [DataMember]
        string firstName;
        string fullName;

        public Person3(string firstName, string lastName)
        {
            // This constructor is not called during deserialization.
            this.lastName = lastName;
            this.firstName = firstName;
            fullName = firstName + " " + lastName;
        }

        public string FullName
        {
            get { return fullName; }
        }

        // This method is called after the object
        // is completely deserialized. Use it instead of the
        // constructror.
        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            fullName = firstName + " " + lastName;
        }
    }
    //</snippet3>

    //<snippet4>
    // The KnownTypeAttribute specifies types to be
    // used during serialization.
    [KnownType(typeof(USAddress))]
    [DataContract]
    class Person4
    {

        [DataMember]
        string fullNameValue;
        [DataMember]
        Address address; // Address is abstract

        public Person4(string fullName, Address address)
        {
            this.fullNameValue = fullName;
            this.address = address;
        }

        public string FullName
        {
            get { return fullNameValue; }
        }
    }

    [DataContract]
    public abstract class Address
    {
        public abstract string FullAddress { get; }
    }

    [DataContract]
    public class USAddress : Address
    {

        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string ZipCode { get; set; }

        public override string FullAddress
        {
            get
            {
                return Street + "\n" + City + ", " + State + " " + ZipCode;
            }
        }
    }
    //</snippet4>

    //<snippet5>
    // Implement the IExtensibleDataObject interface.
    [DataContract]
    class Person5 : IExtensibleDataObject
    {
        ExtensionDataObject serializationData;
        [DataMember]
        string fullNameValue;

        public Person5(string fullName)
        {
            this.fullNameValue = fullName;
        }

        public string FullName
        {
            get { return fullNameValue; }
        }

        ExtensionDataObject IExtensibleDataObject.ExtensionData
        {
            get
            {
                return serializationData;
            }
            set { serializationData = value; }
        }
    }
    //</snippet5>

    //<snippet6>
    public class Address2
    {
        [System.Xml.Serialization.XmlAttribute] // Serialize as XML attribute, instead of an element.
        public string Name { get { return "Poe, Toni"; } set { } }
        [System.Xml.Serialization.XmlElement(ElementName = "StreetLine")] // Explicitly name the element.
        public string Street = "1 Main Street";
    }
    //</snippet6>

    //<snippet7>
    // Apply SerializableAttribute to support runtime serialization.
    [Serializable]
    public class Person6
    {
        // Code not shown.
    }
    //</snippet7>

    //<snippet8>
    // Implement the ISerializable interface for more control.
    [Serializable]
    public class Person_Runtime_Serializable : ISerializable
    {
        string fullName;

        public Person_Runtime_Serializable() { }
        
        //<snippet9>
        protected Person_Runtime_Serializable(SerializationInfo info, StreamingContext context){
            //</snippet9>
            if (info == null) throw new System.ArgumentNullException("info");
            fullName = (string)info.GetValue("name", typeof(string));
        }

        //<snippet10>
        void ISerializable.GetObjectData(SerializationInfo info,
                StreamingContext context) {
        //</snippet10>
            if (info == null) throw new System.ArgumentNullException("info");
            info.AddValue("name", fullName);
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
    }
    //</snippet8>
}
