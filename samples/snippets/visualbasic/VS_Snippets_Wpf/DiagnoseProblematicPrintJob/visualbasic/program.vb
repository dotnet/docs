Imports System.Collections.Generic
Imports System.Text
Imports System.Printing
Imports System.IO

Namespace DiagnoseProblematicPrintJob
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			' Obtain a list of print servers.
			Console.Write("Enter path and file name of CRLF-delimited list of print servers" & vbLf & "(press Return for default ""C:\PrintServers.txt""): ")
			Dim pathToListOfPrintServers As String = Console.ReadLine()
			If pathToListOfPrintServers = "" Then
				pathToListOfPrintServers = "C:\PrintServers.txt"
			End If
			Dim fileOfPrintServers As New StreamReader(pathToListOfPrintServers)

			' Obtain the username of the person with the problematic print job.
			Console.Write(vbLf & "Enter username of person that submitted print job" & vbLf & "(press Return for the current user {0}: ", Environment.UserName)
			Dim userName As String = Console.ReadLine()
			If userName = "" Then
				userName = Environment.UserName
			End If

			' Prompt user to determine the method that will be used to read the queue status.
			Console.Write(vbLf & "Enter ""Y"" to check the problematic job using its JobStatus attributes." & vbLf & "Otherwise, press Return and the job will be checked using its specific properties: ")
			Dim useAttributesResponse As String = Console.ReadLine()

			' Create list of all jobs submitted by user.
			Dim line As String
			Dim atLeastOne As Boolean = False
			Dim jobList As String = vbLf & vbLf & "All print jobs submitted by the user are listed here:" & vbLf & vbLf
			line = fileOfPrintServers.ReadLine()
			Do While line IsNot Nothing
				Dim myPS As New PrintServer(line, PrintSystemDesiredAccess.AdministrateServer)
				Dim myPrintQueues As PrintQueueCollection = myPS.GetPrintQueues()

				'<SnippetEnumerateJobsInQueues>
				For Each pq As PrintQueue In myPrintQueues
					pq.Refresh()
					Dim jobs As PrintJobInfoCollection = pq.GetPrintJobInfoCollection()
					For Each job As PrintSystemJobInfo In jobs
						' Since the user may not be able to articulate which job is problematic,
						' present information about each job the user has submitted.
						If job.Submitter = userName Then
							atLeastOne = True
							jobList = jobList & vbLf & "Server:" & line
							jobList = jobList & vbLf & vbTab & "Queue:" & pq.Name
							jobList = jobList & vbLf & vbTab & "Location:" & pq.Location
							jobList = jobList & vbLf & vbTab & vbTab & "Job: " & job.JobName & " ID: " & job.JobIdentifier
						End If
					Next job ' end for each print job

				Next pq ' end for each print queue
				'</SnippetEnumerateJobsInQueues>
				line = fileOfPrintServers.ReadLine()
			Loop ' end while list of print servers is not yet exhausted

			fileOfPrintServers.Close()

			If Not atLeastOne Then
				jobList = vbLf & vbLf & "No jobs submitted by " & userName & " were found." & vbLf & vbLf
				Console.WriteLine(jobList)
			Else
				jobList = jobList & vbLf & vbLf & "If multiple jobs are listed, use the information provided" & " above and by the user to identify the job needing diagnosis." & vbLf & vbLf
				Console.WriteLine(jobList)
				'<SnippetIdentifyAndDiagnoseProblematicJob>
				' When the problematic print job has been identified, enter information about it.
				Console.Write(vbLf & "Enter the print server hosting the job (including leading slashes \\): " & vbLf & "(press Return for the current computer \\{0}): ", Environment.MachineName)
				Dim pServer As String = Console.ReadLine()
				If pServer = "" Then
					pServer = "\\" & Environment.MachineName
				End If
				Console.Write(vbLf & "Enter the print queue hosting the job: ")
				Dim pQueue As String = Console.ReadLine()
				Console.Write(vbLf & "Enter the job ID: ")
				Dim jobID As Int16 = Convert.ToInt16(Console.ReadLine())

				' Create objects to represent the server, queue, and print job.
				Dim hostingServer As New PrintServer(pServer, PrintSystemDesiredAccess.AdministrateServer)
				Dim hostingQueue As New PrintQueue(hostingServer, pQueue, PrintSystemDesiredAccess.AdministratePrinter)
				Dim theJob As PrintSystemJobInfo = hostingQueue.GetJob(jobID)

				If useAttributesResponse = "Y" Then
					TroubleSpotter.SpotTroubleUsingJobAttributes(theJob)
					' TroubleSpotter class is defined in the complete example.
				Else
					TroubleSpotter.SpotTroubleUsingProperties(theJob)
				End If

				TroubleSpotter.ReportQueueAndJobAvailability(theJob)
				'</SnippetIdentifyAndDiagnoseProblematicJob>           
			End If ' end else at least one job was submitted by user

			' End the program
			Console.WriteLine(vbLf & "Press Return to end.")
			Console.ReadLine()

		End Sub

	End Class

	Friend Class TroubleSpotter
		' <SnippetSpotTroubleUsingJobProperties>
		' Check for possible trouble states of a print job using its properties
		Friend Shared Sub SpotTroubleUsingProperties(ByVal theJob As PrintSystemJobInfo)
			If theJob.IsBlocked Then
				Console.WriteLine("The job is blocked.")
			End If
			If theJob.IsCompleted OrElse theJob.IsPrinted Then
				Console.WriteLine("The job has finished. Have user recheck all output bins and be sure the correct printer is being checked.")
			End If
			If theJob.IsDeleted OrElse theJob.IsDeleting Then
				Console.WriteLine("The user or someone with administration rights to the queue has deleted the job. It must be resubmitted.")
			End If
			If theJob.IsInError Then
				Console.WriteLine("The job has errored.")
			End If
			If theJob.IsOffline Then
				Console.WriteLine("The printer is offline. Have user put it online with printer front panel.")
			End If
			If theJob.IsPaperOut Then
				Console.WriteLine("The printer is out of paper of the size required by the job. Have user add paper.")
			End If

			If theJob.IsPaused OrElse theJob.HostingPrintQueue.IsPaused Then
				HandlePausedJob(theJob)
				'HandlePausedJob is defined in the complete example.
			End If

			If theJob.IsPrinting Then
				Console.WriteLine("The job is printing now.")
			End If
			If theJob.IsSpooling Then
				Console.WriteLine("The job is spooling now.")
			End If
			If theJob.IsUserInterventionRequired Then
				Console.WriteLine("The printer needs human intervention.")
			End If

		End Sub
		' </SnippetSpotTroubleUsingJobProperties>

		' <SnippetSpotTroubleUsingJobAttributes>
		' Check for possible trouble states of a print job using the flags of the JobStatus property
		Friend Shared Sub SpotTroubleUsingJobAttributes(ByVal theJob As PrintSystemJobInfo)
			If (theJob.JobStatus And PrintJobStatus.Blocked) = PrintJobStatus.Blocked Then
				Console.WriteLine("The job is blocked.")
			End If
			If ((theJob.JobStatus And PrintJobStatus.Completed) = PrintJobStatus.Completed) OrElse ((theJob.JobStatus And PrintJobStatus.Printed) = PrintJobStatus.Printed) Then
				Console.WriteLine("The job has finished. Have user recheck all output bins and be sure the correct printer is being checked.")
			End If
			If ((theJob.JobStatus And PrintJobStatus.Deleted) = PrintJobStatus.Deleted) OrElse ((theJob.JobStatus And PrintJobStatus.Deleting) = PrintJobStatus.Deleting) Then
				Console.WriteLine("The user or someone with administration rights to the queue has deleted the job. It must be resubmitted.")
			End If
			If (theJob.JobStatus And PrintJobStatus.Error) = PrintJobStatus.Error Then
				Console.WriteLine("The job has errored.")
			End If
			If (theJob.JobStatus And PrintJobStatus.Offline) = PrintJobStatus.Offline Then
				Console.WriteLine("The printer is offline. Have user put it online with printer front panel.")
			End If
			If (theJob.JobStatus And PrintJobStatus.PaperOut) = PrintJobStatus.PaperOut Then
				Console.WriteLine("The printer is out of paper of the size required by the job. Have user add paper.")
			End If

			If ((theJob.JobStatus And PrintJobStatus.Paused) = PrintJobStatus.Paused) OrElse ((theJob.HostingPrintQueue.QueueStatus And PrintQueueStatus.Paused) = PrintQueueStatus.Paused) Then
				HandlePausedJob(theJob)
				'HandlePausedJob is defined in the complete example.
			End If

			If (theJob.JobStatus And PrintJobStatus.Printing) = PrintJobStatus.Printing Then
				Console.WriteLine("The job is printing now.")
			End If
			If (theJob.JobStatus And PrintJobStatus.Spooling) = PrintJobStatus.Spooling Then
				Console.WriteLine("The job is spooling now.")
			End If
			If (theJob.JobStatus And PrintJobStatus.UserIntervention) = PrintJobStatus.UserIntervention Then
				Console.WriteLine("The printer needs human intervention.")
			End If

		End Sub
		' </SnippetSpotTroubleUsingJobAttributes>

		'<SnippetHandlePausedJob>
		Friend Shared Sub HandlePausedJob(ByVal theJob As PrintSystemJobInfo)
			' If there's no good reason for the queue to be paused, resume it and 
			' give user choice to resume or cancel the job.
			Console.WriteLine("The user or someone with administrative rights to the queue" & vbLf & "has paused the job or queue." & vbLf & "Resume the queue? (Has no effect if queue is not paused.)" & vbLf & "Enter ""Y"" to resume, otherwise press return: ")
			Dim [resume] As String = Console.ReadLine()
			If [resume] = "Y" Then
				theJob.HostingPrintQueue.Resume()

				' It is possible the job is also paused. Find out how the user wants to handle that.
				Console.WriteLine("Does user want to resume print job or cancel it?" & vbLf & "Enter ""Y"" to resume (any other key cancels the print job): ")
				Dim userDecision As String = Console.ReadLine()
				If userDecision = "Y" Then
					theJob.Resume()
				Else
					theJob.Cancel()
				End If
			End If 'end if the queue should be resumed

		End Sub
		'</SnippetHandlePausedJob>

		'<SnippetReportQueueAndJobAvailability>
		Friend Shared Sub ReportQueueAndJobAvailability(ByVal theJob As PrintSystemJobInfo)
			If Not(ReportAvailabilityAtThisTime(theJob.HostingPrintQueue) AndAlso ReportAvailabilityAtThisTime(theJob)) Then
				If Not ReportAvailabilityAtThisTime(theJob.HostingPrintQueue) Then
					Console.WriteLine(vbLf & "That queue is not available at this time of day." & vbLf & "Jobs in the queue will start printing again at {0}", TimeConverter.ConvertToLocalHumanReadableTime(theJob.HostingPrintQueue.StartTimeOfDay).ToShortTimeString())
					' TimeConverter class is defined in the complete sample
				End If

				If Not ReportAvailabilityAtThisTime(theJob) Then
					Console.WriteLine(vbLf & "That job is set to print only between {0} and {1}", TimeConverter.ConvertToLocalHumanReadableTime(theJob.StartTimeOfDay).ToShortTimeString(), TimeConverter.ConvertToLocalHumanReadableTime(theJob.UntilTimeOfDay).ToShortTimeString())
				End If
				Console.WriteLine(vbLf & "The job will begin printing as soon as it reaches the top of the queue after:")
				If theJob.StartTimeOfDay > theJob.HostingPrintQueue.StartTimeOfDay Then
					Console.WriteLine(TimeConverter.ConvertToLocalHumanReadableTime(theJob.StartTimeOfDay).ToShortTimeString())
				Else
					Console.WriteLine(TimeConverter.ConvertToLocalHumanReadableTime(theJob.HostingPrintQueue.StartTimeOfDay).ToShortTimeString())
				End If

			End If 'end if at least one is not available

		End Sub
		'</SnippetReportQueueAndJobAvailability>

		'<SnippetPrintQueueStartUntil>
		Private Shared Function ReportAvailabilityAtThisTime(ByVal pq As PrintQueue) As Boolean
			Dim available As Boolean = True
			If pq.StartTimeOfDay <> pq.UntilTimeOfDay Then ' If the printer is not available 24 hours a day
				Dim utcNow As Date = Date.UtcNow
				Dim utcNowAsMinutesAfterMidnight As Int32 = (utcNow.TimeOfDay.Hours * 60) + utcNow.TimeOfDay.Minutes

				' If now is not within the range of available times . . .
				If Not((pq.StartTimeOfDay < utcNowAsMinutesAfterMidnight) AndAlso (utcNowAsMinutesAfterMidnight < pq.UntilTimeOfDay)) Then
					available = False
				End If
			End If
			Return available
		End Function 'end ReportAvailabilityAtThisTime
		'</SnippetPrintQueueStartUntil>

		' <SnippetUsingJobStartAndUntilTimes>
		Private Shared Function ReportAvailabilityAtThisTime(ByVal theJob As PrintSystemJobInfo) As Boolean
			Dim available As Boolean = True
			If theJob.StartTimeOfDay <> theJob.UntilTimeOfDay Then ' If the job cannot be printed at all times of day
				Dim utcNow As Date = Date.UtcNow
				Dim utcNowAsMinutesAfterMidnight As Int32 = (utcNow.TimeOfDay.Hours * 60) + utcNow.TimeOfDay.Minutes

				' If "now" is not within the range of available times . . .
				If Not((theJob.StartTimeOfDay < utcNowAsMinutesAfterMidnight) AndAlso (utcNowAsMinutesAfterMidnight < theJob.UntilTimeOfDay)) Then
					available = False
				End If
			End If
			Return available
		End Function 'end ReportAvailabilityAtThisTime
		' </SnippetUsingJobStartAndUntilTimes>

	End Class

	'<SnippetTimeConverter>
	Friend Class TimeConverter
		' Convert time as minutes past UTC midnight into human readable time in local time zone.
		Friend Shared Function ConvertToLocalHumanReadableTime(ByVal timeInMinutesAfterUTCMidnight As Int32) As Date
			' Construct a UTC midnight object.
			' Must start with current date so that the local Daylight Savings system, if any, will be taken into account.
			Dim utcNow As Date = Date.UtcNow
			Dim utcMidnight As New Date(utcNow.Year, utcNow.Month, utcNow.Day, 0, 0, 0, DateTimeKind.Utc)

			' Add the minutes passed into the method in order to get the intended UTC time.
			Dim minutesAfterUTCMidnight As Double = CType(timeInMinutesAfterUTCMidnight, Double)
			Dim utcTime As Date = utcMidnight.AddMinutes(minutesAfterUTCMidnight)

			' Convert to local time.
			Dim localTime As Date = utcTime.ToLocalTime()

			Return localTime

		End Function ' end ConvertToLocalHumanReadableTime

	End Class
	'</SnippetTimeConverter>

End Namespace ' end namespace
