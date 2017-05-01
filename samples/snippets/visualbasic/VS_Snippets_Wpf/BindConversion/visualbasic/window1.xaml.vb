Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Data
Imports System.Windows.Media

Namespace SDKSample
  ''' <summary>
  ''' Window1: This is the class that encapsulates the code
  ''' "behind" the Window1.Xaml page.
  ''' </summary>
  '<Snippet3>
  Partial Public Class Window1
	  Inherits Window
	Private _theConverter As MyConverter = Nothing

	Public ReadOnly Property TheConverter() As MyConverter
	  Get
		If _theConverter Is Nothing Then
		  _theConverter = New MyConverter()
		End If

		Return _theConverter
	  End Get
	End Property

	'<Snippet2>
	Public Sub ChangeTheCulture(ByVal sSelectedCulture As String)
		Dim sCulture As String

'<SnippetParentBinding>
		  Dim binding As Binding = myDateText.GetBindingExpression(TextBlock.TextProperty).ParentBinding
'</SnippetParentBinding>

		Select Case sSelectedCulture
			Case "English (en-US)"
			  sCulture = "en-US"
			Case "Spanish (es-ES)"
			  sCulture = "es-ES"
			Case "German (de-DE)"
			  sCulture = "de-DE"
			Case "French (fr-FR)"
			  sCulture = "fr-FR"
			Case Else
			  sCulture = ""
		End Select
	End Sub
	'</Snippet2>

	Private Sub OnSelectionChanged(ByVal sender As Object, ByVal args As RoutedEventArgs)
	  Dim oLI As ListBoxItem = CType(lbChooseCulture.SelectedItem, ListBoxItem)
	  Dim sSelectedCulture As String = oLI.Content.ToString()
	  ChangeTheCulture(sSelectedCulture)
	End Sub

	  Public Sub RelativeSource_snip()
		  '<SnippetRelativeSource>
		  Dim myBinding As New Binding()
		  ' Returns the second ItemsControl encountered on the upward path
		  ' starting at the target element of the binding
		  myBinding.RelativeSource = New RelativeSource(RelativeSourceMode.FindAncestor, GetType(ItemsControl), 2)
		  '</SnippetRelativeSource>
	  End Sub


	'<Snippet1>
	Private Sub OnPageLoaded(ByVal sender As Object, ByVal e As EventArgs)
		' Make a new source, to grab a new timestamp
		Dim myChangedData As New MyData()

		' Create a new binding
	' TheDate is a property of type DateTime on MyData class
		Dim myNewBindDef As New Binding("TheDate")

		myNewBindDef.Mode = BindingMode.OneWay
		myNewBindDef.Source = myChangedData
		myNewBindDef.Converter = TheConverter
		myNewBindDef.ConverterCulture = New CultureInfo("en-US")

	'<SnippetBOSetBinding>
	' myDatetext is a TextBlock object that is the binding target object
		BindingOperations.SetBinding(myDateText, TextBlock.TextProperty, myNewBindDef)
		BindingOperations.SetBinding(myDateText, TextBlock.ForegroundProperty, myNewBindDef)
	'</SnippetBOSetBinding>

	'</Snippet1>
		lbChooseCulture.SelectedIndex = 0
'<Snippetend1>
	End Sub
'</Snippetend1>
  End Class
  '</Snippet3>
End Namespace
