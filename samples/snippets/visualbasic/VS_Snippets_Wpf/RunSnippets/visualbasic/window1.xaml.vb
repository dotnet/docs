Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace RunSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub TextProp()
			' <Snippet_Run_Text>
			Dim textRun As New Run()
			textRun.Text = "The text contents of this text run."
			' </Snippet_Run_Text>
		End Sub

		Private Sub Constructors()
				' <Snippet_Run_Const1>
				Dim textRun As New Run("The text contents of this text run.")
				' </Snippet_Run_Const1>

				' <Snippet_Run_Const2>
				' Create a new, empty paragraph to host the text run.
				Dim par As New Paragraph()

				' Get a TextPointer for the end of content in the paragraph.
				Dim insertionPoint As TextPointer = par.ContentEnd

				' This line will create a new text run, initialize it with the supplied string,
				' and insert it at the specified insertion point (which happens to be the end of
				' content for the host paragraph).
            Dim textRun2 As New Run("The text contents of this text run.", insertionPoint)
				' </Snippet_Run_Const2>

		End Sub
	End Class
End Namespace