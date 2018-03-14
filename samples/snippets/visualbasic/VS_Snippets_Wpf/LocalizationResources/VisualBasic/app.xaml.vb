Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports System.Globalization
Imports System.Threading
Imports System.Resources
Imports System.Reflection
Imports System.Windows.Resources

Namespace MySampleApp
	Partial Public Class app
			Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
				' Setup the application window.
				Dim Mywindow As New Window()
				Mywindow.Width =(500)
				Mywindow.Height =(420)
				Dim rm As New ResourceManager("stringtable", System.Reflection.Assembly.GetExecutingAssembly())
				Mywindow.Title = rm.GetString("Title")
				Dim root As FrameworkElement
		Dim page As New MySampleApp.MyPage()
		page.InitializeComponent()
		root = TryCast(page, FrameworkElement)
				Mywindow.Content=root
				Mywindow.Show()
			End Sub
	End Class
End Namespace
