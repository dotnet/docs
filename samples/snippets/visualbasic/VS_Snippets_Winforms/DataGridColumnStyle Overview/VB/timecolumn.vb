'<snippet1>
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Security.Permissions

' This example shows how to create your own column style that
' hosts a control, in this case, a DateTimePicker.
Public Class DataGridTimePickerColumn
    Inherits DataGridColumnStyle

    Private customDateTimePicker1 As New CustomDateTimePicker()

    ' The isEditing field tracks whether or not the user is
    ' editing data with the hosted control.
    Private isEditing As Boolean

    Public Sub New()
        customDateTimePicker1.Visible = False
    End Sub

    Protected Overrides Sub Abort(ByVal rowNum As Integer)
        isEditing = False
        RemoveHandler customDateTimePicker1.ValueChanged, _
            AddressOf TimePickerValueChanged
        Invalidate()
    End Sub

    Protected Overrides Function Commit _
        (ByVal dataSource As CurrencyManager, ByVal rowNum As Integer) _
        As Boolean

        customDateTimePicker1.Bounds = Rectangle.Empty

        RemoveHandler customDateTimePicker1.ValueChanged, _
            AddressOf TimePickerValueChanged

        If Not isEditing Then
            Return True
        End If
        isEditing = False

        Try
            Dim value As DateTime = customDateTimePicker1.Value
            SetColumnValueAtRow(dataSource, rowNum, value)
        Catch
        End Try

        Invalidate()
        Return True
    End Function

    Protected Overloads Overrides Sub Edit( _
        ByVal [source] As CurrencyManager, _
        ByVal rowNum As Integer, _
        ByVal bounds As Rectangle, _
        ByVal [readOnly] As Boolean, _
        ByVal displayText As String, _
        ByVal cellIsVisible As Boolean)

        Dim value As DateTime = _
        CType(GetColumnValueAtRow([source], rowNum), DateTime)
        If cellIsVisible Then
            customDateTimePicker1.Bounds = New Rectangle _
            (bounds.X + 2, bounds.Y + 2, bounds.Width - 4, _
            bounds.Height - 4)

            customDateTimePicker1.Value = value
            customDateTimePicker1.Visible = True
            AddHandler customDateTimePicker1.ValueChanged, _
            AddressOf TimePickerValueChanged
        Else
            customDateTimePicker1.Value = value
            customDateTimePicker1.Visible = False
        End If

        If customDateTimePicker1.Visible Then
            DataGridTableStyle.DataGrid.Invalidate(bounds)
        End If

        customDateTimePicker1.Focus()

    End Sub

    Protected Overrides Function GetPreferredSize( _
        ByVal g As Graphics, _
        ByVal value As Object) As Size

        Return New Size(100, customDateTimePicker1.PreferredHeight + 4)

    End Function

    Protected Overrides Function GetMinimumHeight() As Integer
        Return customDateTimePicker1.PreferredHeight + 4
    End Function

    Protected Overrides Function GetPreferredHeight( _
        ByVal g As Graphics, ByVal value As Object) As Integer

        Return customDateTimePicker1.PreferredHeight + 4

    End Function

    Protected Overloads Overrides Sub Paint( _
        ByVal g As Graphics, ByVal bounds As Rectangle, _
        ByVal [source] As CurrencyManager, ByVal rowNum As Integer)

        Paint(g, bounds, [source], rowNum, False)

    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, _
        ByVal bounds As Rectangle, ByVal [source] As CurrencyManager, _
        ByVal rowNum As Integer, ByVal alignToRight As Boolean)

        Paint(g, bounds, [source], rowNum, Brushes.Red, _
            Brushes.Blue, alignToRight)

    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, _
        ByVal bounds As Rectangle, ByVal [source] As CurrencyManager, _
        ByVal rowNum As Integer, ByVal backBrush As Brush, _
        ByVal foreBrush As Brush, ByVal alignToRight As Boolean)

        Dim [date] As DateTime = _
        CType(GetColumnValueAtRow([source], rowNum), DateTime)
        Dim rect As Rectangle = bounds
        g.FillRectangle(backBrush, rect)
        rect.Offset(0, 2)
        rect.Height -= 2
        g.DrawString([date].ToString("d"), _
            Me.DataGridTableStyle.DataGrid.Font, foreBrush, _
            RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

    End Sub

    Protected Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)
        MyBase.SetDataGridInColumn(value)
        If (customDateTimePicker1.Parent IsNot Nothing) Then
            customDateTimePicker1.Parent.Controls.Remove(customDateTimePicker1)
        End If
        If (value IsNot Nothing) Then
            value.Controls.Add(customDateTimePicker1)
        End If
    End Sub

    Private Sub TimePickerValueChanged( _
        ByVal sender As Object, ByVal e As EventArgs)

        ' Remove the handler to prevent it from being called twice in a row.
        RemoveHandler customDateTimePicker1.ValueChanged, _
            AddressOf TimePickerValueChanged
        Me.isEditing = True
        MyBase.ColumnStartedEditing(customDateTimePicker1)

    End Sub

