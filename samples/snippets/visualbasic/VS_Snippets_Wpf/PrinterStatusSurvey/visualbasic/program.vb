Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Printing
Imports System.Collections
Imports System.IO

Namespace PrinterStatusSurvey
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			' Obtain a list of print servers
			Console.Write("Enter path and file name of CRLF-delimited list of print servers: ")
			Dim pathToListOfPrintServers As String = Console.ReadLine()
			Dim fileOfPrintServers As New StreamReader(pathToListOfPrintServers)

			' Prompt user to determine the method of reading queue status that will be used
			Console.Write("Enter ""y"" to check queues using their QueueStatus attributes." & vbLf & "Otherwise, press Return and they will be checked using their specific properties: ")
			Dim useAttributesResponse As String = Console.ReadLine()


			'<SnippetSurveyQueues>
			' Survey queue status for every queue on every print server
			Dim line As String
			Dim statusReport As String = vbLf & vbLf & "Any problem states are indicated below:" & vbLf & vbLf
			line = fileOfPrintServers.ReadLine()
			Do While line IsNot Nothing
				 Dim myPS As New PrintServer(line, PrintSystemDesiredAccess.AdministrateServer)
				 Dim myPrintQueues As PrintQueueCollection = myPS.GetPrintQueues()
				 statusReport = statusReport & vbLf & line
				 For Each pq As PrintQueue In myPrintQueues
					 pq.Refresh()
					 statusReport = statusReport & vbLf & vbTab & pq.Name & ":"
					 If useAttributesResponse = "y" Then
						 TroubleSpotter.SpotTroubleUsingQueueAttributes(statusReport, pq)
						 ' TroubleSpotter class is defined in the complete example.
					 Else
						 TroubleSpotter.SpotTroubleUsingProperties(statusReport, pq)
					 End If

				 Next pq ' end for each print queue

				line = fileOfPrintServers.ReadLine()
			Loop ' end while list of print servers is not yet exhausted

			fileOfPrintServers.Close()
			Console.WriteLine(statusReport)
			Console.WriteLine(vbLf & "Press Return to continue.")
			Console.ReadLine()

			'</SnippetSurveyQueues>

		End Sub 'end Main

	End Class 'end Program class

	Friend Class TroubleSpotter
		' <SnippetSpotTroubleUsingQueueProperties>
		' Check for possible trouble states of a printer using its properties
		Friend Shared Sub SpotTroubleUsingProperties(ByRef statusReport As String, ByVal pq As PrintQueue)
			If pq.HasPaperProblem Then
				statusReport = statusReport & "Has a paper problem. "
			End If
			If Not(pq.HasToner) Then
				statusReport = statusReport & "Is out of toner. "
			End If
			If pq.IsDoorOpened Then
				statusReport = statusReport & "Has an open door. "
			End If
			If pq.IsInError Then
				statusReport = statusReport & "Is in an error state. "
			End If
			If pq.IsNotAvailable Then
				statusReport = statusReport & "Is not available. "
			End If
			If pq.IsOffline Then
				statusReport = statusReport & "Is off line. "
			End If
			If pq.IsOutOfMemory Then
				statusReport = statusReport & "Is out of memory. "
			End If
			If pq.IsOutOfPaper Then
				statusReport = statusReport & "Is out of paper. "
			End If
			If pq.IsOutputBinFull Then
				statusReport = statusReport & "Has a full output bin. "
			End If
			If pq.IsPaperJammed Then
				statusReport = statusReport & "Has a paper jam. "
			End If
			If pq.IsPaused Then
				statusReport = statusReport & "Is paused. "
			End If
			If pq.IsTonerLow Then
				statusReport = statusReport & "Is low on toner. "
			End If
			If pq.NeedUserIntervention Then
				statusReport = statusReport & "Needs user intervention. "
			End If

			' Check if queue is even available at this time of day
			' The following method is defined in the complete example.
			ReportAvailabilityAtThisTime(statusReport, pq)

		End Sub 'end SpotTroubleUsingProperties
		' </SnippetSpotTroubleUsingQueueProperties>

		' <SnippetSpotTroubleUsingQueueAttributes>
		' Check for possible trouble states of a printer using the flags of the QueueStatus property
		Friend Shared Sub SpotTroubleUsingQueueAttributes(ByRef statusReport As String, ByVal pq As PrintQueue)
			If (pq.QueueStatus And PrintQueueStatus.PaperProblem) = PrintQueueStatus.PaperProblem Then
				statusReport = statusReport & "Has a paper problem. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.NoToner) = PrintQueueStatus.NoToner Then
				statusReport = statusReport & "Is out of toner. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.DoorOpen) = PrintQueueStatus.DoorOpen Then
				statusReport = statusReport & "Has an open door. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.Error) = PrintQueueStatus.Error Then
				statusReport = statusReport & "Is in an error state. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.NotAvailable) = PrintQueueStatus.NotAvailable Then
				statusReport = statusReport & "Is not available. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.Offline) = PrintQueueStatus.Offline Then
				statusReport = statusReport & "Is off line. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.OutOfMemory) = PrintQueueStatus.OutOfMemory Then
				statusReport = statusReport & "Is out of memory. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.PaperOut) = PrintQueueStatus.PaperOut Then
				statusReport = statusReport & "Is out of paper. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.OutputBinFull) = PrintQueueStatus.OutputBinFull Then
				statusReport = statusReport & "Has a full output bin. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.PaperJam) = PrintQueueStatus.PaperJam Then
				statusReport = statusReport & "Has a paper jam. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.Paused) = PrintQueueStatus.Paused Then
				statusReport = statusReport & "Is paused. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.TonerLow) = PrintQueueStatus.TonerLow Then
				statusReport = statusReport & "Is low on toner. "
			End If
			If (pq.QueueStatus And PrintQueueStatus.UserIntervention) = PrintQueueStatus.UserIntervention Then
				statusReport = statusReport & "Needs user intervention. "
			End If

			' Check if queue is even available at this time of day
			' The method below is defined in the complete example.
			ReportAvailabilityAtThisTime(statusReport, pq)
		End Sub
		' </SnippetSpotTroubleUsingQueueAttributes>

		' <SnippetUsingStartAndUntilTimes>
		Private Shared Sub ReportAvailabilityAtThisTime(ByRef statusReport As String, ByVal pq As PrintQueue)
			If pq.StartTimeOfDay <> pq.UntilTimeOfDay Then ' If the printer is not available 24 hours a day
		Dim utcNow As Date = Date.UtcNow
		Dim utcNowAsMinutesAfterMidnight As Int32 = (utcNow.TimeOfDay.Hours * 60) + utcNow.TimeOfDay.Minutes

				' If now is not within the range of available times . . .
				If Not((pq.StartTimeOfDay < utcNowAsMinutesAfterMidnight) AndAlso (utcNowAsMinutesAfterMidnight < pq.UntilTimeOfDay)) Then
					statusReport = statusReport & " Is not available at this time of day. "
				End If
			End If
		End Sub
		' </SnippetUsingStartAndUntilTimes>

	End Class ' end TroubleSpotter class

End Namespace 'end namespace
