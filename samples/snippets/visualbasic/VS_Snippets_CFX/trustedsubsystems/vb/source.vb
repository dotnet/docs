Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.ServiceModel.Channels
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Permissions
Imports System.ServiceModel.Description
Imports System.Configuration


Namespace Windows.Communication.Foundation.Samples


    Public Class Test
        Private Sub New()
        End Sub

        Shared Sub Main()
            Console.WriteLine("Hello")
            Console.ReadLine()
        End Sub
        Private Class Snippets
            Private Sub Snippet1()
                '<snippet1>
                Dim baseAddress As New Uri("http://localhost:8000/FacadeService")
                Using myServiceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
                    Dim binding As New WSHttpBinding()
                    binding.Security.Mode = SecurityMode.Message
                    binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName
                    myServiceHost.AddServiceEndpoint(GetType(CalculatorService), binding, String.Empty)
                    myServiceHost.Open()
                    ' Wait for calls. 
                    myServiceHost.Close()
                End Using
                '</snippet1>
            End Sub
        End Class
    End Class
    <System.ServiceModel.ServiceContractAttribute([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator
        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Subtract", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/SubtractResponse")> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Divide", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/DivideResponse")> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface 'ICalculator
    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
            Implements ICalculator.Add
            Return n1 + n2
        End Function 'Add

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double _
            Implements ICalculator.Subtract
            Return n1 - n2
        End Function 'Subtract

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double _
            Implements ICalculator.Divide
            Return n1 / n2
        End Function
        ' <snippet2>
        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double _
            Implements ICalculator.Multiply
            ' Create the binding.
            Dim bindingElements As New BindingElementCollection()
            bindingElements.Add(SecurityBindingElement.CreateUserNameOverTransportBindingElement())
            bindingElements.Add(New WindowsStreamSecurityBindingElement())
            bindingElements.Add(New TcpTransportBindingElement())
            Dim backendServiceBinding As New CustomBinding(bindingElements)

            ' Create the endpoint address. 
            Dim ea As New EndpointAddress("http://contoso.com:8001/BackendService")

            ' Call the back-end service.
            Dim client As New CalculatorClient(backendServiceBinding, ea)
            client.ClientCredentials.UserName.UserName = ServiceSecurityContext.Current.PrimaryIdentity.Name
            Dim result As Double = client.Multiply(n1, n2)
            client.Close()

            Return result
        End Function
        ' </snippet2>    
    End Class
    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Partial Public Class CalculatorClient
        Inherits System.ServiceModel.ClientBase(Of Windows.Communication.Foundation.Samples.ICalculator)
        Implements Windows.Communication.Foundation.Samples.ICalculator

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

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Windows.Communication.Foundation.Samples.ICalculator.Add
            Return MyBase.Channel.Add(n1, n2)
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Windows.Communication.Foundation.Samples.ICalculator.Subtract
            Return MyBase.Channel.Subtract(n1, n2)
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Windows.Communication.Foundation.Samples.ICalculator.Multiply
            Return MyBase.Channel.Multiply(n1, n2)
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements Windows.Communication.Foundation.Samples.ICalculator.Divide
            Return MyBase.Channel.Divide(n1, n2)
        End Function
    End Class
End Namespace
