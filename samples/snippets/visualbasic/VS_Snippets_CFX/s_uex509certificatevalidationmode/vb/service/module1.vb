'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
Imports System
Imports System.Collections.Generic

Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Tokens
Imports System.IdentityModel.Selectors

Imports System.Security.Principal

Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security


' Define a service contract.
<ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface 'ICalculator

' Service class which implements the service contract.
' Added code to write output to the console window
<ServiceBehavior(IncludeExceptionDetailInFaults:=True)> _
Public Class CalculatorService

    Implements ICalculator

    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add

        Dim result As Double = n1 + n2
        Console.WriteLine("Received Add({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function 'Add



    Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract

        Dim result As Double = n1 - n2
        Console.WriteLine("Received Subtract({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function 'Subtract



    Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply

        Dim result As Double = n1 * n2
        Console.WriteLine("Received Multiply({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function 'Multiply



    Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
        Dim result As Double = n1 / n2
        Console.WriteLine("Received Divide({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function 'Divide





    ' Host the service within this EXE console application.
    Public Shared Sub Main()
        ' Create a ServiceHost for the CalculatorService type and provide the base address.
        Dim serviceHost As New ServiceHost(GetType(CalculatorService))
        ' Open the ServiceHost to create listeners and start listening for messages.
        serviceHost.Open()

        ' The service can now be accessed.
        Console.WriteLine("The service is ready.")
        Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name)
        Console.WriteLine("Press <ENTER> to terminate service.")
        Console.WriteLine()
        Console.ReadLine()

        ' Close the ServiceHost to shutdown the service.
        serviceHost.Close()

    End Sub 'Main
End Class 'CalculatorService


Public Class MyServiceAuthorizationManager
    Inherits ServiceAuthorizationManager

    Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean
        ' Extact the action URI from the OperationContext. We will use this to match against the claims
        ' in the AuthorizationContext
        Dim action As String = operationContext.RequestContext.RequestMessage.Headers.Action
        Console.WriteLine("action: {0}", action)

        ' Iterate through the various claimsets in the authorizationcontext
        Dim cs As ClaimSet
        For Each cs In operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets
            ' Only look at claimsets issued by System.
            If cs.Issuer Is ClaimSet.System Then
                ' Iterate through claims of type "http://example.org/claims/allowedoperation"
                Dim c As Claim
                For Each c In cs.FindClaims("http://example.org/claims/allowedoperation", Rights.PossessProperty)
                    ' Dump the Claim resource to the console.
                    Console.WriteLine("resource: {0}", c.Resource.ToString())

                    ' If the Claim resource matches the action URI then return true to allow access
                    If action = c.Resource.ToString() Then
                        Return True
                    End If
                Next c
            End If
        Next cs
        ' If we get here, return false, denying access.
        Return False

    End Function 'CheckAccessCore
End Class 'MyServiceAuthorizationManager


Public Class MyCustomUserNameValidator
    Inherits UserNamePasswordValidator

    ' This method validates users. It allows in two users, test1 and test2 
    ' with passwords 1tset and 2tset respectively.
    ' This code is for illustration purposes only and 
    ' MUST NOT be used in a production environment because it is NOT secure.	
    Public Overrides Sub Validate(ByVal userName As String, ByVal password As String)
        If Nothing = userName OrElse Nothing = password Then
            Throw New ArgumentNullException()
        End If

        If Not (userName = "test1" AndAlso password = "1tset") AndAlso Not (userName = "test2" AndAlso password = "2tset") Then
            Throw New SecurityTokenException("Unknown Username or Password")
        End If

    End Sub 'Validate
End Class 'MyCustomUserNameValidator