Imports System.Windows.Forms
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        InitializeListView()
    End Sub

    Friend WithEvents Button1 As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(120, 224)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '<snippet1>
    '<snippet2>

    ' Declare the Listview object.
    Friend WithEvents myListView As System.Windows.Forms.ListView

    ' Initialize the ListView object with subitems of a different
    ' style than the default styles for the ListView.
    Private Sub InitializeListView()

        ' Set the Location, View and Width properties for the 
        ' ListView object. 
        myListView = New ListView
        With (myListView)
            .Location = New System.Drawing.Point(20, 20)

            ' The View property must be set to Details for the 
            ' subitems to be visible.
            .View = View.Details
            .Width = 250
        End With

        ' Each SubItem object requires a column, so add three columns.
        Me.myListView.Columns.Add("Key", 50, HorizontalAlignment.Left)
        Me.myListView.Columns.Add("A", 100, HorizontalAlignment.Left)
        Me.myListView.Columns.Add("B", 100, HorizontalAlignment.Left)

        ' Add a ListItem object to the ListView.
        Dim entryListItem As ListViewItem = myListView.Items.Add("Items")

        ' Set UseItemStyleForSubItems property to false to change 
        ' look of subitems.
        entryListItem.UseItemStyleForSubItems = False

        ' Add the expense subitem.
        Dim expenseItem As ListViewItem.ListViewSubItem = _
            entryListItem.SubItems.Add("Expense")

        ' Change the expenseItem object's color and font.
        expenseItem.ForeColor = System.Drawing.Color.Red
        expenseItem.Font = New System.Drawing.Font _
            ("Arial", 10, System.Drawing.FontStyle.Italic)

        ' Add a subitem called revenueItem 
        Dim revenueItem As ListViewItem.ListViewSubItem = _
            entryListItem.SubItems.Add("Revenue")

        ' Change the revenueItem object's color and font.
        revenueItem.ForeColor = System.Drawing.Color.Blue
        revenueItem.Font = New System.Drawing.Font _
            ("Times New Roman", 10, System.Drawing.FontStyle.Bold)

        ' Add the ListView to the form.
        Me.Controls.Add(Me.myListView)
    End Sub
    '</snippet1>

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' Use the ListView.TopItem property to access the SubItems
        ' and then reset their appearance.
        myListView.TopItem.SubItems(1).ResetStyle()
        myListView.TopItem.SubItems(2).ResetStyle()
    End Sub
    '</snippet2>

      <System.STAThreadAttribute()>Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
