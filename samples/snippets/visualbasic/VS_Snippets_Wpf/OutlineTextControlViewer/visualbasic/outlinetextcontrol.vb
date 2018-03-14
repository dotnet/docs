Imports System.Globalization


Namespace OutlineText
	''' <summary>
	''' OutlineText custom control class derives layout, event, data binding, and rendering from derived FrameworkElement class.
	''' </summary>
	Public Class OutlineTextControl
		Inherits FrameworkElement
		#Region "Private Fields"

		Private _textGeometry As Geometry
		Private _textHighLightGeometry As Geometry

		#End Region

		#Region "Private Methods"

		''' <summary>
		''' Invoked when a dependency property has changed. Generate a new FormattedText object to display.
		''' </summary>
		''' <param name="d">OutlineText object whose property was updated.</param>
		''' <param name="e">Event arguments for the dependency property.</param>
		Private Shared Sub OnOutlineTextInvalidated(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			CType(d, OutlineTextControl).CreateText()
		End Sub

		#End Region

		#Region "FrameworkElement Overrides"
'<SnippetOnRender>
		''' <summary>
		''' OnRender override draws the geometry of the text and optional highlight.
		''' </summary>
		''' <param name="drawingContext">Drawing context of the OutlineText control.</param>
		Protected Overrides Sub OnRender(ByVal drawingContext As DrawingContext)
			' Draw the outline based on the properties that are set.
			drawingContext.DrawGeometry(Fill, New Pen(Stroke, StrokeThickness), _textGeometry)

			' Draw the text highlight based on the properties that are set.
			If Highlight = True Then
				drawingContext.DrawGeometry(Nothing, New Pen(Stroke, StrokeThickness), _textHighLightGeometry)
			End If
		End Sub
'</SnippetOnRender>
'<SnippetCreateText>
		''' <summary>
		''' Create the outline geometry based on the formatted text.
		''' </summary>
		Public Sub CreateText()
			Dim fontStyle As FontStyle = FontStyles.Normal
			Dim fontWeight As FontWeight = FontWeights.Medium

			If Bold = True Then
				fontWeight = FontWeights.Bold
			End If
			If Italic = True Then
				fontStyle = FontStyles.Italic
			End If

			' Create the formatted text based on the properties set.
			Dim formattedText As New FormattedText(Text, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface(Font, fontStyle, fontWeight, FontStretches.Normal), FontSize, Brushes.Black) ' This brush does not matter since we use the geometry of the text.

			' Build the geometry object that represents the text.
			_textGeometry = formattedText.BuildGeometry(New Point(0, 0))

			' Build the geometry object that represents the text hightlight.
			If Highlight = True Then
				_textHighLightGeometry = formattedText.BuildHighlightGeometry(New Point(0, 0))
			End If
		End Sub
  '</SnippetCreateText>      
		#End Region

		#Region "DependencyProperties"

		''' <summary>
		''' Specifies whether the font should display Bold font weight.
		''' </summary>
		Public Property Bold() As Boolean
			Get
				Return CBool(GetValue(BoldProperty))
			End Get

			Set(ByVal value As Boolean)
				SetValue(BoldProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the Bold dependency property.
		''' </summary>
		Public Shared ReadOnly BoldProperty As DependencyProperty = DependencyProperty.Register("Bold", GetType(Boolean), GetType(OutlineTextControl), New FrameworkPropertyMetadata(False, FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		''' <summary>
		''' Specifies the brush to use for the fill of the formatted text.
		''' </summary>
		Public Property Fill() As Brush
			Get
				Return CType(GetValue(FillProperty), Brush)
			End Get

			Set(ByVal value As Brush)
				SetValue(FillProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the Fill dependency property.
		''' </summary>
		Public Shared ReadOnly FillProperty As DependencyProperty = DependencyProperty.Register("Fill", GetType(Brush), GetType(OutlineTextControl), New FrameworkPropertyMetadata(New SolidColorBrush(Colors.LightSteelBlue), FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		''' <summary>
		''' The font to use for the displayed formatted text.
		''' </summary>
		Public Property Font() As FontFamily
			Get
				Return CType(GetValue(FontProperty), FontFamily)
			End Get

			Set(ByVal value As FontFamily)
				SetValue(FontProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the Font dependency property.
		''' </summary>
		Public Shared ReadOnly FontProperty As DependencyProperty = DependencyProperty.Register("Font", GetType(FontFamily), GetType(OutlineTextControl), New FrameworkPropertyMetadata(New FontFamily("Arial"), FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		''' <summary>
		''' The current font size.
		''' </summary>
		Public Property FontSize() As Double
			Get
				Return CDbl(GetValue(FontSizeProperty))
			End Get

			Set(ByVal value As Double)
				SetValue(FontSizeProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the FontSize dependency property.
		''' </summary>
		Public Shared ReadOnly FontSizeProperty As DependencyProperty = DependencyProperty.Register("FontSize", GetType(Double), GetType(OutlineTextControl), New FrameworkPropertyMetadata(CDbl(48.0), FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		''' <summary>
		''' Specifies whether to show the text highlight.
		''' </summary>
		Public Property Highlight() As Boolean
			Get
				Return CBool(GetValue(HighlightProperty))
			End Get

			Set(ByVal value As Boolean)
				SetValue(HighlightProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the Hightlight dependency property.
		''' </summary>
		Public Shared ReadOnly HighlightProperty As DependencyProperty = DependencyProperty.Register("Highlight", GetType(Boolean), GetType(OutlineTextControl), New FrameworkPropertyMetadata(False, FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		''' <summary>
		''' Specifies whether the font should display Italic font style.
		''' </summary>
		Public Property Italic() As Boolean
			Get
				Return CBool(GetValue(ItalicProperty))
			End Get

			Set(ByVal value As Boolean)
				SetValue(ItalicProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the Italic dependency property.
		''' </summary>
		Public Shared ReadOnly ItalicProperty As DependencyProperty = DependencyProperty.Register("Italic", GetType(Boolean), GetType(OutlineTextControl), New FrameworkPropertyMetadata(False, FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		''' <summary>
		''' Specifies the brush to use for the stroke and optional hightlight of the formatted text.
		''' </summary>
		Public Property Stroke() As Brush
			Get
				Return CType(GetValue(StrokeProperty), Brush)
			End Get

			Set(ByVal value As Brush)
				SetValue(StrokeProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the Stroke dependency property.
		''' </summary>
		Public Shared ReadOnly StrokeProperty As DependencyProperty = DependencyProperty.Register("Stroke", GetType(Brush), GetType(OutlineTextControl), New FrameworkPropertyMetadata(New SolidColorBrush(Colors.Teal), FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		''' <summary>
		'''     The stroke thickness of the font.
		''' </summary>
		Public Property StrokeThickness() As UShort
			Get
				Return CUShort(GetValue(StrokeThicknessProperty))
			End Get

			Set(ByVal value As UShort)
				SetValue(StrokeThicknessProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the StrokeThickness dependency property.
		''' </summary>
		Public Shared ReadOnly StrokeThicknessProperty As DependencyProperty = DependencyProperty.Register("StrokeThickness", GetType(UShort), GetType(OutlineTextControl), New FrameworkPropertyMetadata(CUShort(0), FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		''' <summary>
		''' Specifies the text string to display.
		''' </summary>
		Public Property Text() As String
			Get
				Return CStr(GetValue(TextProperty))
			End Get

			Set(ByVal value As String)
				SetValue(TextProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the Text dependency property.
		''' </summary>
		Public Shared ReadOnly TextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(String), GetType(OutlineTextControl), New FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnOutlineTextInvalidated), Nothing))

		#End Region
	End Class
End Namespace
