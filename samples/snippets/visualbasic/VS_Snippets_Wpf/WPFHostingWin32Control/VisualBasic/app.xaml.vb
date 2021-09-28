'This is a list of commonly used namespaces for an application class.

Imports System.Windows
Imports System.Runtime.InteropServices

Namespace WPF_Hosting_Win32_Control
  Partial Public Class app
	  Inherits Application
	<DllImport("comctl32.dll", EntryPoint:="InitCommonControls", CharSet:=CharSet.Auto)>
	Public Shared Sub InitCommonControls()
	End Sub

	Private Sub ApplicationStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
	  InitCommonControls()
	  Dim host As New HostWindow()
	  host.InitializeComponent()
	  host.Show()
	End Sub
  End Class
End Namespace