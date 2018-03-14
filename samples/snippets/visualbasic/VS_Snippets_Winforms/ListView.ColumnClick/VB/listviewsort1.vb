'<Snippet1>
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections


Namespace ListViewSortFormNamespace

    Public Class ListViewSortForm
        Inherits Form

        Private listView1 As ListView

        Public Sub New()
            ' Create ListView items to add to the control.
            Dim listViewItem1 As New ListViewItem(New String() {"Banana", "a", "b", "c"}, -1, Color.Empty, Color.Yellow, Nothing)
            Dim listViewItem2 As New ListViewItem(New String() {"Cherry", "v", "g", "t"}, -1, Color.Empty, Color.Red, New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CType(0, System.Byte)))
            Dim listViewItem3 As New ListViewItem(New String() {"Apple", "h", "j", "n"}, -1, Color.Empty, Color.Lime, Nothing)
            Dim listViewItem4 As New ListViewItem(New String() {"Pear", "y", "u", "i"}, -1, Color.Empty, Color.FromArgb(CType(192, System.Byte), CType(128, System.Byte), CType(156, System.Byte)), Nothing)

            'Initialize the ListView control and add columns to it.
            Me.listView1 = New ListView

            ' Set the initial sorting type for the ListView.
            Me.listView1.Sorting = SortOrder.None
            ' Disable automatic sorting to enable manual sorting.
            Me.listView1.View = View.Details
            ' Add columns and set their text.
            Me.listView1.Columns.Add(New ColumnHeader)
            Me.listView1.Columns(0).Text = "Column 1"
            Me.listView1.Columns(0).Width = 100
            listView1.Columns.Add(New ColumnHeader)
            listView1.Columns(1).Text = "Column 2"
            listView1.Columns.Add(New ColumnHeader)
            listView1.Columns(2).Text = "Column 3"
            listView1.Columns.Add(New ColumnHeader)
            listView1.Columns(3).Text = "Column 4"
            ' Suspend control logic until form is done configuring form.
            Me.SuspendLayout()
            ' Add Items to the ListView control.
            Me.listView1.Items.AddRange(New ListViewItem() {listViewItem1, listViewItem2, listViewItem3, listViewItem4})
            ' Set the location and size of the ListView control.
            Me.listView1.Location = New Point(10, 10)
            Me.listView1.Name = "listView1"
            Me.listView1.Size = New Size(300, 100)
            Me.listView1.TabIndex = 0
            ' Enable editing of the items in the ListView.
            Me.listView1.LabelEdit = True
            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.listView1.ColumnClick, AddressOf ColumnClick

            ' Initialize the form.
            Me.ClientSize = New Size(400, 400)
            Me.Controls.AddRange(New Control() {Me.listView1})
            Me.Name = "ListViewSortForm"
            Me.Text = "Sorted ListView Control"
            ' Resume layout of the form.
            Me.ResumeLayout(False)
        End Sub 'New


        ' ColumnClick event handler.
        Private Sub ColumnClick(ByVal o As Object, ByVal e As ColumnClickEventArgs)
            ' Set the ListViewItemSorter property to a new ListViewItemComparer 
            ' object. Setting this property immediately sorts the 
            ' ListView using the ListViewItemComparer object.
            Me.listView1.ListViewItemSorter = New ListViewItemComparer(e.Column)
        End Sub

    End Class

    ' Implements the manual sorting of items by columns.
    Class ListViewItemComparer
        Implements IComparer

        Private col As Integer

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(ByVal column As Integer)
            col = column
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        End Function
    End Class
End Namespace
'</Snippet1>