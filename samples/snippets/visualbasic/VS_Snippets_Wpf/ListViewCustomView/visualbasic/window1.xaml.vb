Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			ChangeView("GridView")
		End Sub

		Private Sub SwitchViewMenu(ByVal sender As Object, ByVal args As RoutedEventArgs)
			Dim mi As MenuItem = CType(sender, MenuItem)
			ChangeView(mi.Header.ToString())
		End Sub

		Private Sub ChangeView(ByVal str As String)
			If str = "GridView" Then
				lv.View = TryCast(lv.FindResource("gridView"), ViewBase)
				currentView.Text = "GridView"
			ElseIf str = "IconView" Then
				lv.View = TryCast(lv.FindResource("iconView"), ViewBase)
				currentView.Text = "IconView"
			ElseIf str = "TileView" Then
				'<SnippetListViewtileViewmode>
				'Set the ListView View property to the tileView custom view
				lv.View = TryCast(lv.FindResource("tileView"), ViewBase)
				'</SnippetListViewtileViewmode>
				currentView.Text = "TileView"
			ElseIf str = "OneButtonHeaderView" Then
				lv.View = TryCast(lv.FindResource("OneButtonHeaderView"), ViewBase)
				currentView.Text = "OneButtonHeaderView"
			End If
		End Sub
	End Class
End Namespace