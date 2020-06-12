Namespace Microsoft.ServiceModel.Samples

    '<snippet10>  
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
    System.ServiceModel.ServiceContractAttribute(Namespace:="http://Microsoft.ServiceModel.Samples", _
                                                 ConfigurationName:="Microsoft.ServiceModel.Samples.ICalculator")> _
    Public Interface ICalculator

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Add", _
                                                        ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Subtract", _
                                                        ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/SubtractResponse")> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", _
                                                        ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Divide", _
                                                        ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/DivideResponse")> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface
    '</snippet10>

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Interface ICalculatorChannel
        Inherits Microsoft.ServiceModel.Samples.ICalculator, System.ServiceModel.IClientChannel
    End Interface

    '<snippet20>
    <System.Diagnostics.DebuggerStepThroughAttribute(), _
    System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Partial Public Class CalculatorClient
        Inherits System.ServiceModel.ClientBase(Of Microsoft.ServiceModel.Samples.ICalculator)
        Implements Microsoft.ServiceModel.Samples.ICalculator

        Public Sub New()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress _
                       As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress _
                       As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) _
        As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Add
            Return MyBase.Channel.Add(n1, n2)
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) _
        As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Subtract
            Return MyBase.Channel.Subtract(n1, n2)
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) _
        As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Multiply
            Return MyBase.Channel.Multiply(n1, n2)
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) _
        As Double Implements Microsoft.ServiceModel.Samples.ICalculator.Divide
            Return MyBase.Channel.Divide(n1, n2)
        End Function
    End Class
    '</snippet20>
End Namespace
