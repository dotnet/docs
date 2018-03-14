' System.Web.Services.Description.SoapBodyBinding.PartsString
' System.Web.Services.Description.SoapFaultBinding.ctor
' System.Web.Services.Description.SoapFaultBinding.Use
' System.Web.Services.Description.SoapFaultBinding.Encoding
' System.Web.Services.Description.SoapFaultBinding.NameSpace

' The following example demonstrates the 'PartsString' property of 'SoapBodyBinding' class.
' and constructor, 'Encoding', 'NameSpace' and 'Use'properties of 'SoapFaultBinding' class and

' It creates an instance of 'ServiceDescription' class by reading  an existing 
' wsdl file. Then it creates an instance of 'SoapFaultBinding' and adds it to 
' the collection object of 'Binding' class. It generates a new wsdl file where 
' the properties of 'SoapFaultBinding' objects are reflected and which could be
' used for generating a proxy.

Imports System
Imports System.Web.Services.Description

Public Class MySoapFaultBindingSample
   Public Shared Sub Main()
      Try
         ' Input wsdl file.
         Dim myInputWsdlFile As String = "SoapFaultInput_vb.wsdl"
         ' Output wsdl file.
         Dim myOutputWsdlFile As String = "SoapFaultOutput_vb.wsdl"
         ' Initialize an instance of a 'ServiceDescription' object.
         Dim myServiceDescription As ServiceDescription = _
                                       ServiceDescription.Read(myInputWsdlFile)
         ' Get a SOAP binding object with binding name "MyService1Soap". 
         Dim myBinding As Binding = myServiceDescription.Bindings("MyService1Soap")
         ' Create the 'OperationBinding' object for the 'SOAP' protocol.
         Dim myOperationBinding As New OperationBinding()
         myOperationBinding.Name = "Add"

         ' Create the 'SoapOperationBinding' object for the 'SOAP' protocol.
         Dim mySoapOperationBinding As New SoapOperationBinding()
         mySoapOperationBinding.SoapAction = "http://tempuri.org/Add"
         mySoapOperationBinding.Style = SoapBindingStyle.Document
         ' Add the 'SoapOperationBinding' object to 'OperationBinding' object.
         myOperationBinding.Extensions.Add(mySoapOperationBinding)
' <Snippet1>
         ' Create the 'InputBinding' object for the 'SOAP' protocol.
         Dim myInput As New InputBinding()
         Dim mySoapBinding1 As New SoapBodyBinding()
         mySoapBinding1.PartsString = "parameters"
         mySoapBinding1.Use = SoapBindingUse.Literal
         myInput.Extensions.Add(mySoapBinding1)
         ' Assign the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInput
         ' Create the 'OutputBinding' object' for the 'SOAP' protocol..
         Dim myOutput As New OutputBinding()
         myOutput.Extensions.Add(mySoapBinding1)
         ' Assign the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutput
' </Snippet1>

' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
         ' Create a new instance of 'SoapFaultBinding' class.
         Dim mySoapFaultBinding As New SoapFaultBinding()
         ' Encode fault message using rules specified by 'Encoding' property.
         mySoapFaultBinding.Use = SoapBindingUse.Encoded
         ' Set the URI representing the encoding style.
         mySoapFaultBinding.Encoding = "http://tempuri.org/stockquote"
         ' Set the URI representing the location of the specification 
         ' for encoding of content not defined by 'Encoding' property'.
         mySoapFaultBinding.Namespace = "http://tempuri.org/stockquote"
         ' Create a new instance of 'FaultBinding'.
         Dim myFaultBinding As New FaultBinding()
         myFaultBinding.Name = "AddFaultbinding"
         myFaultBinding.Extensions.Add(mySoapFaultBinding)
         ' Get existing 'OperationBinding' object.
         myOperationBinding.Faults.Add(myFaultBinding)
         myBinding.Operations.Add(myOperationBinding)
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>
         ' Create a new wsdl file.
         myServiceDescription.Write(myOutputWsdlFile)
         Console.WriteLine("The new wsdl file created is :" + myOutputWsdlFile)
         Console.WriteLine("Proxy could be created using command : wsdl /language:VB " + _
                           myOutputWsdlFile)
      Catch e As Exception
         Console.WriteLine("Error occured : " + e.Message)
      End Try
   End Sub 'Main
End Class 'MySoapFaultBindingSample