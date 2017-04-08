Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

Namespace FloaterFigureSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal ags As RoutedEventArgs)
			Consts()
			FigureProps()
			FloaterProps()
		End Sub

		Private Sub Consts()
				' <Snippet_FigureConst1>
            Dim parx1 As New Paragraph(New Run("Figure content..."))
            Dim figx1 As New Figure(parx1)
				' </Snippet_FigureConst1>

				' <Snippet_FigureConst2>
            Dim spanx2 As New Span()
            Dim parx2 As New Paragraph(New Run("Figure content..."))
				' This will populate the Figure with the Paragraph parx, and insert
				' the Figure at the beginning of the Span spanx.
            Dim figx2 As New Figure(parx2, spanx2.ContentStart)
				' </Snippet_FigureConst2>

				' <Snippet_FloaterConst1>
            Dim parx3 As New Paragraph(New Run("Floater content..."))
            Dim flotx3 As New Floater(parx3)
				' </Snippet_FloaterConst1>

				' <Snippet_FloaterConst2>
            Dim spanx4 As New Span()
            Dim parx4 As New Paragraph(New Run("Floater content..."))

				' This will populate the Floater with the Paragraph parx, and insert
				' the Floater at the beginning of the Span spanx.
            Dim flotx4 As New Floater(parx4, spanx4.ContentStart)
				' </Snippet_FloaterConst2>
		End Sub

		Private Sub FigureProps()
			' <Snippet_FigureProps>
            Dim figx As New Figure()
            With figx
                .Name = "myFigure"
                .Width = New FigureLength(140)
                .Height = New FigureLength(50)
                .HorizontalAnchor = FigureHorizontalAnchor.PageCenter
                .VerticalAnchor = FigureVerticalAnchor.PageCenter
                .HorizontalOffset = 100
                .VerticalOffset = 20
                .WrapDirection = WrapDirection.Both
            End With

            Dim parx As New Paragraph(figx)
            Dim flowDoc As New FlowDocument(parx)
            ' </Snippet_FigureProps>
		End Sub

		Private Sub FloaterProps()
			' <Snippet_FloaterProps>
			Dim flotx As New Floater()
			flotx.Name = "myFloater"
			flotx.Width = 100
			flotx.HorizontalAlignment = HorizontalAlignment.Left

			Dim parx As New Paragraph(flotx)
			Dim flowDoc As New FlowDocument(parx)
			' </Snippet_FloaterProps>
		End Sub


	End Class
End Namespace