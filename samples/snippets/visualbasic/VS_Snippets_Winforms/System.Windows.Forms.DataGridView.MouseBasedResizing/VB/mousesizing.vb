Imports System.Windows.Forms
Imports System.Drawing
Imports System

Public Class MouseSizing
    Inherits System.Windows.Forms.Form

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New MouseSizing())
    End Sub

#Region " set up form "
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1 = New FlowLayoutPanel
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()

        Me.Button1.Location = New System.Drawing.Point(454, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"

        Me.Button2.Location = New System.Drawing.Point(454, 33)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"

        Me.Button3.Location = New System.Drawing.Point(454, 62)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Button3"

        Me.Button4.Location = New System.Drawing.Point(3, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Button4"

        Me.Button5.Location = New System.Drawing.Point(3, 32)
        Me.Button5.Name = "Button5"
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Button5"

        Me.Button6.Location = New System.Drawing.Point(3, 61)
        Me.Button6.Name = "Button6"
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Button6"

        Me.FlowLayoutPanel1.Controls.Add(Me.Button4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button5)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button6)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button7)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button8)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button9)
        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New Point(454, 102)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.TabIndex = 7

        Me.Button7.Location = New System.Drawing.Point(3, 90)
        Me.Button7.Name = "Button7"
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "Button 7"

        Me.Button8.Location = New System.Drawing.Point(3, 119)
        Me.Button8.Name = "Button8"
        Me.Button8.TabIndex = 7
        Me.Button8.Text = "Button8"

        Me.Button9.Location = New System.Drawing.Point(3, 148)
        Me.Button9.Name = "Button9"
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "Button9"

        Me.AutoSize = True
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        InitializeButton(Button1, "Reset")
        InitializeButton(Button2, "Change Column 3 Header")
        InitializeButton(Button3, "Change Meatloaf Recipe")

        InitializeButtonsForAffectingMouseResizing()

        Me.Name = "MouseSizing"
        Me.Text = "MouseSizing"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
#End Region

#Region "setup form"
    Private startingSize As Size
    Private thirdColumnHeader As String = "Main Ingredients"
    Private boringMeatloaf As String = "ground beef"
    Private boringMeatloafRanking As String = "*"
    Private boringRecipe As Boolean
    Private shortMode As Boolean

    Private Sub InitializeDataGridView(ByVal ignored As Object, _
        ByVal ignoredToo As EventArgs) Handles Me.Load

        Me.DataGridView1 = New DataGridView
        Me.Controls.Add(Me.DataGridView1)

        startingSize = New Size(450, 400)
        DataGridView1.Size = startingSize

        SetUpColumns()
        PopulateRows()

        shortMode = False
        boringRecipe = True
    End Sub

    Private Sub SetupColumns()
        DataGridView1.ColumnCount = 4
        DataGridView1.ColumnHeadersVisible = True

        Dim columnHeaderStyle As New DataGridViewCellStyle
        columnHeaderStyle.BackColor = Color.Aqua
        columnHeaderStyle.Font = _
            New Font("Verdana", 10, FontStyle.Bold)
        DataGridView1.ColumnHeadersDefaultCellStyle = _
            columnHeaderStyle

        DataGridView1.Columns(0).Name = "Recipe"
        DataGridView1.Columns(1).Name = "Category"
        DataGridView1.Columns(2).Name = thirdColumnHeader
        DataGridView1.Columns(3).Name = "Rating"
    End Sub

    Private Sub PopulateRows()
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
            {"Black Bean and Rice Salad", _
            "Salad", "black beans, brown rice", _
            "****"}
        Dim row5 As String() = New String() _
            {"Chocolate Cheesecake", "Dessert", "cream cheese", _
            "***"}
        Dim row6 As String() = New String() _
            {"Black Bean Dip", "Appetizer", _
            "black beans, sour cream", "***"}
        Dim rows As Object() = New Object() {row1, row2, row3, _
            row4, row5, row6}

        Dim rowArray As String()
        For Each rowArray In rows
            DataGridView1.Rows.Add(rowArray)
        Next
    End Sub

    Private Shared Sub InitializeButton(ByVal button As Button, _
        ByVal buttonLabel As String)

        button.Text = buttonLabel
        button.AutoSize = True
    End Sub

    Private Sub resetToDisorder(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button1.Click

        Controls.Remove(DataGridView1)
        DataGridView1.Dispose()
        InitializeDataGridView(Nothing, Nothing)
    End Sub

    Private Sub ChangeColumn3Header(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button2.Click

        Toggle(shortMode)
        If shortMode Then DataGridView1.Columns(2).HeaderText = _
            "S" _
            Else DataGridView1.Columns(2).HeaderText = _
            thirdColumnHeader
    End Sub

    Private Shared Sub Toggle(ByRef toggleThis As Boolean)
        toggleThis = Not toggleThis
    End Sub

    Private Sub ChangeMeatloafRecipe(ByVal sender As Object, _
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

        DataGridView1.Rows(0).Cells(2).Value = recipe
        DataGridView1.Rows(0).Cells(3).Value = rating
    End Sub
#End Region

#Region "preventing mouse resizing"
    Private Sub InitializeButtonsForAffectingMouseResizing()
        InitializeButton(Button4, "Fix Column Header Height")
        InitializeButton(Button5, "Fix Row Header Width")
        InitializeButton(Button6, "Fix Third Column")
        InitializeButton(Button7, "Allow Mouse Resizing of Third Column ")
        InitializeButton(Button8, _
            "Use Sizing Behavior for Third Column")
        InitializeButton(Button9, "Fix Fourth Row")
    End Sub

    Private Sub FixColumnHeaderHeight(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        '<snippet10>
        DataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        '</snippet10>

    End Sub

    Private Sub FixRowHeadersWidth(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button5.Click

        '<snippet11>
        DataGridView1.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.DisableResizing
        '</snippet11>

    End Sub

    Private Sub FixThirdColumn(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button6.Click

        '<snippet12>
        DataGridView1.Columns(2).Resizable = DataGridViewTriState.False
        '</snippet12>

    End Sub

    Private Sub AllowThirdColumnToResize(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button7.Click

        '<snippet13>
        DataGridView1.Columns(2).Resizable = DataGridViewTriState.True
        '</snippet13>

    End Sub

    Private Sub SetThirdColumnToDefaultBehaviour( _
        ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button8.Click

        '<snippet14>
        DataGridView1.Columns(2).Resizable = _
            DataGridViewTriState.NotSet
        '</snippet14>

    End Sub

    Private Sub FixFourthRow(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button9.Click

        '<snippet15>
        DataGridView1.Rows(3).Resizable = DataGridViewTriState.False
        '</snippet15>

    End Sub
#End Region
End Class