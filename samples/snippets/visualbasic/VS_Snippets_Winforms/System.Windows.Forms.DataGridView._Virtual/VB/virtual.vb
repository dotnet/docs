'<snippet0>
Imports System.IO
Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class VirtualModeDemo
    Inherits System.Windows.Forms.Form

    Dim WithEvents dataGridView1 As New DataGridView

    Public Sub New()

        MyBase.New()

        Text = "DataGridView virtual-mode demo (cell-level commit scope)"

        Controls.Add(dataGridView1)
        dataGridView1.VirtualMode = True
        dataGridView1.AllowUserToDeleteRows = False
        dataGridView1.Columns.Add("Numbers", "Positive Numbers")
        dataGridView1.Rows.AddCopies(0, initialSize)

    End Sub

    '<snippet20>
    Dim newRowNeeded As Boolean

    Private Sub dataGridView1_NewRowNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewRowEventArgs) _
        Handles dataGridView1.NewRowNeeded

        newRowNeeded = True
    End Sub

    Const initialSize As Integer = 5000000
    Dim numberOfRows As Integer = initialSize

    '<snippet30>
    Private Sub dataGridView1_RowsAdded(ByVal sender As Object, _
        ByVal e As DataGridViewRowsAddedEventArgs) _
        Handles dataGridView1.RowsAdded

        If newRowNeeded Then
            newRowNeeded = False
            numberOfRows = numberOfRows + 1
        End If
    End Sub
    '</snippet30>

    '<snippet10>
#Region "data store maintance"
    Const initialValue As Integer = -1

    Private Sub dataGridView1_CellValueNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValueNeeded

        If store.ContainsKey(e.RowIndex) Then
            ' Use the store if the e value has been modified 
            ' and stored.
            e.Value = store(e.RowIndex)
        ElseIf newRowNeeded AndAlso e.RowIndex = numberOfRows Then
            If dataGridView1.IsCurrentCellInEditMode Then
                e.Value = initialValue
            Else
                ' Show a blank value if the cursor is just resting
                ' on the last row.
                e.Value = String.Empty
            End If
        Else
            e.Value = e.RowIndex
        End If
    End Sub

    Private Sub dataGridView1_CellValuePushed(ByVal sender As Object, _
        ByVal e As DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValuePushed

        store.Add(e.RowIndex, CInt(e.Value))

    End Sub
#End Region

    Dim store As System.Collections.Generic.Dictionary(Of Integer, Integer) = _
        New Dictionary(Of Integer, Integer)
    '</snippet10>
    '</snippet20>

    '<snippet40>
    Private Sub dataGridView1_CellValidating(ByVal sender As Object, _
        ByVal e _
        As DataGridViewCellValidatingEventArgs) _
        Handles dataGridView1.CellValidating

        Me.dataGridView1.Rows(e.RowIndex).ErrorText = ""
        Dim newInteger As Integer

        ' Don't try to validate the 'new row' until finished 
        ' editing since there
        ' is not any point in validating its initial value.
        If dataGridView1.Rows(e.RowIndex).IsNewRow Then Return
        If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) _
            OrElse newInteger < 0 Then

            e.Cancel = True
            Me.dataGridView1.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"

        End If
    End Sub
    '</snippet40>

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New VirtualModeDemo())
    End Sub
End Class
'</snippet0>