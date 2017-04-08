
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
Imports System
Imports System.Configuration
Imports System.ServiceModel
Imports System.ServiceModel.Description

' Define a service contract.
<ServiceContract([Namespace] := "http://Microsoft.ServiceModel.Samples")>  _
Public Interface ICalculator
    <OperationContract()>  _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double 
    <OperationContract()>  _
    Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double 
    <OperationContract()>  _
    Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double 
    <OperationContract()>  _
    Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double 
End Interface 

' Service class that implements the service contract.
' Added code to write output to the console window.

Public Class CalculatorService
    Implements ICalculator
    
    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
       Implements ICalculator.Add
        Dim result As Double = n1 + n2
        Console.WriteLine("Received Add({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result
    
    End Function 
    
    
    Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double _
       Implements ICalculator.Subtract
        Dim result As Double = n1 - n2
        Console.WriteLine("Received Subtract({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result
    End Function 
    
    
    Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double _
       Implements ICalculator.Multiply
        Dim result As Double = n1 * n2
        Console.WriteLine("Received Multiply({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result
    End Function 
    
    Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double _
       Implements ICalculator.Divide
        Dim result As Double = n1 / n2
        Console.WriteLine("Received Divide({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result
    End Function 
    
    ' Host the service within this EXE console application.
    '<snippet1>
    Public Shared Sub Main() 
        ' Get base address from appsettings in configuration.
        Dim baseAddress As New Uri(ConfigurationManager.AppSettings("baseAddress"))
        
        ' Create a ServiceHost for the CalculatorService type 
        ' and provide the base address.
        Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
        Try
            '<snippet2>
            ' Create a new auditing behavior and set the log location.
            Dim newAudit As New ServiceSecurityAuditBehavior()
            newAudit.AuditLogLocation = AuditLogLocation.Application
            '</snippet2>
            '<snippet3>
            newAudit.MessageAuthenticationAuditLevel = _
                AuditLevel.SuccessOrFailure
            newAudit.ServiceAuthorizationAuditLevel = _
                AuditLevel.SuccessOrFailure
            '</snippet3>
            '<snippet4>
            newAudit.SuppressAuditFailure = False
            '</snippet4>
            '<snippet5>            
            ' Remove the old behavior and add the new.
            serviceHost.Description.Behaviors.Remove(Of ServiceSecurityAuditBehavior)
            serviceHost.Description.Behaviors.Add(newAudit)
            '</snippet5>
            ' Open the ServiceHostBase to create listeners 
            ' and start listening for messages.
            serviceHost.Open()
            
            ' The service can now be accessed.
            Console.WriteLine("The service is ready.")
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()
            
            ' Close the ServiceHostBase to shutdown the service.
            serviceHost.Close()
        Finally
        End Try
    
    End Sub 
    '</snippet1>
End Class 

