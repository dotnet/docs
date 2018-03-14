' XpsSave SDK Sample - XpfContent.vb
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This file provides the methods for creating the default
' DocumentViewer content used by the XpsSave SDK sample.


Imports System
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
Imports SDKSample


Namespace SDKSampleHelper
	' -------------------------- class XPFContent ----------------------------
	''' <summary>
	'''   Generating content in memory for the SDK sample
	'''   (Visuals, FixedPages, and FixedDocuments). </summary>
	''' <remarks>
	'''   The PrintHelper class calls XPFCpntent to create
	'''   all of the media for in the documents.</remarks>
	Friend Class XPFContent
		' ---------------------- XPFContent constructor ----------------------
		''' <summary>
		'''   Initialize a new instance of the XPFContent class.</summary>
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

			' Add a rectangle to the page
			Dim firstRectangle As New Rectangle()
			firstRectangle.Fill = New SolidColorBrush(Colors.Red)
			Dim thick As New Thickness()
			thick.Left = 150
			thick.Top = 150
			firstRectangle.Margin = thick
			firstRectangle.Width = 300
			firstRectangle.Height = 300
			canvas1.Children.Add(firstRectangle)
			'_visual = firstRectangle

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

			' Adding a Polygon
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


		'<SnippetXpsSaveCreateFixedDocPages>
		' ------------------- CreateFixedDocumentWithPages -------------------
		''' <summary>
		'''   Creates a FixedDocument with fixed pages.</summary>
		''' <returns>
		'''   A FixedDocument containing fixed pages.</returns>
		Public Function CreateFixedDocumentWithPages() As FixedDocument
			' Create a FixedDocument
			Dim fixedDocument As FixedDocument = CreateFixedDocument()

			' Add Page 1 to a fixed document
			Dim page1Content As PageContent = CreateFirstPageContent()
			fixedDocument.Pages.Add(page1Content)

			' Adding Page 2 to a fixed document
			Dim page2Content As PageContent = CreateSecondPageContent()
			fixedDocument.Pages.Add(page2Content)

			' Adding Page 3 to a fixed document
			Dim page3Content As PageContent = CreateThirdPageContent()
			fixedDocument.Pages.Add(page3Content)

			' Adding Page 4 to a fixed document;
			Dim page4Content As PageContent = CreateFourthPageContent()
			fixedDocument.Pages.Add(page4Content)

			' Adding Page 5 to a fixed document;
			Dim page5Content As PageContent = CreateFifthPageContent()
			fixedDocument.Pages.Add(page5Content)

			Return fixedDocument
		End Function ' end:CreateFixedDocumentWithPages()
		'</SnippetXpsSaveCreateFixedDocPages>


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


		'<SnippetXpsSaveLoadFixedDocSeq>
		'--------------- LoadFixedDocumentSequenceFromDocument ---------------
		''' <summary>
		'''   Returns the FixedDocumentSequence from the sample
		'''   ViewFixedDocumentSequence.xps document.</summary>
		''' <returns>
		'''   FixedDocumentSequence from ViewFixedDocumentSequence.xps.</returns>
		Public Function LoadFixedDocumentSequenceFromDocument() As FixedDocumentSequence
			Dim fullPath As String = _contentDir & "\ViewFixedDocumentSequence.xps"

			Dim xpsPackage As New XpsDocument(fullPath, FileAccess.Read, CompressionOption.NotCompressed)

			Dim fixedDocumentSequence As FixedDocumentSequence = xpsPackage.GetFixedDocumentSequence()

			Return fixedDocumentSequence
		End Function
		'</SnippetXpsSaveLoadFixedDocSeq>


		'<SnippetCreateFixedDocument>
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
		'</SnippetCreateFixedDocument>


		#Region "Create FixedPage methods"
		' ---------------------- CreateFirstPageContent ----------------------
		''' <summary>
		'''   Creates the content for the first fixed page.</summary>
		''' <returns>
		'''   The page content for the first fixed page.</returns>
		Private Function CreateFirstPageContent() As PageContent
			Dim pageContent As New PageContent()
			Dim fixedPage As FixedPage = CreateFirstFixedPage()
			CType(pageContent, IAddChild).AddChild(fixedPage)
			Return pageContent
		End Function


		'<SnippetXpsSaveCreateFixedPage1>
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

			Dim sz As New Size(8.5 * 96, 11 * 96)
			fixedPage.Measure(sz)
			fixedPage.Arrange(New Rect(New Point(), sz))
			fixedPage.UpdateLayout()

			Return fixedPage
		End Function ' end:CreateFirstFixedPage()
		'</SnippetXpsSaveCreateFixedPage1>


		' --------------------- CreateSecondPageContent ----------------------
		''' <summary>
		'''   Creates the content for the second fixed page.</summary>
		''' <returns>
		'''   The page content for the second fixed page.</returns>
		Private Function CreateSecondPageContent() As PageContent
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

			Dim sz As New Size(8.5 * 96, 11 * 96)
			fixedPage.Measure(sz)
			fixedPage.Arrange(New Rect(New Point(), sz))
			fixedPage.UpdateLayout()

			CType(pageContent, IAddChild).AddChild(fixedPage)
			Return pageContent
		End Function ' end:CreateSecondPageContent()


		' --------------------- CreateThirdPageContent -----------------------
		''' <summary>
		'''   Creates the content for the third fixed page.</summary>
		''' <returns>
		'''   The page content for the third fixed page.</returns>
		Public Function CreateThirdPageContent() As PageContent
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

			Dim sz As New Size(8.5 * 96, 11 * 96)
			fixedPage.Measure(sz)
			fixedPage.Arrange(New Rect(New Point(), sz))
			fixedPage.UpdateLayout()

			CType(pageContent, IAddChild).AddChild(fixedPage)
			Return pageContent
		End Function ' end:CreateThirdPageContent()


		' --------------------- CreateFourthPageContent ----------------------
		''' <summary>
		'''   Creates the content for the fourth fixed page.</summary>
		''' <returns>
		'''   The page content for the fourth fixed page.</returns>
		Private Function CreateFourthPageContent() As PageContent
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

			CType(pageContent, IAddChild).AddChild(fixedPage)

			Dim pageWidth As Double = 96 * 8.5
			Dim pageHeight As Double = 96 * 11

			fixedPage.Width = pageWidth
			fixedPage.Height = pageHeight

			Dim sz As New Size(8.5 * 96, 11 * 96)

			fixedPage.Measure(sz)
			fixedPage.Arrange(New Rect(New Point(), sz))
			fixedPage.UpdateLayout()

			Return pageContent
		End Function ' end:CreateFourthPageContent()


		'<SnippetXpsSaveCreateFixedPage5>
		' --------------------- CreateFifthPageContent -----------------------
		''' <summary>
		'''   Creates the content for the fifth fixed page.</summary>
		''' <returns>
		'''   The page content for the fifth fixed page.</returns>
		Private Function CreateFifthPageContent() As PageContent
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

			Dim sz As New Size(8.5 * 96, 11 * 96)
			fixedPage.Measure(sz)
			fixedPage.Arrange(New Rect(New Point(), sz))
			fixedPage.UpdateLayout()

			CType(pageContent, IAddChild).AddChild(fixedPage)
			Return pageContent
		End Function ' end:CreateFifthPageContent()
		'</SnippetXpsSaveCreateFixedPage5>
		#End Region ' Create FixedPage methods


		' ---------------------------- SetEllipse ----------------------------
		'
		' Set Ellipse dimensions.
		'
		''' <summary>
		'''   Sets the default dimensions of a sample ellipse.</summary>
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
		End Sub ' end:SetEllipse()


		#Region "private members"

		Private _contentDir As String ' Path to the \Content folder

		' Text strings for samples.
		Private Shared String1 As String = "No scene from prehistory is quite so vivid as that of the mortal struggles"
		Private Shared String2 As String = "of great beasts in the tar pits. In the mind's eye one sees dinosaurs,"
		Private Shared String3 As String = " mammoths, and sabertoothed tigers struggling against the grip of the tar."
		Private Shared String4 As String = "The fiercer the struggle, the more entangling the tar, and no"
		Private Shared String5 As String = "beast is so strong or so skillful but that he ultimately sinks."

		Private Shared _paragraphText As String = "The story which follows was first written out in Paris " & "during the Peace Conference, from notes jotted daily on " & "the march, strengthened by some reports sent to my chiefs in " & "Cairo. Afterwards, in the autumn of 1919, this first draft " & "and some of the notes were lost. It seemed to me historically " & "needful to reproduce the tale, as perhaps no one but myself " & "in Feisal's army had thought of writing down at the time what " & "we felt, what we hoped, what we tried. So it was built again " & "with heavy repugnance in London in the winter of 1919-20 from " & "memory and my surviving notes. The record of events was not " & "dulled in me and perhaps few actual mistakes crept in - " & "except in details of dates or numbers - but the outlines and " & "significance of things had lost edge in the haze of new interestz."

		#End Region ' private members

	End Class 'end:class XPFContent

End Namespace ' end:namespace SDKSampleHelper
