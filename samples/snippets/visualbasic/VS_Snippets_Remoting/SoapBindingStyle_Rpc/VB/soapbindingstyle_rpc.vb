' System.Web.Services.Description.SoapBindingStyle.Rpc
' System.Web.Services.Description.SoapBindingUse.Encoded
' System.Web.Services.Description.SoapBodyBinding.Encoding
' System.Web.Services.Description.SoapBodyBinding.Namespace
' System.Web.Services.Description.SoapHeaderBinding.Encoding
' System.Web.Services.Description.SoapHeaderBinding.Namespace

' The following example demonstrates the 'Rpc' member of 'SoapBindingStyle' 
' enumeration ,'Encoded' member of 'SoapBindingUse' enumeration ,'Encoding'
' and 'Namespace' properties of 'SoapBodyBinding' class and 'Encoding'
' and 'Namespace' properties of 'SoapHeaderBinding' class.
' It takes as input a wsdl file which does not contain a binding for SOAP.
' By using the 'Read' method of 'ServiceDescription' class it gets a 'ServiceDescription' object.
' It uses the SOAP protocol related classes  and  creates 'Binding' element
' of 'SOAP' protocol which are then added to the 'ServiceDescription' object.
' An output wsdl file is generated from 'ServiceDescription' object which 
' could be used for generating a proxy.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Public Class MySoapBindingClass

   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = _
               ServiceDescription.Read("SoapBindingStyleInput_vb.wsdl")
      Dim myBinding As New Binding()
      myBinding.Name = "SOAPSvrMgr_SOAPBinding"
      myBinding.Type = New XmlQualifiedName("tns:SOAPSvrMgr_portType")

' <Snippet1>
      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      ' Message to be transmitted contains parameters to call a procedure.
      mySoapBinding.Style = SoapBindingStyle.Rpc
      myBinding.Extensions.Add(mySoapBinding)
' </Snippet1>

      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = "GetServerStats"

      Dim mySoapOperationBinding As New SoapOperationBinding()
      mySoapOperationBinding.SoapAction = "http://tempuri.org/soapsvcmgr/GetServerStats"
      myOperationBinding.Extensions.Add(mySoapOperationBinding)

      ' Create InputBinding for operation for the 'SOAP' protocol.
      Dim myInputBinding As New InputBinding()
' <Snippet2>
' <Snippet3>
' <Snippet4>
      Dim mySoapBodyBinding As New SoapBodyBinding()
      ' Encode SOAP body using rules specified by the 'Encoding' property.
      mySoapBodyBinding.Use = SoapBindingUse.Encoded
      ' Set URI representing the encoding style for encoding the body.
      mySoapBodyBinding.Encoding = "http://schemas.xmlsoap.org/soap/encoding/"
      ' Set the Uri representing the location of the specification 
      ' for encoding of content not defined by 'Encoding' property'.
      mySoapBodyBinding.Namespace = "http://tempuri.org/soapsvcmgr/"
      myInputBinding.Extensions.Add(mySoapBodyBinding)
' </Snippet4>
' </Snippet3>
' </Snippet2>

' <Snippet5>
' <Snippet6>
      Dim mySoapHeaderBinding As New SoapHeaderBinding()
      mySoapHeaderBinding.Message = New XmlQualifiedName("tns:Soapsvcmgr_Headers_Request")
      mySoapHeaderBinding.Part = "AuthCS"
      ' Encode SOAP header using rules specified by the 'Encoding' property.
      mySoapHeaderBinding.Use = SoapBindingUse.Encoded
      ' Set URI representing the encoding style for encoding the header.
      mySoapHeaderBinding.Encoding = "http://schemas.xmlsoap.org/soap/encoding/"
      ' Set the Uri representing the location of the specification 
      ' for encoding of content not defined by 'Encoding' property'.
      mySoapHeaderBinding.Namespace = "http://tempuri.org/SOAPSvr/soapsvcmgr/headers.xsd"
      ' Add mySoapHeaderBinding to the 'myInputBinding' object.
      myInputBinding.Extensions.Add(mySoapHeaderBinding)
' </Snippet5>
' </Snippet6>

      ' Create OutputBinding for operation.
      Dim myOutputBinding As New OutputBinding()
      myOutputBinding.Extensions.Add(mySoapBodyBinding)
      mySoapHeaderBinding.Part = "AuthSC"
      mySoapHeaderBinding.Message = _
                        New XmlQualifiedName("tns:Soapsvcmgr_Headers_Response")
      myOutputBinding.Extensions.Add(mySoapHeaderBinding)
      
      ' Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'.
      myOperationBinding.Input = myInputBinding
      myOperationBinding.Output = myOutputBinding
      myBinding.Operations.Add(myOperationBinding)
      
      myServiceDescription.Bindings.Add(myBinding)
      myServiceDescription.Write("SoapBindingStyleOutput_vb.wsdl")
      Console.WriteLine("'SoapBindingStyleOutput_vb.wsdl' file is generated.")
      Console.WriteLine("Proxy could be created using command" + _
                        " 'wsdl /language:VB SoapBindingStyleOutput_vb.wsdl'")
   End Sub 'Main
End Class 'MySoapBindingClass