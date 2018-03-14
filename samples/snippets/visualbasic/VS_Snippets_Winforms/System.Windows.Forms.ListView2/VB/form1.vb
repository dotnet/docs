
' The following code example demonstrates using the ListView.CheckedItems, 
' CheckedItem.CheckState, ListView.BeginUpdate, and ListView.EndUpdate 
' members, along with instances of the ListViewCheckedItemCollection, 
' and ItemCheckEventArgs classes


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

    <System.STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    Private Sub InitializeListView()
        Me.ListView1 = New System.Windows.Forms.ListView

        ' Set properties such as BackColor, Location and Size
        Me.ListView1.BackColor = System.Drawing.SystemColors.Control
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Size = New System.Drawing.Size(292, 130)
        Me.ListView1.View = System.Windows.Forms.View.Details
        Me.ListView1.HideSelection = False

        ' Allow user to select multiple items.
        Me.ListView1.MultiSelect = True

        ' Show check boxes in the ListView.
        Me.ListView1.CheckBoxes = True

        'Set the column headers and populate the columns.
        ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable
        Dim columnHeader1 As New ColumnHeader
        With columnHeader1
            .Text = "Breakfast Choices"
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

        Dim foodPrice() As String = New String() {"1.09", "1.09", "2.19", _
            "2.79", "2.09", "2.69"}
        Dim count As Integer

        ' Members are added one at a time, so call BeginUpdate to ensure 
        ' the list is painted only once, rather than as each list item is added.
        ListView1.BeginUpdate()

        For count = 0 To foodList.Length - 1
            Dim listItem As New ListViewItem(foodList(count))
            listItem.SubItems.Add(foodPrice(count))
            ListView1.Items.Add(listItem)
        Next

        'Call EndUpdate when you finish adding items to the ListView.
        ListView1.EndUpdate()
        Me.Controls.Add(Me.ListView1)
    End Sub
    '</snippet1>

    '<snippet2>
    Dim price As Double = 0.0

    ' Handles the ItemChecked event. The method uses the CurrentValue property 
    ' of the ItemCheckEventArgs to retrieve and tally the price of the menu 
    ' items selected.  
    Private Sub ListView1_ItemCheck1(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ItemCheckEventArgs) _
        Handles ListView1.ItemCheck

        If (e.CurrentValue = CheckState.Unchecked) Then
            price += Double.Parse( _
            Me.ListView1.Items(e.Index).SubItems(1).Text)
        ElseIf (e.CurrentValue = CheckState.Checked) Then
            price -= Double.Parse( _
                Me.ListView1.Items(e.Index).SubItems(1).Text)
        End If

        ' Output the price to TextBox1.
        TextBox1.Text = CType(price, String)

    End Sub
    '</snippet2>


    '<snippet3>
    ' Handles the ItemCheck event.  The method loops through all the 
    ' checked items and tallies a new price each time an item is 
    ' checked or unchecked. It outputs the price to TextBox1.
    Private Sub ListView1_ItemCheck2(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ItemCheckEventArgs) _
        Handles ListView1.ItemCheck

        Dim item As ListViewItem
        Dim price As Double = 0.0
        Dim checkedItems As ListView.CheckedListViewItemCollection = _
            ListView1.CheckedItems
        For Each item In checkedItems
            price += Double.Parse(item.SubItems(1).Text)
        Next
        If (e.CurrentValue = CheckState.Unchecked) Then
            price += Double.Parse(Me.ListView1.Items(e.Index).SubItems(1).Text)
        ElseIf (e.CurrentValue = CheckState.Checked) Then
            price -= Double.Parse(Me.ListView1.Items(e.Index).SubItems(1).Text)
        End If

        ' Output the price to TextBox1.
        TextBox1.Text = CType(price, String)
    End Sub
    '</snippet3>

End Class


