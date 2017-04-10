Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace SpanSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			Dim spanx As New Span()
			Constructors()
			BoldConstructors()
			ItalicConstructors()
			UnderlineConstructors()
			UIContConstructors()
			ParagraphConst()

			TextProp()
		End Sub

		Private Sub Constructors()
            ' <Snippet_Span_Const1>
            ' A child Inline element for the new Span element.
            Dim runx1 As New Run("The Run element derives from Inline, and is therefore" & "an acceptable child element for this new Span.")

            ' After this line executes, the new element "spanx"
            ' contains the specified Inline element, "runx".
            Dim spanx1 As New Span(runx1)
            ' </Snippet_Span_Const1>

            ' <Snippet_Span_Const2>
            ' A child Inline element for the new Span element.
            Dim runx2 As New Run("The Run element derives from Inline, and is therefore" & "an acceptable child element for this new Span.")

            ' An empty paragraph will serve as the container for the new Span element.
            Dim parx2 As New Paragraph()

            ' After this line executes, the new element "spanx"
            ' contains the specified Inline element, "runx".  Also, "spanx" is
            ' inserted at the point indicated by the insertionPosition parameter, 
            ' which in this case indicates the content start position in the Paragraph 
            ' element "parx".
            Dim spanx2 As New Span(runx2, parx2.ContentStart)
            ' </Snippet_Span_Const2>

            ' <Snippet_Span_Const3>
            ' Create a paragraph and three text runs to serve as example content.  
            Dim parx3 As New Paragraph()
            Dim run1 As New Run("Text run 1.")
            Dim run2 As New Run("Text run 2.")
            Dim run3 As New Run("Text run 3.")

            ' Add the three text runs to the paragraph, separated by linebreaks.
            parx3.Inlines.Add(run1)
            parx3.Inlines.Add(New LineBreak())
            parx3.Inlines.Add(run2)
            parx3.Inlines.Add(New LineBreak())
            parx3.Inlines.Add(run3)

            ' After this line executes, the selection of content
            ' indicated by the "start" and "end" parameters will be
            ' enclosed by the new Span.  In this case, the new Span
            ' will enclose the entire contents of the Paragraph "parx",
            ' which happens to contain three text runs and two linebreaks.               
            Dim spanx As New Span(parx3.ContentStart, parx3.ContentEnd)

            ' Now, properties set on "spanx" will override default properties
            ' on elements contained by "spanx".  For example, setting 
            ' these arbitrary display properties on "spanx" will affect
            ' the child text runs enclosed by "spanx".
            spanx.Foreground = Brushes.Blue
            spanx.Background = Brushes.GhostWhite
            spanx.FontFamily = New FontFamily("Century Gothic")

            ' Non-default property values override any settings on the 
            ' enclosing Span element.
            run2.Foreground = Brushes.Red
            run2.Background = Brushes.AntiqueWhite
            run2.FontFamily = New FontFamily("Lucida Handwriting")
            ' </Snippet_Span_Const3>

            flowDoc.Blocks.Add(parx3)

            ' <Snippet_Section_Const1>
            ' A child Block element for the new Section element.
            Dim parx As New Paragraph(New Run("A bit of text content..."))

            ' After this line executes, the new element "secx"
            ' contains the specified Block element, "parx".
            Dim secx As New Section(parx)
            ' </Snippet_Section_Const1>
		End Sub

		Private Sub InlinesProp()
			' Append an Inline element (Run) to the contents of a Span.
			' <Snippet_SpanInlinesAdd>
			Dim spanx As New Span()
			spanx.Inlines.Add(New Run("A bit of text content..."))
			spanx.Inlines.Add(New Run("A bit more text content..."))
			' </Snippet_SpanInlinesAdd>

			' Insert a content inline at the begining of the Span.
			' <Snippet_SpanInlinesInsert>
			Dim runx As New Run("Text to insert...")
			spanx.Inlines.InsertBefore(spanx.Inlines.FirstInline, runx)
			' </Snippet_SpanInlinesInsert>

			' Get the number of top-level Inline elements in the Span.
			' <Snippet_SpanInlinesCount>
			Dim countTopLevelInlines As Integer = spanx.Inlines.Count
			' </Snippet_SpanInlinesCount>

			' Remove the last inline in the Span.
			' <Snippet_SpanInlinesRemoveLast>
			spanx.Inlines.Remove(spanx.Inlines.LastInline)
			' </Snippet_SpanInlinesRemoveLast>

			' Clear all of the inlines (contents) of the Span.
			' <Snippet_SpanInlinesClear>
			spanx.Inlines.Clear()
			' </Snippet_SpanInlinesClear>
		End Sub

		Private Sub TextProp()
			' <Snippet_Span_Text>
			Dim spanx As New Span()
			spanx.Inlines.Add(New Run("The text contents of this Span."))
			' </Snippet_Span_Text>

			' <Snippet_Paragraph_Text>
			Dim parx As New Paragraph()
			parx.Inlines.Add(New Run("The text contents of this Paragraph."))
			' </Snippet_Paragraph_Text>

			' <Snippet_TextBlock_Text>
			Dim textBlock As New TextBlock()
			textBlock.Text = "The text contents of this TextBlock."
			' </Snippet_TextBlock_Text>
		End Sub


		Private Sub BoldConstructors()
            ' <Snippet_Bold_Const1>
            ' A child Inline element for the new Bold element.
            Dim runx1 As New Run("Text to make bold.")

            ' After this line executes, the new element "boldx"
            ' contains the specified Inline element, "runx".
            Dim boldx1 As New Bold(runx1)
            ' </Snippet_Bold_Const1>

            ' <Snippet_Bold_Const2>
            ' A child Inline element for the new Bold element.
            Dim runx2 As New Run("Text to make bold.")

            ' An empty paragraph will serve as the container for the new Bold element.
            Dim parx2 As New Paragraph()

            ' After this line executes, the new element "boldx"
            ' contains the specified Inline element, "runx".  Also, "boldx" is
            ' inserted at the point indicated by the insertionPosition parameter, 
            ' which in this case indicates the content start position in the Paragraph 
            ' element "parx".
            Dim boldx2 As New Bold(runx2, parx2.ContentStart)
            ' </Snippet_Bold_Const2>

            ' <Snippet_Bold_Const3>
            ' Create a paragraph and three text runs to serve as example content.  
            Dim parx As New Paragraph()
            Dim run1 As New Run("Text run 1.")
            Dim run2 As New Run("Text run 2, make bold.")
            Dim run3 As New Run("Text run 3.")

            ' Add the three text runs to the paragraph, separated by linebreaks.
            parx.Inlines.Add(run1)
            parx.Inlines.Add(New LineBreak())
            parx.Inlines.Add(run2)
            parx.Inlines.Add(New LineBreak())
            parx.Inlines.Add(run3)

            ' After this line executes, the selection of content
            ' indicated by the "start" and "end" parameters will be
            ' enclosed by the new Bold.  In this case, the new Bold
            ' will enclose the second text run, "run2".
            Dim boldx3 As New Bold(run2.ContentStart, run2.ContentEnd)
            ' </Snippet_Bold_Const3>
		End Sub

		Private Sub ItalicConstructors()
            ' <Snippet_Italic_Const1>
            ' A child Inline element for the new Italic element.
            Dim runx1 As New Run("Text to make italic.")

            ' After this line executes, the new element "italx"
            ' contains the specified Inline element, "runx".
            Dim italx1 As New Italic(runx1)
            ' </Snippet_Italic_Const1>

            ' <Snippet_Italic_Const2>
            ' A child Inline element for the new Italic element.
            Dim runx2 As New Run("Text to make italic.")

            ' An empty paragraph will serve as the container for the new Italic element.
            Dim parx2 As New Paragraph()

            ' After this line executes, the new element "italx"
            ' contains the specified Inline element, "runx".  Also, "italx" is
            ' inserted at the point indicated by the insertionPosition parameter, 
            ' which in this case indicates the content start position in the Paragraph 
            ' element "parx".
            Dim italx2 As New Italic(runx2, parx2.ContentStart)
            ' </Snippet_Italic_Const2>

            ' <Snippet_Italic_Const3>
            ' Create a paragraph and three text runs to serve as example content.  
            Dim parx As New Paragraph()
            Dim run1 As New Run("Text run 1.")
            Dim run2 As New Run("Text run 2, make italic.")
            Dim run3 As New Run("Text run 3.")

            ' Add the three text runs to the paragraph, separated by linebreaks.
            parx.Inlines.Add(run1)
            parx.Inlines.Add(New LineBreak())
            parx.Inlines.Add(run2)
            parx.Inlines.Add(New LineBreak())
            parx.Inlines.Add(run3)

            ' After this line executes, the selection of content
            ' indicated by the "start" and "end" parameters will be
            ' enclosed by the new Italic.  In this case, the new Italic
            ' will enclose the second text run, "run2".
            Dim italx3 As New Italic(run2.ContentStart, run2.ContentEnd)
            ' </Snippet_Italic_Const3>
		End Sub

		Private Sub UnderlineConstructors()
            ' <Snippet_Underline_Const1>
            ' A child Inline element for the new Underline element.
            Dim runx1 As New Run("Text to make underlined.")

            ' After this line executes, the new element "underx"
            ' contains the specified Inline element, "runx".
            Dim underx1 As New Underline(runx1)
            ' </Snippet_Underline_Const1>

            ' <Snippet_Underline_Const2>
            ' A child Inline element for the new Underline element.
            Dim runx2 As New Run("Text to make underlined.")

            ' An empty paragraph will serve as the container for the new Underline element.
            Dim parx2 As New Paragraph()

            ' After this line executes, the new element "underx"
            ' contains the specified Inline element, "runx".  Also, "underx" is
            ' inserted at the point indicated by the insertionPosition parameter, 
            ' which in this case indicates the content start position in the Paragraph 
            ' element "parx".
            Dim underx2 As New Underline(runx2, parx2.ContentStart)
            ' </Snippet_Underline_Const2>

            ' <Snippet_Underline_Const3>
            ' Create a paragraph and three text runs to serve as example content.  
            Dim parx As New Paragraph()
            Dim run1 As New Run("Text run 1.")
            Dim run2 As New Run("Text run 2, make underlined.")
            Dim run3 As New Run("Text run 3.")

            ' Add the three text runs to the paragraph, separated by linebreaks.
            parx.Inlines.Add(run1)
            parx.Inlines.Add(New LineBreak())
            parx.Inlines.Add(run2)
            parx.Inlines.Add(New LineBreak())
            parx.Inlines.Add(run3)

            ' After this line executes, the selection of content
            ' indicated by the "start" and "end" parameters will be
            ' enclosed by the new Underline.  In this case, the new Underline
            ' will enclose the second text run, "run2".
            Dim underx As New Underline(run2.ContentStart, run2.ContentEnd)
            ' </Snippet_Underline_Const3>
		End Sub

		Private Sub InlineUI()
            ' <Snippet_InlineUI_Child>
            Dim parx As New Paragraph()
            Dim run1 As New Run(" Text to precede the button... ")
            Dim run2 As New Run(" Text to follow the button... ")

            ' Create a new button to be hosted in the paragraph.
            Dim buttonx As New Button()
            buttonx.Content = "Click me!"

            ' Create a new InlineUIContainer, and assign the button 
            ' as the UI container's child.
            Dim uiCont As New InlineUIContainer()
            uiCont.Child = buttonx

            ' Add the text runs and UI container to the paragraph, in order.
            parx.Inlines.Add(run1)
            parx.Inlines.Add(uiCont)
            parx.Inlines.Add(run2)
            ' </Snippet_InlineUI_Child>

            ' <Snippet_BlockUI_Child>
            Dim secx As New Section()
            Dim par1 As New Paragraph(New Run(" Text to precede the button... "))
            Dim par2 As New Paragraph(New Run(" Text to follow the button... "))

            ' Create a new button to be hosted in the section.
            Dim buttonx2 As New Button()
            buttonx2.Content = "Click me!"

            ' Create a new BlockUIContainer, and assign the button 
            ' as the UI container's child.
            Dim uiCont2 As New BlockUIContainer()
            uiCont2.Child = buttonx2

            ' Add the text runs and UI container to the paragraph, in order.
            secx.Blocks.Add(par1)
            secx.Blocks.Add(uiCont2)
            secx.Blocks.Add(par2)
            ' </Snippet_BlockUI_Child>
		End Sub

		Private Sub UIContConstructors()
            ' <Snippet_InlineUI_Const1>
            ' A child UIElement element for the new InlineUIContainer element.
            Dim buttonx1 As New Button()
            buttonx1.Content = "Click me!"

            ' After this line executes, the new element "inlineUI"
            ' contains the specified Inline element, "runx".
            Dim inlineUI As New InlineUIContainer(buttonx1)
            ' </Snippet_InlineUI_Const1>

            ' <Snippet_InlineUI_Const2>
            ' A child UIElement element for the new InlineUIContainer element.
            Dim buttonx2 As New Button()
            buttonx2.Content = "Click me!"

            ' An empty paragraph will serve as the container for the new InlineUIContainer element.
            Dim parx As New Paragraph()

            ' After this line executes, the new element "inlineUI"
            ' contains the specified UIElement element, "buttonx".  Also, "inlineUI" is
            ' inserted at the point indicated by the insertionPosition parameter, 
            ' which in this case indicates the content start position in the Paragraph 
            ' element "parx".
            Dim inlineUI2 As New InlineUIContainer(buttonx2, parx.ContentStart)
            ' </Snippet_InlineUI_Const2>

            ' <Snippet_BlockUI_Const1>
            ' A child UIElement element for the new BlockUIContainer element.
            Dim buttonx3 As New Button()
            buttonx3.Content = "Click me!"

            ' After this line executes, the new element "inlineUI"
            ' contains the specified Inline element, "runx".
            Dim blockUI As New BlockUIContainer(buttonx3)
            ' </Snippet_BlockUI_Const1>

		End Sub
		Private Sub ParagraphConst()
			' <Snippet_Paragraph_Const1>
			' A child Inline element for the new Paragraph element.
			Dim runx As New Run("Text to be hosted in the new paragraph...")

			' After this line executes, the new element "parx"
			' contains the specified Inline element, "runx".
			Dim parx As New Paragraph(runx)
			' </Snippet_Paragraph_Const1>
		End Sub
	End Class
End Namespace