End Class

Public Class CustomDateTimePicker
    Inherits DateTimePicker

    <SecurityPermissionAttribute( _
    SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Function ProcessKeyMessage(ByRef m As Message) As Boolean
        ' Keep all the keys for the DateTimePicker.
        Return ProcessKeyEventArgs(m)
    End Function

End Class

Public Class MyForm
    Inherits Form

    Private namesDataTable As DataTable
    Private myGrid As DataGrid = New DataGrid()

    Public Sub New()

        InitForm()

        namesDataTable = New DataTable("NamesTable")
        namesDataTable.Columns.Add(New DataColumn("Name"))
        Dim dateColumn As DataColumn = _
             New DataColumn("Date", GetType(DateTime))
        dateColumn.DefaultValue = DateTime.Today
        namesDataTable.Columns.Add(dateColumn)
        Dim namesDataSet As DataSet = New DataSet()
        namesDataSet.Tables.Add(namesDataTable)
        myGrid.DataSource = namesDataSet
        myGrid.DataMember = "NamesTable"
        AddGridStyle()
        AddData()

    End Sub

    Private Sub AddGridStyle()
        Dim myGridStyle As DataGridTableStyle = _
                    New DataGridTableStyle()
        myGridStyle.MappingName = "NamesTable"

        Dim nameColumnStyle As DataGridTextBoxColumn = _
            New DataGridTextBoxColumn()
        nameColumnStyle.MappingName = "Name"
        nameColumnStyle.HeaderText = "Name"
        myGridStyle.GridColumnStyles.Add(nameColumnStyle)

        Dim customDateTimePicker1ColumnStyle As DataGridTimePickerColumn = _
            New DataGridTimePickerColumn()
        customDateTimePicker1ColumnStyle.MappingName = "Date"
        customDateTimePicker1ColumnStyle.HeaderText = "Date"
        customDateTimePicker1ColumnStyle.Width = 100
        myGridStyle.GridColumnStyles.Add(customDateTimePicker1ColumnStyle)

        myGrid.TableStyles.Add(myGridStyle)
    End Sub

    Private Sub AddData()
        Dim dRow As DataRow = namesDataTable.NewRow()
        dRow("Name") = "Name 1"
        dRow("Date") = New DateTime(2001, 12, 1)
        namesDataTable.Rows.Add(dRow)

        dRow = namesDataTable.NewRow()
        dRow("Name") = "Name 2"
        dRow("Date") = New DateTime(2001, 12, 4)
        namesDataTable.Rows.Add(dRow)

        dRow = namesDataTable.NewRow()
        dRow("Name") = "Name 3"
        dRow("Date") = New DateTime(2001, 12, 29)
        namesDataTable.Rows.Add(dRow)

        dRow = namesDataTable.NewRow()
        dRow("Name") = "Name 4"
        dRow("Date") = New DateTime(2001, 12, 13)
        namesDataTable.Rows.Add(dRow)

        dRow = namesDataTable.NewRow()
        dRow("Name") = "Name 5"
        dRow("Date") = New DateTime(2001, 12, 21)
        namesDataTable.Rows.Add(dRow)

        namesDataTable.AcceptChanges()
    End Sub

    Private Sub InitForm()
        Me.Size = New Size(500, 500)
        myGrid.Size = New Size(350, 250)
        myGrid.TabStop = True
        myGrid.TabIndex = 1
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Controls.Add(myGrid)
    End Sub

    <STAThread()> _
    Public Shared Sub Main()
        Application.Run(New MyForm())
    End Sub

End Class
'</snippet1>