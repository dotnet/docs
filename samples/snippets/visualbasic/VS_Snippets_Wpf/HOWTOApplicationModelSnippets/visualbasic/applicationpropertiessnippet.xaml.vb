Imports System.Text

Namespace SDKSample
  ''' <summary>
  ''' Interaction logic for ApplicationPropertiesSnippet.xaml
  ''' </summary>

  Public Class CustomType
  End Class

  Partial Public Class ApplicationPropertiesSnippet
	  Inherits Window

	Public Sub New()
	  InitializeComponent()
	End Sub

	Private Sub GetCurrentApplication()

	  '<SnippetGetCurrentApplication>
	  ' Get a reference to the current Application object
	  Dim currentApplication As Application = Application.Current
	  '</SnippetGetCurrentApplication>
	End Sub

	Private Sub SetApplicationProperties()
	  '<SnippetSetApplicationScopeProperty>
	  ' Set an application-scope property
	  Application.Current.Properties("MyApplicationScopeProperty") = "myApplicationScopePropertyValue"
	  '</SnippetSetApplicationScopeProperty>

	  '<SnippetSetApplicationScopePropertyCustomType>
	  ' Set an application-scope property with a custom type
	  Dim customType As New CustomType()
	  Application.Current.Properties("CustomType") = customType
	  '</SnippetSetApplicationScopePropertyCustomType>

	End Sub

	Private Sub GetApplicationProperties()

	  '<SnippetGetApplicationScopeProperty>
	  ' Get an application-scope property
	  ' NOTE: Need to convert since Application.Properties is a dictionary of System.Object
	  Dim myApplicationScopeProperty As String = CStr(Application.Current.Properties("MyApplicationScopeProperty"))
	  '</SnippetGetApplicationScopeProperty>

	  '<SnippetGetApplicationScopePropertyCustomType>
	  ' Get an application-scope property
	  ' NOTE: Need to convert since Application.Properties is a dictionary of System.Object
	  Dim customType As CustomType = CType(Application.Current.Properties("CustomType"), CustomType)
	  '</SnippetGetApplicationScopePropertyCustomType>
	End Sub

	Private Sub SetApplicationScopeResources()
	  '<SnippetSetApplicationScopeResourceCODE>
	  ' Set an application-scope resource
	  Application.Current.Resources("ApplicationScopeResource") = Brushes.White
	  '</SnippetSetApplicationScopeResourceCODE>
	End Sub

	Private Sub GetApplicationScopeResources()
	  '<SnippetGetApplicationScopeResourceCODE>
	  ' Get an application-scope resource
	  Dim whiteBrush As Brush = CType(Application.Current.Resources("ApplicationScopeResource"), Brush)
	  '</SnippetGetApplicationScopeResourceCODE>
	End Sub
  End Class
End Namespace