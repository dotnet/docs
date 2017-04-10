'<Snippet1>
Imports System
Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.ServiceModel.Description

Namespace UE.ServiceModel.Samples

    <ServiceContract(Namespace:="http://UE.ServiceModel.Samples")> _
    Public Interface ICalculator
        <OperationContract(IsOneWay:=False)> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract(IsOneWay:=False)> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract(IsOneWay:=False)> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract(IsOneWay:=False)> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface

    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
        Implements ICalculator.Add
            Dim result As Double = n1 + n2
            Console.WriteLine("Received Add({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double _
        Implements ICalculator.Subtract
            Dim result As Double = n1 - n2
            Console.WriteLine("Received Subtract({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double _
        Implements ICalculator.Multiply
            Dim result As Double = n1 * n2
            Console.WriteLine("Received Multiply({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double _
        Implements ICalculator.Divide
            Dim result As Double = n1 / n2
            Console.WriteLine("Received Divide({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Shared Sub Main()
            '<Snippet2>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            '</Snippet2>

            binding.Name = "binding1"

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
'</Snippet1>