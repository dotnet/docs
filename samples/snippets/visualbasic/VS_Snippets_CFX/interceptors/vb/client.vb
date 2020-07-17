Imports System.ServiceModel
Imports System.ServiceModel.Channels

Imports microsoft.wcf.documentation

Public Class Client
    Public Shared Sub Main()
        ' Picks up configuration from the config file.
        Dim wcfClient As New SampleServiceClient()
        Try
            ' Making calls.
            Console.WriteLine("Enter the greeting to send: ")
            Dim greeting As String = Console.ReadLine()
            Console.WriteLine("The service responded: " & wcfClient.SampleMethod(greeting))

            Console.WriteLine("Press ENTER to exit:")
            Console.ReadLine()

            ' Done with service. 
            wcfClient.Close()
            Console.WriteLine("Done!")
        Catch timeProblem As TimeoutException
            Console.WriteLine("The service operation timed out. " & timeProblem.Message)
            Console.Read()
            wcfClient.Abort()
        Catch fault As FaultException(Of SampleFault)
            Console.WriteLine("SampleFault fault occurred: {0}", fault.Detail.FaultMessage)
            Console.Read()
            wcfClient.Abort()
        Catch commProblem As CommunicationException
            Console.WriteLine("There was a communication problem. " & commProblem.Message)
            Console.Read()
            wcfClient.Abort()
        End Try
    End Sub
End Class
