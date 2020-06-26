Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media
Imports System.Windows.Media.TextFormatting


Namespace SDKSamples
   Partial Public Class Window1
	   Inherits Window
	  Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
		 ' Enumerate the fonts and add them to the font family combobox.
		 For Each fontFamily As System.Windows.Media.FontFamily In Fonts.SystemFontFamilies
			fontFamilyCB.Items.Add(fontFamily.Source)
		 Next fontFamily
		 fontFamilyCB.SelectedIndex = 7

		 ' Load the font size combo box with common font sizes.
		 For i As Integer = 0 To CommonFontSizes.Length - 1
			fontSizeCB.Items.Add(CommonFontSizes(i))
		 Next i
		 fontSizeCB.SelectedIndex = 21

		 'Load capitals combo box
		 typographyMenuBar.Visibility = Visibility.Collapsed

		 'Set up the initial render state of the drawn text.
		 If _currentRendering Is Nothing Then
			_currentRendering = New FontRendering(CDbl(fontSizeCB.SelectedItem), TextAlignment.Left, Nothing, System.Windows.Media.Brushes.Black, New Typeface("Arial"))
		 End If

		 ' Initialize the text store.
		 If _textStore Is Nothing Then
			_textStore = New CustomTextSource()
		 End If

		 _UILoaded = True 'All UI is loaded, can handle events now
		 UpdateFormattedText()
	  End Sub

	  ''' <summary>
	  ''' Method for starting the text formatting process. Each event handler
	  ''' will call this after the current fontrendering is updated.
	  ''' </summary>
	  Private Sub UpdateFormattedText()
		 ' Make sure all UI is loaded
		 If Not _UILoaded Then
			Return
		 End If

		 Dim textStorePosition As Integer = 0 'Index into the text of the textsource
		 Dim linePosition As New System.Windows.Point(0, 0) 'current line

		 '<Snippet100>
		 ' Create a DrawingGroup object for storing formatted text.
		 textDest = New DrawingGroup()
		 Dim dc As DrawingContext = textDest.Open()

		 ' Update the text store.
		 _textStore.Text = textToFormat.Text
		 _textStore.FontRendering = _currentRendering

		 ' Create a TextFormatter object.
		 Dim formatter As TextFormatter = TextFormatter.Create()

		 ' Format each line of text from the text store and draw it.
		 Do While textStorePosition < _textStore.Text.Length
			' Create a textline from the text store using the TextFormatter object.
			Using myTextLine As TextLine = formatter.FormatLine(_textStore, textStorePosition, 96*6, New GenericTextParagraphProperties(_currentRendering), Nothing)
				' Draw the formatted text into the drawing context.
				myTextLine.Draw(dc, linePosition, InvertAxes.None)

				' Update the index position in the text store.
				textStorePosition += myTextLine.Length

				' Update the line position coordinate for the displayed line.
				linePosition.Y += myTextLine.Height
			End Using
		 Loop

		 ' Persist the drawn text content.
		 dc.Close()

		 ' Display the formatted text in the DrawingGroup object.
		 myDrawingBrush.Drawing = textDest
		 '</Snippet100>
	  End Sub

	  ''' <summary>
	  ''' Event handler for when the user selects a new font size
	  ''' </summary>
	  ''' <param name="sender"></param>
	  ''' <param name="e"></param>
	  Private Sub FontSizeChangedEventHandler(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
		 ' Make sure all UI is loaded
		 If Not _UILoaded Then
			Return
		 End If

		 ' Determine whether a new font size has been selected.
		 If _currentRendering.FontSize <> CDbl(fontSizeCB.SelectedItem) Then
			_currentRendering.FontSize = CDbl(fontSizeCB.SelectedItem)
			UpdateFormattedText()
		 End If
	  End Sub

	  ''' <summary>
	  ''' Event handler for when the user selects a new font family
	  ''' </summary>
	  ''' <param name="sender"></param>
	  ''' <param name="e"></param>
	  Private Sub FontFamilyChangedEventHandler(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
		 ' Make sure all UI is loaded
		 If Not _UILoaded Then
			Return
		 End If

		' Determine whether a new font family has been selected.
		 If _currentRendering.Typeface.FontFamily.Source <> CStr(fontFamilyCB.SelectedItem) Then
			Dim oldFace As Typeface = _currentRendering.Typeface
			Dim newFace As New Typeface(New System.Windows.Media.FontFamily(CStr(fontFamilyCB.SelectedItem)), oldFace.Style, oldFace.Weight, oldFace.Stretch)

			_currentRendering.Typeface = newFace
			UpdateFormattedText()
		 End If
	  End Sub

	  ''' <summary>
	  ''' Event handler for when the bold button is clicked.
	  ''' </summary>
	  ''' <param name="sender"></param>
	  ''' <param name="e"></param>
	  Private Sub BoldClickedEventHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
		 ' Make sure All UI is loaded
		 If Not _UILoaded Then
			Return
		 End If

		 Dim toggle As ToggleButton = TryCast(sender, ToggleButton)

		 Dim oldFace As Typeface = _currentRendering.Typeface
		 Dim newFace As Typeface

		 If toggle.IsChecked = True Then
			newFace = New Typeface(oldFace.FontFamily, oldFace.Style, FontWeights.Bold, oldFace.Stretch)
		 Else
			newFace = New Typeface(oldFace.FontFamily, oldFace.Style, FontWeights.Normal, oldFace.Stretch)
		 End If
		 _currentRendering.Typeface = newFace
		 UpdateFormattedText()
	  End Sub

	  ''' <summary>
	  ''' Event handler for when the italic button is selected.
	  ''' </summary>
	  ''' <param name="sender"></param>
	  ''' <param name="e"></param>
	  Private Sub ItalicClickEventHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
		 ' Make sure All UI is loaded
		 If Not _UILoaded Then
			Return
		 End If

		 Dim toggle As ToggleButton = TryCast(sender, ToggleButton)

		 Dim oldFace As Typeface = _currentRendering.Typeface
		 Dim newFace As Typeface

		 If toggle.IsChecked = True Then
			newFace = New Typeface(oldFace.FontFamily, FontStyles.Italic, oldFace.Weight, oldFace.Stretch)
		 Else
			newFace = New Typeface(oldFace.FontFamily, FontStyles.Normal, oldFace.Weight, oldFace.Stretch)
		 End If
		 _currentRendering.Typeface = newFace
		 UpdateFormattedText()
	  End Sub

	  ''' <summary>
	  ''' Event handler for when a new decoration is selected/deselected.
	  ''' </summary>
	  ''' <param name="sender"></param>
	  ''' <param name="e"></param>
	  Private Sub DecorationClickEventHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
		 ' Make sure All UI is loaded
		 If Not _UILoaded Then
			Return
		 End If

		 Dim tds As New TextDecorationCollection()

		 If underlineButton.IsChecked = True Then
			Dim underline As New TextDecoration()
			underline.Location = TextDecorationLocation.Underline
			underline.Pen = New System.Windows.Media.Pen(System.Windows.Media.Brushes.Blue, 1)
			underline.PenThicknessUnit = TextDecorationUnit.FontRecommended
			tds.Add(underline)
		 End If
		 If strikeButton.IsChecked = True Then
			Dim strikethrough As New TextDecoration()
			strikethrough.Location = TextDecorationLocation.Strikethrough
			strikethrough.Pen = New System.Windows.Media.Pen(System.Windows.Media.Brushes.Red, 1)
			strikethrough.PenThicknessUnit = TextDecorationUnit.FontRecommended
			tds.Add(strikethrough)
		 End If
		 _currentRendering.TextDecorations = tds
		 UpdateFormattedText()
	  End Sub

	  ''' <summary>
	  ''' Event handler for text changed events from the textbox
	  ''' </summary>
	  ''' <param name="sender"></param>
	  ''' <param name="e"></param>
	  Private Sub TextChangedEventHandler(ByVal sender As Object, ByVal e As TextChangedEventArgs)
		 'Make sure All UI is loaded
		 If Not _UILoaded Then
			Return
		 End If

		 UpdateFormattedText()
	  End Sub

	  ''' <summary>
	  ''' Event handler for the handling checked events on the Alignment buttons
	  ''' </summary>
	  ''' <param name="sender">The button that was checked.</param>
	  ''' <param name="e">N/A</param>
	  Private Sub AlignmentChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
		 Dim btn As ToggleButton = CType(sender, ToggleButton)

		 ' Make sure All UI is loaded
		 If Not _UILoaded Then
			Return
		 End If
		 ' Ignore all non-checked events.
		 If btn.IsChecked = False Then
			Return
		 End If

		 Select Case btn.Name
			Case ("leftAlign")
			   _currentRendering.TextAlignment = TextAlignment.Left
			   centerAlign.IsChecked = False
			   rightAlign.IsChecked = False
			   justify.IsChecked = False
			Case ("centerAlign")
			   _currentRendering.TextAlignment = TextAlignment.Center
			   leftAlign.IsChecked = False
			   rightAlign.IsChecked = False
			   justify.IsChecked = False
			Case ("rightAlign")
			   _currentRendering.TextAlignment = TextAlignment.Right
			   leftAlign.IsChecked = False
			   centerAlign.IsChecked = False
			   justify.IsChecked = False
			Case ("justify")
			   _currentRendering.TextAlignment = TextAlignment.Justify
			   leftAlign.IsChecked = False
			   centerAlign.IsChecked = False
			   rightAlign.IsChecked = False
		 End Select
		 UpdateFormattedText()
	  End Sub

	  ' Some common font sizes.
	  Public Shared CommonFontSizes() As Double = { 3.0R, 4.0R, 5.0R, 6.0R, 6.5R, 7.0R, 7.5R, 8.0R, 8.5R, 9.0R, 9.5R, 10.0R, 10.5R, 11.0R, 11.5R, 12.0R, 12.5R, 13.0R, 13.5R, 14.0R, 15.0R, 16.0R, 17.0R, 18.0R, 19.0R, 20.0R, 22.0R, 24.0R, 26.0R, 28.0R, 30.0R, 32.0R, 34.0R, 36.0R, 38.0R, 40.0R, 44.0R, 48.0R, 52.0R, 56.0R, 60.0R, 64.0R, 68.0R, 72.0R, 76.0R, 80.0R, 88.0R, 96.0R, 104.0R, 112.0R, 120.0R, 128.0R, 136.0R, 144.0R, 152.0R, 160.0R, 176.0R, 192.0R, 208.0R, 224.0R, 240.0R, 256.0R, 272.0R, 288.0R, 304.0R, 320.0R, 352.0R, 384.0R, 416.0R, 448.0R, 480.0R, 512.0R, 544.0R, 576.0R, 608.0R, 640.0R}

	  Private _currentRendering As FontRendering
	  Private _textStore As CustomTextSource
	  Private _UILoaded As Boolean = False
   End Class
End Namespace