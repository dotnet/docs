// <snippet1>
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(Namespace = "http://microsoft.wcf.documentation")]
  public interface ISampleService{
    [OperationContract]
    Person SampleMethod(Person personParam);
  }

  [DataContract(Name="OriginalPerson", Namespace="http://microsoft.wcf.documentation")]
  public class Person : IExtensibleDataObject
  {
    [DataMember]
    public string firstName;
    [DataMember]
    public string lastName;
    [DataMember]
    public string Message;
    [DataMember]
    public XmlNode[] Blob;

    #region IExtensibleDataObject Members
    private ExtensionDataObject data = null;

    public ExtensionDataObject ExtensionData
    {
      get
      {
        return this.data;
      }
      set
      {
        this.data = value;
      }
    }
    #endregion
  }

  [ServiceBehaviorAttribute(
    IgnoreExtensionDataObject=false, 
    ValidateMustUnderstand=false
  )]
  class SampleService : ISampleService
  {
  #region ISampleService Members
    public Person SampleMethod(Person msg)
    {
      Console.WriteLine(msg.firstName);
      Console.WriteLine(msg.lastName);
      Console.WriteLine(msg.Message);

      msg.lastName = "First Name";
      msg.firstName = "Last Name";
      msg.Message = "This is the Reply message.";
 	    return msg;
    }
  #endregion
  }
}
// </snippet1>
