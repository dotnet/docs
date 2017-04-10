Imports System
Imports System.Windows.Forms
Imports System.Drawing

'<snippet0> 
Public Class AutoSizing
    Inherits System.Windows.Forms.Form

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
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
    Friend WithEvents Button11 As Button = New Button()
    Friend WithEvents DataGridView1 As DataGridView

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        AddDirections()

        AddButton(Button1, "Reset")
        AddButton(Button2, "Change Column 3 Header")
        AddButton(Button3, "Change Meatloaf Recipe")
        AddButton(Button4, "Change Restaurant 2")

        AddButtonsForAutomaticResizing()
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

    Private Sub InitializeComponent()
        Me.FlowLayoutPanel1 = New FlowLayoutPanel
        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = _
            New System.Drawing.Point(454, 0)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.TabIndex = 7

        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Text = Me.GetType().Name
        Me.AutoSize = True
    End Sub

    Private startingSize As Size
    Private thirdColumnHeader As String = "Main Ingredients"
    Private boringMeatloaf As String = "ground beef"
    Private boringMeatloafRanking As String = "*"
    Private boringRecipe As Boolean
    Private shortMode As Boolean
    Private otherRestaurant As String = "Gomes's Saharan Sushi"

    Private Sub InitializeDataGridView(ByVal ignored As Object, _
    ByVal ignoredToo As EventArgs) Handles Me.Load
        DataGridView1 = New System.Windows.Forms.DataGridView
        Controls.Add(DataGridView1)
        startingSize = New Size(450, 400)
        DataGridView1.Size = startingSize

        SetUpColumns()
        PopulateRows()

        shortMode = False
        boringRecipe = True
        AddLabels()
    End Sub

    Private Sub SetUpColumns()
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
            {"Black Bean Dip", "Appetizer", "black beans, sour cream", _
                "***"}
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
        FlowLayoutPanel1.Controls.Add(button)
    End Sub

    Private Sub resetToDisorder(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button1.Click

        DataGridView1.Size = startingSize
        Controls.Remove(DataGridView1)
        DataGridView1.Dispose()
        InitializeDataGridView(Nothing, Nothing)
    End Sub

    Private Sub ChangeColumn3Header(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button2.Click

        Toggle(shortMode)
        If shortMode Then DataGridView1.Columns(2).HeaderText = "S" _
            Else DataGridView1.Columns(2).HeaderText = _
                thirdColumnHeader
    End Sub

    Private Shared Function Toggle(ByRef toggleThis As Boolean) _
    As Boolean
        toggleThis = Not toggleThis
        Return toggleThis
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
                & "1 clove of garlic, 1/2 pack onion soup mix, " _
                & "dash of your favorite BBQ Sauce"
            SetMeatloaf(greatMeatloafRecipe, "***")
        End If
    End Sub

    Private Sub ChangeRestaurant(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        If Not DataGridView1.Rows(2).HeaderCell.Value _
            .Equals(otherRestaurant) Then

            DataGridView1.Rows(2).HeaderCell.Value = _
                otherRestaurant
        Else
            DataGridView1.Rows(2).HeaderCell.Value = _
                "Restaurant 2"
        End If
    End Sub

    Private Sub SetMeatloaf(ByVal recipe As String, _
    ByVal rating As String)
        DataGridView1.Rows(0).Cells(2).Value = recipe
        DataGridView1.Rows(0).Cells(3).Value = rating
    End Sub

    Private currentLayoutName As String = _
        "DataGridView.AutoSizeRowsMode is currently: "
    Private Sub AddLabels()
        Dim current As Label = CType( _
        FlowLayoutPanel1.Controls(currentLayoutName), Label)

        If current Is Nothing Then
            current = New Label()
            current.AutoSize = True
            current.Name = currentLayoutName
            FlowLayoutPanel1.Controls.Add(current)
            current.Text = currentLayoutName & _
               DataGridView1.AutoSizeRowsMode.ToString()
        End If
    End Sub

#Region "Automatic Resizing"
    Private Sub AddButtonsForAutomaticResizing()
        AddButton(Button5, "Keep Column Headers Sized")
        AddButton(Button6, "Keep Row Headers Sized")
        AddButton(Button7, "Keep Rows Sized")
        AddButton(Button8, "Keep Row Headers Sized with RowsMode")
        AddButton(Button9, "Disable AutoSizeRowsMode")
        AddButton(Button10, "AutoSize third column by rows")
        AddButton(Button11, "AutoSize third column by rows and headers")
    End Sub

    '<snippet7>
    Private Sub ColumnHeadersHeightSizeMode(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button5.Click

        DataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.AutoSize

    End Sub
    '</snippet7>

    '<snippet8>
    Private Sub RowHeadersWidthSizeMode(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button6.Click

        DataGridView1.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

    End Sub
    '</snippet8>

    '<snippet9>
    Private Sub AutoSizeRowsMode(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button7.Click

        DataGridView1.AutoSizeRowsMode = _
            DataGridViewAutoSizeRowsMode.AllCells

    End Sub
    '</snippet9>

    Private Sub AutoSizeRowHeadersUsingAllHeadersMode _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Button8.Click

        DataGridView1.AutoSizeRowsMode = _
            DataGridViewAutoSizeRowsMode.AllHeaders

    End Sub

    '<snippet10>
    Private Sub WatchRowsModeChanges(ByVal sender As Object, _
        ByVal modeEvent As DataGridViewAutoSizeModeEventArgs) _
        Handles DataGridView1.AutoSizeRowsModeChanged

        Dim label As Label = CType(FlowLayoutPanel1.Controls _
            (currentLayoutName), Label)

        If modeEvent.PreviousModeAutoSized Then
            label.Text = "changed to different " & label.Name & _
                DataGridView1.AutoSizeRowsMode.ToString()
        Else
            label.Text = label.Name & _
                DataGridView1.AutoSizeRowsMode.ToString()
        End If
    End Sub
    '</snippet10>

    Private Sub DisableAutoSizeRowsMode(ByVal sender As Object, _
    ByVal modeEvent As EventArgs) Handles Button9.Click

        DataGridView1.AutoSizeRowsMode = _
            DataGridViewAutoSizeRowsMode.None
    End Sub

    '<snippet11>
    Private Sub AutoSizeOneColumn(ByVal sender As Object, _
    ByVal theEvent As EventArgs) Handles Button10.Click

        Dim column As DataGridViewColumn = DataGridView1.Columns(2)
        column.AutoSizeMode = _
            DataGridViewAutoSizeColumnMode.DisplayedCells

    End Sub
    '</snippet11>

    Private Sub AutoSizeOneColumnIncludingHeaders(ByVal sender As Object, _
    ByVal theEvent As EventArgs) Handles Button11.Click

        Dim column As DataGridViewColumn = DataGridView1.Columns(2)
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

    End Sub
#End Region

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New AutoSizing())
    End Sub

End Class
'</snippet0>