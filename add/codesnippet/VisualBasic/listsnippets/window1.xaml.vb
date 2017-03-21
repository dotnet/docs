Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace ListSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            ListProps()
            ListConsts()
            ListItemsProp()
		End Sub

		Private Sub ListProps()
			' <Snippet_List_Props>
			Dim listx As New List()
			' Set the space between the markers and list content to 25 DIP.
			listx.MarkerOffset = 25
			' Use uppercase Roman numerals.
			listx.MarkerStyle = TextMarkerStyle.UpperRoman
			' Start list numbering at 5.
			listx.StartIndex = 5

			' Create the list items that will go into the list.
			Dim liV As New ListItem(New Paragraph(New Run("Boron")))
			Dim liVI As New ListItem(New Paragraph(New Run("Carbon")))
			Dim liVII As New ListItem(New Paragraph(New Run("Nitrogen")))
			Dim liVIII As New ListItem(New Paragraph(New Run("Oxygen")))
			Dim liIX As New ListItem(New Paragraph(New Run("Fluorine")))
			Dim liX As New ListItem(New Paragraph(New Run("Neon")))

			' Finally, add the list items to the list.
			listx.ListItems.Add(liV)
			listx.ListItems.Add(liVI)
			listx.ListItems.Add(liVII)
			listx.ListItems.Add(liVIII)
			listx.ListItems.Add(liIX)
			listx.ListItems.Add(liX)
			' </Snippet_List_Props>
		End Sub

		Private Sub ListConsts()

			' <Snippet_List_Const>
			' This line uses the ListItem constructor to create a new ListItem
			' and initialize it with the specified Paragraph.
			Dim lix As New ListItem(New Paragraph(New Run("ListItem text...")))
			' This line uses the List constructor to create a new List and populate
			' it with the previously created ListItem.
			Dim listx As New List(lix)
			' </Snippet_List_Const>
		End Sub

		Private Sub ListItemsProp()
			' <Snippet_List_ListItems>
			' Add ListItems to the List.
			Dim listx As New List()
			Dim spanx As New Span()
			listx.ListItems.Add(New ListItem(New Paragraph(New Run("A bit of text content..."))))
			listx.ListItems.Add(New ListItem(New Paragraph(New Run("A bit more text content..."))))

			' Insert a ListItem at the begining of the List.
			Dim lix As New ListItem(New Paragraph(New Run("ListItem to insert...")))
			listx.ListItems.InsertBefore(listx.ListItems.FirstListItem, lix)

			' Get the number of ListItems in the List.
			Dim countListItems As Integer = listx.ListItems.Count

			' Remove the last ListItem from the List.
			listx.ListItems.Remove(listx.ListItems.LastListItem)

			' Clear all of the ListItems from the List.
			listx.ListItems.Clear()
			' </Snippet_List_ListItems>
		End Sub
	End Class
End Namespace