' System.Web.Services.Description.ServiceDescriptionBaseCollection.

'  The following example demonstrates 'ServiceDescriptionBaseCollection' class.
'  A 'ServiceDescription' instance is obtained from the existing Wsdl.
'  'MyMethod' takes an instance of 'ServiceDescriptionBaseCollection' as a parameter.
'  Instance of different types of collections that were actually derived from 
'  'ServiceDescriptionBaseCollection' are passed to my method and modifications of
'  corresponding  instances in done.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class ServiceDescription_Sample
   Public Shared myServiceDescription As ServiceDescription
   
   Public Shared Sub Main()
      ' Read a ServiceDescription of existing WSDL.
      myServiceDescription = ServiceDescription.Read("Input_VB.wsdl")
      ' Get the ServiceCollection of the ServiceDescription.
      Dim myServiceCollection As ServiceCollection = myServiceDescription.Services
      MyMethod(myServiceCollection)
      Dim myBindingCollection As BindingCollection = myServiceDescription.Bindings
      MyMethod(myBindingCollection)
      Dim myPortTypeCollection As PortTypeCollection = myServiceDescription.PortTypes
      MyMethod(myPortTypeCollection)
      myServiceDescription.Write("Output.Wsdl")
   End Sub 'Main
   
' <Snippet1>
   Public Shared Sub MyMethod(myServiceCollection As _
      ServiceDescriptionBaseCollection)
      Dim myType As Type = myServiceCollection.GetType()
      If myType.Equals( _
         GetType(System.Web.Services.Description.ServiceCollection)) Then

         ' Remove the services at index 0 of the collection.
         CType(myServiceCollection, ServiceCollection).Remove( _
            myServiceDescription.Services(0))

         ' Build a new Service.
         Dim myService As New Service()
         myService.Name = "MathService"
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("s0:MathServiceSoap")

         ' Build a new Port for SOAP.
         Dim mySoapPort As New Port()
         mySoapPort.Name = "MathServiceSoap"
         mySoapPort.Binding = myXmlQualifiedName
         Dim mySoapAddressBinding As New SoapAddressBinding()
         mySoapAddressBinding.Location = "http://localhost/" & _
            "ServiceDescriptionBaseCollection_VB/AddSubtractService.VB.asmx"
         mySoapPort.Extensions.Add(mySoapAddressBinding)

         ' Build a new Port for HTTP-GET.
         Dim myXmlQualifiedName2 As _
            New XmlQualifiedName("s0:MathServiceHttpGet")
         Dim myHttpGetPort As New Port()
         myHttpGetPort.Name = "MathServiceHttpGet"
         myHttpGetPort.Binding = myXmlQualifiedName2
         Dim myHttpAddressBinding As New HttpAddressBinding()
         myHttpAddressBinding.Location = "http://localhost/" & _
            "ServiceDescriptionBaseCollection_VB/AddSubtractService.VB.asmx"
         myHttpGetPort.Extensions.Add(myHttpAddressBinding)

         ' Add the ports to the Service.
         myService.Ports.Add(myHttpGetPort)
         myService.Ports.Add(mySoapPort)

         ' Add the Service to the ServiceCollection.
         myServiceDescription.Services.Add(myService)
      Else
         If myType.Equals( _
            GetType(System.Web.Services.Description.BindingCollection)) Then

            ' Remove the Binding in the BindingCollection at index 0.
            CType(myServiceCollection, BindingCollection).Remove( _
               myServiceDescription.Bindings(0))

            ' Build a new Binding.
            Dim myBinding As New Binding()
            myBinding.Name = "MathServiceSoap"
            Dim myXmlQualifiedName As _
               New XmlQualifiedName("s0:MathServiceSoap")
            myBinding.Type = myXmlQualifiedName
            Dim mySoapBinding As New SoapBinding()
            mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
            mySoapBinding.Style = SoapBindingStyle.Document

            ' Create the operations for the binding.
            Dim addOperationBinding As OperationBinding = _
               CreateOperationBinding("Add", _
               myServiceDescription.TargetNamespace)
            Dim subtractOperationBinding As OperationBinding = _
               CreateOperationBinding("Subtract", _
               myServiceDescription.TargetNamespace)

            ' Add the operations to the Binding.
            myBinding.Operations.Add(subtractOperationBinding)
            myBinding.Operations.Add(addOperationBinding)
            myBinding.Extensions.Add(mySoapBinding)

            ' Add the Binding to the Bindings collection.
            myServiceDescription.Bindings.Add(myBinding)
         Else
            If myType.Equals( _ 
               GetType(System.Web.Services.Description.PortTypeCollection)) Then

               ' Remove the PortType at index 0.
               CType(myServiceCollection, PortTypeCollection).Remove( _ 
                  myServiceDescription.PortTypes(0))

               ' Build a new PortType.
               Dim myPortType As New PortType()
               myPortType.Name = "MathServiceSoap"

               ' Build an AddOperation for the PortType.
               Dim myAddOperation As New Operation()
               myAddOperation.Name = "Add"

               ' Build the Input and Output messages for the Operations.
               Dim myOperationInputMessage1 As New OperationInput()
               Dim myXmlQualifiedName1 As New XmlQualifiedName("s0:AddSoapIn")
               myOperationInputMessage1.Message = myXmlQualifiedName1
               
               Dim myOperationOutputMessage1 As New OperationOutput()
               Dim myXmlQualifiedName2 As New XmlQualifiedName("s0:AddSoapOut")
               myOperationOutputMessage1.Message = myXmlQualifiedName2

               ' Add the messages to the operations.
               myAddOperation.Messages.Add(myOperationInputMessage1)
               myAddOperation.Messages.Add(myOperationOutputMessage1)

               ' Build an Add Operation for the PortType.
               Dim mySubtractOperation As New Operation()
               mySubtractOperation.Name = "Subtract"

               ' Build the Input and Output messages for the operations.
               Dim myOperationInputMessage2 As New OperationInput()
               Dim myXmlQualifiedName3 As _
                  New XmlQualifiedName("s0:SubtractSoapIn")
               myOperationInputMessage2.Message = myXmlQualifiedName3
               Dim myOperationOutputMessage2 As New OperationOutput()
               Dim myXmlQualifiedName4 As _
                  New XmlQualifiedName("s0:SubtractSoapOut")
               myOperationOutputMessage2.Message = myXmlQualifiedName4

               ' Add the messages to the operations.
               mySubtractOperation.Messages.Add(myOperationInputMessage2)
               mySubtractOperation.Messages.Add(myOperationOutputMessage2)

               ' Add the operations to the PortType.
               myPortType.Operations.Add(myAddOperation)
               myPortType.Operations.Add(mySubtractOperation)

               ' Add the PortType to the collection.
               myServiceDescription.PortTypes.Add(myPortType)
            End If
         End If
      End If
   End Sub 'MyMethod
' </Snippet1>
   
   Public Shared Function CreateOperationBinding(operation As String, _
         targetNamespace As String) As OperationBinding
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
End Class 'ServiceDescription_Sample
