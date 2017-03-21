<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
Partial Public Class SampleServiceClient
    Inherits System.ServiceModel.ClientBase(Of ISampleService)
    Implements ISampleService

    Public Sub New()
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String)
        MyBase.New(endpointConfigurationName)
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
        MyBase.New(endpointConfigurationName, remoteAddress)
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String, _
                   ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(endpointConfigurationName, remoteAddress)
    End Sub

    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, _
                   ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)
    End Sub

    Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
        Return MyBase.Channel.SampleMethod(msg)
    End Function
End Class