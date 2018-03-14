Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.IO.Packaging
Imports System.Xml
Imports System.Windows.Xps
Imports System.Windows.Xps.Packaging
Imports System.Printing

Public Class PrintServerCreate
	<STAThread>
	Shared Sub Main(ByVal args() As String)
		Dim psCreate As New PrintServerCreate()
		psCreate.Run()
	End Sub

	Public Sub Run()
		' <Snippet_CreatePrintServer>

		' Create a PrintServer
		' "theServer" must be a print server to which the user has full print access.
		Dim myPrintServer As New PrintServer("\\theServer")

		' List the print server's queues
		Dim myPrintQueues As PrintQueueCollection = myPrintServer.GetPrintQueues()
		Dim printQueueNames As String = "My Print Queues:" & vbLf & vbLf
		For Each pq As PrintQueue In myPrintQueues
			printQueueNames &= vbTab & pq.Name & vbLf
		Next pq
		Console.WriteLine(printQueueNames)
		Console.WriteLine(vbLf & "Press Return to continue.")
		Console.ReadLine()

		' </Snippet_CreatePrintServer>
	End Sub 'end Run()

End Class ' end:class PrintServerCreate
