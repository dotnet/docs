' System.Web.Services.Description.OperationBinding
' System.Web.Services.Description.OperationBinding.OperationBinding
' System.Web.Services.Description.OperationBinding.Name
' System.Web.Services.Description.OperationBinding.Input
' System.Web.Services.Description.OperationBinding.Output
' System.Web.Services.Description.OperationBinding.Extensions
' System.Web.Services.Description.OperationBinding.Faults
' System.Web.Services.Description.OperationBinding.Binding


' The following example demonstrates the usage of the 'OperationBinding'
' class, constructor 'OperationBinding()' and various properties of the class. The
' input to the program is a WSDL file 'MathService_input_cs.wsdl' without the
' add operation binding for SOAP protocol. In the example the WSDL file is modified to insert
' a new 'OperationBinding' instance for SOAP. The 'OperationBinding' instance
' is populated based on WSDL document structure defined in WSDL specification.The updated
' instance is then written to 'MathService_new_cs.wsdl'.
'


' <Snippet1>
Imports System
Imports System.Web.Services.Description

Class MyOperationBindingSample

   Shared Sub Main()
      Try
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_input_vb.wsdl")
         Dim myTargetNamespace As String = _
            myServiceDescription.TargetNamespace

' <Snippet2>
' <Snippet3>
         ' Create an OperationBinding for the Add operation.
         Dim addOperationBinding As New OperationBinding()
         Dim addOperation As String = "Add"
         addOperationBinding.Name = addOperation
' </Snippet3>

' <Snippet4>
         ' Create an InputBinding for the Add operation.
         Dim myInputBinding As New InputBinding()
         Dim mySoapBodyBinding As New SoapBodyBinding()
         mySoapBodyBinding.Use = SoapBindingUse.Literal
         myInputBinding.Extensions.Add(mySoapBodyBinding)

         ' Add the InputBinding to the OperationBinding.
         addOperationBinding.Input = myInputBinding
' </Snippet4>

' <Snippet5>
         ' Create an OutputBinding for the Add operation.
         Dim myOutputBinding As New OutputBinding()
         myOutputBinding.Extensions.Add(mySoapBodyBinding)

         ' Add the OutputBinding to the OperationBinding.
         addOperationBinding.Output = myOutputBinding
' </Snippet5>

' <Snippet6>
         ' Create an extensibility element for a SoapOperationBinding.
         Dim mySoapOperationBinding As New SoapOperationBinding()
         mySoapOperationBinding.Style = SoapBindingStyle.Document
         mySoapOperationBinding.SoapAction = myTargetNamespace & addOperation

         ' Add the extensibility element SoapOperationBinding to 
         ' the OperationBinding.
         addOperationBinding.Extensions.Add(mySoapOperationBinding)
' </Snippet6>
' </Snippet2>

' <Snippet7>
         Dim myExtensions As ServiceDescriptionFormatExtensionCollection

         ' Get the FaultBindingCollection from the OperationBinding.
         Dim myFaultBindingCollection As FaultBindingCollection = _
            addOperationBinding.Faults
         Dim myFaultBinding As New FaultBinding()
         myFaultBinding.Name = "ErrorFloat"

         ' Associate SOAP fault binding to the fault binding of the operation.
         myExtensions = myFaultBinding.Extensions
         Dim mySoapFaultBinding As New SoapFaultBinding()
         mySoapFaultBinding.Use = SoapBindingUse.Literal
         mySoapFaultBinding.Namespace = myTargetNamespace
         myExtensions.Add(mySoapFaultBinding)
         myFaultBindingCollection.Add(myFaultBinding)
' </Snippet7>

         ' Get the BindingCollection from the ServiceDescription.
         Dim myBindingCollection As BindingCollection = _
            myServiceDescription.Bindings

         ' Get the OperationBindingCollection of SOAP binding 
         ' from the BindingCollection.
         Dim myOperationBindingCollection As OperationBindingCollection = _
            myBindingCollection(0).Operations
         myOperationBindingCollection.Add(addOperationBinding)

         Console.WriteLine( _
            "The operations supported by this service are:")
         Dim myOperationBinding As OperationBinding
         For Each myOperationBinding In  myOperationBindingCollection
' <Snippet8>
            Dim myBinding As Binding = myOperationBinding.Binding
            Console.WriteLine(" Binding : " & myBinding.Name & _
               " :: Name of operation : " & myOperationBinding.Name)
' </Snippet8>
            Dim myFaultBindingCollection1 As FaultBindingCollection = _
               myOperationBinding.Faults
            Dim myFaultBinding1 As FaultBinding
            For Each myFaultBinding1 In myFaultBindingCollection1
               Console.WriteLine("    Fault : " & myFaultBinding1.Name)
            Next myFaultBinding1
         Next myOperationBinding

         ' Save the ServiceDescripition to an external file.
         myServiceDescription.Write("MathService_new_vb.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyOperationBindingSample
' </Snippet1>
