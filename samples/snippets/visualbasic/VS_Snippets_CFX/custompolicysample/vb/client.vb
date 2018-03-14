Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.Text
Imports System.Web.Services.Description
Imports System.Xml

Namespace Microsoft.WCF.Documentation
  Friend Class Client
	Private wcfClient As StatefulServiceClient = Nothing

	Private Sub Run()
	  ' Picks up configuration from the config file.
	  Me.wcfClient = New StatefulServiceClient()
	  Try
		'<snippet10>
		' Download all metadata. 
		Dim endpoints As ServiceEndpointCollection = MetadataResolver.Resolve(GetType(IStatefulService), New EndpointAddress("http://localhost:8080/StatefulService/mex"))
		'</snippet10>

		Console.WriteLine("Calling 5 times: ")

                For i = 0 To 4
                    Dim response = Me.wcfClient.GetSessionID()
                    Console.WriteLine(response)
                Next i
		Console.WriteLine("Press ENTER to exit...")
		Console.ReadLine()
	  Catch timeProblem As TimeoutException
		Console.WriteLine("The service operation timed out. " & timeProblem.Message)
	  Catch commProblem As CommunicationException
		Console.WriteLine("There was a communication problem. " & commProblem.Message)
	  Finally
		If wcfClient.State <> CommunicationState.Closed Then
		  wcfClient.Close()
		End If
	  End Try
	End Sub

	Shared Sub Main(ByVal args() As String)
	  Dim client As New Client()
	  client.Run()
	End Sub
  End Class
End Namespace
