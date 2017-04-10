Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Resources
Imports System.Reflection
Imports System.Resources
Imports System.Threading
Imports System.Collections

Namespace ResourcesSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

			Dim button As New Button()
            button.Content = "Click Me"
            AddHandler button.Click, Sub()
                                         Dim bob As New Uri("pack://application:,,,/EmbeddedResource.bmp")
                                     End Sub
            Me.Content = button

			' Get embedded resource in referenced assembly
            Dim uri As New Uri("pack://application:,,,/ResourceLibrary;component/ReferencedEmbeddedResource.bmp", UriKind.RelativeOrAbsolute) ' Works
			Dim info As StreamResourceInfo = Application.GetResourceStream(uri)
            ' Get loose resource in referenced assembly - doesn't work			
			Console.Write(info.ContentType & " -> ")
			Console.WriteLine(info.Stream.ToString())
		End Sub

		Protected Overrides Sub OnActivated(ByVal e As EventArgs)
			MyBase.OnActivated(e)
		End Sub
	End Class
End Namespace