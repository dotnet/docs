' XpsPrint SDK Sample - WpfContent.vb
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This file provides the methods for creating the default
' DocumentViewer content used by the XpsPrint SDK sample.


Imports System.Collections.Generic
Imports System.IO
Imports System.IO.Packaging
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Xps.Packaging
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Markup
Imports System.Printing
Imports SDKSample


Namespace SDKSampleHelper
	' -------------------------- class WPFContent ----------------------------
	''' <summary>
	'''   Generates sample content in memory
	'''   (Visuals, FixedPages, and FixedDocuments). </summary>
	''' <remarks>
	'''   The XpsPrintHelper class calls WPFContent to create
	'''   all the media for all the documents used by the sample.</remarks>
	Friend Class WPFContent
		' ---------------------- WPFContent constructor ----------------------
		''' <summary>
		'''   Initialize a new instance of the WPFContent class.</summary>
		''' <param name="contentPath">
		'''   The path to the "\Content" folder.</param>
		Public Sub New(ByVal contentPath As String)
			_contentDir = contentPath
		End Sub


		#Region "Create Visuals Methods"

		' ------------------------- CreateFirstVisual ------------------------
		''' <summary>
		'''   Creates content for the first visual sample.</summary>
		''' <param name="shouldMeasure">
		'''   true to remeasure the layout.</param>
		''' <returns>
		'''   The canvas containing the visual.</returns>
		Public Function CreateFirstVisual(ByVal shouldMeasure As Boolean) As Canvas
			Dim canvas1 As New Canvas()
			canvas1.Width = 96 * 8.5
			canvas1.Height = 96 * 11

			' Top-Left
			Dim label As New TextBlock()
			label.Foreground = Brushes.DarkBlue
			label.FontFamily = New System.Windows.Media.FontFamily("Arial")
			label.FontSize = 36.0
			label.Text = "TopLeft"
			Canvas.SetTop(label, 0)
			Canvas.SetLeft(label, 0)
			canvas1.Children.Add(label)

			' Bottom-Right
			label = New TextBlock()
			label.Foreground = Brushes.Bisque
			label.Text = "BottomRight"
			label.FontFamily = New System.Windows.Media.FontFamily("Arial")
			label.FontSize = 56.0
			Canvas.SetTop(label, 750)
			Canvas.SetLeft(label, 520)
			canvas1.Children.Add(label)

			' Top-Right
			label = New TextBlock()
			label.Foreground = Brushes.BurlyWood
			label.Text = "TopRight"
			label.FontFamily = New System.Windows.Media.FontFamily("CASTELLAR")
			label.FontSize = 32.0
			Canvas.SetTop(label, 0)
			Canvas.SetLeft(label, 520)
			canvas1.Children.Add(label)

			' Bottom-Left
			label = New TextBlock()
			label.Foreground = Brushes.Cyan
			label.Text = "BottomLeft"
			label.FontFamily = New System.Windows.Media.FontFamily("Arial")
			label.FontSize = 18.0
			Canvas.SetTop(label, 750)
			Canvas.SetLeft(label, 0)
			canvas1.Children.Add(label)

			' Adding a rectangle to the page
			Dim firstRectangle As New Rectangle()
			firstRectangle.Fill = New SolidColorBrush(Colors.Red)
			Dim thick As New Thickness()
			thick.Left = 150
			thick.Top = 150
			firstRectangle.Margin = thick
			firstRectangle.Width = 300
			firstRectangle.Height = 300
			canvas1.Children.Add(firstRectangle)

			'Add a button to the page
			Dim firstButton As New Button()
			firstButton.Background = Brushes.LightYellow
			firstButton.BorderBrush = New SolidColorBrush(Colors.Black)
			firstButton.BorderThickness = New Thickness(4)
			firstButton.Content = "I am button 1..."
			firstButton.FontSize = 16.0
			thick.Left = 80
			thick.Top = 250
			firstButton.Margin = thick
			canvas1.Children.Add(firstButton)

			' Add an Ellipse
			Dim firstEllipse As New Ellipse()
			Dim firstSolidColorBrush As New SolidColorBrush(Colors.DarkCyan)
			firstSolidColorBrush.Opacity = 0.7
			firstEllipse.Fill = firstSolidColorBrush
			SetEllipse(firstEllipse, 500, 350, 120, 250)
			canvas1.Children.Add(firstEllipse)

			' Add a Polygon
			Dim polygon As New Polygon()
			polygon.Fill = Brushes.Bisque
			polygon.Opacity = 0.2
			Dim points As New PointCollection()
			points.Add(New Point(50, 0))
			points.Add(New Point(10, 30))
			points.Add(New Point(30, 170))
			points.Add(New Point(90, 40))
			points.Add(New Point(230, 180))
			points.Add(New Point(200, 60))
			points.Add(New Point(240, 10))
			points.Add(New Point(70, 130))
			polygon.Points = points
			polygon.Stroke = Brushes.Navy
			Canvas.SetTop(polygon, 300)
			Canvas.SetLeft(polygon, 160)
			canvas1.Children.Add(polygon)

			If shouldMeasure Then
				Dim sz As New Size(8.5 * 96, 11 * 96)
				canvas1.Measure(sz)
				canvas1.Arrange(New Rect(New Point(), sz))
				canvas1.UpdateLayout()
			End If

			Return canvas1
		End Function ' end:CreateFirstVisual()


		' ------------------------- CreateSecondVisual -----------------------
		''' <summary>
		'''   Creates content for the second visual sample.</summary>
		''' <param name="shouldMeasure">
		'''   true to remeasure the layout.</param>
		''' <returns>
		'''   The canvas containing the visual.</returns>
		Public Function CreateSecondVisual(ByVal shouldMeasure As Boolean) As Canvas
			Dim canvas As New Canvas()

			Dim ellipse As New Ellipse()
			ellipse.Fill = Brushes.LightSeaGreen
			SetEllipse(ellipse, 130, 200, 100, 70)
			ellipse.Stroke = Brushes.Black
			canvas.Children.Add(ellipse)

			Dim rectangle As New Rectangle()
			rectangle.Fill = Brushes.PowderBlue
			rectangle.Opacity = 0.8
			rectangle.RadiusX = 5
			rectangle.RadiusY = 5
			rectangle.Stroke = Brushes.Orange
			rectangle.Height = 200
			rectangle.Width = 350
			Canvas.SetTop(rectangle, 50)
			Canvas.SetLeft(rectangle, 100)
			canvas.Children.Add(rectangle)

			Dim polygon As New Polygon()
			polygon.Fill = Brushes.MediumVioletRed
			polygon.Opacity = 0.7
			Dim points As New PointCollection()
			points.Add(New Point(50, 0))
			points.Add(New Point(10, 30))
			points.Add(New Point(30, 170))
			points.Add(New Point(90, 40))
			points.Add(New Point(230, 180))
			points.Add(New Point(200, 60))
			points.Add(New Point(240, 10))
			points.Add(New Point(70, 130))
			polygon.Points = points
			polygon.Stroke = Brushes.Navy
			Canvas.SetTop(polygon, 150)
			Canvas.SetLeft(polygon, 250)
			canvas.Children.Add(polygon)

			Dim scribble As New TextBlock()
			scribble.Foreground = Brushes.Green
			scribble.FontFamily = New System.Windows.Media.FontFamily("Courier New")
			scribble.FontSize = 18
			scribble.Opacity = 0.5
			Canvas.SetLeft(scribble, 96 * 3.7)
			Canvas.SetTop(scribble, 96 * 10.3)
			canvas.Children.Add(scribble)

			Dim para As New TextBlock()
			para.Text = "This is a piece of text content."
			para.FontSize = 16
			para.FontFamily = New System.Windows.Media.FontFamily("Comic Sans MS")
			para.Foreground = Brushes.Orange
			Canvas.SetTop(para, 96 * 6)
			Canvas.SetLeft(para, 15)
			canvas.Children.Add(para)

			para = New TextBlock()
			para.Text = "This is the second piece of text content."
			para.FontSize = 16
			para.FontFamily = New System.Windows.Media.FontFamily("Comic Sans MS")
			para.Foreground = Brushes.Blue
			Canvas.SetTop(para, 96 * 7.2)
			Canvas.SetLeft(para, 15)
			canvas.Children.Add(para)

			para = New TextBlock()
			para.Text = "This is the last text section."
			para.FontSize = 16
			para.FontFamily = New System.Windows.Media.FontFamily("Comic Sans MS")
			para.Foreground = Brushes.Red
			Canvas.SetTop(para, 96 * 8.4)
			Canvas.SetLeft(para, 15)
			canvas.Children.Add(para)

			If shouldMeasure Then
				Dim sz As New Size(8.5 * 96, 11 * 96)
				canvas.Measure(sz)
				canvas.Arrange(New Rect(New Point(), sz))
				canvas.UpdateLayout()
			End If

			Return canvas
		End Function ' end:CreateSecondVisual()


		' ------------------------- CreateThirdVisual ------------------------
		''' <summary>
		'''   Creates content for the third visual sample.</summary>
		''' <param name="shouldMeasure">
		'''   true to remeasure the layout.</param>
		''' <returns>
		'''   The canvas containing the visual.</returns>
		Public Function CreateThirdVisual(ByVal shouldMeasure As Boolean) As Canvas
			Dim canvas As New Canvas()
			Dim brush As New RadialGradientBrush()

			brush.GradientStops.Add(New GradientStop(Colors.Black, 0))
			brush.GradientStops.Add(New GradientStop(Colors.Yellow, 0.5))
			brush.GradientStops.Add(New GradientStop(Colors.Red, 1))

			brush.SpreadMethod = GradientSpreadMethod.Repeat
			brush.Center = New Point(0.5, 0.5)
			brush.RadiusX = 0.2
			brush.RadiusY = 0.2
			brush.GradientOrigin = New Point(0.5, 0.5)

			Dim r As New Rectangle()
			r.Fill = brush

			Dim thick As New Thickness()
			thick.Left = 100
			thick.Top = 100

			r.Margin = thick
			r.Width = 400
			r.Height = 400

			canvas.Children.Add(r)

			Dim linear As New LinearGradientBrush()

			linear.GradientStops.Add(New GradientStop(Colors.Blue, 0))
			linear.GradientStops.Add(New GradientStop(Colors.Yellow, 1))

			linear.SpreadMethod = GradientSpreadMethod.Reflect
			linear.StartPoint = New Point(0, 0)
			linear.EndPoint = New Point(0.06125, 0)
			linear.Opacity = 0.5

			r = New Rectangle()
			r.Fill = linear

			thick = New Thickness()
			thick.Left = 200
			thick.Top = 200

			r.Margin = thick
			r.Width = 400
			r.Height = 400

			canvas.Children.Add(r)

			If shouldMeasure Then
				Dim sz As New Size(8.5 * 96, 11 * 96)
				canvas.Measure(sz)
				canvas.Arrange(New Rect(New Point(), sz))
				canvas.UpdateLayout()
			End If

			Return canvas
		End Function ' end:CreateThirdVisual()

		#End Region ' Create Visuals Methods


		' ------------------- CreateFixedDocumentWithPages -------------------
		''' <summary>
		'''   Creates a FixedDocument with fixed pages.</summary>
		''' <returns>
		'''   A FixedDocument containing fixed pages.</returns>
		Public Function CreateFixedDocumentWithPages(ByVal pq As PrintQueue) As FixedDocument
			' Create a FixedDocument
			Dim fixedDocument As FixedDocument = CreateFixedDocument()

			' Add Page 1 to a fixed document
			Dim page1Content As PageContent = CreateFirstPageContent(pq)
			fixedDocument.Pages.Add(page1Content)

			' Adding Page 2 to a fixed document
			Dim page2Content As PageContent = CreateSecondPageContent(pq)
			fixedDocument.Pages.Add(page2Content)

			' Adding Page 3 to a fixed document
			Dim page3Content As PageContent = CreateThirdPageContent(pq)
			fixedDocument.Pages.Add(page3Content)

			' Adding Page 4 to a fixed document;
			Dim page4Content As PageContent = CreateFourthPageContent(pq)
			fixedDocument.Pages.Add(page4Content)

			' Adding Page 5 to a fixed document;
			Dim page5Content As PageContent = CreateFifthPageContent(pq)
			fixedDocument.Pages.Add(page5Content)

			Return fixedDocument
		End Function ' end:CreateFixedDocumentWithPages()


		' --------------- CreatePopulatedFixedDocumentSequence ---------------
		''' <summary>
		'''   Creates a FixedDocumentSequence with content.</summary>
		''' <param name="pq">
		'''   The print queue to print to.</param>
		''' <returns>
		'''   A FixedDocumentSequence with content.</returns>
		Public Function CreatePopulatedFixedDocumentSequence(ByVal pq As PrintQueue) As FixedDocumentSequence
			' Create FixedDocumentSequence
			Dim fixedDocumentSequence As New FixedDocumentSequence()

			' Add Documents to a Fixed Document Sequence
			Dim documentRef As New DocumentReference()
			documentRef.SetDocument(CreateFixedDocumentWithPages(pq))
			fixedDocumentSequence.References.Add(documentRef)

			Return fixedDocumentSequence
		End Function ' end:CreatePopulatedFixedDocumentSequence()


		' ------------------------ CreateFlowDocument ------------------------
		''' <summary>
		'''   Creates a FlowDocument with content.</summary>
		''' <returns>
		'''   A FlowDocument with content.</returns>
		Public Function CreateFlowDocument() As IDocumentPaginatorSource
			Dim doc As New FlowDocument()

			For i As Integer = 0 To 1
				Dim paragraph As New Paragraph(New Run(_paragraphText))
				doc.Blocks.Add(paragraph)
			Next i

			Return doc
		End Function ' end:CreateFlowDocument()


		'--------------- LoadFixedDocumentSequenceFromDocument ---------------
		''' <summary>
		'''   Gets the FixedDocumentSequence from
		'''   the current container.</summary>
		''' <returns>
		'''   The FixedDocumentSequence within the current container.</returns>
		Public Function LoadFixedDocumentSequenceFromDocument() As FixedDocumentSequence
			Dim fullPath As String = _contentDir & "\ViewFixedDocumentSequence.xps"
			Dim xpsPackage As New XpsDocument(fullPath, FileAccess.Read, CompressionOption.NotCompressed)

			Dim fixedDocumentSequence As FixedDocumentSequence = xpsPackage.GetFixedDocumentSequence()
			Return fixedDocumentSequence
		End Function

		'<SnippetCreateFixedDocumentWithConfiguredPaginator>
		' ------------------------ CreateFixedDocument -----------------------
		''' <summary>
		'''   Creates an empty FixedDocument.</summary>
		''' <returns>
		'''   An empty FixedDocument without any content.</returns>
		Private Function CreateFixedDocument() As FixedDocument
			Dim fixedDocument As New FixedDocument()
			fixedDocument.DocumentPaginator.PageSize = New Size(96 * 8.5, 96 * 11)
			Return fixedDocument
		End Function
		'</SnippetCreateFixedDocumentWithConfiguredPaginator>

		#Region "Create FixedPage methods"
		' ---------------------- CreateFirstPageContent ----------------------
		''' <summary>
		'''   Creates the content for the first fixed page.</summary>
		''' <param name="pq">
		'''   The print queue to output to.</parm>
		''' <returns>
		'''   The page content for the first fixed page.</returns>
		Private Function CreateFirstPageContent(ByVal pq As PrintQueue) As PageContent
			Dim pageContent As New PageContent()
			Dim fixedPage As FixedPage = CreateFirstFixedPage()

			PerformTransform(fixedPage, pq)

			CType(pageContent, IAddChild).AddChild(fixedPage)
			Return pageContent
		End Function


		' ----------------------- CreateFirstFixedPage -----------------------
		''' <summary>
		'''   Creates the FixedPage for the first page.</summary>
		''' <returns>
		'''   The FixedPage for the first page.</returns>
		Private Function CreateFirstFixedPage() As FixedPage
			Dim fixedPage As New FixedPage()
			fixedPage.Background = Brushes.LightYellow
			Dim visual As UIElement = CreateFirstVisual(False)

			FixedPage.SetLeft(visual, 0)
			FixedPage.SetTop(visual, 0)

			Dim pageWidth As Double = 96 * 8.5
			Dim pageHeight As Double = 96 * 11
			fixedPage.Width = pageWidth
			fixedPage.Height = pageHeight

			fixedPage.Children.Add(CType(visual, UIElement))

			Return fixedPage
		End Function ' end:CreateFirstFixedPage()


		' --------------------- CreateSecondPageContent ----------------------
		''' <summary>
		'''   Creates the content for the second fixed page.</summary>
		''' <param name="pq">
		'''   The print queue to output to.</param>
		''' <returns>
		'''   The page content for the second fixed page.</returns>
		Private Function CreateSecondPageContent(ByVal pq As PrintQueue) As PageContent
			Dim pageContent As New PageContent()
			Dim fixedPage As New FixedPage()
			fixedPage.Background = Brushes.LightGray
			Dim visual As UIElement = CreateSecondVisual(False)

			FixedPage.SetLeft(visual, 0)
			FixedPage.SetTop(visual, 0)

			Dim pageWidth As Double = 96 * 8.5
			Dim pageHeight As Double = 96 * 11
			fixedPage.Width = pageWidth
			fixedPage.Height = pageHeight

			fixedPage.Children.Add(CType(visual, UIElement))

			PerformTransform(fixedPage, pq)

			CType(pageContent, IAddChild).AddChild(fixedPage)
			Return pageContent
		End Function ' end:CreateSecondPageContent()


		' --------------------- CreateThirdPageContent -----------------------
		''' <summary>
		'''   Creates the content for the third fixed page.</summary>
		''' <param name="pq">
		'''   The print queue to output to.</param>
		''' <returns>
		'''   The page content for the third fixed page.</returns>
		Public Function CreateThirdPageContent(ByVal pq As PrintQueue) As PageContent
			Dim pageContent As New PageContent()
			Dim fixedPage As New FixedPage()
			fixedPage.Background = Brushes.White
			Dim canvas1 As New Canvas()
			canvas1.Width = 8.5 * 96
			canvas1.Height = 11 * 96

			' Top-Left
			Dim label As New TextBlock()
			label.Foreground = Brushes.Black
			label.FontFamily = New System.Windows.Media.FontFamily("Arial")
			label.FontSize = 14.0
			label.Text = String1
			Canvas.SetTop(label, 0)
			Canvas.SetLeft(label, 0)
			canvas1.Children.Add(label)

			label = New TextBlock()
			label.Foreground = Brushes.Black
			label.FontFamily = New System.Windows.Media.FontFamily("Arial")
			label.FontSize = 14.0
			label.Text = String2
			Canvas.SetTop(label, 20)
			Canvas.SetLeft(label, 0)
			canvas1.Children.Add(label)

			label = New TextBlock()
			label.Foreground = Brushes.Black
			label.FontFamily = New System.Windows.Media.FontFamily("Arial")
			label.FontSize = 14.0
			label.Text = String3
			Canvas.SetTop(label, 40)
			Canvas.SetLeft(label, 0)
			canvas1.Children.Add(label)

			label = New TextBlock()
			label.Foreground = Brushes.Black
			label.FontFamily = New System.Windows.Media.FontFamily("Arial")
			label.FontSize = 14.0
			label.Text = String4
			Canvas.SetTop(label, 60)
			Canvas.SetLeft(label, 0)
			canvas1.Children.Add(label)

			label = New TextBlock()
			label.Foreground = Brushes.Black
			label.FontFamily = New System.Windows.Media.FontFamily("Arial")
			label.FontSize = 14.0
			label.Text = String5
			Canvas.SetTop(label, 80)
			Canvas.SetLeft(label, 0)
			canvas1.Children.Add(label)

			fixedPage.Children.Add(canvas1)

			Dim pageWidth As Double = 96 * 8.5
			Dim pageHeight As Double = 96 * 11
			fixedPage.Width = pageWidth
			fixedPage.Height = pageHeight

			PerformTransform(fixedPage, pq)

			CType(pageContent, IAddChild).AddChild(fixedPage)
			Return pageContent
		End Function ' end:CreateThirdPageContent()


		' --------------------- CreateFourthPageContent ----------------------
		''' <summary>
		'''   Creates the content for the fourth fixed page.</summary>
		''' <param name="pq">
		'''   The print queue to output to.</param>
		''' <returns>
		'''   The page content for the fourth fixed page.</returns>
		Private Function CreateFourthPageContent(ByVal pq As PrintQueue) As PageContent
			Dim pageContent As New PageContent()
			Dim fixedPage As New FixedPage()
			fixedPage.Background = Brushes.BlanchedAlmond

			Dim bitmapImage As New BitmapImage(New Uri(_contentDir & "\tiger.jpg", UriKind.RelativeOrAbsolute))

			Dim image As New Image()
			image.Source = bitmapImage
			Canvas.SetTop(image, 0)
			Canvas.SetLeft(image, 0)
			fixedPage.Children.Add(image)

			Dim image2 As New Image()
			image2.Source = bitmapImage
			image2.Opacity = 0.3
			FixedPage.SetTop(image2,150)
			FixedPage.SetLeft(image2,150)
			fixedPage.Children.Add(image2)

			PerformTransform(fixedPage, pq)

			CType(pageContent, IAddChild).AddChild(fixedPage)

			Dim pageWidth As Double = 96 * 8.5
			Dim pageHeight As Double = 96 * 11

			fixedPage.Width = pageWidth
			fixedPage.Height = pageHeight

			Return pageContent
		End Function ' end:CreateFourthPageContent()


		' --------------------- CreateFifthPageContent -----------------------
		''' <summary>
		'''   Creates the content for the fifth fixed page.</summary>
		''' <param name="pq">
		'''   The print queue to output to.</param>
		''' <returns>
		'''   The page content for the fifth fixed page.</returns>
		Private Function CreateFifthPageContent(ByVal pq As PrintQueue) As PageContent
			Dim pageContent As New PageContent()
			Dim fixedPage As New FixedPage()
			Dim visual As UIElement = CreateThirdVisual(False)

			FixedPage.SetLeft(visual, 0)
			FixedPage.SetTop(visual, 0)

			Dim pageWidth As Double = 96 * 8.5
			Dim pageHeight As Double = 96 * 11

			fixedPage.Width = pageWidth
			fixedPage.Height = pageHeight

			fixedPage.Children.Add(CType(visual, UIElement))

			PerformTransform(fixedPage, pq)

			CType(pageContent, IAddChild).AddChild(fixedPage)
			Return pageContent
		End Function ' end:CreateFifthPageContent()


		' ------------------------- PerformTransform -------------------------
		''' <summary>
		'''   Computes the render transfer for outputting a
		'''   given fixed page to a specified print queue.</summary>
		''' <param name="fp">
		'''   The fixed page to computer the render transform for.</param>
		''' <param name="fp">
		'''   The print queue that the page will be output to.</param>
		Private Sub PerformTransform(ByRef fp As FixedPage, ByVal pq As PrintQueue)
			Const inch As Double = 96

			' Getting margins
			Dim xMargin As Double = 1.25 * inch
			Dim yMargin As Double = 1 * inch

			Dim pt As PrintTicket = pq.UserPrintTicket
			Dim printableWidth As Double = pt.PageMediaSize.Width.Value
			Dim printableHeight As Double = pt.PageMediaSize.Height.Value

			Dim xScale As Double = (printableWidth - xMargin * 2) / printableWidth
			Dim yScale As Double = (printableHeight - yMargin * 2) / printableHeight

			fp.RenderTransform = New MatrixTransform(xScale, 0, 0, yScale, xMargin, yMargin)
		End Sub

		#End Region ' Create FixedPage methods


		' ---------------------------- SetEllipse ----------------------------
		''' <summary>
		'''   Sets the default dimensions for the sample ellipse.</summary>
		''' <param name="shape">The ellipse shape attributes.</param>
		''' <param name="cx">The width of the ellipse.</param>
		''' <param name="cy">The height of the ellipse</param>
		''' <param name="rx">The width of the pen.</param>
		''' <param name="ry">The height of the pen.</param>
		Private Sub SetEllipse(ByVal shape As Ellipse, ByVal cx As Double, ByVal cy As Double, ByVal rx As Double, ByVal ry As Double)
			Dim thick As New Thickness()
			thick.Left = cx - rx
			thick.Top = cy - ry

			shape.Margin = thick
			shape.Width = rx * 2
			shape.Height = ry * 2
		End Sub


		' --------------------- AdjustFlowDocumentToPage ---------------------
		''' <summary>
		'''   Fits a given flow document to a specified media size.</summary>
		''' <param name="ipd">
		'''   The document paginator containing the flow document.</param>
		''' <param name="pq">
		'''   The print queue the document will be output to.
		Public Function AdjustFlowDocumentToPage(ByVal idp As DocumentPaginator, ByVal pq As PrintQueue) As Visual
			Const inch As Double = 96

			Dim pt As PrintTicket = pq.UserPrintTicket

			' Get the media size.
			Dim width As Double = pt.PageMediaSize.Width.Value
			Dim height As Double = pt.PageMediaSize.Height.Value

			' Set the margins.
			Dim leftmargin As Double = 1.25 * inch
			Dim rightmargin As Double = 1.25 * inch
			Dim topmargin As Double = 1 * inch
			Dim bottommargin As Double = 1 * inch

			' Calculate the content size.
			Dim contentwidth As Double = width - leftmargin - rightmargin
			Dim contentheight As Double = height - topmargin - bottommargin
			idp.PageSize = New Size(contentwidth, contentheight)

			Dim p As DocumentPage = idp.GetPage(0)

			' Create a wrapper visual for transformation and add extras.
			Dim page As New ContainerVisual()

			page.Children.Add(p.Visual)

			Dim title As New DrawingVisual()

			Using ctx As DrawingContext = title.RenderOpen()
				Dim typeface As New Typeface("Times New Roman")
				Dim pen As Brush = Brushes.Black
				Dim text As New FormattedText("Page 0", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, typeface, 14, pen)

				ctx.DrawText(text, New Point(inch / 4, -inch / 2))
			End Using

			page.Children.Add(title)
			page.Transform = New TranslateTransform(leftmargin, topmargin)

			Return page
		End Function ' end:AdjustFlowDocumentToPage()


		#Region "private members"

		' Text strings for samples.
		Private Shared String1 As String = "No scene from prehistory is quite so vivid as that of the mortal struggles"
		Private Shared String2 As String = "of great beasts in the tar pits. In the mind's eye one sees dinosaurs,"
		Private Shared String3 As String = " mammoths, and sabertoothed tigers struggling against the grip of the tar."
		Private Shared String4 As String = "The fiercer the struggle, the more entangling the tar, and no"
		Private Shared String5 As String = "beast is so strong or so skillful but that he ultimately sinks."

		Private Shared _paragraphText As String = "The story which follows was first written out in Paris " & "during the Peace Conference, from notes jotted daily on " & "the march, strengthened by some reports sent to my chiefs in " & "Cairo. Afterwards, in the autumn of 1919, this first draft " & "and some of the notes were lost. It seemed to me historically " & "needful to reproduce the tale, as perhaps no one but myself " & "in Feisal's army had thought of writing down at the time what " & "we felt, what we hoped, what we tried. So it was built again " & "with heavy repugnance in London in the winter of 1919-20 from " & "memory and my surviving notes. The record of events was not " & "dulled in me and perhaps few actual mistakes crept in - " & "except in details of dates or numbers - but the outlines and " & "significance of things had lost edge in the haze of new interests."

		Private _contentDir As String

		#End Region ' private members

	End Class

End Namespace ' end:namespace SDKSampleHelper
