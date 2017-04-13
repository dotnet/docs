Imports System.Net
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
'<snippet11>
Imports System
Imports System.ServiceModel


Namespace Microsoft.ServiceModel.Samples
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
    
    ' Step 1: Create service class that implements the service contract.
'<snippet110>
    Public Class CalculatorService
        Implements ICalculator
'</snippet110>
        
        ' Step 2: Implement functionality for the service operations.
'<snippet111>
        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Dim result As Double = n1 + n2
            ' Code added to write output to the console window.
            Console.WriteLine("Received Add({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Dim result As Double = n1 - n2
            Console.WriteLine("Received Subtract({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Dim result As Double = n1 * n2
            Console.WriteLine("Received Multiply({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        
        End Function
        
        
        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
            Dim result As Double = n1 / n2
            Console.WriteLine("Received Divide({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        
        End Function
'</snippet111>
    End Class
End Namespace
'</snippet11>

Namespace HowToCreateAclient
    
    Public Class Test
        
        Shared Sub Main() 
            '<snippet15>
            Dim machineName As String = Dns.GetHostEntry("").HostName
            ' Print the fully qualified address to the screen.
            Console.WriteLine("Listening on: {0}:8000/servicemodel/", machineName)
            Console.ReadLine()
            '</snippet15>
        End Sub
    End Class
End Namespace
