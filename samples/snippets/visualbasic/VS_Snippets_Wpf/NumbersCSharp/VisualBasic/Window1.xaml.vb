Imports System.Text

'<SnippetNumbersVisualBasic>
Namespace BidiTest
	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

			Dim currentLanguage As String = System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag

			text1.Language = System.Windows.Markup.XmlLanguage.GetLanguage(currentLanguage)

			If currentLanguage.ToLower().StartsWith("ar") Then
				text1.FlowDirection = FlowDirection.RightToLeft
			Else
				text1.FlowDirection = FlowDirection.LeftToRight
			End If
		End Sub
	End Class
End Namespace
'</SnippetNumbersVisualBasic>