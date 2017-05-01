' System.Web.Services.Description.SoapBinding.Namespace
' System.Web.Services.Description.SoapBodyBinding.Parts

' The following example demonstrates the 'Namespace' field of 'SoapBinding' class
' and 'parts' property of 'SoapBodyBinding' class.
' It takes a wsdl file which supports two protocols 'HttpGet' and 'HttpPost' as input. By
' using the 'Read' method of 'ServiceDescription' class it gets the 'ServiceDescription'
' object. It uses the SOAP protocol related classes to create 'Binding' elements of
' 'SOAP' protocol. It adds all the elements to the 'ServiceDescription' object. The
' 'ServiceDescription' object creates another wsdl file which supports 'SOAP' protocol
' also. This wsdl file is used to generate a proxy which is used by the .aspx file.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MySoapClass
   
   Public Shared Sub Main()
      Dim myDescription As ServiceDescription = ServiceDescription.Read("AddNumbersInput_vb.wsdl")
      ' Create a 'Binding' object for the 'SOAP' protocol.
      Dim myBinding As New Binding()
      myBinding.Name = "Service1Soap"
      Dim qualifiedName As New XmlQualifiedName("s0:Service1Soap")
      
      myBinding.Type = qualifiedName
' <Snippet1>
      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      mySoapBinding.Style = SoapBindingStyle.Document
      ' Get the URI for XML namespace of the SoapBinding class.
      Dim myNameSpace As String = SoapBinding.Namespace
      Console.WriteLine("The URI of the XML Namespace is :" + myNameSpace)
' </Snippet1>
      ' Add the 'SoapBinding'  object to the 'Binding' object.
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
      
' <Snippet2>
      ' Create the 'InputBinding' object for the 'SOAP' protocol.
      Dim myInput As New InputBinding()
      Dim mySoapBinding1 As New SoapBodyBinding()
      mySoapBinding1.Use = SoapBindingUse.Literal
      
      Dim myParts(0) As String
      myParts(0) = "parameters"
      ' Set the names of the message parts to appear in the SOAP body.
      mySoapBinding1.Parts = myParts
      myInput.Extensions.Add(mySoapBinding1)
      ' Add the 'InputBinding' object to 'OperationBinding' object.
      myOperationBinding.Input = myInput
      ' Create the 'OutputBinding' object'.
      Dim myOutput As New OutputBinding()
      myOutput.Extensions.Add(mySoapBinding1)

      ' Add the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding.Output = myOutput
' </Snippet2>
      ' Add the 'OperationBinding' to 'Binding'.
      myBinding.Operations.Add(myOperationBinding)
      
      ' Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myDescription.Bindings.Add(myBinding)
      
      ' Write the 'ServiceDescription' as a WSDL file.
      myDescription.Write("AddNumbersOut_vb.wsdl")
      Console.WriteLine(" 'AddNumbersOut_vb.Wsdl' file was generated")
   End Sub 'Main
End Class 'MySoapClass