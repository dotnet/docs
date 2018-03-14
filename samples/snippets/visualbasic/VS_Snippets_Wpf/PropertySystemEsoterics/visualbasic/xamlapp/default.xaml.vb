Imports System
Imports System.Windows
Imports System.Collections
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Text
Imports Microsoft.VisualBasic

Namespace SDKSample
	Partial Public Class XAMLAPP
	  Private Sub ReportState(ByVal sender As Object, ByVal e As EventArgs)
		Dim sb As New StringBuilder()
		Dim tb As New TextBlock()
		'<SnippetGetMetadataInit>
		Dim pm As PropertyMetadata
		'</SnippetGetMetadataInit>
		sb.Append("MyStateControl State default = ")
		'<SnippetGetMetadataType>
		pm = MyStateControl.StateProperty.GetMetadata(GetType(MyStateControl))
		'</SnippetGetMetadataType>
		sb.Append(pm.DefaultValue.ToString())
		sb.Append(vbLf)
		sb.Append("UnrelatedStateControl State default = ")
		'<SnippetGetMetadataDOType>
		Dim dt As DependencyObjectType = unrelatedInstance.DependencyObjectType
		pm = UnrelatedStateControl.StateProperty.GetMetadata(dt)
		'</SnippetGetMetadataDOType>
		sb.Append(pm.DefaultValue.ToString())
		sb.Append(vbLf)
		sb.Append("MyAdvancedStateControl State default = ")
		'<SnippetGetMetadataDOInstance>
		pm = MyAdvancedStateControl.StateProperty.GetMetadata(advancedInstance)
		'</SnippetGetMetadataDOInstance>
		sb.Append(pm.GetType().ToString())
		sb.Append(vbLf)
		'</SnippetDefaultMetadataDOInstance>
		tb.Text = sb.ToString()
		root.Children.Add(tb)
        End Sub

	  Private Sub NavPage2(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page2.xaml", UriKind.RelativeOrAbsolute)
	  End Sub
	End Class
End Namespace