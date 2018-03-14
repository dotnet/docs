' <SnippetSaveLoadPrintRTBCodeExampleWholePage>

Imports System
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Media

Namespace SDKSample

	Partial Public Class SaveLoadPrintRTB
		Inherits Page

		' Handle "Save RichTextBox Content" button click.
		Private Sub SaveRTBContent(ByVal sender As Object, ByVal args As RoutedEventArgs)

			' Send an arbitrary URL and file name string specifying
			' the location to save the XAML in.
			SaveXamlPackage("C:\test.xaml")
		End Sub

		' Handle "Load RichTextBox Content" button click.
		Private Sub LoadRTBContent(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' Send URL string specifying what file to retrieve XAML
			' from to load into the RichTextBox.
			LoadXamlPackage("C:\test.xaml")
		End Sub

		' Handle "Print RichTextBox Content" button click.
		Private Sub PrintRTBContent(ByVal sender As Object, ByVal args As RoutedEventArgs)
			PrintCommand()
		End Sub

		' Save XAML in RichTextBox to a file specified by _fileName
		Private Sub SaveXamlPackage(ByVal _fileName As String)
			Dim range As TextRange
			Dim fStream As FileStream
			range = New TextRange(richTB.Document.ContentStart, richTB.Document.ContentEnd)
			fStream = New FileStream(_fileName, FileMode.Create)
			range.Save(fStream, DataFormats.XamlPackage)
			fStream.Close()
		End Sub

		' Load XAML into RichTextBox from a file specified by _fileName
		Private Sub LoadXamlPackage(ByVal _fileName As String)
			Dim range As TextRange
			Dim fStream As FileStream
			If File.Exists(_fileName) Then
				range = New TextRange(richTB.Document.ContentStart, richTB.Document.ContentEnd)
				fStream = New FileStream(_fileName, FileMode.OpenOrCreate)
				range.Load(fStream, DataFormats.XamlPackage)
				fStream.Close()
			End If
		End Sub

		' Print RichTextBox content
		Private Sub PrintCommand()
			Dim pd As New PrintDialog()
			If (pd.ShowDialog() = True) Then
				'use either one of the below      
				pd.PrintVisual(TryCast(richTB, Visual), "printing as visual")
				pd.PrintDocument(((CType(richTB.Document, IDocumentPaginatorSource)).DocumentPaginator), "printing as paginator")
			End If
		End Sub
	End Class
End Namespace
' </SnippetSaveLoadPrintRTBCodeExampleWholePage>