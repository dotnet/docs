Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace TextTrimming_layout
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Private Sub ChangeTextTrimmingProperty()
			' <Snippet_TextTrimmingSetTextTrimming>
			myTextBlock.TextTrimming = TextTrimming.CharacterEllipsis
			' </Snippet_TextTrimmingSetTextTrimming>
		End Sub
	End Class
End Namespace