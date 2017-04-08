'<snippet200>
Imports System.Windows.Forms
Imports System.Drawing

Public Class DataGridViewRowDemo
    Inherits Form

#Region "Form setup"
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        AddButton(Button1, "Reset")
        AddButton(Button2, "Change Column 3 Header")
        AddButton(Button3, "Change Meatloaf Recipe")
        AddAdditionalButtons()
    End Sub

    Friend WithEvents dataGridView As DataGridView
    Friend WithEvents Button1 As Button = New Button()
    Friend WithEvents Button2 As Button = New Button()
    Friend WithEvents Button3 As Button = New Button()
    Friend WithEvents Button4 As Button = New Button()
    Friend WithEvents Button5 As Button = New Button()
    Friend WithEvents Button6 As Button = New Button()
    Friend WithEvents Button7 As Button = New Button()
    Friend WithEvents Button8 As Button = New Button()
    Friend WithEvents Button9 As Button = New Button()
    Friend WithEvents Button10 As Button = New Button()
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel _
        = New FlowLayoutPanel()

    Private Sub InitializeComponent()
        FlowLayoutPanel1.Location = New Point(454, 0)
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel1.Name = "flowlayoutpanel"
        ClientSize = New System.Drawing.Size(614, 360)
        Controls.Add(FlowLayoutPanel1)
        Text = Me.GetType.Name
        AutoSize = True
    End Sub
#End Region

#Region "setup DataGridView"
    Private thirdColumnHeader As String = "Main Ingredients"
    Private boringMeatloaf As String = "ground beef"
    Private boringMeatloafRanking As String = "*"
    Private boringRecipe As Boolean
    Private shortMode As Boolean

    Private Sub InitializeDataGridView(ByVal ignored As Object, _
    ByVal ignoredToo As EventArgs) Handles Me.Load

        dataGridView = New System.Windows.Forms.DataGridView
        Controls.Add(dataGridView)
        dataGridView.Size = New Size(300, 200)

        ' Create an unbound DataGridView by declaring a
        ' column count.
        dataGridView.ColumnCount = 4
        dataGridView.ColumnHeadersVisible = True
        AdjustDataGridViewSizing()

        ' Set the column header style.
        Dim columnHeaderStyle As New DataGridViewCellStyle
        columnHeaderStyle.BackColor = Color.Aqua
        columnHeaderStyle.Font = _
            New Font("Verdana", 10, FontStyle.Bold)
        dataGridView.ColumnHeadersDefaultCellStyle = _
            columnHeaderStyle

        ' Set the column header names.
        dataGridView.Columns(0).Name = "Recipe"
        dataGridView.Columns(1).Name = "Category"
        dataGridView.Columns(2).Name = thirdColumnHeader
        dataGridView.Columns(3).Name = "Rating"

        ' Populate the rows.
        Dim row1 As String() = New String() _
            {"Meatloaf", "Main Dish", boringMeatloaf, _
            boringMeatloafRanking}
        Dim row2 As String() = New String() _
            {"Key Lime Pie", "Dessert", _
            "lime juice, evaporated milk", _
            "****"}
        Dim row3 As String() = New String() _
            {"Orange-Salsa Pork Chops", "Main Dish", _
            "pork chops, salsa, orange juice", "****"}
        Dim row4 As String() = New String() _
            {"Black Bean and Rice Salad", "Salad", _
            "black beans, brown rice", _
            "****"}
        Dim row5 As String() = New String() _
            {"Chocolate Cheesecake", "Dessert", "cream cheese", _
            "***"}
        Dim row6 As String() = New String() _
            {"Black Bean Dip", "Appetizer", _
            "black beans, sour cream", _
                "***"}
        Dim rows As Object() = New Object() {row1, row2, _
            row3, row4, row5, row6}

        Dim rowArray As String()
        For Each rowArray In rows
            dataGridView.Rows.Add(rowArray)
        Next

        shortMode = False
        boringRecipe = True
    End Sub

    Private Sub AddButton(ByVal button As Button, _
        ByVal buttonLabel As String)

        FlowLayoutPanel1.Controls.Add(button)
        button.TabIndex = FlowLayoutPanel1.Controls.Count
        button.Text = buttonLabel
        button.AutoSize = True
    End Sub

    ' Reset columns to initial disorderly arrangement.
    Private Sub Button1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button1.Click
        Controls.Remove(dataGridview)
        dataGridView.Dispose()
        InitializeDataGridView(Nothing, Nothing)
    End Sub

    ' Change column 3 header.
    Private Sub Button2_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button2.Click

        Toggle(shortMode)
        If shortMode Then dataGridView.Columns(2).HeaderText = _
            "S" _
            Else dataGridView.Columns(2).HeaderText = _
                thirdColumnHeader
    End Sub

    Private Shared Sub Toggle(ByRef toggleThis As Boolean)
        toggleThis = Not toggleThis
    End Sub

    ' Change meatloaf recipe.
    Private Sub Button3_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button3.Click

        Toggle(boringRecipe)
        If boringRecipe Then
            SetMeatloaf(boringMeatloaf, boringMeatloafRanking)
        Else
            Dim greatMeatloafRecipe As String = "1 lb. lean ground beef, " _
                & "1/2 cup bread crumbs, 1/4 cup ketchup," _
                & "1/3 tsp onion powder, " _
                & "1 clove of garlic, 1/2 pack onion soup mix " _
                & " dash of your favorite BBQ Sauce"
            SetMeatloaf(greatMeatloafRecipe, "***")
        End If
    End Sub

    Private Sub SetMeatloaf(ByVal recipe As String, _
        ByVal rating As String)

        dataGridView.Rows(0).Cells(2).Value = recipe
        dataGridView.Rows(0).Cells(3).Value = rating
    End Sub
