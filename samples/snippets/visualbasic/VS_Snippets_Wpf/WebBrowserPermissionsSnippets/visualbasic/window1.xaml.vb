Imports System
Imports System.Windows
Imports System.Security.Permissions

Namespace WindowsApplication1
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		' Web browser permission code attributes.

		' <SnippetWebBrowserPermissionAttribute1>
        <WebBrowserPermissionAttribute(SecurityAction.Demand, Level:=WebBrowserPermissionLevel.None)>
        Public Sub Method01()
        End Sub
        ' </SnippetWebBrowserPermissionAttribute1>

		' <SnippetWebBrowserPermissionAttribute2>
        <WebBrowserPermissionAttribute(SecurityAction.Demand, Level:=WebBrowserPermissionLevel.Safe)>
        Public Sub Method02()
        End Sub
        ' </SnippetWebBrowserPermissionAttribute2>

		' <SnippetWebBrowserPermissionAttribute3>
        <WebBrowserPermissionAttribute(SecurityAction.Demand, Level:=WebBrowserPermissionLevel.Unrestricted)>
        Public Sub Method03()
        End Sub
        ' </SnippetWebBrowserPermissionAttribute3>

		' <SnippetWebBrowserPermissionAttribute4>
        <WebBrowserPermissionAttribute(SecurityAction.Demand)>
        Public Sub Method04()
        End Sub
        ' </SnippetWebBrowserPermissionAttribute4>

		' Create Web browser permission via constructor.
		Public Sub Stub04()
			' <SnippetWebBrowserPermission1>
			Dim webBrowserPermission As New WebBrowserPermission(PermissionState.Unrestricted)
			' </SnippetWebBrowserPermission1>

			' <SnippetWebBrowserPermission5>
			Dim isUnrestricted As Boolean = webBrowserPermission.IsUnrestricted()
			' </SnippetWebBrowserPermission5>

			webBrowserPermission = New WebBrowserPermission(PermissionState.None)
			isUnrestricted = webBrowserPermission.IsUnrestricted()

			' <SnippetWebBrowserPermission6>
			Dim webBrowserPermissionLevel As WebBrowserPermissionLevel = webBrowserPermission.Level
			' </SnippetWebBrowserPermission6>
		End Sub

		Public Sub Stub05()
			' <SnippetWebBrowserPermission2>
			Dim webBrowserPermission As New WebBrowserPermission(WebBrowserPermissionLevel.None)
			' </SnippetWebBrowserPermission2>
		End Sub

		Public Sub Stub06()
			' <SnippetWebBrowserPermission3>
			Dim webBrowserPermission As New WebBrowserPermission(WebBrowserPermissionLevel.Safe)
			' </SnippetWebBrowserPermission3>
		End Sub

		Public Sub Stub07()
			' <SnippetWebBrowserPermission4>
			Dim webBrowserPermission As New WebBrowserPermission(WebBrowserPermissionLevel.Unrestricted)
			' </SnippetWebBrowserPermission4>
		End Sub
	End Class
End Namespace