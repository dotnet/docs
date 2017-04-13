Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels

Imports microsoft.wcf.documentation

Public Class Client

  Public Shared Sub Main()
    ' Picks up configuration from the config file.
    Using wcfClient As SampleServiceClient = New SampleServiceClient()
      Try
        ' Making calls.
        Console.WriteLine("Enter the greeting to send: ")
        Dim greeting As String = Console.ReadLine()
        Console.WriteLine("The service responded: " + wcfClient.SampleMethod(greeting))

        Console.WriteLine("Press ENTER to exit:")
        Console.ReadLine()

        ' Done with service. 
        wcfClient.Close()
        Console.WriteLine("Done!")
      Catch timeProblem As TimeoutException
        Console.WriteLine("The service operation timed out. " + timeProblem.Message)
        Console.Read()
      Catch fault As FaultException(Of microsoft.wcf.documentation.SampleFault)
        If (True) Then
          Console.WriteLine("SampleFault fault occurred: {0}", fault.Detail.FaultMessage)
          Console.Read()
        End If
      Catch commProblem As CommunicationException
        If (True) Then
          Console.WriteLine("There was a communication problem. " + commProblem.Message)
          Console.Read()
        End If
      Finally
        wcfClient.Close()
      End Try
    End Using
  End Sub 'Main
End Class 'Client