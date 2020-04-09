Imports System.ComponentModel

Public Class CollectionView

    Public listingDataView As CollectionViewSource

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        listingDataView = CType(Resources("listingDataView"), CollectionViewSource)

    End Sub

    ' <ListingViewFilter>
    Private Sub AddFilteringCheckBox_Checked(sender As Object, e As RoutedEventArgs)
        Dim checkBox = DirectCast(sender, CheckBox)

        If checkBox.IsChecked = True Then
            AddHandler listingDataView.Filter, AddressOf ListingDataView_Filter
        Else
            RemoveHandler listingDataView.Filter, AddressOf ListingDataView_Filter
        End If
    End Sub
    ' </ListingViewFilter>

    Private Sub AddGroupingCheckBox_Checked(sender As Object, e As RoutedEventArgs)
        ' <ListingGroupCheck>
        ' This groups the items in the view by the property "Category"
        Dim groupDescription = New PropertyGroupDescription()
        groupDescription.PropertyName = "Category"
        listingDataView.GroupDescriptions.Add(groupDescription)
        ' </ListingGroupCheck>
    End Sub

    ' <FilterEvent>
    Private Sub ListingDataView_Filter(sender As Object, e As FilterEventArgs)

        ' Start with everything excluded
        e.Accepted = False

        Dim product As AuctionItem = TryCast(e.Item, AuctionItem)

        If product IsNot Nothing Then

            ' Only include products with prices lower than 25
            If product.CurrentPrice < 25 Then e.Accepted = True

        End If

    End Sub
    ' </FilterEvent>

    ' <AddSortChecked>
    Private Sub AddSortCheckBox_Checked(sender As Object, e As RoutedEventArgs)
        ' Sort the items first by Category And then by StartDate
        listingDataView.SortDescriptions.Add(New SortDescription("Category", ListSortDirection.Ascending))
        listingDataView.SortDescriptions.Add(New SortDescription("StartDate", ListSortDirection.Ascending))
    End Sub
    ' </AddSortChecked>
End Class
