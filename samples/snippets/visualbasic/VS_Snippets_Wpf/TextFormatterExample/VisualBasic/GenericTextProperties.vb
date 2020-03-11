Imports System.Globalization
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.TextFormatting

Namespace SDKSamples
   ''' <summary>
   ''' Class to implement TextParagraphProperties, used by TextSource
   ''' </summary>
   Friend Class GenericTextParagraphProperties
	   Inherits TextParagraphProperties
	  #Region "Constructors"
	  Public Sub New(ByVal flowDirection As FlowDirection, ByVal textAlignment As TextAlignment, ByVal firstLineInParagraph As Boolean, ByVal alwaysCollapsible As Boolean, ByVal defaultTextRunProperties As TextRunProperties, ByVal textWrap As TextWrapping, ByVal lineHeight As Double, ByVal indent As Double)
		 _flowDirection = flowDirection
		 _textAlignment = textAlignment
		 _firstLineInParagraph = firstLineInParagraph
		 _alwaysCollapsible = alwaysCollapsible
		 _defaultTextRunProperties = defaultTextRunProperties
		 _textWrap = textWrap
		 _lineHeight = lineHeight
		 _indent = indent
	  End Sub

	  Public Sub New(ByVal newRendering As FontRendering)
		 _flowDirection = FlowDirection.LeftToRight
		 _textAlignment = newRendering.TextAlignment
		 _firstLineInParagraph = False
		 _alwaysCollapsible = False
		 _defaultTextRunProperties = New GenericTextRunProperties(newRendering.Typeface, newRendering.FontSize, newRendering.FontSize, newRendering.TextDecorations, newRendering.TextColor, Nothing, BaselineAlignment.Baseline, CultureInfo.CurrentUICulture)
		 _textWrap = TextWrapping.Wrap
		 _lineHeight = 0
		 _indent = 0
		 _paragraphIndent = 0
	  End Sub
	  #End Region

	  #Region "Properties"
	  Public Overrides ReadOnly Property FlowDirection() As FlowDirection
		 Get
			 Return _flowDirection
		 End Get
	  End Property

	  Public Overrides ReadOnly Property TextAlignment() As TextAlignment
		 Get
			 Return _textAlignment
		 End Get
	  End Property

	  Public Overrides ReadOnly Property FirstLineInParagraph() As Boolean
		 Get
			 Return _firstLineInParagraph
		 End Get
	  End Property

	  Public Overrides ReadOnly Property AlwaysCollapsible() As Boolean
		 Get
			 Return _alwaysCollapsible
		 End Get
	  End Property

	  Public Overrides ReadOnly Property DefaultTextRunProperties() As TextRunProperties
		 Get
			 Return _defaultTextRunProperties
		 End Get
	  End Property

	  Public Overrides ReadOnly Property TextWrapping() As TextWrapping
		 Get
			 Return _textWrap
		 End Get
	  End Property

	  Public Overrides ReadOnly Property LineHeight() As Double
		 Get
			 Return _lineHeight
		 End Get
	  End Property

	  Public Overrides ReadOnly Property Indent() As Double
		 Get
			 Return _indent
		 End Get
	  End Property

	  Public Overrides ReadOnly Property TextMarkerProperties() As TextMarkerProperties
		 Get
			 Return Nothing
		 End Get
	  End Property

	  Public Overrides ReadOnly Property ParagraphIndent() As Double
		 Get
			 Return _paragraphIndent
		 End Get
	  End Property
#End Region

	  #Region "Private Fields"
	  Private _flowDirection As FlowDirection
	  Private _textAlignment As TextAlignment
	  Private _firstLineInParagraph As Boolean
	  Private _alwaysCollapsible As Boolean
	  Private _defaultTextRunProperties As TextRunProperties
	  Private _textWrap As TextWrapping
	  Private _indent As Double
	  Private _paragraphIndent As Double
	  Private _lineHeight As Double
	  #End Region
   End Class

   ''' <summary>
   ''' Class used to implement TextRunProperties
   ''' </summary>
   Friend Class GenericTextRunProperties
	   Inherits TextRunProperties
	  #Region "Constructors"
	  Public Sub New(ByVal typeface As Typeface, ByVal size As Double, ByVal hintingSize As Double, ByVal textDecorations As TextDecorationCollection, ByVal forgroundBrush As Brush, ByVal backgroundBrush As Brush, ByVal baselineAlignment As BaselineAlignment, ByVal culture As CultureInfo)
		 If typeface Is Nothing Then
			Throw New ArgumentNullException("typeface")
		 End If

		 ValidateCulture(culture)


		 _typeface = typeface
		 _emSize = size
		 _emHintingSize = hintingSize
		 _textDecorations = textDecorations
		 _foregroundBrush = forgroundBrush
		 _backgroundBrush = backgroundBrush
		 _baselineAlignment = baselineAlignment
		 _culture = culture
	  End Sub

	  Public Sub New(ByVal newRender As FontRendering)
		 _typeface = newRender.Typeface
		 _emSize = newRender.FontSize
		 _emHintingSize = newRender.FontSize
		 _textDecorations = newRender.TextDecorations
		 _foregroundBrush = newRender.TextColor
		 _backgroundBrush = Nothing
		 _baselineAlignment = BaselineAlignment.Baseline
		 _culture = CultureInfo.CurrentUICulture
	  End Sub
	  #End Region

	  #Region "Private Methods"
	  Private Shared Sub ValidateCulture(ByVal culture As CultureInfo)
		 If culture Is Nothing Then
			Throw New ArgumentNullException("culture")
		 End If
            If culture.IsNeutralCulture OrElse culture.Equals(Globalization.CultureInfo.InvariantCulture) Then
                Throw New ArgumentException("Specific Culture Required", "culture")
            End If
	  End Sub

	  Private Shared Sub ValidateFontSize(ByVal emSize As Double)
		 If emSize <= 0 Then
			Throw New ArgumentOutOfRangeException("emSize", "Parameter Must Be Greater Than Zero.")
		 End If
		 'if (emSize > MaxFontEmSize)
		 '   Throw New ArgumentOutOfRangeException("emSize", "Parameter Is Too Large.")
		 If Double.IsNaN(emSize) Then
			Throw New ArgumentOutOfRangeException("emSize", "Parameter Cannot Be NaN.")
		 End If
	  End Sub
	  #End Region

	  #Region "Properties"
	  Public Overrides ReadOnly Property Typeface() As Typeface
		 Get
			 Return _typeface
		 End Get
	  End Property

	  Public Overrides ReadOnly Property FontRenderingEmSize() As Double
		  Get
			  Return _emSize
		  End Get
	  End Property

	  Public Overrides ReadOnly Property FontHintingEmSize() As Double
		 Get
			 Return _emHintingSize
		 End Get
	  End Property

	  Public Overrides ReadOnly Property TextDecorations() As TextDecorationCollection
		 Get
			 Return _textDecorations
		 End Get
	  End Property

	  Public Overrides ReadOnly Property ForegroundBrush() As Brush
		 Get
			 Return _foregroundBrush
		 End Get
	  End Property

	  Public Overrides ReadOnly Property BackgroundBrush() As Brush
		 Get
			 Return _backgroundBrush
		 End Get
	  End Property

	  Public Overrides ReadOnly Property BaselineAlignment() As BaselineAlignment
		 Get
			 Return _baselineAlignment
		 End Get
	  End Property

	  Public Overrides ReadOnly Property CultureInfo() As CultureInfo
		 Get
			 Return _culture
		 End Get
	  End Property

	  Public Overrides ReadOnly Property TypographyProperties() As TextRunTypographyProperties
		 Get
			 Return Nothing
		 End Get
	  End Property

	  Public Overrides ReadOnly Property TextEffects() As TextEffectCollection
		 Get
			 Return Nothing
		 End Get
	  End Property

	  Public Overrides ReadOnly Property NumberSubstitution() As NumberSubstitution
		 Get
			 Return Nothing
		 End Get
	  End Property
	  #End Region

	  #Region "Private Fields"
	  Private _typeface As Typeface
	  Private _emSize As Double
	  Private _emHintingSize As Double
	  Private _textDecorations As TextDecorationCollection
	  Private _foregroundBrush As Brush
	  Private _backgroundBrush As Brush
	  Private _baselineAlignment As BaselineAlignment
	  Private _culture As CultureInfo
	  #End Region
   End Class
End Namespace