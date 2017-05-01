'<snippet0>
Imports System.IO
Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class TriValueVirtualCheckBox
    Inherits System.Windows.Forms.Form

    Dim WithEvents dataGridView1 As New DataGridView

    Const initialSize As Integer = 500

    Dim store As New Dictionary(Of Integer, LightStatus)

    Public Sub New()
        MyBase.New()
        Text = Me.GetType().Name

        Dim index As Integer = 0
        For index = 0 To initialSize
            store.Add(index, LightStatus.Unknown)
        Next

        Controls.Add(dataGridView1)
        dataGridView1.VirtualMode = True
        dataGridView1.AllowUserToDeleteRows = False
        dataGridView1.Columns.Add(CreateCheckBoxColumn())
        dataGridView1.Rows.AddCopies(0, initialSize)
    End Sub

    '<snippet10>
    Private Function CreateCheckBoxColumn() As DataGridViewCheckBoxColumn
        Dim dataGridViewCheckBoxColumn1 _
            As New DataGridViewCheckBoxColumn()
        dataGridViewCheckBoxColumn1.HeaderText = "Lights On"
        dataGridViewCheckBoxColumn1.TrueValue = LightStatus.TurnedOn
        dataGridViewCheckBoxColumn1.FalseValue = LightStatus.TurnedOff
        dataGridViewCheckBoxColumn1.IndeterminateValue = _
            LightStatus.Unknown
        dataGridViewCheckBoxColumn1.ThreeState = True
        dataGridViewCheckBoxColumn1.ValueType = GetType(LightStatus)
        Return dataGridViewCheckBoxColumn1
    End Function
    '</snippet10>

#Region "data store maintance"
    Private Sub dataGridView1_CellValueNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValueNeeded

        e.Value = store(e.RowIndex)
    End Sub

    Private Sub dataGridView1_CellValuePushed(ByVal sender As Object, _
        ByVal e As DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValuePushed

        store.Item(e.RowIndex) = CType(e.Value, LightStatus)
    End Sub
#End Region

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New TriValueVirtualCheckBox())
    End Sub
End Class

Public Enum LightStatus
    Unknown
    TurnedOn
    TurnedOff
End Enum
'</snippet0>