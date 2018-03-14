
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security

Namespace UE.ServiceModel.Samples
    Public Class Snippets
        Public Shared Sub Snippet3()
            ' <Snippet3>
            Dim binding As BasicHttpBinding = New BasicHttpBinding(BasicHttpSecurityMode.Message)
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.None

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                ' Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHost to shutdown the service.
                serviceHost.Close()
            End Using
            ' </Snippet3>
        End Sub

        Public Shared Sub Snippet4()
            ' <Snippet4>
            Dim binding As BasicHttpBinding = New BasicHttpBinding("BasicBinding")
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.None

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                ' Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHost to shutdown the service.
                serviceHost.Close()
            End Using
            ' </Snippet4>

        End Sub

        Public Shared Sub Snippet5()
            ' <Snippet5>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.Message

            ' <Snippet6>
            Dim security As BasicHttpSecurity = binding.Security
            Dim msgSecurity As BasicHttpMessageSecurity = security.Message
            ' </Snippet6>

            ' <Snippet7>
            Dim sas As SecurityAlgorithmSuite = msgSecurity.AlgorithmSuite
            Dim credType As BasicHttpMessageCredentialType = msgSecurity.ClientCredentialType
            ' </Snippet7>

            Console.WriteLine("The algorithm suite used is {0}", sas.ToString())
            Console.WriteLine("The client credential type used is {0}", credType.ToString())
            ' </Snippet5>
        End Sub

        Public Shared Sub Snippet8()
            ' <Snippet8>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.Message

            ' <Snippet9>
            Dim security As BasicHttpSecurity = binding.Security
            Dim msgSecurity As BasicHttpMessageSecurity = security.Message
            ' </Snippet9>

            ' <Snippet10>
            Dim secMode As BasicHttpSecurityMode = security.Mode
            ' </Snippet10>

            ' <Snippet11>
            Dim transSec As HttpTransportSecurity = security.Transport
            ' </Snippet11>

            Console.WriteLine("The message-level security setting is {0}", secMode.ToString())
            Console.WriteLine("The transport-level security setting is {0}", transSec.ToString())
            ' </Snippet8>
        End Sub
    End Class
End Namespace

