Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Imports System.Security.Permissions
Imports System.Security

Namespace WPFPlatformSecuritySnippet
	''' <summary>
	''' Interaction logic for Page1.xaml
	''' </summary>

	Partial Public Class Page1
		Inherits Page
		Public Sub New()
			InitializeComponent()

			'<SnippetPermission>
			Dim fp As New FileIOPermission(PermissionState.Unrestricted)
			fp.Assert()

			' Perform operation that uses the assert

			' Revert the assert when operation is completed
			CodeAccessPermission.RevertAssert()
			'</SnippetPermission>
		End Sub

	End Class
End Namespace