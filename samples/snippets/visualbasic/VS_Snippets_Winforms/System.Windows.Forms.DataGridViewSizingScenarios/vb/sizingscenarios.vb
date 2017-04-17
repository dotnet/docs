'<snippet00>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private dataGridView1 As New DataGridView()

    Public Sub New()
        dataGridView1.Dock = DockStyle.Fill
        Controls.Add(dataGridView1)
        Width *= 2
        Text = "DataGridView Sizing Scenarios"
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        '<snippet10>
        Dim idColumn As New DataGridViewTextBoxColumn()
        idColumn.HeaderText = "ID"
        idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        idColumn.Resizable = DataGridViewTriState.False
        idColumn.ReadOnly = True
        idColumn.Width = 20
        '</snippet10>

        '<snippet20>
        Dim titleColumn As New DataGridViewTextBoxColumn()
        titleColumn.HeaderText = "Title"
        titleColumn.AutoSizeMode = _
            DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        '</snippet20>

        '<snippet30>
        dataGridView1.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.Fill

        Dim subTitleColumn As new DataGridViewTextBoxColumn()
        subTitleColumn.HeaderText = "Subtitle"
        subTitleColumn.MinimumWidth = 50
        subTitleColumn.FillWeight = 100

        Dim summaryColumn As new DataGridViewTextBoxColumn()
        summaryColumn.HeaderText = "Summary"
        summaryColumn.MinimumWidth = 50
        summaryColumn.FillWeight = 200

        Dim contentColumn As new DataGridViewTextBoxColumn()
        contentColumn.HeaderText = "Content"
        contentColumn.MinimumWidth = 50
        contentColumn.FillWeight = 300
        '</snippet30>

        '<snippet40>
        dataGridView1.Columns.AddRange(New DataGridViewTextBoxColumn() { _
            idColumn, titleColumn, subTitleColumn, _
            summaryColumn, contentColumn})
        dataGridView1.Rows.Add(New String() {"1", _
            "A Short Title", "A Longer SubTitle", _
            "A short description of the main point.", _
            "The full contents of the topic, with detailed examples."})
        '</snippet40>

        MyBase.OnLoad(e)
    End Sub
End Class
'</snippet00>