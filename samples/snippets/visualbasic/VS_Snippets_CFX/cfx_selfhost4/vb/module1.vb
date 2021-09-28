'<snippet5>
'<snippet1>
Imports System.ServiceModel
Imports System.ServiceModel.Description
'</snippet1>

Module Module1

    '<snippet2>
    <ServiceContract()>
    Public Interface IHelloWorldService
        <OperationContract()>
        Function SayHello(ByVal name As String) As String
    End Interface

    Public Class HelloWorldService
        Implements IHelloWorldService

        Public Function SayHello(ByVal name As String) As String Implements IHelloWorldService.SayHello
            Return String.Format("Hello, {0}", name)
        End Function
    End Class
    '</snippet2>

    Sub Main()
        '<snippet3>
        Dim baseAddress As Uri = New Uri("http://localhost:8080/hello")
        '</snippet3>

        '<snippet4>
        ' Create the ServiceHost.
        Using host As New ServiceHost(GetType(HelloWorldService), baseAddress)

            ' Enable metadata publishing.
            Dim smb As New ServiceMetadataBehavior()
            smb.HttpGetEnabled = True
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15
            host.Description.Behaviors.Add(smb)

            ' Open the ServiceHost to start listening for messages. Since
            ' no endpoints are explicitly configured, the runtime will create
            ' one endpoint per base address for each service contract implemented
            ' by the service.
            host.Open()

            Console.WriteLine("The service is ready at {0}", baseAddress)
            Console.WriteLine("Press <Enter> to stop the service.")
            Console.ReadLine()

            ' Close the ServiceHost.
            host.Close()

        End Using
        '</snippet4>

    End Sub

End Module
'</snippet5>
