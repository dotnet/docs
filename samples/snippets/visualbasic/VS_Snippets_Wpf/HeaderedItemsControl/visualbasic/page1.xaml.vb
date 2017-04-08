Imports System.ComponentModel
Imports System.Collections.ObjectModel

Namespace HeaderedItemsControlSimple
	''' <summary>
	''' Interaction logic for Page1.xaml
	''' </summary>


	Public Class myColors
		Inherits ObservableCollection(Of String)
		Public Sub New()
			Add("Red")
			Add("Purple")
			Add("Blue")
			Add("Green")
		End Sub
	End Class


	Public Class MyNumbers
		Inherits ObservableCollection(Of String)
		Public Sub New()
			Add("one")
			Add("two")
			Add("three")
			Add("four")
			Add("five")
		End Sub
	End Class

	Partial Public Class Page1
		Inherits Canvas

		Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetHeaderedItemsControl_HasHeader>
			If hitemsCtrl.HasHeader = True Then
				MessageBox.Show(hitemsCtrl.Header.ToString())

			End If
			'</SnippetHeaderedItemsControl_HasHeader>
		End Sub
	End Class
End Namespace

