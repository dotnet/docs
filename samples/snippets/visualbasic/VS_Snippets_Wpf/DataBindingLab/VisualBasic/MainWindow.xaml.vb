Imports System.ComponentModel

Partial Public Class MainWindow
    Inherits Window

    '<Snippet4()>
    Private listingDataView As CollectionViewSource

    Public Sub New()
        InitializeComponent()
        listingDataView = CType((Me.Resources("listingDataView")), CollectionViewSource)
    End Sub
    '</Snippet4()>

    '<Snippet5>
    Private Sub ShowOnlyBargainsFilter(ByVal sender As Object, ByVal e As FilterEventArgs)
        Dim product As AuctionItem = CType(e.Item, AuctionItem)
        If Not (product Is Nothing) Then
            'Filter out products with price 25 or above
            If product.CurrentPrice < 25 Then
                e.Accepted = True
            Else
                e.Accepted = False
            End If
        End If
    End Sub
    '</Snippet5>

    Private Sub AddGrouping(ByVal sender As Object, ByVal args As RoutedEventArgs)
        '<Snippet6>
        'This groups by property "Category"
        Dim groupDescription As PropertyGroupDescription = New PropertyGroupDescription
        groupDescription.PropertyName = "Category"
        listingDataView.GroupDescriptions.Add(groupDescription)
        '</Snippet6>
    End Sub

    '<Snippet7>
    Private Sub RemoveGrouping(ByVal sender As Object, ByVal args As RoutedEventArgs)
        listingDataView.GroupDescriptions.Clear()
    End Sub
    '</Snippet7>

    '<Snippet8>
    Private Sub AddSorting(ByVal sender As Object, ByVal args As RoutedEventArgs)
        'This sorts the items first by Category and within each Category, by StartDate
        'Notice that because Category is an enumeration, the order of the items is the same as in the 
        'enumeration declaration
        listingDataView.SortDescriptions.Add(New SortDescription("Category", ListSortDirection.Ascending))
        listingDataView.SortDescriptions.Add(New SortDescription("StartDate", ListSortDirection.Ascending))
    End Sub
    '</Snippet8>

    '<Snippet9>
    Private Sub RemoveSorting(ByVal sender As Object, ByVal args As RoutedEventArgs)
        listingDataView.SortDescriptions.Clear()
    End Sub
    '</Snippet9>

    Private Sub AddFiltering(ByVal sender As Object, ByVal args As RoutedEventArgs)
        '<Snippet10>
        AddHandler listingDataView.Filter, AddressOf ShowOnlyBargainsFilter
        '</Snippet10>
    End Sub

    '<Snippet11>
    Private Sub RemoveFiltering(ByVal sender As Object, ByVal args As RoutedEventArgs)
        RemoveHandler listingDataView.Filter, AddressOf ShowOnlyBargainsFilter
    End Sub
    '</Snippet11>

    Private Sub OpenAddProductWindow(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim addProductWindow As AddProductWindow = New AddProductWindow
        addProductWindow.ShowDialog()
    End Sub

End Class
