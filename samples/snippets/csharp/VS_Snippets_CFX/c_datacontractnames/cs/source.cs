using System;
using System.Runtime.Serialization;

//<snippet1>
// This overrides the standard namespace mapping for all contracts
// in Contoso.CRM.
[assembly: ContractNamespace("http://schemas.example.com/crm",
   ClrNamespace = "Contoso.CRM")]
namespace Contoso.CRM
{
    // The namespace is overridden to become:
    // http://schemas.example.com/crm.
    // But the name is the default "Customer".
    [DataContract]
    public class Customer
    {
        // Code not shown.
    }
}
namespace Contoso.OrderProc
{
    [DataContract]
    public class PurchaseOrder
    {
        // This data member is named "Amount" by default.
        [DataMember]
        public double Amount;

        // The default is overridden to become "Address".
        [DataMember(Name = "Address")]
        public string Ship_to;
    }
    // The namespace is the default value:
    // http://schemas.datacontract.org/2004/07/Contoso.OrderProc
    // The name is "PurchaseOrder" instead of "MyInvoice".
    [DataContract(Name = "PurchaseOrder")]
    public class MyInvoice
    {
        // Code not shown.
    }

    // The contract name is "Payment" instead of "MyPayment"
    // and the Namespace is "http://schemas.example.com" instead
    // of the default.
    [DataContract(Name = "Payment",
        Namespace = "http://schemas.example.com")]
    public class MyPayment
    {
        // Code not shown.
    }
}
//</snippet1>

namespace Snippet2
{
    //<snippet2>
    [DataContract]
    public class Drawing<Shape, Brush>
    {
        // Code not shown.
    }

    [DataContract(Namespace = "urn:shapes")]
    public class Square
    {
        // Code not shown.
    }

    [DataContract(Name = "RedBrush", Namespace = "urn:default")]
    public class RegularRedBrush
    {
        // Code not shown.
    }

    [DataContract(Name = "RedBrush", Namespace = "urn:special")]
    public class SpecialRedBrush
    {
        // Code not shown.
    }
    //</snippet2>
}

namespace Snippet3
{
    //<snippet3>
    [DataContract(Name = "Drawing_using_{1}_brush_and_{0}_shape")]
    public class Drawing<Shape, Brush>
    {
        // Code not shown.
    }
    //</snippet3>
    public class Test
    {
        static void Main()
        { }
    }
}

namespace DataMemberOrder
{

    //<snippet4>
    [DataContract]
    public class BaseType
    {

        [DataMember]
        public string zebra;
    }
    [DataContract]
    public class DerivedType : BaseType
    {
        [DataMember(Order = 0)]
        public string bird;
        [DataMember(Order = 1)]
        public string parrot;
        [DataMember]
        public string dog;
        [DataMember(Order = 3)]
        public string antelope;
        [DataMember]
        public string cat;
        [DataMember(Order = 1)]
        public string albatross;
    }
    //</snippet4>
}
namespace DataContractEquivalence
{
    //<snippet5>
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string fullName;

        [DataMember]
        public string telephoneNumber;
    }

    [DataContract(Name = "Customer")]
    public class Person
    {
        [DataMember(Name = "fullName")]
        private string nameOfPerson;

        private string address;

        [DataMember(Name = "telephoneNumber")]
        private string phoneNumber;
    }
    //</snippet5>

    //<snippet6>
    [DataContract(Name = "Coordinates")]
    public class Coords1
    {
        [DataMember]
        public int X;
        [DataMember]
        public int Y;
        // Order is alphabetical (X,Y).
    }

    [DataContract(Name = "Coordinates")]
    public class Coords2
    {
        [DataMember]
        public int Y;
        [DataMember]
        public int X;
        // Order is alphabetical (X,Y), equivalent
        // to the preceding code.
    }

    [DataContract(Name = "Coordinates")]
    public class Coords3
    {
        [DataMember(Order = 2)]
        public int Y;
        [DataMember(Order = 1)]
        public int X;
        // Order is according to the Order property (X,Y),
        // equivalent to the preceding code.
    }
    //</snippet6>

    //<snippet7>
    [DataContract(Name = "Coordinates")]
    public class Coords4
    {
        [DataMember(Order = 1)]
        public int Y;
        [DataMember(Order = 2)]
        public int X;
        // Order is according to the Order property (Y,X),
        // different from the preceding code.
    }
    //</snippet7>
}

namespace DatacontractEQ2
{
    //<snippet8>
    [DataContract]
    public class Person
    {
        [DataMember]
        public string name;
    }
    [DataContract]
    public class Employee : Person
    {
        [DataMember]
        public int department;
        [DataMember]
        public string title;
        [DataMember]
        public int salary;
    }
    // Order is "name", "department", "salary", "title"
    // (base class first, then alphabetical).

    [DataContract(Name = "Employee")]
    public class Worker
    {
        [DataMember(Order = 1)]
        public string name;
        [DataMember(Order = 2)]
        public int department;
        [DataMember(Order = 2)]
        public string title;
        [DataMember(Order = 2)]
        public int salary;
    }
    // Order is "name", "department", "salary", "title"
    // (Order=1 first, then Order=2 in alphabetical order),
    // which is equivalent to the Employee order}.
    //</snippet8>
}