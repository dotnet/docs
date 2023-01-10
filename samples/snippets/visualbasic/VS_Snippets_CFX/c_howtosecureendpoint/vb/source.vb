Imports System.Collections
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.Security.Permissions

Namespace Microsoft.Security.Samples
    Public Class Test
        Shared Sub Main()
            Dim t As New Test()
            Console.WriteLine("Starting....")
            t.Run()

        End Sub

        Private Sub Run()
            '<snippet0>
            Dim myBinding As New WSHttpBinding()
            With myBinding.Security
                .Mode = SecurityMode.Message
                .Message.ClientCredentialType = MessageCredentialType.Windows
            End With

            ' Create the Type instances for later use and the URI for 
            ' the base address.
            Dim contractType = GetType(ICalculator)
            Dim serviceType = GetType(Calculator)
            Dim baseAddress As New Uri("http://localhost:8037/serviceModelSamples/")

            ' Create the ServiceHost and add an endpoint. 
            Dim myServiceHost As New ServiceHost(serviceType, baseAddress)
            myServiceHost.AddServiceEndpoint(contractType, myBinding, "secureCalculator")

            '<snippet1>
            ' Create a new metadata behavior object and set its properties to 
            ' create a secure endpoint. 
            Dim sb As New ServiceMetadataBehavior()

            With sb
                .HttpsGetEnabled = True
                .HttpsGetUrl = New Uri("https://myMachineName:8036/myEndpoint")
            End With

            With myServiceHost
                .Description.Behaviors.Add(sb)
                .Open()
            End With
            '</snippet1>

            ' Use the GetHostEntry method to return the actual machine name.
            Dim machineName = System.Net.Dns.GetHostEntry("").HostName
            Console.WriteLine("Listening @ {0}:8037/serviceModelSamples/", machineName)
            Console.WriteLine("Press Enter to close the service")
            Console.ReadLine()
            myServiceHost.Close()
            '</snippet0>

        End Sub
    End Class

    <ServiceContract()> _
    Public Interface ICalculator
        <OperationContract()> _
        Function Add(ByVal a As Double, ByVal b As Double) As Double
    End Interface

    Public Class Calculator
        Implements ICalculator
        Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
            Return a + b
        End Function
    End Class
End Namespace
