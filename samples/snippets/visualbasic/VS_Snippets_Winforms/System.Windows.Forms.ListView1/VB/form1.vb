' The following Snippet code example demonstrates using the: 
' ListView.MultiSelect, ListView.SelectedItems, 
' ListView.SelectIndices, SelectedIndexCollection, 
' SelectedListViewItemCollection ListView.SelectedIndexChanged event, 
' and ListView.HeaderStyle members and the SelectedIndexCollection and
' SelectedListViewItemCollection classes.

 
Imports System.Windows.Forms
Imports System.Drawing
Imports System

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        InitializeListView()
    End Sub

    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()

        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        Me.TextBox1.Location = New System.Drawing.Point(88, 168)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(120, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        Me.Label1.Location = New System.Drawing.Point(32, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Total: $"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)

        Me.Name = "Form1"
        Me.Text = "Breakfast Menu"
        Me.ResumeLayout(False)

    End Sub

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    ' This method adds two columns to the ListView, setting the Text 
    ' and TextAlign, and Width properties of each ColumnHeader.  The 
    ' HeaderStyle property is set to NonClickable since the ColumnClick 
    ' event is not handled.  Finally the method adds ListViewItems and 
    ' SubItems to each column.
    Private Sub InitializeListView()
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ListView1.BackColor = System.Drawing.SystemColors.Control
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(292, 130)
        Me.ListView1.TabIndex = 0
        Me.ListView1.View = System.Windows.Forms.View.Details
        Me.ListView1.MultiSelect = True
        Me.ListView1.HideSelection = False
        ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable
        Dim columnHeader1 As New ColumnHeader
        With columnHeader1
            .Text = "Breakfast Item"
            .TextAlign = HorizontalAlignment.Left
            .Width = 146
        End With
        Dim columnHeader2 As New ColumnHeader
        With columnHeader2
            .Text = "Price Each"
            .TextAlign = HorizontalAlignment.Center
            .Width = 142
        End With

        Me.ListView1.Columns.Add(columnHeader1)
        Me.ListView1.Columns.Add(columnHeader2)
        Dim foodList() As String = New String() {"Juice", "Coffee", _
            "Cereal & Milk", "Fruit Plate", "Toast & Jelly", _
            "Bagel & Cream Cheese"}
        Dim foodPrice() As String = New String() {"1.09", "1.09", _
            "2.19", "2.49", "1.49", "1.49"}
        Dim count As Integer
        For count = 0 To foodList.Length - 1
            Dim listItem As New ListViewItem(foodList(count))
            listItem.SubItems.Add(foodPrice(count))
            ListView1.Items.Add(listItem)
        Next
        Me.Controls.Add(Me.ListView1)
    End Sub
    '</snippet1>

    ' You can access the selected items directly with the SelectedItems   
    ' property or you can access them through the items' indices,  
    ' using the SelectedIndices property.  The following methods show
    ' the two approaches.


    '<snippet2>
    ' Uses the SelectedItems property to retrieve and tally the price 
    ' of the selected menu items.
    Private Sub ListView1_SelectedIndexChanged_UsingItems _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListView1.SelectedIndexChanged

        Dim breakfast As ListView.SelectedListViewItemCollection = _
            Me.ListView1.SelectedItems
        Dim item As ListViewItem
        Dim price As Double = 0.0
        For Each item In breakfast
            price += Double.Parse(item.SubItems(1).Text)
        Next

        ' Output the price to TextBox1.
        TextBox1.Text = CType(price, String)
    End Sub
    '</snippet2>

    '<snippet3>
    ' Uses the SelectedIndices property to retrieve and tally the price of  
    ' the selected menu items.
    Private Sub ListView1_SelectedIndexChanged_UsingIndices _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListView1.SelectedIndexChanged

        Dim indexes As ListView.SelectedIndexCollection = _
            Me.ListView1.SelectedIndices
        Dim index As Integer
        Dim price As Double = 0.0
        For Each index In indexes
            price += Double.Parse(Me.ListView1.Items(index).SubItems(1).Text)
        Next

        ' Output the price to TextBox1.
        TextBox1.Text = CType(price, String)
    End Sub
    '</snippet3>

End Class
 
