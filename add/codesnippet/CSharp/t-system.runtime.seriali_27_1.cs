[assembly: ContractNamespaceAttribute("http://www.cohowinery.com/employees",
    ClrNamespace = "Microsoft.Contracts.Examples")]
namespace Microsoft.Contracts.Examples
{
    [DataContract]
    public class Person
    {
        [DataMember]
        internal string FirstName;
        [DataMember]
        internal string LastName;
    }
}