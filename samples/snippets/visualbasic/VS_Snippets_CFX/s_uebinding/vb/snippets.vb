Imports System
Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.ServiceModel.Description

Namespace UE.ServiceModel.Samples

    Public Class Snippets

        Public Shared Sub snippet3()
            '<Snippet4>
            '<Snippet3>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            '</Snippet3>
            binding.Namespace = "http:\\My.ServiceModel.Samples"
            '</Snippet4>

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            'Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)
                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                'Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                'The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()
                'Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
            End Using
        End Sub

        Public Shared Sub snippet5()
            '<Snippet5>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            binding.Namespace = "http:\\My.ServiceModel.Samples"
            Dim elements As BindingElementCollection = binding.CreateBindingElements()
            '</Snippet5> 

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            'Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                'Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                'The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()
                'Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
            End Using
        End Sub

        Public Shared Sub snippet6()

            '<Snippet6>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            binding.Namespace = "http:\\My.ServiceModel.Samples"
            binding.CloseTimeout = New TimeSpan(0, 5, 0)
            '</Snippet6>

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            'Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                'Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                'The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()
                'Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
            End Using
        End Sub

        Public Shared Sub snippet7()

            '<Snippet7>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Binding.Name = "binding1"
            Binding.Namespace = "http:\\My.ServiceModel.Samples"
            Binding.OpenTimeout = New TimeSpan(0, 0, 30)
            '</Snippet7>

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            'Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                'Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                'The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()
                'Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
            End Using
        End Sub

        Public Shared Sub snippet8()

            '<Snippet8>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Binding.Name = "binding1"
            Binding.Namespace = "http:\\My.ServiceModel.Samples"
            Binding.ReceiveTimeout = New TimeSpan(0, 5, 0)
            '</Snippet8>

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            'Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                'Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                'The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()
                'Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
            End Using
        End Sub

        Public Shared Sub snippet9()
            '<Snippet9>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Binding.Name = "binding1"
            Binding.Namespace = "http:\\My.ServiceModel.Samples"
            Binding.SendTimeout = New TimeSpan(0, 5, 0)
            '</Snippet9>

            '<Snippet10>
            Dim scheme As String = binding.Scheme
            Console.WriteLine("Binding is Imports the {0} scheme", scheme)
            '</Snippet10>

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            'Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                'Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                'The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()
                'Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
            End Using
        End Sub
    End Class
End Namespace