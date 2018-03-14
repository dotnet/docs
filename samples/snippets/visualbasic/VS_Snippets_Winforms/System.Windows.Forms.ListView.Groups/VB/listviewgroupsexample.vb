'<Snippet1>
Imports System
Imports System.Collections
Imports System.Windows.Forms

Public Class ListViewGroupsExample
    Inherits Form

    Private myListView As ListView

    ' Determine whether Windows XP or a later
    ' operating system is present.
    Private isRunningXPOrLater As Boolean = _
        OSFeature.Feature.IsPresent(OSFeature.Themes)
    
    ' Declare a Hashtable array in which to store the groups.
    Private groupTables() As Hashtable
    
    ' Declare a variable to store the current grouping column.
    Private groupColumn As Integer = 0
    
    Public Sub New()
        ' Initialize myListView.
        myListView = New ListView()
        myListView.Dock = DockStyle.Fill
        myListView.View = View.Details
        myListView.Sorting = SortOrder.Ascending
        
        ' Create and initialize column headers for myListView.
        Dim columnHeader0 As New ColumnHeader()
        columnHeader0.Text = "Title"
        columnHeader0.Width = -1
        Dim columnHeader1 As New ColumnHeader()
        columnHeader1.Text = "Author"
        columnHeader1.Width = -1
        Dim columnHeader2 As New ColumnHeader()
        columnHeader2.Text = "Year"
        columnHeader2.Width = -1
        
        ' Add the column headers to myListView.
        myListView.Columns.AddRange( New ColumnHeader() _
            {columnHeader0, columnHeader1, columnHeader2} )
        
        ' Add a handler for the ColumnClick event.
        AddHandler myListView.ColumnClick, AddressOf myListView_ColumnClick
        
        ' Create items and add them to myListView.
        Dim item0 As New ListViewItem( New String() _
            {"Programming Windows", _
            "Petzold, Charles", _
            "1998"} )
        Dim item1 As New ListViewItem( New String() _
            {"Code: The Hidden Language of Computer Hardware and Software", _
            "Petzold, Charles", _
            "2000"} )
        Dim item2 As New ListViewItem( New String() _
            {"Programming Windows with C#", _
            "Petzold, Charles", _
            "2001"} )
        Dim item3 As New ListViewItem( New String() _
            {"Coding Techniques for Microsoft Visual Basic .NET", _
            "Connell, John", _
            "2001"} )
        Dim item4 As New ListViewItem( New String() _
            {"C# for Java Developers", _
            "Jones, Allen / Freeman, Adam", _
            "2002"} )
        Dim item5 As New ListViewItem( New String() _
            {"Microsoft .NET XML Web Services Step by Step", _
            "Jones, Allen / Freeman, Adam", _
            "2002"} )
        myListView.Items.AddRange( _
            New ListViewItem() {item0, item1, item2, item3, item4, item5})
        
        If isRunningXPOrLater
            ' Create the groupsTable array and populate it with one 
            ' hash table for each column.
            groupTables = New Hashtable(myListView.Columns.Count) {}
            Dim column As Integer
            For column = 0 To myListView.Columns.Count - 1
                ' Create a hash table containing all the groups 
                ' needed for a single column.
                groupTables(column) = CreateGroupsTable(column)
            Next column
            
            ' Start with the groups created for the Title column.
            SetGroups(0)
        End If
        
        ' Initialize the form.
        Me.Controls.Add(myListView)
        Me.Size = New System.Drawing.Size(550, 330)
        Me.Text = "ListView Groups Example"
    End Sub 'New
    
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New ListViewGroupsExample())
    End Sub 'Main
    
    ' Groups the items using the groups created for the clicked 
    ' column.
    Private Sub myListView_ColumnClick( _
        sender As Object, e As ColumnClickEventArgs)

        ' Set the sort order to ascending when changing
        ' column groups; otherwise, reverse the sort order.
        If myListView.Sorting = SortOrder.Descending OrElse _
            isRunningXPOrLater And e.Column <> groupColumn Then
            myListView.Sorting = SortOrder.Ascending
        Else
            myListView.Sorting = SortOrder.Descending
        End If
        groupColumn = e.Column
        
        ' Set the groups to those created for the clicked column.
        If isRunningXPOrLater Then
            SetGroups(e.Column)
        End If
    End Sub 'myListView_ColumnClick
    
    '<Snippet2>
    ' Sets myListView to the groups created for the specified column.
    Private Sub SetGroups(column As Integer)
        ' Remove the current groups.
        myListView.Groups.Clear()
        
        ' Retrieve the hash table corresponding to the column.
        Dim groups As Hashtable = CType(groupTables(column), Hashtable)
        
        ' Copy the groups for the column to an array.
        Dim groupsArray(groups.Count - 1) As ListViewGroup
        groups.Values.CopyTo(groupsArray, 0)
        
        ' Sort the groups and add them to myListView.
        Array.Sort(groupsArray, New ListViewGroupSorter(myListView.Sorting))
        myListView.Groups.AddRange(groupsArray)
        
        ' Iterate through the items in myListView, assigning each 
        ' one to the appropriate group.
        Dim item As ListViewItem
        For Each item In myListView.Items
            ' Retrieve the subitem text corresponding to the column.
            Dim subItemText As String = item.SubItems(column).Text
            
            ' For the Title column, use only the first letter.
            If column = 0 Then
                subItemText = subItemText.Substring(0, 1)
            End If 

            ' Assign the item to the matching group.
            item.Group = CType(groups(subItemText), ListViewGroup)
        Next item
    End Sub 'SetGroups
    '</Snippet2>

    '<Snippet3>
    ' Creates a Hashtable object with one entry for each unique
    ' subitem value (or initial letter for the parent item)
    ' in the specified column.
    Private Function CreateGroupsTable(column As Integer) As Hashtable
        ' Create a Hashtable object.
        Dim groups As New Hashtable()
        
        ' Iterate through the items in myListView.
        Dim item As ListViewItem
        For Each item In myListView.Items
            ' Retrieve the text value for the column.
            Dim subItemText As String = item.SubItems(column).Text
            
            ' Use the initial letter instead if it is the first column.
            If column = 0 Then
                subItemText = subItemText.Substring(0, 1)
            End If 

            ' If the groups table does not already contain a group
            ' for the subItemText value, add a new group using the 
            ' subItemText value for the group header and Hashtable key.
            If Not groups.Contains(subItemText) Then
                groups.Add( subItemText, New ListViewGroup(subItemText, _
                    HorizontalAlignment.Left) )
            End If
        Next item
        
        ' Return the Hashtable object.
        Return groups
    End Function 'CreateGroupsTable
    '</Snippet3>

    ' Sorts ListViewGroup objects by header value.
    Private Class ListViewGroupSorter
        Implements IComparer 
        
        Private order As SortOrder
        
        ' Stores the sort order.
        Public Sub New(theOrder As SortOrder)
            order = theOrder
        End Sub 'New
        
        ' Compares the groups by header value, using the saved sort
        ' order to return the correct value.
        Public Function Compare(x As Object, y As Object) As Integer _
            Implements IComparer.Compare
            Dim result As Integer = String.Compare( _
                CType(x, ListViewGroup).Header, _
                CType(y, ListViewGroup).Header )
            If order = SortOrder.Ascending Then
                Return result
            Else
                Return -result
            End If
        End Function 'Compare
    End Class 'ListViewGroupSorter 

End Class 'ListViewGroupsExample
'</Snippet1>