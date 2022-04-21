using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Example
{
    //<snippet1>
    [ServiceContract]
    public interface ISampleInterface
    {
        // No data contract is required since both the parameter
        // and return types are primitive types.
        [OperationContract]
        double SquareRoot(int root);

        // No Data Contract required because both parameter and return
        // types are marked with the SerializableAttribute attribute.
        [OperationContract]
        System.Drawing.Bitmap GetPicture(System.Uri pictureUri);

        // The MyTypes.PurchaseOrder is a complex type, and thus
        // requires a data contract.
        [OperationContract]
        bool ApprovePurchaseOrder(MyTypes.PurchaseOrder po);
    }
    //</snippet1>

    public sealed class Test
    {
        private Test() { }
        static void Main()
        { }
    }
}

//<snippet2>
namespace MyTypes
{
    [DataContract]
    public class PurchaseOrder
    {
        private int poId_value;

        // Apply the DataMemberAttribute to the property.
        [DataMember]
        public int PurchaseOrderId
        {

            get { return poId_value; }
            set { poId_value = value; }
        }
    }
}
//</snippet2>

namespace GenericTypes
{

    //<snippet3>
    [DataContract]
    public class MyGenericType1<T>
    {
        // Code not shown.
    }
    //</snippet3>

    //<snippet4>
    [DataContract]
    public class MyGenericType2<T>
    {
        [DataMember]
        T theData;
    }
    //</snippet4>
}

namespace Intro
{
    //<snippet5>
    [DataContractAttribute]
    public class Person
    {
        [DataMemberAttribute]
        private string Name;

        private string NickName;
        [DataMemberAttribute]
        private Address address;
    }

    [DataContractAttribute]
    public class Address
    {
        [DataMemberAttribute]
        private string AddressLine1;
        [DataMemberAttribute]
        private string AddressLine2;
        [DataMemberAttribute]
        private string AddressLine3;
        [DataMemberAttribute]
        private string CityName;
        [DataMemberAttribute]
        private string Postcode;
        [DataMemberAttribute]
        private string CountryName;
    }
    //</snippet5>
}

namespace Intro2
{
    //<snippet6>
    public class Person
    {
        private string Name;
        private string NickName;
        private Address Address;
    }

    public class Address
    {
        private string AddressLine1;
        private string AddressLine2;
        private string AddressLine3;
        private string CityName;
        private string PostCode;
        private string CountryName;
    }
    //</snippet6>
}

namespace ForwardCompatible1
{
    //<snippet7>
    [DataContract]
    public class Person
    {
        [DataMember]
        public string fullName;
    }
    //</snippet7>
}

namespace ForwardCompatible
{
    //<snippet8>
    [DataContract]
    public class Person : IExtensibleDataObject
    {
        [DataMember]
        public string fullName;
        private ExtensionDataObject theData;

        public virtual ExtensionDataObject ExtensionData
        {
            get { return theData; }
            set { theData = value; }
        }
    }
    //</snippet8>
}
namespace VersionTolerantCallback
{
    //<snippet9>
    // The following Data Contract is version 2 of an earlier data
    // contract.
    [DataContract]
    public class Address
    {
        [DataMember]
        public string Street;

        [DataMember]
        public string State;

        // This data member was added in version 2, and thus may be missing
        // in the incoming data if the data conforms to version 1 of the
        // Data Contract. Use the callback to add a default for this case.
        [DataMember(Order=2)]
        public string CountryRegion;

        // This method is used as a kind of constructor to initialize
        // a default value for the CountryRegion data member before
        // deserialization.
        [OnDeserializing]
        private void setDefaultCountryRegion(StreamingContext c)
        {
            CountryRegion = "Japan";
        }
    }
    //</snippet9>
}
