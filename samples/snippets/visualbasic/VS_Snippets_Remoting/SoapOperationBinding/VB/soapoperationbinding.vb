' System.Web.Services.Description.SoapBinding
' System.Web.Services.Description.SoapOperationBinding
' System.Web.Services.Description.SoapBodyBinding
' System.Web.Services.Description.SoapAddressBinding
' System.Web.Services.Description.SoapBinding.HttpTransport;

' The following example demonstrates the 'SoapBinding', 'SoapOperationBinding' ,
' 'SoapBodyBinding' , SoapAddressBinding'  classes and 'HttpTransport' field of
' 'SoapBinding' class.

' It takes a wsdl file which supports two protocols 'HttpGet' and 'HttpPost' as
' input. By using the 'Read' method of 'ServiceDescription' class it gets the
' 'ServiceDescription' object. It uses the SOAP protocol related classes and
' creates 'Binding','Port' and 'PortType' elements of 'SOAP' protocol. It adds
' all the elements to the 'ServiceDescription' object. The 'ServiceDescription'
' object creates another wsdl file which supports 'SOAP' also. This wsdl file 
' is used to generate a proxy which is used by the .aspx file.

' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
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

' <Snippet5>
      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Transport = SoapBinding.HttpTransport
      mySoapBinding.Style = SoapBindingStyle.Document
' </Snippet5>

      ' Add the 'SoapBinding' object to the 'Binding' object.
      myBinding.Extensions.Add(mySoapBinding)

      ' Create the 'OperationBinding' object for the 'SOAP' protocol.
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = "AddNumbers"

      ' Create the 'SoapOperationBinding' object for the 'SOAP' protocol.
      Dim mySoapOperationBinding As New SoapOperationBinding()
      mySoapOperationBinding.SoapAction = "http://tempuri.org/AddNumbers"
      mySoapOperationBinding.Style = SoapBindingStyle.Document
      ' Add the 'SoapOperationBinding' object to 'OperationBinding' object.
      myOperationBinding.Extensions.Add(mySoapOperationBinding)

      ' Create the 'InputBinding' object for the 'SOAP' protocol.
      Dim myInput As New InputBinding()
      Dim mySoapBinding1 As New SoapBodyBinding()
      mySoapBinding1.Use = SoapBindingUse.Literal
      myInput.Extensions.Add(mySoapBinding1)
      ' Assign the 'InputBinding' to 'OperationBinding'.
      myOperationBinding.Input = myInput
      ' Create the 'OutputBinding' object' for the 'SOAP' protocol.
      Dim myOutput As New OutputBinding()
      myOutput.Extensions.Add(mySoapBinding1)
      ' Assign the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding.Output = myOutput

      ' Add the 'OperationBinding' to 'Binding'.
      myBinding.Operations.Add(myOperationBinding)

      ' Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myDescription.Bindings.Add(myBinding)

      Dim soapPort As New Port()
      soapPort.Name = "Service1Soap"
      soapPort.Binding = New XmlQualifiedName("s0:Service1Soap")

      ' Create a 'SoapAddressBinding' object for the 'SOAP' protocol.
      Dim mySoapAddressBinding As New SoapAddressBinding()
      mySoapAddressBinding.Location = "http://localhost/AddNumbers.vb.asmx"

      ' Add the 'SoapAddressBinding' to the 'Port'.
      soapPort.Extensions.Add(mySoapAddressBinding)

      ' Add the 'Port' to 'PortCollection' of 'ServiceDescription'.
      myDescription.Services(0).Ports.Add(soapPort)

      ' Write the 'ServiceDescription' as a WSDL file.
      myDescription.Write("AddNumbersOut_vb.wsdl")
      Console.WriteLine(" 'AddNumbersOut_vb.Wsdl' file was generated")
   End Sub 'Main
End Class 'MySoapClass
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>