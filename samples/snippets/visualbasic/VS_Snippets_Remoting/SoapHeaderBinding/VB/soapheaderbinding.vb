' System.Web.Services.Description.SoapHeaderBinding

'  The following example demonstrates the class 'SoapHeaderBinding'.
'  It takes as input a wsdl file. By using the 'Read' method 
'  of 'ServiceDescription' class it gets a 'ServiceDescription' object. 
'  It uses the SOAP protocol related classes  and  creates 'Binding' element
'  of 'SOAP' protocol which are then added to the 'ServiceDescription' object.
'  An output wsdl file is generated from 'ServiceDescription' object which 
'  could be used for generating a proxy.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Public Class MySampleClass
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = _
                        ServiceDescription.Read("SoapHeaderBindingInput_vb.wsdl")
      Dim myBinding As New Binding()
      myBinding.Name = "MyWebServiceSoap"
      myBinding.Type = New XmlQualifiedName("s0:MyWebServiceSoap")

      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      mySoapBinding.Style = SoapBindingStyle.Document
      myBinding.Extensions.Add(mySoapBinding)

      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = "Hello"

      Dim mySoapOperationBinding As New SoapOperationBinding()
      mySoapOperationBinding.SoapAction = "http://tempuri.org/Hello"
      mySoapOperationBinding.Style = SoapBindingStyle.Document
      myOperationBinding.Extensions.Add(mySoapOperationBinding)

      ' Create InputBinding for operation for the 'SOAP' protocol.
      Dim myInputBinding As New InputBinding()
      Dim mySoapBodyBinding As New SoapBodyBinding()
      mySoapBodyBinding.Use = SoapBindingUse.Literal
      myInputBinding.Extensions.Add(mySoapBodyBinding)
      Dim mySoapHeaderBinding As New SoapHeaderBinding()
      mySoapHeaderBinding.Message = New XmlQualifiedName("s0:HelloMyHeader")
      mySoapHeaderBinding.Part = "MyHeader"
      mySoapHeaderBinding.Use = SoapBindingUse.Literal
      ' Add mySoapHeaderBinding to 'myInputBinding' object.
      myInputBinding.Extensions.Add(mySoapHeaderBinding)
      ' Create OutputBinding for operation for the 'SOAP' protocol.
      Dim myOutputBinding As New OutputBinding()
      myOutputBinding.Extensions.Add(mySoapBodyBinding)

      ' Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'.
      myOperationBinding.Input = myInputBinding
      myOperationBinding.Output = myOutputBinding
      myBinding.Operations.Add(myOperationBinding)

      myServiceDescription.Bindings.Add(myBinding)
      myServiceDescription.Write("SoapHeaderBindingOut_vb.wsdl")
      Console.WriteLine("'SoapHeaderBindingOut_vb.wsdl' file is generated.")
      Console.WriteLine("Proxy could be created using " + _
                        "'wsdl /language:VB SoapHeaderBindingOut_vb.wsdl'.")
   End Sub 'Main
End Class 'MySampleClass
' </Snippet1>