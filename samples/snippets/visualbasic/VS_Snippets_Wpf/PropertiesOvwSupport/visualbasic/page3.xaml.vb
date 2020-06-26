Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Input
Namespace MyNamespace
  Partial Public Class MyCanvasCode
	  Inherits Canvas
	Private Sub DoStuff()
'<SnippetDPBasicPropSet>
	  myCanvas.Background = New SolidColorBrush(Colors.Green)
'</SnippetDPBasicPropSet>
	End Sub
'<SnippetResourceProceduralGet>
	Private Sub SetBGByResource(ByVal sender As Object, ByVal e As RoutedEventArgs)
	  Dim b As Button = TryCast(sender, Button)
	  b.Background = CType(Me.FindResource("RainbowBrush"), Brush)
	End Sub
'</SnippetResourceProceduralGet>
	Private Sub WrapsAroundDOTCode()
'<SnippetDOTFromSystemType>
		Dim dt As DependencyObjectType = DependencyObjectType.FromSystemType(GetType(Window))
'</SnippetDOTFromSystemType>
	End Sub
	Private Sub OnTheFlyResource(ByVal sender As Object, ByVal e As RoutedEventArgs)
	  Dim b As Button = TryCast(sender, Button)
	  Dim rd As New ResourceDictionary()
	  Dim SecretSauce As New SolidColorBrush(Colors.MediumOrchid)
	  rd.Add("SecretSauce", SecretSauce)
	  b.Resources = rd
	  b.Background = CType(b.FindResource("RainbowBrush"), Brush)
	  WrapsAroundDOTCode()
	End Sub
  End Class
'<SnippetOverrideMetadata>
  Public Class SpinnerControl
	  Inherits ItemsControl
	  Shared Sub New()
		  DefaultStyleKeyProperty.OverrideMetadata(GetType(SpinnerControl), New FrameworkPropertyMetadata(GetType(SpinnerControl)))
	  End Sub
  End Class
'</SnippetOverrideMetadata>
End Namespace
