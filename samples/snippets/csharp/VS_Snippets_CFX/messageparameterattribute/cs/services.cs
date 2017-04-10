// <snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(Namespace="http://microsoft.wcf.documentation")]
  public interface ISampleService{
    [OperationContract]
    [return:MessageParameter(Name = "Output")]
    string SampleMethod([MessageParameter(Name = "Input")]string msg);
  }

  /*
   The preceding use of MessageParameterAttribute generates the following XSD:

<?xml version="1.0" encoding="utf-8" ?> 
  <xs:schema 
    elementFormDefault="qualified" 
    targetNamespace="http://microsoft.wcf.documentation" 
    xmlns:xs="http://www.w3.org/2001/XMLSchema" 
    xmlns:tns="http://microsoft.wcf.documentation">
    <xs:element name="SampleMethod">
      <xs:complexType>
        <xs:sequence>
          <xs:element minOccurs="0" name="Input" nillable="true" type="xs:string" /> 
        </xs:sequence>
      </xs:complexType>
    </xs:element>
    <xs:element name="SampleMethodResponse">
      <xs:complexType>
        <xs:sequence>
          <xs:element minOccurs="0" name="Output" nillable="true" type="xs:string" /> 
        </xs:sequence>
      </xs:complexType>
    </xs:element>
  </xs:schema>
   
   And the message sent is edited for clarity:
  <s:Body>
    <SampleMethod xmlns="http://microsoft.wcf.documentation">
      <Input>hello!</Input>
    </SampleMethod>
  </s:Body>   
   */
  // </snippet1>

  class SampleService : ISampleService
  {
    public string  SampleMethod(string msg)
    {
 	    return "The service greets you: " + msg;
    }
  }
}
