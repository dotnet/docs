' System.Web.Services.Description.ServiceDescription.Bindings

' The following example demonstrates the property 'Bindings' of 
' 'ServiceDescription' class. The input to the program is a WSDL file 
' 'MyWsdl_VB.wsdl'. This program removes one 'Binding' from the existing WSDL.
' A new Binding is defined and added to the ServiceDescription object.
' The program generates a new Web Service Description document.

Imports System
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Xml

Namespace ServiceDescription1

   Class MyService
      
      Shared Sub Main()
         Try
' <Snippet1>
            ' Obtain the ServiceDescription from existing WSDL.
            Dim myDescription As ServiceDescription = _
               ServiceDescription.Read("MyWsdl_VB.wsdl")
            ' Remove the Binding from the BindingCollection of 
            ' the ServiceDescription.
            Dim myBindingCollection As BindingCollection = _
               myDescription.Bindings
            myBindingCollection.Remove(myBindingCollection(0))
            
            ' Form a new Binding.
            Dim myBinding As New Binding()
            myBinding.Name = "Service1Soap"
            Dim myXmlQualifiedName As New XmlQualifiedName("s0:Service1Soap")
            myBinding.Type = myXmlQualifiedName
            
            Dim mySoapBinding As New SoapBinding()
            mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
            mySoapBinding.Style = SoapBindingStyle.Document
            
            Dim addOperationBinding As OperationBinding = _
               CreateOperationBinding("Add", myDescription.TargetNamespace)
            myBinding.Operations.Add(addOperationBinding)
            myBinding.Extensions.Add(mySoapBinding)
            
            ' Add the Binding to the ServiceDescription.
            myDescription.Bindings.Add(myBinding)
            myDescription.Write("MyOutWsdl.wsdl")
' </Snippet1>
         Catch e As Exception
            Console.WriteLine("Exception: " + e.Message.ToString())
         End Try
      End Sub 'Main
      
      ' Used to create OperationBinding instances within 'Binding'.
      Public Shared Function CreateOperationBinding(operation As String, targetNamespace As String) _
                                                      As OperationBinding
         ' Create OperationBinding instance for operation.
         Dim myOperationBinding As New OperationBinding()
         myOperationBinding.Name = operation
         ' Create InputBinding for operation.
         Dim myInputBinding As New InputBinding()
         Dim mySoapBodyBinding As New SoapBodyBinding()
         mySoapBodyBinding.Use = SoapBindingUse.Literal
         myInputBinding.Extensions.Add(mySoapBodyBinding)
         ' Create OutputBinding for operation.
         Dim myOutputBinding As New OutputBinding()
         myOutputBinding.Extensions.Add(mySoapBodyBinding)
         ' Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'. 
         myOperationBinding.Input = myInputBinding
         myOperationBinding.Output = myOutputBinding
         ' Create extensibility element for 'SoapOperationBinding'.
         Dim mySoapOperationBinding As New SoapOperationBinding()
         mySoapOperationBinding.Style = SoapBindingStyle.Document
         mySoapOperationBinding.SoapAction = targetNamespace + operation
         ' Add extensibility element 'SoapOperationBinding' to 'OperationBinding'.
         myOperationBinding.Extensions.Add(mySoapOperationBinding)
         Return myOperationBinding
      End Function 'CreateOperationBinding
   End Class 'MyService
End Namespace 'ServiceDescription1
