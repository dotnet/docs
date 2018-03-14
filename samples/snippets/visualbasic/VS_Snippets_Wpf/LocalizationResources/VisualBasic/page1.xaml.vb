Imports System
Imports System.Windows.Controls
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Globalization
Imports System.Threading
Imports System.Resources
Imports System.Reflection
Imports System.Windows.Resources

Namespace MySampleApp ' Namespace must be the same as what you set in project file

	Partial Public Class MyPage
		'<Snippet2>
		Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  Dim rm As New ResourceManager("stringtable", System.Reflection.Assembly.GetExecutingAssembly())
		  Text1.Text = rm.GetString("Message")
		End Sub
		'</Snippet2>
	End Class
End Namespace

