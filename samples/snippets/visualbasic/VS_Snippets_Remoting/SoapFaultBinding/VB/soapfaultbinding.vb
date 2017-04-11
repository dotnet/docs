' System.Web.Services.Description.SoapFaultBinding

' The following example demonstrates 'SoapFaultBinding' class. 
' It creates an instance of 'ServiceDescription' class by reading  an existing 
' wsdl file. Then it creates an instance of 'SoapFaultBinding' and adds it to 
' the collection object of 'Binding' class. It generates a new wsdl file where 
' the properties of 'SoapFaultBinding' objects are reflected and which could be
' used for generating a proxy.

' <Snippet1>
Imports System
Imports System.Web.Services.Description

Public Class MySoapFaultBindingSample
   
   Public Shared Sub Main()
      Try
         ' Input wsdl file.
         Dim myInputWsdlFile As String = "SoapFaultBindingInput_vb.wsdl"
         ' Output wsdl file.
         Dim myOutputWsdlFile As String = "SoapFaultBindingOutput_vb.wsdl"
         ' Initialize an instance of a 'ServiceDescription' object.
         Dim myServiceDescription As ServiceDescription = ServiceDescription.Read(myInputWsdlFile)
         ' Get a SOAP binding object with binding name "MyService1Soap". 
         Dim myBinding As Binding = myServiceDescription.Bindings("MyService1Soap")
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
         Dim myOperationBinding As OperationBinding = myBinding.Operations(0)
         myOperationBinding.Faults.Add(myFaultBinding)
         ' Create a new wsdl file.
         myServiceDescription.Write(myOutputWsdlFile)
         Console.WriteLine("The new wsdl file created is :" + myOutputWsdlFile)
         Console.WriteLine("Proxy could be created using command : wsdl /language:VB " + myOutputWsdlFile)
      Catch e As Exception
         Console.WriteLine("Error occured : " + e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MySoapFaultBindingSample
' </Snippet1>