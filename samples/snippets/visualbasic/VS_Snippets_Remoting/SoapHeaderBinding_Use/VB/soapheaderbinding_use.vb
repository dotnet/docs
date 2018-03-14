' System.Web.Services.Description.SoapHeaderBinding.SoapHeaderBinding
' System.Web.Services.Description.SoapHeaderBinding.Message
' System.Web.Services.Description.SoapHeaderBinding.Part
' System.Web.Services.Description.SoapHeaderBinding.Use

' The following example demonstrates the constructor, 'Message' , 'Part'
' and 'Use' properties of the class 'SoapHeaderBinding'.
' It takes as input a wsdl file. The binding element corresponding to 
' SOAP protocol is removed from the input file. By using the 'Read' method 
' of 'ServiceDescription' class it gets a 'ServiceDescription' object. 
' It uses the SOAP protocol related classes  and  creates 'Binding' element
' of 'SOAP' protocol which are then added to the 'ServiceDescription' object.
' An output wsdl file is generated from 'ServiceDescription' object which 
' could be used for generating a proxy.

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
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
      Dim mySoapHeaderBinding As New SoapHeaderBinding()
      ' Set the Message within the XML Web service to which the 
      ' 'SoapHeaderBinding' applies.
      mySoapHeaderBinding.Message = New XmlQualifiedName("s0:HelloMyHeader")
      mySoapHeaderBinding.Part = "MyHeader"
      mySoapHeaderBinding.Use = SoapBindingUse.Literal
      ' Add mySoapHeaderBinding to the 'myInputBinding' object.
      myInputBinding.Extensions.Add(mySoapHeaderBinding)
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>
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