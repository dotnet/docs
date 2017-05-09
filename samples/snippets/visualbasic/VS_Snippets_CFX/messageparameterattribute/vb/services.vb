' <snippet1>
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://microsoft.wcf.documentation")> _
  Public Interface ISampleService
	<OperationContract> _
	Function SampleMethod(<MessageParameter(Name := "Input")> ByVal msg As String) As <MessageParameter(Name := "Output")> String
  End Interface

'  
'   The preceding use of MessageParameterAttribute generates the following XSD:
'
'<?xml version="1.0" encoding="utf-8" ?> 
'  <xs:schema 
'    elementFormDefault="qualified" 
'    targetNamespace="http://microsoft.wcf.documentation" 
'    xmlns:xs="http://www.w3.org/2001/XMLSchema" 
'    xmlns:tns="http://microsoft.wcf.documentation">
'    <xs:element name="SampleMethod">
'      <xs:complexType>
'        <xs:sequence>
'          <xs:element minOccurs="0" name="Input" nillable="true" type="xs:string" /> 
'        </xs:sequence>
'      </xs:complexType>
'    </xs:element>
'    <xs:element name="SampleMethodResponse">
'      <xs:complexType>
'        <xs:sequence>
'          <xs:element minOccurs="0" name="Output" nillable="true" type="xs:string" /> 
'        </xs:sequence>
'      </xs:complexType>
'    </xs:element>
'  </xs:schema>
'   
'   And the message sent is edited for clarity:
'  <s:Body>
'    <SampleMethod xmlns="http://microsoft.wcf.documentation">
'      <Input>hello!</Input>
'    </SampleMethod>
'  </s:Body>   
'   
  ' </snippet1>

  Friend Class SampleService
	  Implements ISampleService
	Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
		 Return "The service greets you: " & msg
	End Function
  End Class
End Namespace
