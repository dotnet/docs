Namespace HyperlinkSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			Constructors()
		End Sub

        Private Sub Constructors()
            With True
                ' <Snippet_Hyperlink_Const1>
                ' A child Inline element for the new Hyperlink element.
                Dim runx As New Run("Link text for the Hyperlink element.")

                ' After this line executes, the new element "hyper1"
                ' contains the specified Inline element, "runx".
                Dim hyperl As New Hyperlink(runx)
                ' </Snippet_Hyperlink_Const1>
            End With

            With True
                ' <Snippet_Hyperlink_Const2>
                ' A child Inline element for the new Hyperlink element.
                Dim runx As New Run("Link text for the Hyperlink element.")

                ' An empty paragraph will serve as the container for the new Hyperlink element.
                Dim parx As New Paragraph()

                ' After this line executes, the new element "hyperl"
                ' contains the specified Inline element, "runx".  Also, "hyperl" is
                ' inserted at the point indicated by the insertionPosition parameter, 
                ' which in this case indicates the content start position in the Paragraph 
                ' element "parx".
                Dim hyperl As New Hyperlink(runx, parx.ContentStart)
                ' </Snippet_Hyperlink_Const2>
            End With
            With True
                ' <Snippet_Hyperlink_Const3>
                ' Create a paragraph and three text runs to serve as example content.  
                Dim parx As New Paragraph()
                Dim run1 As New Run("Text run 1.")
                Dim run2 As New Run("Text to link.")
                Dim run3 As New Run("Text run 3.")

                ' Add the three text runs to the paragraph, separated by linebreaks.
                parx.Inlines.Add(run1)
                parx.Inlines.Add(New LineBreak())
                parx.Inlines.Add(run2)
                parx.Inlines.Add(New LineBreak())
                parx.Inlines.Add(run3)

                ' After this line executes, the selection of content
                ' indicated by the "start" and "end" parameters will be
                ' enclosed by the new Hyperlink.  In this case, the new Hyperlink
                ' will enclose the entire contents of the the text run "run2".  
                Dim hyperl As New Hyperlink(run2.ContentStart, run2.ContentEnd)
                ' </Snippet_Hyperlink_Const3>

                flowDoc.Blocks.Add(parx)
            End With



        End Sub

		Private Sub Props()
			' <Snippet_Hyperlink_NavUri>
			Dim parx As New Paragraph()
			Dim run1 As New Run("Text preceeding the hyperlink.")
			Dim run2 As New Run("Text following the hyperlink.")
			Dim run3 As New Run("Link Text.")

			Dim hyperl As New Hyperlink(run3)
			hyperl.NavigateUri = New Uri("http://search.msn.com")

			parx.Inlines.Add(run1)
			parx.Inlines.Add(hyperl)
			parx.Inlines.Add(run2)
			' </Snippet_Hyperlink_NavUri>
		End Sub
	End Class
End Namespace
