'<snippet1>
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class MyForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.Container
    Private myTable As DataTable
    Private myGrid As DataGrid = New DataGrid()

    Public Shared Sub Main()
        Application.Run(New MyForm())
    End Sub

    Public Sub New()
        Try
            InitializeComponent()
            myTable = New DataTable("NamesTable")
            myTable.Columns.Add(New DataColumn("Name"))
            Dim column As DataColumn = New DataColumn _
            ("id", GetType(System.Int32))
            myTable.Columns.Add(column)
            myTable.Columns.Add(New DataColumn _
            ("calculatedField", GetType(Boolean)))
            Dim namesDataSet As DataSet = New DataSet("myDataSet")
            namesDataSet.Tables.Add(myTable)
            myGrid.SetDataBinding(namesDataSet, "NamesTable")
            AddData()
            AddTableStyle()

        Catch exc As System.Exception
            Console.WriteLine(exc.ToString)
        End Try
    End Sub

    Private Sub AddTableStyle()
        ' Map a new  TableStyle to the DataTable. Then 
        ' add DataGridColumnStyle objects to the collection
        ' of column styles with appropriate mappings.
        Dim dgt As DataGridTableStyle = New DataGridTableStyle()
        dgt.MappingName = "NamesTable"

        Dim dgtbc As DataGridTextBoxColumn = _
        New DataGridTextBoxColumn()
        dgtbc.MappingName = "Name"
        dgtbc.HeaderText = "Name"
        dgt.GridColumnStyles.Add(dgtbc)

        dgtbc = New DataGridTextBoxColumn()
        dgtbc.MappingName = "id"
        dgtbc.HeaderText = "id"
        dgt.GridColumnStyles.Add(dgtbc)

        Dim db As DataGridBoolColumnInherit = _
        New DataGridBoolColumnInherit()
        db.HeaderText = "less than 1000 = blue"
        db.Width = 150
        db.MappingName = "calculatedField"
        dgt.GridColumnStyles.Add(db)

        myGrid.TableStyles.Add(dgt)

        ' This expression instructs the grid to change
        ' the color of the inherited DataGridBoolColumn
        ' according to the value of the id field. If it's
        ' less than 1000, the row is blue. Otherwise,
        ' the color is yellow.
        db.Expression = "id < 1000"
    End Sub

    Private Sub AddData()

        ' Add data with varying numbers for the id field.
        ' If the number is over 1000, the cell will paint
        ' yellow. Otherwise, it will be blue.
        Dim dRow As DataRow

        dRow = myTable.NewRow()
        dRow("Name") = "name 1"
        dRow("id") = 999
        myTable.Rows.Add(dRow)

        dRow = myTable.NewRow()
        dRow("Name") = "name 2"
        dRow("id") = 2300
        myTable.Rows.Add(dRow)

        dRow = myTable.NewRow()
        dRow("Name") = "name 3"
        dRow("id") = 120
        myTable.Rows.Add(dRow)

        dRow = myTable.NewRow()
        dRow("Name") = "name 4"
        dRow("id") = 4023
        myTable.Rows.Add(dRow)

        dRow = myTable.NewRow()
        dRow("Name") = "name 5"
        dRow("id") = 2345
        myTable.Rows.Add(dRow)

        myTable.AcceptChanges()
    End Sub

    Private Sub InitializeComponent()
        Me.Size = New Size(500, 500)
        myGrid.Size = New Size(350, 250)
        myGrid.TabStop = True
        myGrid.TabIndex = 1
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Controls.Add(myGrid)
    End Sub

End Class


Public Class DataGridBoolColumnInherit
    Inherits DataGridBoolColumn

    Private trueBrush As SolidBrush = Brushes.Blue
    Private falseBrush As SolidBrush = Brushes.Yellow
    Private expressionColumn As DataColumn = Nothing
    Shared count As Int32 = 0

    Public Property FalseColor() As Color
        Get
            Return falseBrush.Color
        End Get

        Set(ByVal Value As Color)

            falseBrush = New SolidBrush(Value)
            Invalidate()
        End Set
    End Property

    Public Property TrueColor() As Color
        Get
            Return trueBrush.Color
        End Get

        Set(ByVal Value As Color)

            trueBrush = New SolidBrush(Value)
            Invalidate()
        End Set
    End Property

    Public Sub New()
        count += 1
    End Sub

    ' This will work only with a DataSet or DataTable.
    ' The code is not compatible with IBindingList implementations.
    Public Property Expression() As String
        Get
            If Me.expressionColumn Is Nothing Then
                Return String.Empty
            Else
                Return Me.expressionColumn.Expression
            End If
        End Get
        Set(ByVal Value As String)
            If expressionColumn Is Nothing Then
                AddExpressionColumn(Value)
            Else
                expressionColumn.Expression = Value
            End If
            If (expressionColumn IsNot Nothing) And expressionColumn.Expression.Equals(Value) Then
                Return
            End If
            Invalidate()
        End Set
    End Property

    Private Sub AddExpressionColumn(ByVal value As String)
        ' Get the grid's data source. First check for a null 
        ' table or data grid.
        If Me.DataGridTableStyle Is Nothing Or _
        Me.DataGridTableStyle.DataGrid Is Nothing Then
            Return
        End If

        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim dv As DataView = CType(dg.BindingContext(dg.DataSource, dg.DataMember), CurrencyManager).List

        ' This works only with System.Data.DataTable.
        If dv Is Nothing Then
            Return
        End If

        ' If the user already added a column with the name 
        ' then exit. Otherwise, add the column and set the 
        ' expression to the value passed to this function.
        Dim col As DataColumn = dv.Table.Columns("__Computed__Column__")
        If (col IsNot Nothing) Then
            Return
        End If
        col = New DataColumn("__Computed__Column__" + count.ToString())

        dv.Table.Columns.Add(col)

        col.Expression = value
        expressionColumn = col
    End Sub


    ' Override the OnPaint method to paint the cell based on the expression.
    Protected Overloads Overrides Sub Paint _
    (ByVal g As Graphics, _
    ByVal bounds As Rectangle, _
    ByVal [source] As CurrencyManager, _
    ByVal rowNum As Integer, _
    ByVal backBrush As Brush, _
    ByVal foreBrush As Brush, _
    ByVal alignToRight As Boolean)
        Dim trueExpression As Boolean = False
        Dim hasExpression As Boolean = False
        Dim drv As DataRowView = [source].List(rowNum)
        hasExpression = (Me.expressionColumn IsNot Nothing) And (Me.expressionColumn.Expression IsNot Nothing) And Not Me.expressionColumn.Expression.Equals([String].Empty)

        ' Get the value from the expression column.
        ' For simplicity, we assume a True/False value for the 
        ' expression column.
        If hasExpression Then
            Dim expr As Object = drv.Row(expressionColumn.ColumnName)
            trueExpression = expr.Equals("True")
        End If

        ' Let the DataGridBoolColumn do the painting.
        If Not hasExpression Then
            MyBase.Paint(g, bounds, [source], rowNum, backBrush, foreBrush, alignToRight)
        End If

        ' Paint using the expression color for true or false, as calculated.
        If trueExpression Then
            MyBase.Paint(g, bounds, [source], rowNum, trueBrush, foreBrush, alignToRight)
        Else
            MyBase.Paint(g, bounds, [source], rowNum, falseBrush, foreBrush, alignToRight)
        End If
    End Sub
End Class
'</snippet1>