using System;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.WCF.Documentation
{
	[ServiceContract(
    Namespace="http://microsoft.wcf.documentation",
    ProtectionLevel=ProtectionLevel.EncryptAndSign
  )]
	[WsdlDocumentation("This contract is a stateless contract that provides a mechanism for computing the nth Fibonacci term.")]
	public interface IFibonacci
	{
		[OperationContract]
		[OperationCaching(true)]
		[WsdlDocumentation("The Compute operation returns the nth Fibonacci number.  Because it uses dual recursion it's very inefficient and therefore useful to demonstrate caching.")]
		[return:WsdlParameterDocumentation("The nth Fibonacci number.")]
    int Compute(
      [WsdlParameterDocumentation("The value to use when computing the Fibonacci number.")]
      int num);

    [OperationContract]
    [WsdlDocumentation("The GetPerson operation tests custom WSDL documentation generation.")]
    [return: WsdlParameterDocumentation("The Person object to be returned.")]
    Person GetPerson(
     [WsdlParameterDocumentation("The value for the first parameter.")]
      int FirstParameter, 
      [WsdlParameterDocumentation("The value for the second parameter.")]
      int SecondParameter  
    );
  }

  [DataContract]
  [DataContractDocumentation("The string for the Person type.")]
  public class Person
  {
    string internalName;

    public Person(string n)
    {
      this.internalName = n; 
    }

    [DataMember]
    [DataContractDocumentation("The string for the Name data member.")]
    public string Name
    {
      get { return this.internalName; }
      set { this.internalName = value; }
    }
  }
}
