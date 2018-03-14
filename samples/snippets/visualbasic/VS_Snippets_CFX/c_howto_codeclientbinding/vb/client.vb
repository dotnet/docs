'code for c_HowTo_CodeClientBindings client

Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels

Namespace Microsoft.ServiceModel.Samples
    '<snippet1>
    <ServiceContract()> _
    Public Interface ICalculator

        <OperationContract()> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double

    End Interface

    '</snippet1>
    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Return n1 + n2
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Return n1 - n2
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Return n1 * n2
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
            Return n1 / n2
        End Function

    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Interface ICalculatorChannel
        Inherits Microsoft.ServiceModel.Samples.ICalculator, System.ServiceModel.IClientChannel
    End Interface

    '<snippet2>
    Public Class CalculatorClient
        Inherits System.ServiceModel.ClientBase(Of Microsoft.ServiceModel.Samples.ICalculator)
        Implements Microsoft.ServiceModel.Samples.ICalculator

        Public Sub New()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, _
                       ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, _
                       ByVal remoteAddress As EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal binding As Binding, _
                       ByVal remoteAddress As EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub

        Public Function Add(ByVal n1 As Double, _
                            ByVal n2 As Double) As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Add
            Return MyBase.Channel.Add(n1, n2)
        End Function

        Public Function Subtract(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Subtract
            Return MyBase.Channel.Subtract(n1, n2)
        End Function

        Public Function Multiply(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Multiply
            Return MyBase.Channel.Multiply(n1, n2)
        End Function

        Public Function Divide(ByVal n1 As Double, _
                               ByVal n2 As Double) As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Divide
            Return MyBase.Channel.Divide(n1, n2)
        End Function

    End Class

    '</snippet2>

    '<snippet3>

    'Client implementation code.
    Friend Class Client
        Shared Sub Main()

            'Specify the binding to be used for the client.
            Dim binding As New BasicHttpBinding()

            'Specify the address to be used for the client.
            Dim address As New EndpointAddress("http://localhost/servicemodelsamples/service.svc")


            ' Create a client that is configured with this address and binding.
            Dim client As New CalculatorClient(binding, address)

            ' Call the Add service operation.
            Dim value1 = 100.0R
            Dim value2 = 15.99R
            Dim result = client.Add(value1, value2)
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

            ' Call the Subtract service operation.
            value1 = 145.0R
            value2 = 76.54R
            result = client.Subtract(value1, value2)
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

            ' Call the Multiply service operation.
            value1 = 9.0R
            value2 = 81.25R
            result = client.Multiply(value1, value2)
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

            ' Call the Divide service operation.
            value1 = 22.0R
            value2 = 7.0R
            result = client.Divide(value1, value2)
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()
        End Sub
    End Class
End Namespace

'</snippet3>
