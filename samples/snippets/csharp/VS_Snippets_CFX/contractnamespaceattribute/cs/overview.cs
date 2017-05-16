using System.Security.Permissions;
using System;
using System.Runtime.Serialization;
[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
//<snippet1>
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
//</snippet1>
namespace TestNamespace
{   public class Test
    {
        static void Main(){
            Console.WriteLine("Just for compiling.");
        }
    }
}


