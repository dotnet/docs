' <Snippet10>
' This is the hosting application.

Imports System.ServiceModel.Channels
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel
Imports System.Transactions
Imports System.Runtime.Serialization
Imports System.Collections.Generic

Namespace Microsoft.ServiceModel.Samples
    Friend Class hostApp
        ' Host the service within this EXE console application.
        Public Shared Sub Main()
            ' Get MSMQ queue name from appsettings in configuration.
            Dim queueName As String = ConfigurationManager.AppSettings("queueName")

            ' <Snippet4>
            ' Create the transacted MSMQ queue if necessary.
            If (Not MessageQueue.Exists(queueName)) Then
                MessageQueue.Create(queueName, True)
            End If
            ' </Snippet4>

            ' <Snippet6>
            ' Create a ServiceHost for the OrderProcessorService type.
            Using serviceHost As New ServiceHost(GetType(OrderProcessorService))
                ' Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHostB to shutdown the service.
                serviceHost.Close()
            End Using
            ' </Snippet6>
        End Sub
    End Class
End Namespace
' </Snippet10>
