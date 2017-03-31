Imports System.Text
Imports System.Printing
Imports System.Collections

Namespace EnumerateSubsetOfPrintQueues
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			'<SnippetListSubsetOfPrintQueues>
			' Specify that the list will contain only the print queues that are installed as local and are shared
			Dim enumerationFlags() As EnumeratedPrintQueueTypes = {EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Shared}

			Dim printServer As New LocalPrintServer()

			'Use the enumerationFlags to filter out unwanted print queues
			Dim printQueuesOnLocalServer As PrintQueueCollection = printServer.GetPrintQueues(enumerationFlags)

			Console.WriteLine("These are your shared, local print queues:" & vbLf & vbLf)

			For Each printer As PrintQueue In printQueuesOnLocalServer
				Console.WriteLine(vbTab & "The shared printer " & printer.Name & " is located at " & printer.Location & vbLf)
			Next printer
			Console.WriteLine("Press enter to continue.")
			Console.ReadLine()
			'</SnippetListSubsetOfPrintQueues>
		End Sub

	End Class
End Namespace
