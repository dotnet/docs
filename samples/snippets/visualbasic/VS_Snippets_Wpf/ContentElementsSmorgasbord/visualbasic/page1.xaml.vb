Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Windows.Media
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Data
Imports Foo

Namespace Foo
	Public Class MyData
		Public Sub New()
			_value = "Default value"
		End Sub
		Public Property CustomProperty() As String
			Get
				Return _value
			End Get
			Set(ByVal value As String)
				_value = CType(value, String)
			End Set
		End Property
		Private _value As String
	End Class
  Partial Public Class Page1
	  Inherits Page
	Private Sub dropHandler(ByVal sender As Object, ByVal e As DragEventArgs)
	End Sub

'<SnippetFocus>
	Private Sub FocusOnParagraph(ByVal sender As Object, ByVal e As RoutedEventArgs)
	  Dim ce As ContentElement = TryCast(Me.FindName("focusableP"), ContentElement)
	  ce.Focus()
	End Sub
'</SnippetFocus>
'<SnippetIsMouseCaptured>
	Private Sub CaptureMouseCommandExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
	  MessageBox.Show("Mouse Command")
	  Dim target As IInputElement = Mouse.DirectlyOver

	  target = TryCast(target, Control)
	  If target IsNot Nothing Then
		If Not target.IsMouseCaptured Then
		  Mouse.Capture(target)
		Else
		  Mouse.Capture(Nothing)
		End If
	  End If
	End Sub
'</SnippetIsMouseCaptured>
'<SnippetIsEnabled>
	Private Sub MakeSpecialLink(ByVal sender As Object, ByVal e As RoutedEventArgs)
	  Dim h2 As New Hyperlink(New Run("Now Click here"))
	  ' Associate event handler to the link. You can remove the event 
	  ' handler using "-=" syntax rather than "+=".
	  AddHandler h2.Click, AddressOf Onh2Click
	  h2.Style = CType(FindResource("SpecialHLink"), Style)
	  focusableP.Inlines.Add(h2)
	  text1.Text = "Now click the second link..."
	  h1.IsEnabled = False
	End Sub
	'</SnippetIsEnabled>
	'<SnippetAddHandlerHandledToo>
	Private Sub PrimeHandledToo(ByVal sender As Object, ByVal e As EventArgs)
		myflowdocument.AddHandler(Hyperlink.ClickEvent, New RoutedEventHandler(AddressOf GetHandledToo), True)
	End Sub
	'</SnippetAddHandlerHandledToo>
	'<SnippetFindName>
	Private Sub HighlightParagraph(ByVal paraName As String)
		Try
			Dim wantedNode As Paragraph = CType(myflowdocument.FindName(paraName), Paragraph)
			If wantedNode IsNot Nothing Then
				wantedNode.Background = Brushes.LightYellow
			End If
		Catch 'handle paragraph not found in UI }
		End Try
	End Sub
	'</SnippetFindName>
	'<SnippetFindResource>
	  Private Sub SetBGByResource(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  Dim b As Block = TryCast(sender, Block)
		  b.Background = CType(Me.FindResource("RainbowBrush"), Brush)
	  End Sub
	'</SnippetFindResource>
	'<SnippetTryFindResource>
	  Private Sub SetBGByResourceTry(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  Dim b As Block = TryCast(sender, Block)
		  b.Background = CType(Me.TryFindResource("RainbowBrush"), Brush)
	  End Sub
	'</SnippetTryFindResource>
	  Private Sub FindIntro(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  HighlightParagraph("introParagraph")
		  MakeMenu()
	  End Sub
	  '<SnippetCMProcedural>
	  Private Sub MakeMenu()
		  Dim p1 As New Paragraph()
            p1.Inlines.Add(New Run("Created with VB"))
		  myflowdocument.Blocks.Add(p1)
		  Dim cm As New ContextMenu()
		  p1.ContextMenu = cm
		  Dim m1 As New MenuItem()
		  m1.Header = "Edit"
		  Dim m2 As New MenuItem()
		  m2.Header = "Print"
		  cm.Items.Add(m1)
		  cm.Items.Add(m2)

	  End Sub
	  '</SnippetCMProcedural>
	  '<SnippetIsLoaded>
	  Private Sub OnLoad(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  displayData()
	  End Sub
	  Private Sub updateSummary(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  If myflowdocument.IsLoaded Then
			  displayData()
		  End If
	  End Sub
	  '</SnippetIsLoaded>
	  Private Sub displayData()
		  '<SnippetGetBindingExpression>
		  Dim binding As Binding = introParagraph.GetBindingExpression(FrameworkContentElement.TagProperty).ParentBinding
		  '</SnippetGetBindingExpression>
		  '<SnippetSetBinding>
		  Dim myDataObject As New Date()
		  Dim myBinding As New Binding()
		  myBinding.Source = myDataObject
		  introParagraph.SetBinding(Paragraph.TagProperty, myBinding)
		  '</SnippetSetBinding>
	  End Sub
	  Private Sub displayData2()
		  '<SnippetDataContext>
		  Dim myDataObject As New MyData()
		  myflowdocument.DataContext = myDataObject
		  introParagraph.SetBinding(Paragraph.TagProperty, "CustomData")
		  '</SnippetDataContext>
	  End Sub
	  Private Sub readyanim()
		  '<SnippetNameRegisterName>
		  Dim myLink As New Hyperlink()
		  myLink.Name = "myLink"
		  Me.RegisterName(myLink.Name, myLink)
		  '</SnippetNameRegisterName>
	  End Sub
	Private Sub GetHandledToo(ByVal sender As Object, ByVal e As RoutedEventArgs)
	End Sub

	Private Sub Onh2Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
	End Sub
  End Class
  Public Class MyCustomLink
	  Inherits Hyperlink
'<SnippetAddRemoveHandler>
	Public Shared ReadOnly TapEvent As RoutedEvent = EventManager.RegisterRoutedEvent("Tap", RoutingStrategy.Bubble, GetType(RoutedEventHandler), GetType(MyCustomLink))
	Public Custom Event Tap As RoutedEventHandler
	  AddHandler(ByVal value As RoutedEventHandler)
		  MyBase.AddHandler(TapEvent, value)
	  End AddHandler
	  RemoveHandler(ByVal value As RoutedEventHandler)
		  MyBase.RemoveHandler(TapEvent, value)
	  End RemoveHandler
		 RaiseEvent(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
		 End RaiseEvent
	End Event
'</SnippetAddRemoveHandler>
'<SnippetRaiseEvent>
	Private Sub RaiseTapEvent()
	  Dim newEventArgs As New RoutedEventArgs()
	  newEventArgs.RoutedEvent = MyCustomLink.TapEvent
	  'newEvent.SetSource(Me)
	  MyBase.RaiseEvent(newEventArgs)
	End Sub
'</SnippetRaiseEvent>
  End Class
  '<SnippetDefaultStyleKeyClass>
  Public Class MyExtraBold
	  Inherits Bold
	  Shared Sub New()
		  DefaultStyleKeyProperty.OverrideMetadata(GetType(MyExtraBold), New FrameworkPropertyMetadata(GetType(MyExtraBold)))
	  End Sub
	  Public Sub New()
	  End Sub
  End Class
  '</SnippetDefaultStyleKeyClass>
End Namespace








