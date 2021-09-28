Imports System.Collections.Generic
Imports System.Text
Imports System.Printing
Imports System.Printing.IndexedProperties

Namespace ClonePrinter
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
				'<SnippetClonePrinter>
				Dim myLocalPrintServer As New LocalPrintServer(PrintSystemDesiredAccess.AdministrateServer)
				Dim sourcePrintQueue As PrintQueue = myLocalPrintServer.DefaultPrintQueue
				Dim myPrintProperties As PrintPropertyDictionary = sourcePrintQueue.PropertiesCollection

				' Share the new printer using Remove/Add methods
				Dim [shared] As New PrintBooleanProperty("IsShared", True)
				myPrintProperties.Remove("IsShared")
				myPrintProperties.Add("IsShared", [shared])

				' Give the new printer its share name using SetProperty method
				Dim theShareName As New PrintStringProperty("ShareName", """Son of " & sourcePrintQueue.Name & """")
				myPrintProperties.SetProperty("ShareName", theShareName)

				' Specify the physical location of the new printer using Remove/Add methods
				Dim theLocation As New PrintStringProperty("Location", "the supply room")
				myPrintProperties.Remove("Location")
				myPrintProperties.Add("Location", theLocation)

				' Specify the port for the new printer
				Dim port() As String = { "COM1:" }


				' Install the new printer on the local print server
				Dim clonedPrinter As PrintQueue = myLocalPrintServer.InstallPrintQueue("My clone of " & sourcePrintQueue.Name, "Xerox WCP 35 PS", port, "WinPrint", myPrintProperties)
				myLocalPrintServer.Commit()

				' Report outcome
				Console.WriteLine("{0} in {1} has been installed and shared as {2}", clonedPrinter.Name, clonedPrinter.Location, clonedPrinter.ShareName)
				Console.WriteLine("Press Return to continue ...")
				Console.ReadLine()
				'</SnippetClonePrinter>

		End Sub
	End Class
End Namespace
