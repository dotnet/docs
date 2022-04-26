using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Xml;
namespace DataContractsPrime
{
    //C_DataContractVersioning#1
    //<snippet1>
    // Version 1
    [DataContract]
    public class Person
    {
        [DataMember]
        private string Phone;
    }
    //</snippet1>
}
namespace DataContracts
{
    //<snippet2>
    // Version 2. This is a non-breaking change because the data contract
    // has not changed, even though the type has.
    [DataContract]
    public class Person
    {
        [DataMember(Name = "Phone")]
        private string Telephone;
    }
    //</snippet2>

    //C_DataContractVersioning#2
    //<snippet3>
    // Version 1 of a data contract, on machine V1.
    [DataContract(Name = "Car")]
    public class CarV1
    {
        [DataMember]
        private string Model;
    }

    // Version 2 of the same data contract, on machine V2.
    [DataContract(Name = "Car")]
    public class CarV2
    {
        [DataMember]
        private string Model;

        [DataMember]
        private int HorsePower;
    }
    //</snippet3>
    public class Test
    {
        static void Main()
        {
        }
    }
}
