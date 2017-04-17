' <Snippet8>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

' <Snippet0>
Imports System.ComponentModel
Imports System.ServiceModel
Imports System.ServiceProcess
Imports System.Configuration
Imports System.Configuration.Install
' </Snippet0>

Namespace Microsoft.ServiceModel.Samples
	' <Snippet1>
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
	' </Snippet1>

	' <Snippet2>
	' Implement the ICalculator service contract in a service class.
	Public Class CalculatorService
		Implements ICalculator
		' Implement the ICalculator methods.
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
	' </Snippet2>

	' <Snippet3>
	Public Class CalculatorWindowsService
		Inherits ServiceBase
		Public serviceHost As ServiceHost = Nothing
		Public Sub New()
			' Name the Windows Service
			ServiceName = "WCFWindowsServiceSample"
		End Sub

		Public Shared Sub Main()
			ServiceBase.Run(New CalculatorWindowsService())
		End Sub
	' </Snippet3>

		' <Snippet4>
		' Start the Windows service.
		Protected Overrides Sub OnStart(ByVal args() As String)
			If serviceHost IsNot Nothing Then
				serviceHost.Close()
			End If

			' Create a ServiceHost for the CalculatorService type and 
			' provide the base address.
			serviceHost = New ServiceHost(GetType(CalculatorService))

			' Open the ServiceHostBase to create listeners and start 
			' listening for messages.
			serviceHost.Open()
		End Sub
		' </Snippet4>

		' <Snippet5>
		Protected Overrides Sub OnStop()
			If serviceHost IsNot Nothing Then
				serviceHost.Close()
				serviceHost = Nothing
			End If
		End Sub
		' </Snippet5>
	End Class
    ' <Snippet6>
    ' Provide the ProjectInstaller class which allows 
    ' the service to be installed by the Installutil.exe tool
    <RunInstaller(True)> _
 Public Class ProjectInstaller
        Inherits Installer
        Private process As ServiceProcessInstaller
        Private service As ServiceInstaller

        Public Sub New()
            process = New ServiceProcessInstaller()
            process.Account = ServiceAccount.LocalSystem
            service = New ServiceInstaller()
            service.ServiceName = "WCFWindowsServiceSample"
            Installers.Add(process)
            Installers.Add(service)
        End Sub
    End Class
	' </Snippet6>  
End Namespace
' </Snippet8>