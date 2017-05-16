' <SnippetDisableDpiAwarenessAttribute1>
' Disable Dpi awareness in the application assembly.
<Assembly: DisableDpiAwareness>
' </SnippetDisableDpiAwarenessAttribute1>

Namespace WindowsApplication1
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
End Namespace