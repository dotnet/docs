Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions



Namespace ProxySample


    Public Class Test

        Shared Sub Main()

        End Sub


        Private Sub Impersonation()

        End Sub



        Private Sub ClientCode()
            '<snippet1>             
            Dim client As New CalculatorClient("CalculatorEndpoint")
            client.ClientCredentials.Windows.AllowedImpersonationLevel = _
                System.Security.Principal.TokenImpersonationLevel.Impersonation
            '</snippet1>

        End Sub



        Public Interface ICalculator

            <System.ServiceModel.OperationContractAttribute(ProtectionLevel:=System.Net.Security.ProtectionLevel.EncryptAndSign, Action:="http://tempuri.org/ICalculator/Add", ReplyAction:="http://tempuri.org/ICalculator/AddResponse")> _
            Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        End Interface 'ICalculator

        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
        Public Interface ICalculatorChannel
            : Inherits ICalculator, System.ServiceModel.IClientChannel
        End Interface 'ICalculatorChannel

        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
        Public Class CalculatorClient
            Inherits System.ServiceModel.ClientBase(Of ICalculator)
            Implements ICalculator

            Public Sub New()
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


            Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
                Return MyBase.Channel.Add(n1, n2)

            End Function 'Add
        End Class
    End Class
End Namespace 'ProxySample

Namespace ClientSample



    <ServiceContract()> _
    Interface ICalculator
        <OperationContract()> _
        Function Add(ByVal a As Double, ByVal b As Double) As Double
    End Interface 'ICalculator



    Public Class Calculator
        Implements ICalculator

        '<snippet2>
        <OperationBehavior(Impersonation:=ImpersonationOption.Required)> _
        Public Function Add(ByVal a As Double, ByVal b As Double) As Double _
           Implements ICalculator.Add
            Return a + b
        End Function
        '</snippet2>
    End Class
End Namespace 'ClientSample
