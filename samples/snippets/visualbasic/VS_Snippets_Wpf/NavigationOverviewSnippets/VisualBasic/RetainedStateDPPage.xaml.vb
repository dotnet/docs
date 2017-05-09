Namespace SDKSample
'<SnippetDPDeclarationCODE>
Partial Public Class RetainedStateDPPage
	Inherits Page
	' Journalable dependency property
	Public Shared ReadOnly RetainedStateDP As DependencyProperty

	Shared Sub New()
		' Register the local property with the journalable dependency property
		RetainedStateDPPage.RetainedStateDP = DependencyProperty.Register("RetainedState", GetType(String), GetType(RetainedStateDPPage), New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.Journal))
	End Sub

	Public Sub New()
		InitializeComponent()
	End Sub

	' Property to register with the journalable dependency property
	Public Property RetainedState() As String
		Get
			Return CStr(MyBase.GetValue(RetainedStateDPPage.RetainedStateDP))
		End Get
		Set(ByVal value As String)
			MyBase.SetValue(RetainedStateDPPage.RetainedStateDP, value)
		End Set
	End Property
End Class
	'</SnippetDPDeclarationCODE>
End Namespace