Imports System.Text
Imports System.Windows.Markup


Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnLoaded(ByVal sender As Object, ByVal e As EventArgs)

			'<SnippetMarkupKeyboardNavigationTabNavigationCODE>
			Dim navigationMenu As New Menu()
			Dim item1 As New MenuItem()
			Dim item2 As New MenuItem()
			Dim item3 As New MenuItem()
			Dim item4 As New MenuItem()

			navigationMenu.Items.Add(item1)
			navigationMenu.Items.Add(item2)
			navigationMenu.Items.Add(item3)
			navigationMenu.Items.Add(item4)

			KeyboardNavigation.SetTabNavigation(navigationMenu, KeyboardNavigationMode.Cycle)
			'</SnippetMarkupKeyboardNavigationTabNavigationCODE>

			navigationMenu.Height = 50
			item1.Header = "item1"
			item2.Header = "item2"
			item3.Header = "item3"
			item4.Header = "item4"
			navigationMenu.Background = Brushes.AliceBlue
			navigationMenu.Focusable = True
			MainStack.Children.Add(navigationMenu)

			Keyboard.Focus(item1)
		End Sub

	End Class

	'<SnippetMarkupRuntimeNamePropertyAttribute>
	<RuntimeNameProperty("BookID")>
	Public Class Book
		Public Sub New()
		End Sub

		Public Property BookID() As String
			Get
				Return _bookID
			End Get
			Set(ByVal value As String)
				_bookID = value
			End Set
		End Property

		Private _bookID As String = String.Empty
	End Class
	'</SnippetMarkupRuntimeNamePropertyAttribute>

	'<SnippetMarkupContentPropertyAttribute>
	<ContentProperty("Title")>
	Public Class Film
		Public Sub New()
		End Sub

		Public Property Title() As String
			Get
				Return _title
			End Get
			Set(ByVal value As String)
				_title = value
			End Set
		End Property

		Private _title As String
	End Class
	'</SnippetMarkupContentPropertyAttribute>

	'<SnippetMarkupXmlLanguageProperty>
	<XmlLangProperty("Language")>
	Public Class MyElement
		Inherits UIElement
		Public Sub New()
		End Sub

		Public Property Language() As String
			Get
				Return _language
			End Get
			Set(ByVal value As String)
				_language = value
			End Set
		End Property

		Private _language As String

	End Class
	'</SnippetMarkupXmlLanguageProperty>
End Namespace