#End Region

#Region "demonstration code"
    Private Sub AddAdditionalButtons()
        AddButton(Button4, "Set Row Two Minimum Height")
        AddButton(Button5, "Set Row One Height")
        AddButton(Button6, "Label Rows")
        AddButton(Button7, "Turn on Extra Edge")
        AddButton(Button8, "Give Cheesecake an Excellent Rating")
    End Sub

    Private Sub AdjustDataGridViewSizing()
        dataGridView.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridView.Columns(ratingColumn).Width = 50
    End Sub

    '<snippet207>
    ' Set minimum height.
    Private Sub Button4_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        Dim secondRow As Integer = 1
        Dim row As DataGridViewRow = dataGridView.Rows(secondRow)
        row.MinimumHeight = 40
    End Sub
    '</snippet207> 

    '<snippet208>
    ' Set height.
    Private Sub Button5_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button5.Click

        Dim row As DataGridViewRow = dataGridView.Rows(0)
        row.Height = 15
    End Sub
    '</snippet208>

    '<snippet209>
    ' Set row labels.
    Private Sub Button6_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button6.Click

        Dim rowNumber As Integer = 1
        For Each row As DataGridViewRow In dataGridView.Rows
            If row.IsNewRow Then Continue For
            row.HeaderCell.Value = "Row " & rowNumber
            rowNumber = rowNumber + 1
        Next
        dataGridView.AutoResizeRowHeadersWidth( _
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
    End Sub
    '</snippet209>

    '<snippet210>
    ' Set a thick horizontal edge.
    Private Sub Button7_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button7.Click

        Dim secondRow As Integer = 1
        Dim row As DataGridViewRow = dataGridView.Rows(secondRow)
        row.DividerHeight = 10

    End Sub
    '</snippet210>

    '<snippet211>
    ' Give cheescake excellent rating.
    Private Sub Button8_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button8.Click

        UpdateStars(dataGridView.Rows(4), "******************")
    End Sub

    Private ratingColumn As Integer = 3

    Private Sub UpdateStars(ByVal row As DataGridViewRow, _
        ByVal stars As String)

        row.Cells(ratingColumn).Value = stars

        ' Resize the column width to account for the new value.
        row.DataGridView.AutoResizeColumn(ratingColumn, _
            DataGridViewAutoSizeColumnMode.DisplayedCells)

    End Sub
    '</snippet211>
#End Region

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New DataGridViewRowDemo())
    End Sub

End Class
'</snippet200>