' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels

' Define a service contract.
<ServiceContract(Namespace:="http://UE.ServiceModel.Samples")> _
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

Namespace UE.ServiceModel.Samples

    Class client
        Public Shared Sub Main()

            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.None

            Dim address As EndpointAddress = New EndpointAddress("http://localhost:8000/servicemodelsamples/service/calc")
            Dim channelFactory As ChannelFactory(Of ICalculator) = New ChannelFactory(Of ICalculator)(binding, address)
            Dim channel As ICalculator = channelFactory.CreateChannel()

            Dim value1 As Double = 100D
            Dim value2 As Double = 15.99D
            Dim result As Double = channel.Add(value1, value2)
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

            ' Call the Subtract service operation.
            value1 = 145D
            value2 = 76.54D
            result = channel.Subtract(value1, value2)
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

            ' Call the Multiply service operation.
            value1 = 9D
            value2 = 81.25D
            result = channel.Multiply(value1, value2)
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

            ' Call the Divide service operation.
            value1 = 22D
            value2 = 7D
            result = channel.Divide(value1, value2)
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            CType(channel, IChannel).Close()
            Console.ReadLine()

        End Sub

    End Class

End Namespace

