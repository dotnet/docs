Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Printing
Imports System.Windows.Xps
Imports System.Windows.Xps.Packaging
Imports System.IO



Namespace PrintDialog_Sample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
	' <Snippet1>
		Private Sub InvokePrint(ByVal sender As Object, ByVal e As RoutedEventArgs)
				' Create the print dialog object and set options
				Dim pDialog As New PrintDialog()
				pDialog.PageRangeSelection = PageRangeSelection.AllPages
				pDialog.UserPageRangeEnabled = True

				' Display the dialog. This returns true if the user presses the Print button.
				Dim print? As Boolean = pDialog.ShowDialog()
				If print = True Then
					Dim xpsDocument As New XpsDocument("C:\FixedDocumentSequence.xps", FileAccess.ReadWrite)
					Dim fixedDocSeq As FixedDocumentSequence = xpsDocument.GetFixedDocumentSequence()
					pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job")
				End If
		End Sub
	' </Snippet1>
		' <Snippet5>
		Private Sub GetHeight(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim pDialog As New PrintDialog()
			Dim pt As PrintTicket = pDialog.PrintTicket 'force initialization of the dialog's PrintTicket or PrintQueue
			txt1.Text = pDialog.PrintableAreaHeight.ToString() & " is the printable height"
		End Sub
		' </Snippet5>
		' <Snippet6>
		Private Sub GetWidth(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim pDialog As New PrintDialog()
			Dim pq As PrintQueue = pDialog.PrintQueue 'force initialization of the dialog's PrintTicket or PrintQueue
			txt2.Text = pDialog.PrintableAreaWidth.ToString() & " is the printable width"
		End Sub
		' </Snippet6>
	End Class


End Namespace