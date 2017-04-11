'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
' <snippet1>

Imports System
Imports System.ServiceModel.Description
Imports System.Configuration
Imports System.ServiceModel
Imports System.Security.Principal
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Tokens
Imports System.IdentityModel.Selectors
Imports System.Threading

Namespace Microsoft.ServiceModel.Samples
	' Define a service contract.
	<ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
	Public Interface ICalculator
		<OperationContract> _
		Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract> _
		Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract> _
		Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract> _
		Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
	End Interface

	' Service class that implements the service contract.
	' Added code to write output to the console window
	Public Class CalculatorService
		Implements ICalculator
		Private Shared Sub DisplayIdentityInformation()
			Console.WriteLine(Constants.vbTab + Constants.vbTab & "Thread Identity            :{0}", WindowsIdentity.GetCurrent().Name)
			Console.WriteLine(Constants.vbTab + Constants.vbTab & "Thread Impersonation level :{0}", WindowsIdentity.GetCurrent().ImpersonationLevel)
			Console.WriteLine(Constants.vbTab + Constants.vbTab & "hToken                     :{0}", WindowsIdentity.GetCurrent().Token.ToString())
			Return
		End Sub

' <snippet2>
		<OperationBehavior(Impersonation := ImpersonationOption.Required)> _
		Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Dim result = n1 + n2
			Console.WriteLine("Received Add({0},{1})", n1, n2)
			Console.WriteLine("Return: {0}", result)
			DisplayIdentityInformation()
			Return result
		End Function
' </snippet2>
		Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Dim result = n1 - n2
			Console.WriteLine("Received Subtract({0},{1})", n1, n2)
			Console.WriteLine("Return: {0}", result)
			Console.WriteLine("Before impersonating")
			DisplayIdentityInformation()
			Using ServiceSecurityContext.Current.WindowsIdentity.Impersonate()
				' Make a system call in the caller's context and ACLs 
				' on the system resource are enforced in the caller's context. 
				Console.WriteLine("Impersonating the caller imperatively")
				DisplayIdentityInformation()
			End Using
			Console.WriteLine("After reverting")
			DisplayIdentityInformation()
			Return result
		End Function

		Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Dim result = n1 * n2
			Console.WriteLine("Received Multiply({0},{1})", n1, n2)
			Console.WriteLine("Return: {0}", result)
			Return result
		End Function

		Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
            Dim result = n1 / n2
			Console.WriteLine("Received Divide({0},{1})", n1, n2)
			Console.WriteLine("Return: {0}", result)
			Return result
		End Function


		' Host the service within this EXE console application.
		Public Shared Sub Main()
			' Get base address from appsettings in configuration.
			Dim baseAddress As New Uri(ConfigurationManager.AppSettings("baseAddress"))

			' Create a ServiceHost for the CalculatorService type and provide the base address.
			Using serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
				serviceHost.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.UseWindowsGroups
				' Open the ServiceHostBase to create listeners and start listening for messages.
				serviceHost.Open()

				' The service can now be accessed.
				Console.WriteLine("The service is ready.")
				Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name)
				Console.WriteLine("Press <ENTER> to terminate service.")
				Console.WriteLine()
				Console.ReadLine()

				' Close the ServiceHostBase to shutdown the service.
				serviceHost.Close()
			End Using
		End Sub

	End Class

End Namespace
' </snippet1>