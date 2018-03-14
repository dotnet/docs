Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Namespace BlockSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			Borders()
			MarginPadding()
		End Sub

		Private Sub Borders()
			' <Snippet_Block_Borders>
			Dim par As New Paragraph()

			Dim run1 As New Run("Child elements in this Block element (Paragraph) will be surrounded by a blue border.")
			Dim run2 As New Run("This border will be one quarter inch thick in all directions.")

			par.Inlines.Add(run1)
			par.Inlines.Add(run2)

			par.BorderBrush = Brushes.Blue
			Dim tc As New ThicknessConverter()
			par.BorderThickness = CType(tc.ConvertFromString("0.25in"), Thickness)
			' </Snippet_Block_Borders>

		End Sub

		Private Sub MarginPadding()
			' <Snippet_Block_MarginPadding>
			Dim flowDoc As New FlowDocument()
			Dim sec As New Section()

			flowDoc.Background = Brushes.LightSlateGray
			flowDoc.ColumnWidth = 2000
			sec.Background = Brushes.DarkMagenta
			sec.Margin = New Thickness(0)
			sec.Padding = sec.Margin

			Dim defPar1 As New Paragraph(New Run("Default paragraph."))
			Dim defPar2 As New Paragraph(New Run("Default paragraph."))
			Dim defPar3 As New Paragraph(New Run("Default paragraph."))
			Dim defPar4 As New Paragraph(New Run("Default paragraph."))
			defPar4.Background = Brushes.White
			defPar3.Background = defPar4.Background
			defPar2.Background = defPar3.Background
			defPar1.Background = defPar2.Background

			Dim marginPar As New Paragraph(New Run("This paragraph has a magin of 50 pixels set, but no padding."))
			marginPar.Background = Brushes.LightBlue
			marginPar.Margin = New Thickness(50)
			Dim paddingPar As New Paragraph(New Run("This paragraph has padding of 50 pixels set, but no margin."))
			paddingPar.Background = Brushes.LightCoral
			paddingPar.Padding = New Thickness(50)
			Dim marginPaddingPar As New Paragraph(New Run("This paragraph has both padding and margin set to 50 pixels."))
            With marginPaddingPar
                .Background = Brushes.LightGreen
                .Margin = New Thickness(50)
                .Padding = marginPaddingPar.Margin
            End With

            sec.Blocks.Add(defPar1)
            sec.Blocks.Add(defPar2)
            sec.Blocks.Add(marginPar)
            sec.Blocks.Add(paddingPar)
            sec.Blocks.Add(marginPaddingPar)
            sec.Blocks.Add(defPar3)
            sec.Blocks.Add(defPar4)
            flowDoc.Blocks.Add(sec)
            ' </Snippet_Block_MarginPadding>
		End Sub

		Private Sub FlowDir()
			' <Snippet_Block_FlowDirection>
			Dim par As New Paragraph(New Run("This paragraph will flow from left to right."))
			par.FlowDirection = FlowDirection.LeftToRight
			' </Snippet_Block_FlowDirection>
		End Sub

		Private Sub LineHeight()
			' <Snippet_Block_LineHeight>
			Dim par As New Paragraph()
			par.LineHeight = 48
			' </Snippet_Block_LineHeight>
		End Sub

		Private Sub TextAlign()
			' <Snippet_Block_TextAlignment>
			Dim par As New Paragraph()
			par.TextAlignment = TextAlignment.Center
			' </Snippet_Block_TextAlignment>
		End Sub

		Private Sub Hyphenate()
			' <Snippet_Block_Hyphenate>
			Dim par As New Paragraph()
			par.IsEnabled = True
			' </Snippet_Block_Hyphenate>
		End Sub
	End Class
End Namespace