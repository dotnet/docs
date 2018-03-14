'-----------------------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'-----------------------------------------------------------------------------
Imports System

Imports System.Security.Cryptography.X509Certificates

Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.Security.Principal


'The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.
'Client implementation code.

Class Client

    Shared Sub Main()
        ' Create a WCF client with Username endpoint configuration
        Dim wcfClient As New CalculatorClient("Username")
        Try
            wcfClient.ClientCredentials.UserName.UserName = "test1"
            wcfClient.ClientCredentials.UserName.Password = "1tset"

            ' Call the Add service operation.
            Dim value1 As Double = 100.0
            Dim value2 As Double = 15.99
            Dim result As Double = wcfClient.Add(value1, value2)
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

            ' Call the Subtract service operation.
            value1 = 145.0
            value2 = 76.54
            result = wcfClient.Subtract(value1, value2)
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

            ' Call the Multiply service operation.
            value1 = 9.0
            value2 = 81.25
            result = wcfClient.Multiply(value1, value2)
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

            ' Call the Divide service operation.
            value1 = 22.0
            value2 = 7.0
            result = wcfClient.Divide(value1, value2)
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

        Catch timeout As TimeoutException
            Console.WriteLine(timeout.Message)
            Console.Read()
            wcfClient.Abort()
        Catch commException As CommunicationException
            Console.WriteLine(commException.Message)
            Console.Read()
            wcfClient.Abort()
        End Try

        ' Create a wcfClient with Certificate endpoint configuration
        Dim wcfClient2 As New CalculatorClient("Certificate")
        wcfClient2.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.TrustedPeople, X509FindType.FindBySubjectName, "test1")

        Try
            ' Call the Add service operation.
            Dim value1 As Double = 100.0
            Dim value2 As Double = 15.99
            Dim result As Double = wcfClient2.Add(value1, value2)
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

            ' Call the Subtract service operation.
            value1 = 145.0
            value2 = 76.54
            result = wcfClient2.Subtract(value1, value2)
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

            ' Call the Multiply service operation.
            value1 = 9.0
            value2 = 81.25
            result = wcfClient2.Multiply(value1, value2)
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

            ' Call the Divide service operation.
            value1 = 22.0
            value2 = 7.0
            result = wcfClient2.Divide(value1, value2)
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

        Catch timeout As TimeoutException
            Console.WriteLine(timeout.Message)
            Console.Read()
            wcfClient.Abort()
        Catch commException As CommunicationException
            Console.WriteLine(commException.Message)
            Console.Read()
            wcfClient.Abort()
        End Try

        Console.WriteLine()
        Console.WriteLine("Press <ENTER> to terminate client.")
        Console.ReadLine()

    End Sub 'Main
End Class 'Client