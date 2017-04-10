' for MISC snippets only; do not wrap entire file with a snippet tag.

Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    <STAThread()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Public Sub New()
        dataGridView1.Dock = DockStyle.Fill
        Controls.Add(dataGridView1)
        AddColorColumn()
        dataGridView1.RowCount = 10
    End Sub

    '<snippet20>
    Private WithEvents dataGridView1 As New DataGridView()

    Private Sub AddColorColumn()

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.Items.AddRange( _
            Color.Red, Color.Yellow, Color.Green, Color.Blue)
        comboBoxColumn.ValueType = GetType(Color)
        dataGridView1.Columns.Add(comboBoxColumn)

    End Sub

    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, _
        ByVal e As DataGridViewEditingControlShowingEventArgs) _
        Handles dataGridView1.EditingControlShowing

        Dim combo As ComboBox = CType(e.Control, ComboBox)
        If (combo IsNot Nothing) Then

            ' Remove an existing event-handler, if present, to avoid 
            ' adding multiple handlers when the editing control is reused.
            RemoveHandler combo.SelectedIndexChanged, _
                New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

            ' Add the event handler. 
            AddHandler combo.SelectedIndexChanged, _
                New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

        End If

    End Sub

    Private Sub ComboBox_SelectedIndexChanged( _
        ByVal sender As Object, ByVal e As EventArgs)

        Dim comboBox1 As ComboBox = CType(sender, ComboBox)
        comboBox1.BackColor = _
            CType(CType(sender, ComboBox).SelectedItem, Color)

    End Sub
    '</snippet20>

    '<snippet30>
    ' Workaround for bug that prevents DataGridViewRowCollection.AddRange
    ' from working when the row for new records is selected. 
    Private Sub AddRows(ByVal ParamArray rows As DataGridViewRow())
        InsertRows(dataGridView1.RowCount - 1, rows)
    End Sub

    '<snippet40>
    ' Workaround for bug that prevents DataGridViewRowCollection.InsertRange
    ' from working when any rows before the insertion index are selected.
    Private Sub InsertRows(ByVal index As Integer, _
        ByVal ParamArray rows As DataGridViewRow())

        Dim selectedIndexes As New System.Collections.Generic.List(Of Integer)

        For Each row As DataGridViewRow In dataGridView1.SelectedRows
            If row.Index >= index Then
                selectedIndexes.Add(row.Index)
                row.Selected = False
            End If
        Next row

        dataGridView1.Rows.InsertRange(index, rows)

        For Each selectedIndex As Integer In selectedIndexes
            dataGridView1.Rows(selectedIndex).Selected = True
        Next selectedIndex

    End Sub
    '</snippet40>
    '</snippet30>    

    '<snippet50>
    ' Display NullValue for cell values equal to DataSourceNullValue.
    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting

        Dim value As String = TryCast(e.Value, String)
        If value IsNot Nothing And _
            value.Equals(e.CellStyle.DataSourceNullValue) Then

            e.Value = e.CellStyle.NullValue
            e.FormattingApplied = True

        End If

    End Sub
    '</snippet50>

    '<snippet60>
    Public Function CloneWithValues(ByVal row As DataGridViewRow) _
        As DataGridViewRow

        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next

    End Function
    '</snippet60>

End Class

Public Class DerivedDGVCell
    Inherits DataGridViewCell

    '<snippet10>
    ' Override OnMouseClick in a class derived from DataGridViewCell to 
    ' enter edit mode when the user clicks the cell. 
    Protected Overrides Sub OnMouseClick( _
        ByVal e As DataGridViewCellMouseEventArgs)

        If MyBase.DataGridView IsNot Nothing Then

            Dim point1 As Point = MyBase.DataGridView.CurrentCellAddress
            If point1.X = e.ColumnIndex And _
                point1.Y = e.RowIndex And _
                e.Button = MouseButtons.Left And _
                Not MyBase.DataGridView.EditMode = _
                DataGridViewEditMode.EditProgrammatically Then

                MyBase.DataGridView.BeginEdit(True)

            End If
        End If
    End Sub
    '</snippet10>

End Class

'<snippet70>
Public Class CustomDataGridView
    Inherits DataGridView

    <System.Security.Permissions.UIPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, _
        Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessDialogKey( _
        ByVal keyData As Keys) As Boolean

        ' Extract the key code from the key value. 
        Dim key As Keys = keyData And Keys.KeyCode

        ' Handle the ENTER key as if it were a RIGHT ARROW key. 
        If key = Keys.Enter Then
            Return Me.ProcessRightKey(keyData)
        End If

        Return MyBase.ProcessDialogKey(keyData)

    End Function

    <System.Security.Permissions.SecurityPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, Flags:= _
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Function ProcessDataGridViewKey( _
        ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean

        ' Handle the ENTER key as if it were a RIGHT ARROW key. 
        If e.KeyCode = Keys.Enter Then
            Return Me.ProcessRightKey(e.KeyData)
        End If

        Return MyBase.ProcessDataGridViewKey(e)

    End Function

End Class
'</snippet70>