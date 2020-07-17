Imports System.Collections.Generic
Imports System.Text
Imports System.Printing
Imports System.IO
Imports System.Threading


Namespace BatchPrintXPSFiles
	'<SnippetBatchPrintXPSFiles>
	Friend Class Program
		<System.MTAThreadAttribute()>
		Shared Sub Main(ByVal args() As String) ' Added for clarity, but this line is redundant because MTA is the default.
			' Create the secondary thread and pass the printing method for 
			' the constructor's ThreadStart delegate parameter. The BatchXPSPrinter
			' class is defined below.
            Dim printingThread As New Thread(AddressOf BatchXPSPrinter.PrintXPS)

			' Set the thread that will use PrintQueue.AddJob to single threading.
			printingThread.SetApartmentState(ApartmentState.STA)

			' Start the printing thread. The method passed to the Thread 
			' constructor will execute.
			printingThread.Start()

		End Sub

	End Class

	Public Class BatchXPSPrinter
		Public Shared Sub PrintXPS()
			' Create print server and print queue.
			Dim localPrintServer As New LocalPrintServer()
			Dim defaultPrintQueue As PrintQueue = LocalPrintServer.GetDefaultPrintQueue()

			' Prompt user to identify the directory, and then create the directory object.
			Console.Write("Enter the directory containing the XPS files: ")
			Dim directoryPath As String = Console.ReadLine()
			Dim dir As New DirectoryInfo(directoryPath)

			' If the user mistyped, end the thread and return to the Main thread.
			If Not dir.Exists Then
				Console.WriteLine("There is no such directory.")
			Else
				' If there are no XPS files in the directory, end the thread 
				' and return to the Main thread.
				If dir.GetFiles("*.xps").Length = 0 Then
					Console.WriteLine("There are no XPS files in the directory.")
				Else
					Console.WriteLine(vbLf & "Jobs will now be added to the print queue.")
					Console.WriteLine("If the queue is not paused and the printer is working, jobs will begin printing.")

					' Batch process all XPS files in the directory.
					For Each f As FileInfo In dir.GetFiles("*.xps")
						Dim nextFile As String = directoryPath & "\" & f.Name
						Console.WriteLine("Adding {0} to queue.", nextFile)

						Try
							' Print the Xps file while providing XPS validation and progress notifications.
							Dim xpsPrintJob As PrintSystemJobInfo = defaultPrintQueue.AddJob(f.Name, nextFile, False)
						Catch e As PrintJobException
							Console.WriteLine(vbLf & vbTab & "{0} could not be added to the print queue.", f.Name)
							If e.InnerException.Message = "File contains corrupted data." Then
								Console.WriteLine(vbTab & "It is not a valid XPS file. Use the isXPS Conformance Tool to debug it.")
							End If
							Console.WriteLine(vbTab & "Continuing with next XPS file." & vbLf)
						End Try

					Next f ' end for each XPS file

				End If 'end if there are no XPS files in the directory

			End If 'end if the directory does not exist

			Console.WriteLine("Press Enter to end program.")
			Console.ReadLine()

		End Sub

	End Class
	'</SnippetBatchPrintXPSFiles>
End Namespace ' end namespace
