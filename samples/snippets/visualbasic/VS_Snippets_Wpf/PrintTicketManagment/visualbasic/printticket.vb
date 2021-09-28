'
' * Copyright (c) 1990 - 2005  Microsoft Corporation.
' * All Rights Reserved.
' *
' * This sample application shows how to use the .Net 3.0 API to query printer's PrintCapabilities
' * and to change printer's user-default PrintTicket setting.
' 


Imports System.Printing

Namespace PrintTicketSample
	Friend Class Application
		'<SnippetUsingMergeAndValidate>
		''' <summary>
		''' Changes the user-default PrintTicket setting of the specified print queue.
		''' </summary>
		''' <param name="queue">the printer whose user-default PrintTicket setting needs to be changed</param>
		Private Shared Sub ChangePrintTicketSetting(ByVal queue As PrintQueue)
			'
			' Obtain the printer's PrintCapabilities so we can determine whether or not
			' duplexing printing is supported by the printer.
			'
			Dim printcap As PrintCapabilities = queue.GetPrintCapabilities()

			'
			' The printer's duplexing capability is returned as a read-only collection of duplexing options
			' that can be supported by the printer. If the collection returned contains the duplexing
			' option we want to set, it means the duplexing option we want to set is supported by the printer,
			' so we can make the user-default PrintTicket setting change.
			'
			If printcap.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge) Then
				'
				' To change the user-default PrintTicket, we can first create a delta PrintTicket with
				' the new duplexing setting.
				'
				Dim deltaTicket As New PrintTicket()
				deltaTicket.Duplexing = Duplexing.TwoSidedLongEdge

				'
				' Then merge the delta PrintTicket onto the printer's current user-default PrintTicket,
				' and validate the merged PrintTicket to get the new PrintTicket we want to set as the
				' printer's new user-default PrintTicket.
				'
				Dim result As ValidationResult = queue.MergeAndValidatePrintTicket(queue.UserPrintTicket, deltaTicket)

				'
				' The duplexing option we want to set could be constrained by other PrintTicket settings
				' or device settings. We can check the validated merged PrintTicket to see whether the
				' the validation process has kept the duplexing option we want to set unchanged.
				'
				If result.ValidatedPrintTicket.Duplexing = Duplexing.TwoSidedLongEdge Then
					'
					' Set the printer's user-default PrintTicket and commit the set operation.
					'
					queue.UserPrintTicket = result.ValidatedPrintTicket
					queue.Commit()
					Console.WriteLine("PrintTicket new duplexing setting is set on '{0}'.", queue.FullName)
				Else
					'
					' The duplexing option we want to set has been changed by the validation process
					' when it was resolving setting constraints.
					'
					Console.WriteLine("PrintTicket new duplexing setting is constrained on '{0}'.", queue.FullName)
				End If
			Else
				'
				' If the printer doesn't support the duplexing option we want to set, skip it.
				'
				Console.WriteLine("PrintTicket new duplexing setting is not supported on '{0}'.", queue.FullName)
			End If
		End Sub
		'</SnippetUsingMergeAndValidate>

		'<SnippetUIForMergeAndValidatePTUtility>
		''' <summary>
		''' Displays the correct command line syntax to run this sample program.
		''' </summary>
		Private Shared Sub DisplayUsage()
			Console.WriteLine()
			Console.WriteLine("Usage #1: printticket.exe -l ""<printer_name>""")
			Console.WriteLine("      Run program on the specified local printer")
			Console.WriteLine()
			Console.WriteLine("      Quotation marks may be omitted if there are no spaces in printer_name.")
			Console.WriteLine()
			Console.WriteLine("Usage #2: printticket.exe -r ""\\<server_name>\<printer_name>""")
			Console.WriteLine("      Run program on the specified network printer")
			Console.WriteLine()
			Console.WriteLine("      Quotation marks may be omitted if there are no spaces in server_name or printer_name.")
			Console.WriteLine()
			Console.WriteLine("Usage #3: printticket.exe -a")
			Console.WriteLine("      Run program on all installed printers")
			Console.WriteLine()
		End Sub


		<STAThread>
		Public Shared Sub Main(ByVal args() As String)
			Try
				If (args.Length = 1) AndAlso (args(0) = "-a") Then
					'
					' Change PrintTicket setting for all local and network printer connections.
					'
					Dim server As New LocalPrintServer()

					Dim queue_types() As EnumeratedPrintQueueTypes = {EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections}

					'
					' Enumerate through all the printers.
					'
					For Each queue As PrintQueue In server.GetPrintQueues(queue_types)
						'
						' Change the PrintTicket setting queue by queue.
						'
						ChangePrintTicketSetting(queue)
					Next queue 'end if -a

				ElseIf (args.Length = 2) AndAlso (args(0) = "-l") Then
					'
					' Change PrintTicket setting only for the specified local printer.
					'
					Dim server As New LocalPrintServer()
					Dim queue As New PrintQueue(server, args(1))
					ChangePrintTicketSetting(queue) 'end if -l

				ElseIf (args.Length = 2) AndAlso (args(0) = "-r") Then
					'
					' Change PrintTicket setting only for the specified remote printer.
					'
					Dim serverName As String = args(1).Remove(args(1).LastIndexOf("\"))
					Dim printerName As String = args(1).Remove(0, args(1).LastIndexOf("\")+1)
					Dim ps As New PrintServer(serverName)
					Dim queue As New PrintQueue(ps, printerName)
					ChangePrintTicketSetting(queue) 'end if -r

				Else
					'
					' Unrecognized command line.
					' Show user the correct command line syntax to run this sample program.
					'
					DisplayUsage()
				End If
			Catch e As Exception
				Console.WriteLine(e.Message)
				Console.WriteLine(e.StackTrace)

				'
				' Show inner exception information if it's provided.
				'
				If e.InnerException IsNot Nothing Then
					Console.WriteLine("--- Inner Exception ---")
					Console.WriteLine(e.InnerException.Message)
					Console.WriteLine(e.InnerException.StackTrace)
				End If
			Finally
				Console.WriteLine("Press Return to continue...")
				Console.ReadLine()
			End Try
		End Sub
		'</SnippetUIForMergeAndValidatePTUtility>

	End Class
End Namespace 'end namespace