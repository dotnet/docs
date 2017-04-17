Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.TextFormatting

Namespace SDKSamples
   ''' <summary>
   ''' Class for combining Font and other text related properties. 
   ''' (Typeface, Alignment, Decorations, etc)
   ''' </summary>
   Friend Class FontRendering
	  #Region "Constructors"
	  Public Sub New(ByVal emSize As Double, ByVal alignment As TextAlignment, ByVal decorations As TextDecorationCollection, ByVal textColor As Brush, ByVal face As Typeface)
		 _fontSize = emSize
		 _alignment = alignment
		 _textDecorations = decorations
		 _textColor = textColor
		 _typeface = face
	  End Sub

	  Public Sub New()
		 _fontSize = 12.0f
		 _alignment = TextAlignment.Left
		 _textDecorations = New TextDecorationCollection()
		 _textColor = Brushes.Black
		 _typeface = New Typeface(New FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal)
	  End Sub
	  #End Region

	  #Region "Properties"
	  Public Property FontSize() As Double
		 Get
			 Return _fontSize
		 End Get
		 Set(ByVal value As Double)
			If value <= 0 Then
			   Throw New ArgumentOutOfRangeException("value", "Parameter Must Be Greater Than Zero.")
			End If
			If Double.IsNaN(value) Then
			   Throw New ArgumentOutOfRangeException("value", "Parameter Cannot Be NaN.")
			End If
			_fontSize = value
		 End Set
	  End Property

	  Public Property TextAlignment() As TextAlignment
		 Get
			 Return _alignment
		 End Get
		 Set(ByVal value As TextAlignment)
			 _alignment = value
		 End Set
	  End Property

	  Public Property TextDecorations() As TextDecorationCollection
		 Get
			 Return _textDecorations
		 End Get
		 Set(ByVal value As TextDecorationCollection)
			 _textDecorations = value
		 End Set
	  End Property

	  Public Property TextColor() As Brush
		 Get
			 Return _textColor
		 End Get
		 Set(ByVal value As Brush)
			 _textColor = value
		 End Set
	  End Property

	  Public Property Typeface() As Typeface
		 Get
			 Return _typeface
		 End Get
		 Set(ByVal value As Typeface)
			 _typeface = value
		 End Set
	  End Property
	  #End Region

	  #Region "Private Fields"
	  Private _fontSize As Double
	  Private _alignment As TextAlignment
	  Private _textDecorations As TextDecorationCollection
	  Private _textColor As Brush
	  Private _typeface As Typeface
	  #End Region
   End Class
End Namespace
