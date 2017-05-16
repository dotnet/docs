Imports System.Windows.Forms
Imports System.Drawing
Imports System

'<snippet0>
Public Class ProgrammaticSizing
    Inherits System.Windows.Forms.Form

#Region " form setup "
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        AddDirections()

        AddButton(Button1, "Reset")
        AddButton(Button2, "Change Column 3 Header")
        AddButton(Button3, "Change Meatloaf Recipe")
        AddButton(Button10, "Change Restaurant 2")
        AddButtonsForProgrammaticResizing()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button = New Button()
    Friend WithEvents Button2 As Button = New Button()
    Friend WithEvents Button3 As Button = New Button()
    Friend WithEvents Button4 As Button = New Button()
    Friend WithEvents Button5 As Button = New Button()
    Friend WithEvents Button6 As Button = New Button()
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Button7 As Button = New Button()
    Friend WithEvents Button8 As Button = New Button()
    Friend WithEvents Button9 As Button = New Button()
    Friend WithEvents Button10 As Button = New Button()
    Friend WithEvents Button11 As Button = New Button()

    Private Sub InitializeComponent()
        Me.FlowLayoutPanel1 = New FlowLayoutPanel
        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New Point(454, 0)
        Me.FlowLayoutPanel1.AutoSize = True

        Me.AutoSize = True
        Me.Text = Me.GetType().Name
        Me.Controls.Add(FlowLayoutPanel1)
    End Sub

    Private Sub AddDirections()
        Dim directions As New Label()
        directions.AutoSize = True
        Dim newLine As String = Environment.NewLine
        directions.Text = "Press the buttons that start " & newLine _
            & "with 'Change' to see how different sizing " & newLine _
            & "modes deal with content changes."

        FlowLayoutPanel1.Controls.Add(directions)
    End Sub

    Public Shared Sub Main()
        Application.Run(New ProgrammaticSizing())
    End Sub
#End Region

    Private startingSize As Size
    Private thirdColumnHeader As String = "Main Ingredients"
    Private boringMeatloaf As String = "ground beef"
    Private boringMeatloafRanking As String = "*"
    Private boringRecipe As Boolean
    Private shortMode As Boolean
    Private otherRestaurant As String = "Gomes's Saharan Sushi"

    Private Sub InitializeDataGridView(ByVal ignored As Object, _
        ByVal ignoredToo As EventArgs) Handles Me.Load
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.DataGridView1)

        startingSize = New Size(450, 400)
        DataGridView1.Size = startingSize

        AddColumns()
        PopulateRows()

        shortMode = False
        boringRecipe = True
    End Sub

    Private Sub AddColumns()
        DataGridView1.ColumnCount = 4
        DataGridView1.ColumnHeadersVisible = True

        Dim columnHeaderStyle As New DataGridViewCellStyle
        columnHeaderStyle.BackColor = Color.Aqua
        columnHeaderStyle.Font = New Font("Verdana", 10, _
            FontStyle.Bold)
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
            {"Black Bean and Rice Salad", "Salad", _
            "black beans, brown rice", _
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

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For
            row.HeaderCell.Value = "Restaurant " & row.Index
        Next

    End Sub

    Private Sub AddButton(ByVal button As Button, _
        ByVal buttonLabel As String)

        button.Text = buttonLabel
        button.AutoSize = True
        button.TabIndex = FlowLayoutPanel1.Controls.Count
        FlowLayoutPanel1.Controls.Add(button)
    End Sub

    Private Sub ResetToDisorder(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button1.Click

        Controls.Remove(DataGridView1)
        DataGridView1.Size = startingSize
        DataGridView1.Dispose()
        InitializeDataGridView(Nothing, Nothing)
    End Sub

    Private Sub ChangeColumn3Header(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button2.Click

        Toggle(shortMode)
        If shortMode Then DataGridView1.Columns(2).HeaderText = "S" _
        Else DataGridView1.Columns(2).HeaderText = thirdColumnHeader
    End Sub

    Private Shared Function Toggle(ByRef toggleThis As Boolean) _
        As Boolean

        toggleThis = Not toggleThis
    End Function

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

    Private Sub ChangeRestaurant(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button10.Click

        If DataGridView1.Rows(2).HeaderCell.Value.Equals(otherRestaurant) Then
            DataGridView1.Rows(2).HeaderCell.Value = _
                "Restaurant 2"
        Else
            DataGridView1.Rows(2).HeaderCell.Value = _
                otherRestaurant
        End If

    End Sub

#Region "programmatic resizing"

    Private Sub AddButtonsForProgrammaticResizing()
        AddButton(Button4, "Size Third Column")
        AddButton(Button5, "Size Column Headers")
        AddButton(Button6, "Size All Columns")
        AddButton(Button7, "Size Third Row")
        AddButton(Button8, "Size First Row Header Using All Headers")
        AddButton(Button9, "Size All Rows and Row Headers")
        AddButton(Button11, "Size All Rows")
    End Sub

    ' The following code example resizes the second column to fit.
    '<snippet1>
    Private Sub SizeThirdColumnHeader(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        DataGridView1.AutoResizeColumn( _
            2, DataGridViewAutoSizeColumnMode.ColumnHeader)

    End Sub
    '</snippet1>

    ' The following code example resizes the second column to fit 
    ' the header 
    ' text, but it leaves the widths of the 
    ' row headers and columns unchanged.  
    '<snippet2>
    Private Sub SizeColumnHeaders(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button5.Click

        DataGridView1.AutoResizeColumnHeadersHeight(2)

    End Sub
    '</snippet2>

    ' The following code example resizes all the columns to fit the
    ' header text and column contents.  
    '<snippet3>
    Private Sub SizeAllColumns(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button6.Click

        DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

    End Sub
    '</snippet3>

    ' The following code example resizes the third row 
    ' to fit the column contents.   
    '<snippet4>
    Private Sub SizeThirdRow(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button7.Click

        Dim thirdRow As Integer = 2
        DataGridView1.AutoResizeRow( _
            2, DataGridViewAutoSizeRowMode.AllCellsExceptHeader)

    End Sub
    '</snippet4>

    ' The following code example resizes the first displayed row 
    ' to fit it's header. 
    '<snippet5>
    Private Sub SizeFirstRowHeaderToAllHeaders(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button8.Click

        DataGridView1.AutoResizeRowHeadersWidth( _
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)

    End Sub
    '</snippet5>

    ' Size all the rows, including their headers and columns.
    '<snippet6>
    Private Sub SizeAllRowsAndTheirHeaders(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button9.Click

        DataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)

    End Sub
    '</snippet6>

    '<snippet7>
    Private Sub SizeAllRows(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button11.Click

        DataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)

    End Sub
    '</snippet7>
#End Region
End Class
'</snippet0>