' System.Web.Services.Description.SoapBinding.ctor
' System.Web.Services.Description.SoapBinding.Transport
' System.Web.Services.Description.SoapBinding.Style
' System.Web.Services.Description.SoapBindingStyle.Document
' System.Web.Services.Description.SoapOperationBinding.ctor
' System.Web.Services.Description.SoapOperationBinding.SoapAction
' System.Web.Services.Description.SoapOperationBinding.Style
' System.Web.Services.Description.SoapBodyBinding.ctor
' System.Web.Services.Description.SoapBodyBinding.Use
' System.Web.Services.Description.SoapBindingUse.Literal
' System.Web.Services.Description.SoapAddressBinding.ctor
' System.Web.Services.Description.SoapAddressBinding.Location

' The following example demonstrates the 'SoapBinding' constructor,'Transport','Style'
' properties of 'SoapBinding' class,'Document' member of 'SoapBindingStyle' enum,
' 'SoapOperationBinding' constructor,'SoapAction','Style' properties of 'SoapOperationBinding'
' class, 'SoapBodyBinding' contructor,'Use' property of 'SoapBodyBinding' class,
' 'Literal' member of 'SoapBindingUse' enum and 'SoapAddressBinding' constructor, 'Location' 
' property  of class 'SoapAddressBinding'.

' It takes as input a wsdl file which supports two protocols 'HttpGet' and 'HttpPost' .
' By using the 'Read' method of 'ServiceDescription' class it gets a 'ServiceDescription'
' object. It uses the SOAP protocol related classes  and  creates 'Binding','Port',
' 'PortType' and 'Message' elements of 'SOAP' protocol. It adds all these elements to 
' the 'ServiceDescription' object. The 'ServiceDescription' object creates another 
' wsdl file which supports 'SOAP' also. This wsdl file is used to generate a proxy
' which is used by the .aspx file.
' Note: To run the example run the make file provided and open the '.aspx' file in browser.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MySoapClass

   Public Shared Sub Main()
      Dim myDescription As ServiceDescription = _
                        ServiceDescription.Read("AddNumbersInput_vb.wsdl")
      ' Create a 'Binding' object for the 'SOAP' protocol.
      Dim myBinding As New Binding()
      myBinding.Name = "Service1Soap"
      Dim qualifiedName As New XmlQualifiedName("s0:Service1Soap")
      myBinding.Type = qualifiedName

' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      mySoapBinding.Style = SoapBindingStyle.Document
      ' Add the 'SoapBinding' object to the 'Binding' object.
      myBinding.Extensions.Add(mySoapBinding)
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>

      ' Create the 'OperationBinding' object for the 'SOAP' protocol.
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = "AddNumbers"

' <Snippet5>
' <Snippet6>
' <Snippet7>
      ' Create the 'SoapOperationBinding' object for the 'SOAP' protocol.
      Dim mySoapOperationBinding As New SoapOperationBinding()
      mySoapOperationBinding.SoapAction = "http://tempuri.org/AddNumbers"
      mySoapOperationBinding.Style = SoapBindingStyle.Document
      ' Add the 'SoapOperationBinding' object to 'OperationBinding' object.
      myOperationBinding.Extensions.Add(mySoapOperationBinding)
' </Snippet7>
' </Snippet6>
' </Snippet5>

' <Snippet8>
' <Snippet9>
' <Snippet10>
      ' Create the 'InputBinding' object for the 'SOAP' protocol.
      Dim myInput As New InputBinding()
      Dim mySoapBinding1 As New SoapBodyBinding()
      mySoapBinding1.Use = SoapBindingUse.Literal
      myInput.Extensions.Add(mySoapBinding1)
      ' Add the 'InputBinding' object to 'OperationBinding' object.
      myOperationBinding.Input = myInput
      ' Create the 'OutputBinding' object'.
      Dim myOutput As New OutputBinding()
      myOutput.Extensions.Add(mySoapBinding1)
      ' Add the 'OutputBinding' object to 'OperationBinding' object.
      myOperationBinding.Output = myOutput
      ' Add the 'OperationBinding' object to 'Binding' object.
      myBinding.Operations.Add(myOperationBinding)
      ' Add the 'Binding' object to the ServiceDescription instance.
      myDescription.Bindings.Add(myBinding)
' </Snippet10>
' </Snippet9>
' </Snippet8>

' <Snippet11>
' <Snippet12>
      Dim soapPort As New Port()
      soapPort.Name = "Service1Soap"
      soapPort.Binding = New XmlQualifiedName("s0:Service1Soap")
      ' Create a 'SoapAddressBinding' object for the 'SOAP' protocol.
      Dim mySoapAddressBinding As New SoapAddressBinding()
      mySoapAddressBinding.Location = "http://localhost/Service1_vb.asmx"
      ' Add the 'SoapAddressBinding' object to the 'Port'.
      soapPort.Extensions.Add(mySoapAddressBinding)
      ' Add the 'Port' object to the ServiceDescription instance.
      myDescription.Services(0).Ports.Add(soapPort)
' </Snippet12>
' </Snippet11>

      ' Create a 'PortType' object. for SOAP protocol.
      Dim soapPortType As New PortType()
      soapPortType.Name = "Service1Soap"
      Dim soapOperation As New Operation()
      soapOperation.Name = "AddNumbers"

      Dim soapInput As OperationMessage = _
                           CType(New OperationInput(), OperationMessage)
      soapInput.Message = New XmlQualifiedName("s0:AddNumbersSoapIn")
      Dim soapOutput As OperationMessage = _
                           CType(New OperationOutput(), OperationMessage)
      soapOutput.Message = New XmlQualifiedName("s0:AddNumbersSoapOut")

      soapOperation.Messages.Add(soapInput)
      soapOperation.Messages.Add(soapOutput)

      ' Add the 'Operation' object to 'PortType' object.
      soapPortType.Operations.Add(soapOperation)

      ' Add the 'PortType' object first to 'PortTypeCollection' object
      ' and then to 'ServiceDescription' object.
      myDescription.PortTypes.Add(soapPortType)

      ' Create the 'Message' object.
      Dim soapMessage1 As New Message()
      soapMessage1.Name = "AddNumbersSoapIn"
      ' Create the 'MessageParts' object.
      Dim soapMessagePart1 As New MessagePart()
      soapMessagePart1.Name = "parameters"
      soapMessagePart1.Element = New XmlQualifiedName("s0:AddNumbers")

      ' Add the 'MessagePart' object to 'Messages' object.
      soapMessage1.Parts.Add(soapMessagePart1)

      ' Create another 'Message' object.
      Dim soapMessage2 As New Message()
      soapMessage2.Name = "AddNumbersSoapOut"

      Dim soapMessagePart2 As New MessagePart()
      soapMessagePart2.Name = "parameters"
      soapMessagePart2.Element = New XmlQualifiedName("s0:AddNumbersResponse")
      ' Add the 'MessagePart' object to second 'Message' object.
      soapMessage2.Parts.Add(soapMessagePart2)

      ' Add the 'Message' objects to 'ServiceDescription'.
      myDescription.Messages.Add(soapMessage1)
      myDescription.Messages.Add(soapMessage2)

      ' Write the 'ServiceDescription' object as a WSDL file.
      myDescription.Write("AddNumbersOut_vb.wsdl")
      Console.WriteLine(" 'AddNumbersOut.Wsdl' file was generated")
   End Sub 'Main
End Class 'MySoapClass