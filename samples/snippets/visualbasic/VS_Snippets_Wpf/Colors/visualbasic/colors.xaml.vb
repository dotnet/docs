Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Globalization
Imports System.Reflection
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media

Namespace SDKSample
  Partial Public Class MainWindow
	  Inherits Window
	'----------------  Response to user actions   --------------------//

	'<SnippetNewColor>
	' Event handler for the NewColor button
	Private Sub OnNewColorClicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
	  Dim button As Button = CType(sender, Button)
	  Dim colorList As ColorItemList = CType(button.DataContext, ColorItemList)
	  Dim cv As CollectionView = CType(CollectionViewSource.GetDefaultView(CType(colorList, IEnumerable)), CollectionView)

	  ' add a new color based on the current one, then select the new one
	  Dim newItem As New ColorItem(CType(cv.CurrentItem, ColorItem))
	  colorList.Add(newItem)
	  cv.MoveCurrentTo(newItem)
	End Sub
	'</SnippetNewColor>

	' Event handler for the SortBy radio buttons
	Private Sub OnSortByChanged(ByVal sender As Object, ByVal args As RoutedEventArgs)
	  Dim rb As RadioButton = CType(sender, RadioButton)
	  Dim SortBy As String = rb.Content.ToString()
	  Dim cv As CollectionView

	  If SortBy IsNot Nothing Then
		' sort by the user's chosen property
		cv = CType(CollectionViewSource.GetDefaultView(CType(rb.DataContext, IEnumerable)), CollectionView)
		cv.SortDescriptions.Clear()
		cv.SortDescriptions.Add(New SortDescription(SortBy, ListSortDirection.Descending))
	  End If
	End Sub
  End Class
End Namespace
