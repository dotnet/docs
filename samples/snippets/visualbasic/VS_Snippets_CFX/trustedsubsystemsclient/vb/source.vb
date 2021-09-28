' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.ServiceModel
Imports System.Text


Namespace Microsoft.ServiceModel.Samples

    Class Client

        Public Shared Sub Main()

            Console.WriteLine("Username authentication required.")
            Console.WriteLine("Provide a username and a password that match (ex. username:test password:test)")
            Console.WriteLine("   Enter username:")
            Dim username As String = Console.ReadLine()
            Console.WriteLine("   Enter password:")
            Dim password As New StringBuilder()

            Dim info As ConsoleKeyInfo = Console.ReadKey(True)
            While info.Key <> ConsoleKey.Enter

                If info.Key <> ConsoleKey.Backspace Then

                    password.Append(info.KeyChar)
                    info = Console.ReadKey(True)

                ElseIf info.Key = ConsoleKey.Backspace Then

                    If password.Length <> 0 Then

                        password.Remove(password.Length - 1, 1)

                    End If
                    info = Console.ReadKey(True)

                End If

            End While

            For i As Integer = 0 To password.Length - 1
                Console.Write("*")
            Next

            Console.WriteLine()
            ' <snippet1>
            ' Create the binding.
            Dim subsystemBinding As New WSHttpBinding()
            subsystemBinding.Security.Mode = SecurityMode.Message
            subsystemBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName

            ' Create the URI for the endpoint.
            Dim ea As New EndpointAddress("http://www.cohowinery.com:8000/FacadeService")

            Dim client As New CalculatorClient(subsystemBinding, ea)

            ' Configure client with valid machine or domain account (username,password)
            client.ClientCredentials.UserName.UserName = username
            client.ClientCredentials.UserName.Password = password.ToString()

            ' Call the Multiply service operation.
            Dim value1 As Double = 39
            Dim value2 As Double = 50.44
            Dim result As Double = client.Multiply(value1, value2)
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)


            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()
            ' </snippet1>
        End Sub

    End Class
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://Microsoft.ServiceModel.Samples", ConfigurationName:="Microsoft.ServiceModel.Samples.ICalculator")> _
    Public Interface ICalculator

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double

    End Interface

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Interface ICalculatorChannel
        Inherits Microsoft.ServiceModel.Samples.ICalculator, System.ServiceModel.IClientChannel
    End Interface

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Partial Public Class CalculatorClient
        Inherits System.ServiceModel.ClientBase(Of Microsoft.ServiceModel.Samples.ICalculator)
        Implements Microsoft.ServiceModel.Samples.ICalculator

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Multiply
            Return MyBase.Channel.Multiply(n1, n2)
        End Function

    End Class

End Namespace
