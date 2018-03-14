'<snippet00>
Imports System
Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    <STAThread()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private WithEvents dataGridView1 As New DataGridView()

    Public Sub New()
        dataGridView1.Dock = DockStyle.Fill
        Controls.Add(dataGridView1)
        InitializeDataGridView()
        Width = Width * 2
        Text = "Column Fill-Mode Demo"
    End Sub

    Private Sub InitializeDataGridView()

        ' Add columns to the DataGridView, binding them to the
        ' specified DataGridViewColumn properties.
        AddReadOnlyColumn("HeaderText", "Column")
        AddColumn("AutoSizeMode")
        AddColumn("FillWeight")
        AddColumn("MinimumWidth")
        AddColumn("Width")

        ' Bind the DataGridView to its own Columns collection.
        dataGridView1.AutoGenerateColumns = False
        dataGridView1.DataSource = dataGridView1.Columns

        ' Configure the DataGridView so that users can manually change 
        ' only the column widths, which are set to fill mode. 
        dataGridView1.AllowUserToAddRows = False
        dataGridView1.AllowUserToDeleteRows = False
        dataGridView1.AllowUserToResizeRows = False
        dataGridView1.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dataGridView1.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.Fill

        ' Configure the top left header cell as a reset button.
        dataGridView1.TopLeftHeaderCell.Value = "reset"
        dataGridView1.TopLeftHeaderCell.Style.ForeColor = _
            System.Drawing.Color.Blue

    End Sub

    Private Sub AddReadOnlyColumn(ByVal dataPropertyName As String, _
        ByVal columnName As String)

        AddColumn(GetType(DataGridViewColumn), dataPropertyName, True, _
            columnName)
    End Sub

    Private Sub AddColumn(ByVal dataPropertyName As String)
        AddColumn(GetType(DataGridViewColumn), dataPropertyName, False, _
            dataPropertyName)
    End Sub

    '<snippet10>
    ' Adds a column to the DataGridView control, binding it to specified 
    ' property of the specified type and optionally making it read-only.
    Private Sub AddColumn( _
        ByVal type As Type, _
        ByVal dataPropertyName As String, _
        ByVal isReadOnly As Boolean, _
        ByVal columnName As String)

        ' Retrieve information about the property through reflection.
        Dim propertyInfo1 As PropertyInfo = type.GetProperty(dataPropertyName)

        ' Confirm that the property exists and is accessible.
        If propertyInfo1 Is Nothing Then
            Throw New ArgumentException("No accessible " & dataPropertyName & _
            " property was found in the " & type.Name & " type.")
        End If

        ' Confirm that the property is browsable.
        Dim browsables As BrowsableAttribute() = CType( _
            propertyInfo1.GetCustomAttributes(GetType(BrowsableAttribute), _
            False), BrowsableAttribute())
        If browsables.Length > 0 AndAlso Not browsables(0).Browsable Then
            Throw New ArgumentException("The " & dataPropertyName & " property has a " & _
            "Browsable(false) attribute, and therefore cannot be bound.")
        End If

        ' Create and initialize a column, using a combo box column for 
        ' enumeration properties, a check box column for Boolean properties,
        ' and a text box column otherwise.
        Dim column As DataGridViewColumn
        Dim valueType As Type = propertyInfo1.PropertyType

        If valueType.IsEnum Then

            column = New DataGridViewComboBoxColumn()

            ' Populate the drop-down list with the enumeration values.
            CType(column, DataGridViewComboBoxColumn).DataSource = _
                [Enum].GetValues(valueType)

        ElseIf valueType.Equals(GetType(Boolean)) Then
            column = New DataGridViewCheckBoxColumn()
        Else
            column = New DataGridViewTextBoxColumn()
        End If

        ' Initialize and bind the column.
        column.ValueType = valueType
        column.Name = columnName
        column.DataPropertyName = dataPropertyName
        column.ReadOnly = isReadOnly

        ' Add the column to the control.
        dataGridView1.Columns.Add(column)

    End Sub
    '</snippet10>

    '<snippet20>
    Private Sub ResetDataGridView()
        dataGridView1.CancelEdit()
        dataGridView1.Columns.Clear()
        dataGridView1.DataSource = Nothing
        InitializeDataGridView()
    End Sub
    '</snippet20>

    Private Sub dataGridView1_CellClick( _
        ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellClick

        If e.ColumnIndex = -1 AndAlso e.RowIndex = -1 Then
            ResetDataGridView()
        End If

    End Sub

    Private Sub dataGridView1_ColumnWidthChanged( _
        ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) _
        Handles dataGridView1.ColumnWidthChanged

        ' Invalidate the row corresponding to the column that changed
        ' to ensure that the FillWeight and Width entries are updated.
        dataGridView1.InvalidateRow(e.Column.Index)

    End Sub

    Private Sub dataGridView1_CurrentCellDirtyStateChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles dataGridView1.CurrentCellDirtyStateChanged

        ' For combo box and check box cells, commit any value change as soon
        ' as it is made rather than waiting for the focus to leave the cell.
        If Not dataGridView1.CurrentCell.OwningColumn.GetType() _
            .Equals(GetType(DataGridViewTextBoxColumn)) Then

            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        End If

    End Sub

    Private Sub dataGridView1_DataError( _
        ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) _
        Handles dataGridView1.DataError

        If e.Exception Is Nothing Then Return

        ' If the user-specified value is invalid, cancel the change 
        ' and display the error icon in the row header.
        If Not (e.Context And DataGridViewDataErrorContexts.Commit) = 0 AndAlso _
            (GetType(FormatException).IsAssignableFrom(e.Exception.GetType()) Or _
            GetType(ArgumentException).IsAssignableFrom(e.Exception.GetType())) Then

            dataGridView1.Rows(e.RowIndex).ErrorText = e.Exception.Message
            e.Cancel = True

        Else
            ' Rethrow any exceptions that aren't related to the user input.
            e.ThrowException = True
        End If

    End Sub

    Private Sub dataGridView1_CellEndEdit( _
        ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellEndEdit

        ' Ensure that the error icon in the row header is hidden.
        dataGridView1.Rows(e.RowIndex).ErrorText = ""

    End Sub

    Private Sub dataGridView1_CellValueChanged( _
        ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellValueChanged

        ' Ignore the change to the top-left header cell.
        If e.ColumnIndex < 0 Then Return

        ' Retrieve the property to change.
        Dim nameOfPropertyToChange As String = _
            dataGridView1.Columns(e.ColumnIndex).Name
        Dim propertyToChange As PropertyInfo = _
            GetType(DataGridViewColumn).GetProperty(nameOfPropertyToChange)

        ' Retrieve the column to change.
        Dim nameOfColumnToChange As String = _
            CStr(dataGridView1("Column", e.RowIndex).Value)
        Dim columnToChange As DataGridViewColumn = _
            dataGridView1.Columns(nameOfColumnToChange)

        ' Use reflection to update the value of the column property. 
        propertyToChange.SetValue(columnToChange, _
            dataGridView1(nameOfPropertyToChange, e.RowIndex).Value, Nothing)

    End Sub

End Class
'</snippet00>