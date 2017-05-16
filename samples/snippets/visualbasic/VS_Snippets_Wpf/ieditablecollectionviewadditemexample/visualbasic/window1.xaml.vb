'<SnippetMainWindowLogic> 
Imports System
Imports System.ComponentModel
Imports System.Windows

Partial Class Window1
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        Dim viewToAddDisparateItems As IEditableCollectionViewAddNewItem =
            TryCast(catalogList.Items, IEditableCollectionViewAddNewItem)

        If Not viewToAddDisparateItems.CanAddNewItem Then
            MessageBox.Show("You cannot add items to the list.")
            Exit Sub
        End If

        ' Create a window that prompts the user to enter a new 
        ' item to sell. 
        Dim win As New AddItemWindow()

        ' Create an item, depending on which RadioButton is selected. 
        ' Radio buttons correspond to book, cd, dvd, or other. 
        Dim newItem As LibraryItem

        If CBool(Book.IsChecked) Then
            newItem = New Book("Enter the book title", "Enter an Author",
                "Enter a Genre", "Enter a call number",
                DateTime.Now + New TimeSpan(21, 0, 0, 0))
        ElseIf CBool(cd.IsChecked) Then
            newItem = New MusicCD("Enter the Album", "Enter the artist",
                0, "CD.******", DateTime.Now + New TimeSpan(14, 0, 0, 0))

        ElseIf CBool(dvd.IsChecked) Then
            newItem = New MovieDVD("Enter the movie title",
                "Enter the director", "Enter the genre", New TimeSpan(),
                "DVD.******", DateTime.Now + New TimeSpan(7, 0, 0, 0))
        Else
            newItem = New LibraryItem("Enter the title",
                "Enter the call number",
                DateTime.Now + New TimeSpan(14, 0, 0, 0))
        End If

        ' Add the new item to the collection by calling 
        ' IEditableCollectionViewAddNewItem.AddNewItem. 
        ' Set the DataContext of the AddItemWindow to the 
        ' returned item. 
        win.DataContext = viewToAddDisparateItems.AddNewItem(newItem)

        ' If the user submits the new item, commit the new 
        ' object to the collection. If the user cancels 
        ' adding the new item, discard the new item. 
        If CBool(win.ShowDialog()) Then
            viewToAddDisparateItems.CommitNew()
        Else
            viewToAddDisparateItems.CancelNew()
        End If
    End Sub
End Class
'</SnippetMainWindowLogic> 