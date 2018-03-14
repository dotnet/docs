Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.MsmqIntegration
Imports System.Runtime.Serialization
Imports System.Configuration
Imports System.Messaging
Imports System.Security.Principal
'Imports Order

Module Service
    ' Define a service contract. 
    ' <Snippet1>
    <ServiceContract(Namespace:="http:'Microsoft.ServiceModel.Samples")> _
    <ServiceKnownType(GetType(PurchaseOrder))> _
    Public Interface IOrderProcessor
        <OperationContract(IsOneWay:=True, Action:="*")> _
        Sub SubmitPurchaseOrder(ByVal msg As MsmqMessage(Of PurchaseOrder))
    End Interface
    ' </Snippet1>

    ' Service class that implements the service contract.
    ' Added code to write output to the console window.
    ' <Snippet2>
    Public Class OrderProcessorService
        Implements IOrderProcessor

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Sub SubmitPurchaseOrder(ByVal ordermsg As MsmqMessage(Of PurchaseOrder)) Implements IOrderProcessor.SubmitPurchaseOrder
            Dim po As PurchaseOrder = ordermsg.Body
            Dim statusIndexer As New Random()
            po.Status = statusIndexer.Next(3)
            Console.WriteLine("Processing {0} ", po)
        End Sub
    End Class
    ' </Snippet2>

    Sub Main()
        ' Get base address from appsettings in configuration
        Dim baseAddress As New Uri(ConfigurationManager.AppSettings("baseAddress"))

        ' Create a ServiceHost for the CalculatorService type and provide the base address.
        Using serviceHost As New ServiceHost(GetType(IOrderProcessor), baseAddress)

            ' Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open()

            ' The service can now be accessed.
            Console.WriteLine("The service is ready.")
            Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name)
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()

            ' Close the ServiceHostBase to shutdown the service.
            serviceHost.Close()
        End Using
    End Sub

End Module
