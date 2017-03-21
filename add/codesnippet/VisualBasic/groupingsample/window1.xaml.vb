'<SnippetCode>

Imports System
Imports System.Windows
Imports System.Windows.Data

Namespace GroupingSample
	Partial Public Class Window1
		Inherits System.Windows.Window

		Public Sub New()
			InitializeComponent()
		End Sub

'<SnippetMyView>
		Private myView As CollectionView
'</SnippetMyView>
		Private Sub AddGrouping(ByVal sender As Object, ByVal e As RoutedEventArgs)
'<SnippetGetView>
			myView = CType(CollectionViewSource.GetDefaultView(myItemsControl.ItemsSource), CollectionView)
'</SnippetGetView>
			If myView.CanGroup = True Then
				Dim groupDescription As New PropertyGroupDescription("@Type")
				myView.GroupDescriptions.Add(groupDescription)
			Else
				Return
			End If
		End Sub

		Private Sub RemoveGrouping(ByVal sender As Object, ByVal e As RoutedEventArgs)
			myView = CType(CollectionViewSource.GetDefaultView(myItemsControl.ItemsSource), CollectionView)
			myView.GroupDescriptions.Clear()
		End Sub
	End Class
End Namespace
'</SnippetCode>