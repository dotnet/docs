Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel

Namespace TreeViewDataBinding
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		'<Snippet5>
		Private Sub SelectedNewspaperChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Object))

			Dim engnews As EnglishNewspaper = TryCast(EnglishNewspapers.SelectedItem, EnglishNewspaper)
			If engnews IsNot Nothing Then
				NewspaperFrame.Navigate(New System.Uri(engnews.Website))
			End If
		End Sub
		'</Snippet5>
	End Class

	'<Snippet3>
	Public Class EnglishNewspaper
		Private _name As String
		Private _website As String

		Public Property Website() As String
			Get
				Return _website
			End Get
			Set(ByVal value As String)
				_website = value
			End Set
		End Property

		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				_name = value
			End Set
		End Property

		Public Sub New(ByVal name As String, ByVal website As String)
			Me.Name = name
			Me.Website = website
		End Sub
	End Class
	'</Snippet3>

	'<Snippet4>
	Public Class EasternHemisphereNewspapers
		Inherits ObservableCollection(Of EnglishNewspaper)
		Public Sub New()
			Add(New EnglishNewspaper("SofiaEcho(Bulgaria)", "http://www.sofiaecho.com/"))
			Add(New EnglishNewspaper("India Times(India)", "http://www.indiatimes.com"))
			Add(New EnglishNewspaper("Aftenposten(Norway)", "http://www.aftenposten.no/english/"))
		End Sub
	End Class

	Public Class WesternHemisphereNewspapers
		Inherits ObservableCollection(Of EnglishNewspaper)
		Public Sub New()
			Add(New EnglishNewspaper("Buenos Aires Herald (Argentina)", "http://www.buenosairesherald.com/"))
			Add(New EnglishNewspaper("Tico Times (Central America)", "http://www.ticotimes.net/"))
			Add(New EnglishNewspaper("New York Times (United States)", "http://www.nytimes.com"))
		End Sub
	End Class
	'</Snippet4>
End Namespace