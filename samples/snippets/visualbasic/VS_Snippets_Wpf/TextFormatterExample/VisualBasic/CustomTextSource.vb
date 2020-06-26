Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Media.TextFormatting

Namespace SDKSamples
   ' CustomTextSource is our implementation of TextSource.  This is required to use the WPF
   ' text engine. This implementation is very simplistic as is DOES NOT monitor spans of text
   ' for different properties. The entire text content is considered a single span and all 
   ' changes to the size, alignment, font, etc. are applied across the entire text.
   Friend Class CustomTextSource
	   Inherits TextSource
	  '<Snippet101>
	  ' Used by the TextFormatter object to retrieve a run of text from the text source.
	  Public Overrides Function GetTextRun(ByVal textSourceCharacterIndex As Integer) As TextRun
		 ' Make sure text source index is in bounds.
		 If textSourceCharacterIndex < 0 Then
			Throw New ArgumentOutOfRangeException("textSourceCharacterIndex", "Value must be greater than 0.")
		 End If
		 If textSourceCharacterIndex >= _text.Length Then
			Return New TextEndOfParagraph(1)
		 End If

		 ' Create TextCharacters using the current font rendering properties.
		 If textSourceCharacterIndex < _text.Length Then
			Return New TextCharacters(_text, textSourceCharacterIndex, _text.Length - textSourceCharacterIndex, New GenericTextRunProperties(_currentRendering))
		 End If

		 ' Return an end-of-paragraph if no more text source.
		 Return New TextEndOfParagraph(1)
	  End Function
	  '</Snippet101>

	   Public Overrides Function GetPrecedingText(ByVal textSourceCharacterIndexLimit As Integer) As TextSpan(Of CultureSpecificCharacterBufferRange)
		  Dim cbr As New CharacterBufferRange(_text, 0, textSourceCharacterIndexLimit)
		  Return New TextSpan(Of CultureSpecificCharacterBufferRange)(textSourceCharacterIndexLimit, New CultureSpecificCharacterBufferRange(System.Globalization.CultureInfo.CurrentUICulture, cbr))
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

	  Public Property FontRendering() As FontRendering
		 Get
			 Return _currentRendering
		 End Get
		 Set(ByVal value As FontRendering)
			 _currentRendering = value
		 End Set
	  End Property
	  #End Region

	  #Region "Private Fields"

	  Private _text As String 'text store
	  Private _currentRendering As FontRendering

	  #End Region
   End Class
End Namespace
