Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Imports System.Windows.Media.Animation
Imports System.IO
Imports System.Windows.Markup

Namespace FlowDocumentSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			SetBackground()
			CallBlockConstructor()
			BlocksProperty()
			BlocksPropertyGen()
			ColumnStuff()
			ContentStartEnd()
			FlowDirectionStuff()
			FontStuff()
			LineHeightStuff()
			PageWidthHeight()
			PaddingStuff()
			TextAlignmentStuff()
			TypographyStuff()
			TextEffectsStuff()
			Hyphenate()

			FDRProps()
		End Sub

		Private Sub SetBackground()
			' <Snippet_FlowDocumentBackground>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
			flowDoc.Background = Brushes.IndianRed
			flowDoc.Foreground = Brushes.NavajoWhite
			' </Snippet_FlowDocumentBackground>
		End Sub

		Private Sub CallBlockConstructor()
				' <Snippet_FlowDocumentConstructorSimple>
            Dim flowDocSimple As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
				' </Snippet_FlowDocumentConstructorSimple>

				' <Snippet_TextBlockConstructorSimple>
				Dim txtBlock As New TextBlock(New Run("A bit of text content..."))
				' </Snippet_TextBlockConstructorSimple>

				' <Snippet_FlowDocumentConstructorTable>
				' A paragraph with sample text will serve as table content.
				Dim tableText As New Paragraph(New Run("A bit of text content..."))

				Dim sampleTable As New Table()

				' Create and add a couple of columns.
				sampleTable.Columns.Add(New TableColumn())
				sampleTable.Columns.Add(New TableColumn())

				' Create and add a row group and a couple of rows.
				sampleTable.RowGroups.Add(New TableRowGroup())
				sampleTable.RowGroups(0).Rows.Add(New TableRow())
				sampleTable.RowGroups(0).Rows.Add(New TableRow())

				' Create four cells initialized with the sample text paragraph.
				sampleTable.RowGroups(0).Rows(0).Cells.Add(New TableCell(tableText))
				sampleTable.RowGroups(0).Rows(0).Cells.Add(New TableCell(tableText))
				sampleTable.RowGroups(0).Rows(1).Cells.Add(New TableCell(tableText))
				sampleTable.RowGroups(0).Rows(1).Cells.Add(New TableCell(tableText))

				' Finally, use the FlowDocument constructor to create a new FlowDocument containing 
				' the table constructed above.
            Dim flowDocTable As New FlowDocument(sampleTable)
				' </Snippet_FlowDocumentConstructorTable>
		End Sub

		Private Sub BlocksProperty()
			' Append a content block to the contents of the FlowDocument.
			' <Snippet_FlowDocumentBlocksAdd>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
			flowDoc.Blocks.Add(New Paragraph(New Run("Text to append...")))
			' </Snippet_FlowDocumentBlocksAdd>

			' Insert a content block at the begining of the FlowDocument.
			' <Snippet_FlowDocumentBlocksInsert>
			Dim p As New Paragraph(New Run("Text to insert..."))
			flowDoc.Blocks.InsertBefore(flowDoc.Blocks.FirstBlock, p)
			' </Snippet_FlowDocumentBlocksInsert>

			' Get the number of top-level Block elements in the FlowDocument.
			' <Snippet_FlowDocumentBlocksCount>
			Dim countTopLevelBlocks As Integer = flowDoc.Blocks.Count
			' </Snippet_FlowDocumentBlocksCount>

			' Remove the last block in the FlowDocument.
			' <Snippet_FlowDocumentBlocksRemoveLast>
			flowDoc.Blocks.Remove(flowDoc.Blocks.LastBlock)
			' </Snippet_FlowDocumentBlocksRemoveLast>

			' Clear all of the blocks (contents) of the FlowDocument.
			' <Snippet_FlowDocumentBlocksClear>
			flowDoc.Blocks.Clear()
			' </Snippet_FlowDocumentBlocksClear>
		End Sub

		Private Sub BlocksPropertyGen()
			' Append a content block to the contents of the Section.
			' <Snippet_SectionBlocksAdd>
			Dim secx As New Section()
			secx.Blocks.Add(New Paragraph(New Run("A bit of text content...")))
			' </Snippet_SectionBlocksAdd>

			' Insert a content block at the begining of the Section.
			' <Snippet_SectionBlocksInsert>
			Dim parx As New Paragraph(New Run("Text to insert..."))
			secx.Blocks.InsertBefore(secx.Blocks.FirstBlock, parx)
			' </Snippet_SectionBlocksInsert>

			' Get the number of top-level Block elements in the Section.
			' <Snippet_SectionBlocksCount>
			Dim countTopLevelBlocks As Integer = secx.Blocks.Count
			' </Snippet_SectionBlocksCount>

			' Remove the last block in the Section.
			' <Snippet_SectionBlocksRemoveLast>
			secx.Blocks.Remove(secx.Blocks.LastBlock)
			' </Snippet_SectionBlocksRemoveLast>

			' Clear all of the blocks (contents) of the Section.
			' <Snippet_SectionBlocksClear>
			secx.Blocks.Clear()
			' </Snippet_SectionBlocksClear>
		End Sub

		Private Sub ColumnStuff()
				' <Snippet_FlowDocumentColumnGap>
            Dim flowDocColGap As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
				' Set the desired column gap to 10 device independend pixels.
            flowDocColGap.ColumnGap = 10.0
				' </Snippet_FlowDocumentColumnGap>

				' <Snippet_FlowDocumentColumnRule>
            Dim flowDocColRule As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
				' Set a column rule two pixels wide colored Dodger blue.
            flowDocColRule.ColumnRuleWidth = 2.0
            flowDocColRule.ColumnRuleBrush = Brushes.DodgerBlue
				' </Snippet_FlowDocumentColumnRule>

				' <Snippet_FlowDocumentColumnWidth>
            Dim flowDocColWidth As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
				' Set minimum column width to 140 pixels.
            flowDocColWidth.ColumnWidth = 140.0
				' </Snippet_FlowDocumentColumnWidth>

				' <Snippet_FlowDocumentColumnFlex>
            Dim flowDocColFlex As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
				' Set minimum column width to 140 pixels.
            flowDocColFlex.IsColumnWidthFlexible = True
				' </Snippet_FlowDocumentColumnFlex>
		End Sub

		Private Sub ContentStartEnd()
				' <Snippet_FlowDocumentContentEnd>
				' Create a new, empty FlowDocument.
            Dim flowDocEnd As New FlowDocument()

				' Append an initial paragraph at the "end" of the empty FlowDocument.
            flowDocEnd.Blocks.Add(New Paragraph(New Run("Since the new FlowDocument is empty at this point, this will be the initial content " & "in the FlowDocument.")))
				' Append a line-break.
            flowDocEnd.Blocks.Add(New Paragraph(New LineBreak()))
				' Append another paragraph.
            flowDocEnd.Blocks.Add(New Paragraph(New Run("This text will be in a paragraph that is inserted at the end of the FlowDocument.")))
				' </Snippet_FlowDocumentContentEnd>

				' <Snippet_FlowDocumentContentStart>
				' Create a new, empty FlowDocument.
            Dim flowDocStart As New FlowDocument()

				' Insert an initial paragraph at the beginning of the empty FlowDocument.
            flowDocStart.Blocks.Add(New Paragraph(New Run("Since the new FlowDocument is empty at this point, this will be the initial content " & "in the FlowDocument.")))
				' Insert a line-break at the beginnign of the document, before the previously inserted paragraph.
            flowDocStart.Blocks.InsertBefore(flowDocStart.Blocks.FirstBlock, New Paragraph(New LineBreak()))
				' Insert another paragraph at the beginning of the document.
            flowDocStart.Blocks.InsertBefore(flowDocStart.Blocks.FirstBlock, New Paragraph(New Run("This paragraph will be inserted before the previously added paragraph, replacing the previously" & "added paragraph as the first paragraph in the document.")))
				' </Snippet_FlowDocumentContentStart>
		End Sub

		Private Sub FlowDirectionStuff()
			' <Snippet_FlowDocumentFlowDirection>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
			' Set the content flow direction to left-to-right.
			flowDoc.FlowDirection = System.Windows.FlowDirection.LeftToRight
			' </Snippet_FlowDocumentFlowDirection>
		End Sub

		Private Sub FontStuff()
			' <Snippet_FlowDocumentFontStuff>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
			' Set the desired column gap to 10 device independend pixels.
			flowDoc.FontFamily = New FontFamily("Century Gothic")
			flowDoc.FontSize = 12.0
			flowDoc.FontStretch = FontStretches.UltraExpanded
			flowDoc.FontStyle = FontStyles.Italic
			flowDoc.FontWeight = FontWeights.UltraBold
			' </Snippet_FlowDocumentFontStuff>
		End Sub

		Private Sub LineHeightStuff()
			' <Snippet_FlowDocumentLineHeight>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
			' Set the content flow direction to left-to-right.
            flowDoc.LineHeight = 48
			' </Snippet_FlowDocumentLineHeight>
		End Sub

		Private Sub PageWidthHeight()
			' <Snippet_FlowDocumentPageWidthHeight>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))
			' Set PageHeight and PageWidth to "Auto".
			flowDoc.PageHeight = Double.NaN
			flowDoc.PageWidth = Double.NaN
			' Specify minimum page sizes.
			flowDoc.MinPageWidth = 680.0
			flowDoc.MinPageHeight = 480.0
			'Specify maximum page sizes.
			flowDoc.MaxPageWidth = 1024.0
			flowDoc.MaxPageHeight = 768.0
			' </Snippet_FlowDocumentPageWidthHeight>
		End Sub

		Private Sub PaddingStuff()
			' <Snippet_FlowDocumentPadding>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))

			' Padding is 10 pixels all around.
			flowDoc.PagePadding = New Thickness(10)
			' Padding is 5 pixels on the right and left, and 10 pixels on the top and botton.
			flowDoc.PagePadding = New Thickness(5, 10, 5, 10)
			' </Snippet_FlowDocumentPadding>
		End Sub
		Private Sub TextAlignmentStuff()
			' <Snippet_FlowDocumentTextAlignment>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))

			' Text will be centered.
			flowDoc.TextAlignment = TextAlignment.Center
			' </Snippet_FlowDocumentTextAlignment>
		End Sub

		Private Sub TypographyStuff()
			' <Snippet_FlowDocumentTypography>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))

			' Change various default typography variations.
			flowDoc.Typography.Capitals = FontCapitals.SmallCaps
			flowDoc.Typography.CapitalSpacing = True
			flowDoc.Typography.CaseSensitiveForms = True
			flowDoc.Typography.ContextualAlternates = False
			flowDoc.Typography.ContextualLigatures = False
			flowDoc.Typography.DiscretionaryLigatures = True
			flowDoc.Typography.EastAsianExpertForms = True
			flowDoc.Typography.EastAsianLanguage = FontEastAsianLanguage.Traditional
			flowDoc.Typography.EastAsianWidths = FontEastAsianWidths.Proportional
			flowDoc.Typography.Fraction = FontFraction.Stacked
			flowDoc.Typography.HistoricalForms = True
			flowDoc.Typography.HistoricalLigatures = True
			flowDoc.Typography.Kerning = False
			flowDoc.Typography.MathematicalGreek = True
			flowDoc.Typography.NumeralAlignment = FontNumeralAlignment.Proportional
			flowDoc.Typography.NumeralStyle = FontNumeralStyle.OldStyle
			flowDoc.Typography.SlashedZero = True
			flowDoc.Typography.StandardLigatures = False
			flowDoc.Typography.Variants = FontVariants.Ruby
			' </Snippet_FlowDocumentTypography>

		End Sub

		Private Sub TextEffectsStuff()

			' Create and configure a simple color animation sequence.  Timespan in 100 nanosecond ticks.
			Dim blackToWhite As New ColorAnimation(Colors.White, Colors.Black, New Duration(New TimeSpan(10000000)))
			blackToWhite.AutoReverse = True
			blackToWhite.RepeatBehavior = RepeatBehavior.Forever

			' Create a new brush and apply the color animation.
			Dim scb As New SolidColorBrush(Colors.Black)
			scb.BeginAnimation(SolidColorBrush.ColorProperty, blackToWhite)

			' Create a new TextEffect object; set foreground brush to the previously created brush.
			Dim tfe As New TextEffect()
			tfe.Foreground = scb
			' Range of text to apply (all).
			tfe.PositionStart = 0
			tfe.PositionCount = Integer.MaxValue

			' Add this text effect to the FlowDocument's effects colleciton.
			fd.TextEffects = New TextEffectCollection()
			fd.TextEffects.Add(tfe)

			fd.Blocks.Add(New Paragraph(New Run("Blah blah animate me")))

			Dim runx As New Run("Blah blah animate me")
			runx.TextEffects = New TextEffectCollection()
			runx.TextEffects.Add(tfe)
			fd.Blocks.Add(New Paragraph(runx))

		End Sub

		Private Sub Hyphenate()
			' <Snippet_FlowDocumentHyphenate>
			Dim flowDoc As New FlowDocument(New Paragraph(New Run("A bit of text content...")))

			' Enable automatic hyphenation.
			flowDoc.IsHyphenationEnabled = True
			' Enable optimal paragraph layout.
			flowDoc.IsOptimalParagraphEnabled = True
			' </Snippet_FlowDocumentHyphenate>
		End Sub

		Private Sub FDRProps()
			' <Snippet_FlowDocumentReader>
			Dim flowDocRdr As New FlowDocumentReader()

			' Enable find...
			flowDocRdr.IsFindEnabled = True
			' Enable printing...
			flowDocRdr.IsPrintEnabled = True
			' Set zoom between 50% and 1000%.
			flowDocRdr.MinZoom = 50
			flowDocRdr.MaxZoom = 1000
			' Set the zoom increment to 5%.
			flowDocRdr.ZoomIncrement = 5
			' Set the initial zoom to 120%.
			flowDocRdr.Zoom = 120

			Dim flowDoc As New FlowDocument(New Paragraph(New Run("Flow content...")))
			flowDocRdr.Document = flowDoc
			' </Snippet_FlowDocumentReader>
		End Sub

		Private Sub FDPVProps()
			' <Snippet_FlowDocumentPageViewer>
			Dim flowDocPageViewer As New FlowDocumentPageViewer()

			' Set zoom between 50% and 1000%.
			flowDocPageViewer.MinZoom = 50
			flowDocPageViewer.MaxZoom = 1000
			' Set the zoom increment to 5%.
			flowDocPageViewer.ZoomIncrement = 5
			' Set the initial zoom to 120%.
			flowDocPageViewer.Zoom = 120

			Dim flowDoc As New FlowDocument(New Paragraph(New Run("Flow content...")))
			flowDocPageViewer.Document = flowDoc
			' </Snippet_FlowDocumentPageViewer>
		End Sub

		Private Sub FDSVProps()
			' <Snippet_FlowDocumentScrollViewer>
			Dim flowDocScrollViewer As New FlowDocumentScrollViewer()

            With flowDocScrollViewer
                ' Enable content selection.
                .IsSelectionEnabled = True
                ' Enable the toolbar.
                .IsToolBarVisible = True

                ' Set zoom between 50% and 1000%.
                .MinZoom = 50
                .MaxZoom = 1000
                ' Set the zoom increment to 5%.
                .ZoomIncrement = 5
                ' Set the initial zoom to 120%.
                .Zoom = 120

                Dim flowDoc As New FlowDocument(New Paragraph(New Run("Flow content...")))
                .Document = flowDoc
            End With
            ' </Snippet_FlowDocumentScrollViewer>
		End Sub

		' <Snippet_FlowDocRdr_Load>
		Private Sub LoadFlowDocumentReaderWithXAMLFile(ByVal fileName As String)
			' Open the file that contains the FlowDocument...
			Dim xamlFile As New FileStream(fileName, FileMode.Open, FileAccess.Read)
			' and parse the file with the XamlReader.Load method.
			Dim content As FlowDocument = TryCast(XamlReader.Load(xamlFile), FlowDocument)
			' Finally, set the Document property to the FlowDocument object that was
			' parsed from the input file.
			flowDocRdr.Document = content

			xamlFile.Close()
		End Sub
		' </Snippet_FlowDocRdr_Load>

		' <Snippet_FlowDocPageViewer_Load>
		Private Sub LoadFlowDocumentPageViewerWithXAMLFile(ByVal fileName As String)
			' Open the file that contains the FlowDocument...
			Dim xamlFile As New FileStream(fileName, FileMode.Open, FileAccess.Read)
			' and parse the file with the XamlReader.Load method.
			Dim content As FlowDocument = TryCast(XamlReader.Load(xamlFile), FlowDocument)
			' Finally, set the Document property to the FlowDocument object that was
			' parsed from the input file.
			flowDocPageViewer.Document = content

			xamlFile.Close()
		End Sub
		' </Snippet_FlowDocPageViewer_Load>

		' <Snippet_FlowDocScrollViewer_Load>
		Private Sub LoadFlowDocumentScrollViewerWithXAMLFile(ByVal fileName As String)
			' Open the file that contains the FlowDocument...
			Dim xamlFile As New FileStream(fileName, FileMode.Open, FileAccess.Read)
			' and parse the file with the XamlReader.Load method.
			Dim content As FlowDocument = TryCast(XamlReader.Load(xamlFile), FlowDocument)
			' Finally, set the Document property to the FlowDocument object that was
			' parsed from the input file.
			flowDocScrollViewer.Document = content

			xamlFile.Close()
		End Sub
		' </Snippet_FlowDocScrollViewer_Load>

		' <Snippet_FlowDocRdr_Save>
		Private Sub SaveFlowDocumentReaderWithXAMLFile(ByVal fileName As String)
			' Open or create the output file.
			Dim xamlFile As New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)
			' Save the contents of the FlowDocumentReader to the file stream that was just opened.
			XamlWriter.Save(flowDocRdr.Document, xamlFile)

			xamlFile.Close()
		End Sub
		' </Snippet_FlowDocRdr_Save>

		' <Snippet_FlowDocPageViewer_Save>
		Private Sub SaveFlowDocumentPageViewerWithXAMLFile(ByVal fileName As String)
			' Open or create the output file.
			Dim xamlFile As New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)
			' Save the contents of the FlowDocumentReader to the file stream that was just opened.
			XamlWriter.Save(flowDocPageViewer.Document, xamlFile)

			xamlFile.Close()
		End Sub
		' </Snippet_FlowDocPageViewer_Save>

		' <Snippet_FlowDocScrollViewer_Save>
		Private Sub SaveFlowDocumentScrollViewerWithXAMLFile(ByVal fileName As String)
			' Open or create the output file.
			Dim xamlFile As New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)
			' Save the contents of the FlowDocumentReader to the file stream that was just opened.
			XamlWriter.Save(flowDocScrollViewer.Document, xamlFile)

			xamlFile.Close()
		End Sub
		' </Snippet_FlowDocScrollViewer_Save>


		Private Sub TextBlockProps()
			' <Snippet_TextBlockProps>
			Dim textBlock As New TextBlock(New Run("A bit of text content..."))

			textBlock.Background = Brushes.AntiqueWhite
			textBlock.Foreground = Brushes.Navy

			textBlock.FontFamily = New FontFamily("Century Gothic")
			textBlock.FontSize = 12
			textBlock.FontStretch = FontStretches.UltraExpanded
			textBlock.FontStyle = FontStyles.Italic
			textBlock.FontWeight = FontWeights.UltraBold

			textBlock.LineHeight = Double.NaN
			textBlock.Padding = New Thickness(5, 10, 5, 10)
			textBlock.TextAlignment = TextAlignment.Center
			textBlock.TextWrapping = TextWrapping.Wrap

			textBlock.Typography.NumeralStyle = FontNumeralStyle.OldStyle
			textBlock.Typography.SlashedZero = True
			' </Snippet_TextBlockProps>
		End Sub

		Private Sub TextBlockBase()
				' <Snippet_TextBlockSimple>
				Dim textBlock1 As New TextBlock()
				Dim textBlock2 As New TextBlock()

				textBlock2.TextWrapping = TextWrapping.Wrap
				textBlock1.TextWrapping = textBlock2.TextWrapping
				textBlock2.Background = Brushes.AntiqueWhite
				textBlock2.TextAlignment = TextAlignment.Center

				textBlock1.Inlines.Add(New Bold(New Run("TextBlock")))
				textBlock1.Inlines.Add(New Run(" is designed to be "))
				textBlock1.Inlines.Add(New Italic(New Run("lightweight")))
				textBlock1.Inlines.Add(New Run(", and is geared specifically at integrating "))
				textBlock1.Inlines.Add(New Italic(New Run("small")))
				textBlock1.Inlines.Add(New Run(" portions of flow content into a UI."))

				textBlock2.Text = "By default, a TextBlock provides no UI beyond simply displaying its contents."
				' </Snippet_TextBlockSimple>
		End Sub
	End Class
End Namespace