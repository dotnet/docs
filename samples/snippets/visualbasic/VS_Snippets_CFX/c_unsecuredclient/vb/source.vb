 '<snippet0>
Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
'<snippet0>
Imports System.Security.Permissions
Imports System.ServiceModel.Description
Imports System.Security.Principal



Class Test
    
    Shared Sub Main(ByVal args() As String) 
        Dim t As New Test()
        t.UnsecuredHttp()
    End Sub

    
    Private Sub UnsecuredHttp() 
        '<snippet1>
        ' Create an instance of the BasicHttpBinding. 
        ' By default, there is no security.
        Dim myBinding As New BasicHttpBinding()
        
        ' Create the address string, or get it from configuration.
        Dim httpUri As String = "http://localhost/Calculator"
        
        ' Create an endpoint address with the address.
        Dim myEndpoint As New EndpointAddress(httpUri)
        
        ' Create an instance of the WCF client. The client
        ' code was generated using the Svcutil.exe tool.
        Dim cc As New CalculatorClient(myBinding, myEndpoint)
        Try
            cc.Open()
            ' Begin using the calculator.
            Console.WriteLine(cc.Divide(100, 2))
            
            ' Close the client.
            cc.Close()
        Catch tex As TimeoutException
            Console.WriteLine(tex.Message)
            cc.Abort()
        Catch cex As CommunicationException
            Console.WriteLine(cex.Message)
            cc.Abort()
        Finally
            Console.WriteLine("Closed the client")
            Console.ReadLine()
        End Try
        '</snippet1>
    End Sub
    Private Sub UnsecuredTcp()
        '<snippet2>
        ' Create an instance of the NetTcpBinding and set the
        ' security mode to none.
        Dim myBinding As New NetTcpBinding()
        myBinding.Security.Mode = SecurityMode.None

        ' Create the address string, or get it from configuration.
        Dim tcpUri As String = "net.tcp://machineName:8008/Calculator"

        ' Create an endpoint address with the address.
        Dim myEndpointAddress As New EndpointAddress(tcpUri)

        ' Create an instance of the WCF client. The client
        ' code was generated using the Svcutil.exe tool.
        Dim cc As New CalculatorClient(myBinding, myEndpointAddress)
        Try
            cc.Open()
            '</snippet2>
            ' Begin using the calculator.
            Console.WriteLine(cc.Divide(100, 2))

            ' Close the client.
            cc.Close()
        Catch tex As TimeoutException
            Console.WriteLine(tex.Message)
            cc.Abort()
        Catch cex As CommunicationException
            Console.WriteLine(cex.Message)
            cc.Abort()
        Finally
            Console.WriteLine("Closed the client")
            Console.ReadLine()
        End Try

    End Sub
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), System.ServiceModel.ServiceContractAttribute()>  _
Public Interface ICalculator
    
    <System.ServiceModel.OperationContractAttribute(Action := "http://tempuri.org/ICalculator/Divide", ReplyAction := "http://tempuri.org/ICalculator/DivideResponse")>  _
    Function Divide(ByVal a As Double, ByVal b As Double) As Double 
    
    <System.ServiceModel.OperationContractAttribute(Action := "http://tempuri.org/ICalculator/CalculateTax", ReplyAction := "http://tempuri.org/ICalculator/CalculateTaxResponse")>  _
    Function CalculateTax(ByVal a As Double) As Double 
End Interface

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
Public Interface ICalculatorChannel
    : Inherits ICalculator, System.ServiceModel.IClientChannel
End Interface


Class CalculatorClient
    Inherits System.ServiceModel.ClientBase(Of ICalculator)
    Implements ICalculator
    Public Sub New()
    End Sub 'New
    
    
    Public Sub New(ByVal endpointConfigurationName As String) 
        MyBase.New(endpointConfigurationName)
    
    End Sub 'New
    
    
    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String) 
        MyBase.New(endpointConfigurationName, remoteAddress)
    
    End Sub 'New
    
    
    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress) 
        MyBase.New(endpointConfigurationName, remoteAddress)
    
    End Sub 'New
    
    
    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress) 
        MyBase.New(binding, remoteAddress)
    
    End Sub 'New
    
    
    Public Function Divide(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Divide
        Return MyBase.Channel.Divide(a, b)

    End Function 'Divide
    
    
    Public Function CalculateTax(ByVal a As Double) As Double Implements ICalculator.CalculateTax
        Return MyBase.Channel.CalculateTax(a)

    End Function
End Class 'CalculatorClient
