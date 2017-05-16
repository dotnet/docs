' The following code example demonstrates the use of ListView.Clear() 
' and ListViewItem.Selected members.
'
' This snippet example requires a form that contains a ListView 
' called ListView1, on a form, with the View property set to Details.  
' The form also requires a button called button1.



Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView

    Public Sub New()
        MyBase.New()

        InitializeListView()



        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()

        Me.Button1.Location = New System.Drawing.Point(80, 192)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "See lunch menu"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Meal Selection"
        Me.ResumeLayout(False)

    End Sub

    '<snippet1>
    '<snippet2>
    Private Sub InitializeListView()

        ' Set up the inital values for the ListView and populate it.
        Me.ListView1 = New ListView
        Me.ListView1.Dock = DockStyle.Top
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Size = New System.Drawing.Size(292, 130)
        Me.ListView1.View = View.Details
        Me.ListView1.FullRowSelect = True

        Dim breakfast() As String = New String() {"Continental Breakfast", "Pancakes and Sausage", _
       "Denver Omelet", "Eggs & Bacon", "Bagel & Cream Cheese"}

        Dim breakfastPrices() As String = New String() {"3.09", "4.09", "4.19", _
           "4.79", "2.09"}

        PopulateMenu("Breakfast", breakfast, breakfastPrices)
    End Sub

    Private Sub PopulateMenu(ByVal meal As String, _
        ByVal menuItems() As String, ByVal menuPrices() As String)
        Dim columnHeader1 As New ColumnHeader
        With columnHeader1
            .Text = meal & " Choices"
            .TextAlign = HorizontalAlignment.Left
            .Width = 146
        End With
        Dim columnHeader2 As New ColumnHeader
        With columnHeader2
            .Text = "Price"
            .TextAlign = HorizontalAlignment.Center
            .Width = 142
        End With
        Me.ListView1.Columns.Add(columnHeader1)
        Me.ListView1.Columns.Add(columnHeader2)

        Dim count As Integer

        For count = 0 To menuItems.Length - 1
            Dim listItem As New ListViewItem(menuItems(count))
            listItem.SubItems.Add(menuPrices(count))
            ListView1.Items.Add(listItem)
        Next

        ' Use the Selected property to select the first item on 
        ' the list.
        ListView1.Focus()
        ListView1.Items(0).Selected = True
    End Sub
   '</snippet2>


    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Create new values for the ListView, clear the list, 
        ' and repopulate it.
        Dim lunch() As String = New String() {"Hamburger", _ 
            "Grilled Cheese", "Soup & Salad", "Club Sandwich", "Hotdog"}

        Dim lunchPrices() As String = New String() {"4.09", "5.09", _
            "5.19", "4.79", "2.09"}

        ListView1.Clear()

        PopulateMenu("Lunch", lunch, lunchPrices)
        Button1.Enabled = False
    End Sub
    '</snippet1>

    <System.STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class

 
