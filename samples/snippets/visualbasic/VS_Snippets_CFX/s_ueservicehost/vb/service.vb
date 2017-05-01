
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace ServiceModel.Sample

    ' Define a service contract.
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
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

    ' Service class which implements the service contract.
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

        ' Host the service within this EXE console application.
        Public Shared Sub Main()

            ' Get base address from app settings in configuration
            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            ' <Snippet1>
            Dim svcHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)
            ' </Snippet1>


            ' Open the ServiceHost to create listeners and start listening for messages.
            svcHost.Open()

            ' The service can now be accessed.
            Console.WriteLine("The service is ready.")
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()

            ' Close the ServiceHost to shutdown the service.
            svcHost.Close()

        End Sub

        Public Shared Sub Snippet2()
            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

            ' <Snippet2>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/basic")
            serviceHost.AddServiceEndpoint("IMetadataExchange", binding, address)
            ' </Snippet2>
        End Sub

        Public Shared Sub Snippet3()
            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

            ' <Snippet3>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, "http://localhost:8000/servicemodelsamples/service/basic")
            ' </Snippet3>
        End Sub

        Public Shared Sub Snippet4()
            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

            ' <Snippet4>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/basic")
            serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)
            ' </Snippet4>
        End Sub

        Public Shared Sub Snippet5()
            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

            ' <Snippet5>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Dim listenUri As Uri = New Uri("http://localhost:8000/MyListenUri")
            Dim address As String = "http://localhost:8000/servicemodelsamples/service/basic"
            serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address, listenUri)
            ' </Snippet5>
        End Sub

        Public Shared Sub Snippet6()
            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

            ' <Snippet6>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Dim listenUri As Uri = New Uri("http://localhost:8000/MyListenUri")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/basic")
            serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address, listenUri)
            ' </Snippet6>
        End Sub
    End Class

End Namespace
