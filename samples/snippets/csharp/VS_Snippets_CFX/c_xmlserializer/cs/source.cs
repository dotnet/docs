using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.Xml.Serialization;

namespace UsingXml1
{
    public class Test
    {
        static void Main()
        {
            // empty.
        }
    }

    //<snippet1>
    [ServiceContract]
    [XmlSerializerFormat]
    public class BankingService
    {
	[OperationContract]
        public void ProcessTransaction(BankingTransaction bt)
        {
            // Code not shown.
        }
    }

    //BankingTransaction is not a data contract class,
    //but is an XmlSerializer-compatible class instead.
    public class BankingTransaction
    {
        [XmlAttribute]
        public string Operation;
        [XmlElement]
        public Account fromAccount;
        [XmlElement]
        public Account toAccount;
        [XmlElement]
        public int amount;
    }
    //Notice that the Account class must also be XmlSerializer-compatible.
    //</snippet1>

    public class Account
    {
        public string AcctNumber;
    }

    //<snippet2>
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string firstName;
        [DataMember]
        public string lastName;
        public string creditCardNumber;
    }
    //</snippet2>
}
namespace UsingXml2
{
    using UsingXml1;
    //<snippet3>
    [ServiceContract]
    [XmlSerializerFormat]
    public class BankingService
    {
        [OperationContract]
        public void ProcessTransaction(BankingTransaction bt)
        {
            //Code not shown.
        }
    }

    [MessageContract]
    public class BankingTransaction
    {
        [MessageHeader]
        public string Operation;
        [XmlElement, MessageBodyMember]
        public Account fromAccount;
        [XmlElement, MessageBodyMember]
        public Account toAccount;
        [XmlAttribute, MessageBodyMember]
        public int amount;
    }
    //</snippet3>
}

namespace UsingXml3
{
    using UsingXml1;

    //<snippet4>
    [MessageContract]
    public class BankingTransaction
    {
        [MessageHeader] public string Operation;

        //This element will be <fromAcct> and not <from>:
        [XmlElement(ElementName="fromAcct"), MessageBodyMember(Name="from")]
        public Account fromAccount;

        [XmlElement, MessageBodyMember]
        public Account toAccount;

        [XmlAttribute, MessageBodyMember]
        public int amount;
}
    //</snippet4>
}
