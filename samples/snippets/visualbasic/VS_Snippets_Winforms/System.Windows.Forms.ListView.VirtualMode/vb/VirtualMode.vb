Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

'<snippet1>
Public Class Form1
    Inherits Form
    Private myCache() As ListViewItem 'array to cache items for the virtual list
    Private firstItem As Integer 'stores the index of the first item in the cache
    Private WithEvents listView1 As ListView

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    Public Sub New()
        'Create a simple ListView.
        listView1 = New ListView()
        listView1.View = View.SmallIcon
        listView1.VirtualMode = True
        listView1.VirtualListSize = 10000

        'Add ListView to the form.
        Me.Controls.Add(listView1)

        'Search for a particular virtual item.
        'Notice that we never manually populate the collection!
        'If you leave out the SearchForVirtualItem handler, this will return null.
        Dim lvi As ListViewItem = listView1.FindItemWithText("111111")

        'Select the item found and scroll it into view.
        If Not (lvi Is Nothing) Then
            listView1.SelectedIndices.Add(lvi.Index)
            listView1.EnsureVisible(lvi.Index)
        End If

    End Sub

    '<snippet2>
    'The basic VirtualMode function.  Dynamically returns a ListViewItem
    'with the required properties; in this case, the square of the index.
    Private Sub listView1_RetrieveVirtualItem(ByVal sender As Object, ByVal e As RetrieveVirtualItemEventArgs) Handles listView1.RetrieveVirtualItem
        'Caching is not required but improves performance on large sets.
        'To leave out caching, don't connect the CacheVirtualItems event 
        'and make sure myCache is null.
        'check to see if the requested item is currently in the cache
        If Not (myCache Is Nothing) AndAlso e.ItemIndex >= firstItem AndAlso e.ItemIndex < firstItem + myCache.Length Then
            'A cache hit, so get the ListViewItem from the cache instead of making a new one.
            e.Item = myCache((e.ItemIndex - firstItem))
        Else
            'A cache miss, so create a new ListViewItem and pass it back.
            Dim x As Integer = e.ItemIndex * e.ItemIndex
            e.Item = New ListViewItem(x.ToString())
        End If


    End Sub
    '</snippet2>

    '<snippet3>
    'Manages the cache.  ListView calls this when it might need a 
    'cache refresh.
    Private Sub listView1_CacheVirtualItems(ByVal sender As Object, ByVal e As CacheVirtualItemsEventArgs) Handles listView1.CacheVirtualItems
        'We've gotten a request to refresh the cache.
        'First check if it's really neccesary.
        If Not (myCache Is Nothing) AndAlso e.StartIndex >= firstItem AndAlso e.EndIndex <= firstItem + myCache.Length Then
            'If the newly requested cache is a subset of the old cache, 
            'no need to rebuild everything, so do nothing.
            Return
        End If

        'Now we need to rebuild the cache.
        firstItem = e.StartIndex
        Dim length As Integer = e.EndIndex - e.StartIndex + 1 'indexes are inclusive
        myCache = New ListViewItem(length) {}

        'Fill the cache with the appropriate ListViewItems.
        Dim x As Integer = 0
        Dim i As Integer
        For i = 0 To length
            x = (i + firstItem) * (i + firstItem)
            myCache(i) = New ListViewItem(x.ToString())
        Next i

    End Sub
    '</snippet3>

    '<snippet4>
    'This event handler enables search functionality, and is called
    'for every search request when in Virtual mode.
    Private Sub listView1_SearchForVirtualItem(ByVal sender As Object, ByVal e As SearchForVirtualItemEventArgs) Handles listView1.SearchForVirtualItem
        'We've gotten a search request.
        'In this example, finding the item is easy since it's
        'just the square of its index.  We'll take the square root
        'and round.
        Dim x As Double = 0
        If [Double].TryParse(e.Text, x) Then 'check if this is a valid search
            x = Math.Sqrt(x)
            x = Math.Round(x)
            e.Index = Fix(x)
        End If
        'Note that this only handles simple searches over the entire
        'list, ignoring any other settings.  Handling Direction, StartIndex,
        'and the other properties of SearchForVirtualItemEventArgs is up
        'to this handler.
    End Sub
    '</snippet4>

End Class
'</snippet1>