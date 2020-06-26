Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Namespace RichTextBoxSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' <Snippet_RTB_StringFromCall>            
			Dim plainText As String = StringFromRichTextBox(richTB)
			' </Snippet_RTB_StringFromCall>            
		End Sub

		Private Sub Constructor()
			' <Snippet_RTB_Constructor>
			' Create a simple FlowDocument to serve as the content input for the construtor.
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("Simple FlowDocument")))
			' After this constructor is called, the new RichTextBox rtb will contain flowDoc.
			Dim rtb As New RichTextBox(flowDoc)
			' </Snippet_RTB_Constructor>
		End Sub

		Private Sub ShowSelection()
			' <Snippet_RTB_Selection>
			' Create a simple FlowDocument to serve as the content input for the construtor.
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("Simple FlowDocument")))
			' After this constructor is called, the new RichTextBox rtb will contain flowDoc.
			Dim rtb As New RichTextBox(flowDoc)
			' This call will select the entire contents of the RichTextBox.
			rtb.SelectAll()
			' This call returns the current selection (which happens to be the entire contents
			' of the RichTextBox) as a TextSelection object.
			Dim currentSelection As TextSelection = rtb.Selection
			' </Snippet_RTB_Selection>
		End Sub

		Private Sub ShowDocument()
			' <Snippet_RTB_Document>
			' Create a simple FlowDocument to serve as content.
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("Simple FlowDocument")))
			' Create an empty, default RichTextBox.
			Dim rtb As New RichTextBox()
			' This call sets the contents of the RichTextBox to the specified FlowDocument.
			rtb.Document = flowDoc
			' This call gets a FlowDocument representing the contents of the RichTextBox.
			Dim rtbContents As FlowDocument = rtb.Document
			' </Snippet_RTB_Document>
		End Sub

		Private Sub ShowCaretPosition()
			' <Snippet_RTB_CaretPosition>

			' Create a new FlowDocument, and add 3 paragraphs.
			Dim flowDoc As New FlowDocument()
			flowDoc.Blocks.Add(New Paragraph(New Run("Paragraph 1")))
			flowDoc.Blocks.Add(New Paragraph(New Run("Paragraph 2")))
			flowDoc.Blocks.Add(New Paragraph(New Run("Paragraph 3")))
			' Set the FlowDocument to be the content for a new RichTextBox.
			Dim rtb As New RichTextBox(flowDoc)

			' Get the current caret position.
			Dim caretPos As TextPointer = rtb.CaretPosition

			' Set the TextPointer to the end of the current document.
			caretPos = caretPos.DocumentEnd

			' Specify the new caret position at the end of the current document.
			rtb.CaretPosition = caretPos
			' </Snippet_RTB_CaretPosition>            
		End Sub

		' <Snippet_RTB_StringFrom>            
		Private Function StringFromRichTextBox(ByVal rtb As RichTextBox) As String
				' TextPointer to the start of content in the RichTextBox.
				' TextPointer to the end of content in the RichTextBox.
			Dim textRange As New TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd)

			' The Text property on a TextRange object returns a string
			' representing the plain text content of the TextRange.
			Return textRange.Text
		End Function
		' </Snippet_RTB_StringFrom>  

		' <Snippet_TextBox_MouseUpDownHandlers>
		Private Sub MouseUpHandler(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' This method is called whenever the PreviewMouseUp event fires.
		End Sub

		Private Sub MouseDownHandler(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' This method is called whenever the PreviewMouseDown event fires.
		End Sub
		' </Snippet_TextBox_MouseUpDownHandlers>

		Private Sub AttacheHandlers()
			' <Snippet_TextBox_MouseUpDown>
			Dim textBox As New TextBox()
			AddHandler textBox.PreviewMouseUp, AddressOf MouseUpHandler
			AddHandler textBox.PreviewMouseDown, AddressOf MouseDownHandler
			' Note: Event listeners can also be added using the AddHandler
			' method.
			' </Snippet_TextBox_MouseUpDown>

			' <Snippet_RichTextBox_MouseUpDown>
			Dim richTextBox As New RichTextBox()
			AddHandler richTextBox.PreviewMouseUp, AddressOf MouseUpHandler
			AddHandler richTextBox.PreviewMouseDown, AddressOf MouseDownHandler
			' Note: Event listeners can also be added using the AddHandler
			' method.
			' </Snippet_RichTextBox_MouseUpDown>

			' <Snippet_PasswordBox_MouseUpDown>
			Dim pwBox As New PasswordBox()
			AddHandler pwBox.PreviewMouseUp, AddressOf MouseUpHandler
			AddHandler pwBox.PreviewMouseDown, AddressOf MouseDownHandler
			' </Snippet_PasswordBox_MouseUpDown>
		End Sub

		Private Sub InvokeEditingCommands()
			' <Snippet_EditingCommands_Invoke>
			Dim rTB As New RichTextBox()

			EditingCommands.ToggleInsert.Execute(Nothing, rTB)
			' </Snippet_EditingCommands_Invoke>
		End Sub
	End Class
End Namespace
