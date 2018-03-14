Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.TextFormatting

Namespace CustomTextClasses
	Friend Class CustomTextSource
		Inherits TextSource
		' <SnippetTextFormattingSnippet4>
		' Retrieve the next formatted text run for the text source.
		Public Overrides Function GetTextRun(ByVal textSourceCharacterIndex As Integer) As TextRun
			' Determine whether the text source index is in bounds.
			If textSourceCharacterIndex < 0 Then
				Throw New ArgumentOutOfRangeException("textSourceCharacterIndex", "Value must be greater than 0.")
			End If

			' Determine whether the text source index has exceeded or equaled the text source length.
			If textSourceCharacterIndex >= _text.Length Then
				' Return an end-of-paragraph indicator -- a TextEndOfParagraph object is a special type of text run.
				Return New TextEndOfParagraph(1)
			End If

			' Create and return a TextCharacters object, which is formatted according to
			' the current layout and rendering properties.
			If textSourceCharacterIndex < _text.Length Then
				' The TextCharacters object is a special type of text run that contains formatted text.
				Return New TextCharacters(_text, textSourceCharacterIndex, _text.Length - textSourceCharacterIndex, New CustomTextRunProperties()) ' The layout and rendering properties -  The text store length -  The text store index -  The text store
			End If

			' Return an end-of-paragraph indicator if there is no more text source.
			Return New TextEndOfParagraph(1)
		End Function
		' </SnippetTextFormattingSnippet4>

		Public Overrides Function GetPrecedingText(ByVal textSourceCharacterIndexLimit As Integer) As TextSpan(Of CultureSpecificCharacterBufferRange)
			Throw New Exception("The method or operation is not implemented.")
		End Function

		Public Overrides Function GetTextEffectCharacterIndexFromTextSourceCharacterIndex(ByVal textSourceCharacterIndex As Integer) As Integer
			Throw New Exception("The method or operation is not implemented.")
		End Function

		#Region "Properties"
		Public Property Text() As String
			Get
				Return _text
			End Get
			Set(ByVal value As String)
				_text = value
			End Set
		End Property
		#End Region

		#Region "Private Fields"

		Private _text As String 'text store

		#End Region
	End Class

	Friend Class CustomTextParagraphProperties
		Inherits TextParagraphProperties
		Private _customTextRunProperties As New CustomTextRunProperties()

		Public Overrides ReadOnly Property DefaultTextRunProperties() As TextRunProperties
			Get
				Return _customTextRunProperties
			End Get
		End Property

		Public Overrides ReadOnly Property FirstLineInParagraph() As Boolean
			Get
				Return True
			End Get
		End Property

		Public Overrides ReadOnly Property FlowDirection() As FlowDirection
			Get
				Return FlowDirection.LeftToRight
			End Get
		End Property

		Public Overrides ReadOnly Property Indent() As Double
			Get
				Return 0
			End Get
		End Property

		Public Overrides ReadOnly Property LineHeight() As Double
			Get
				Return 24
			End Get
		End Property

		Public Overrides ReadOnly Property TextAlignment() As TextAlignment
			Get
				Return TextAlignment.Left
			End Get
		End Property

		Public Overrides ReadOnly Property TextMarkerProperties() As TextMarkerProperties
			Get
				Return Nothing
			End Get
		End Property

		Public Overrides ReadOnly Property TextWrapping() As TextWrapping
			Get
				Return TextWrapping.Wrap
			End Get
		End Property
	End Class

	Friend Class CustomTextRunProperties
		Inherits TextRunProperties
		Public Overrides ReadOnly Property BackgroundBrush() As Brush
			Get
				Return Brushes.Transparent
			End Get
		End Property

		Public Overrides ReadOnly Property CultureInfo() As CultureInfo
			Get
				Return CultureInfo.CurrentUICulture
			End Get
		End Property

		Public Overrides ReadOnly Property FontHintingEmSize() As Double
			Get
				Return 24.0
			End Get
		End Property

		Public Overrides ReadOnly Property FontRenderingEmSize() As Double
			Get
				Return 24.0
			End Get
		End Property

		Public Overrides ReadOnly Property ForegroundBrush() As Brush
			Get
				Return Brushes.Teal
			End Get
		End Property

		Public Overrides ReadOnly Property TextDecorations() As TextDecorationCollection
			Get
				Return Nothing
			End Get
		End Property

		Public Overrides ReadOnly Property TextEffects() As TextEffectCollection
			Get
				Return Nothing
			End Get
		End Property

		Public Overrides ReadOnly Property Typeface() As Typeface
			Get
				Return New Typeface("Narkism")
			End Get
		End Property
	End Class
End Namespace
