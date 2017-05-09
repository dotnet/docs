'<snippet00>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Private WithEvents DataGridView1 As New DataGridView()
    Private FlowLayoutPanel1 As New FlowLayoutPanel()
    Private WithEvents Button1 As New Button()
    Private RadioButton1 As New RadioButton()
    Private RadioButton2 As New RadioButton()

    ' Establish the main entry point for the application.
    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Public Sub New()
        ' Initialize the form.
        ' This code can be replaced with designer generated code.
        AutoSize = True
        Text = "DataGridView IComparer sort demo"

        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel1.Location = New System.Drawing.Point(304, 0)
        FlowLayoutPanel1.AutoSize = True

        FlowLayoutPanel1.Controls.Add(RadioButton1)
        FlowLayoutPanel1.Controls.Add(RadioButton2)
        FlowLayoutPanel1.Controls.Add(Button1)

        Button1.Text = "Sort"
        RadioButton1.Text = "Ascending"
        RadioButton2.Text = "Descending"
        RadioButton1.Checked = True

        Controls.Add(FlowLayoutPanel1)
        Controls.Add(DataGridView1)

        PopulateDataGridView()
    End Sub

    ' Replace this with your own code to populate the DataGridView.
    Private Sub PopulateDataGridView()

        DataGridView1.Size = New Size(300, 300)

        ' Add columns to the DataGridView.
        DataGridView1.ColumnCount = 2

        ' Set the properties of the DataGridView columns.
        DataGridView1.Columns(0).Name = "First"
        DataGridView1.Columns(1).Name = "Last"
        DataGridView1.Columns("First").HeaderText = "First Name"
        DataGridView1.Columns("Last").HeaderText = "Last Name"
        DataGridView1.Columns("First").SortMode = _
            DataGridViewColumnSortMode.Programmatic
        DataGridView1.Columns("Last").SortMode = _
            DataGridViewColumnSortMode.Programmatic

        ' Add rows of data to the DataGridView.
        DataGridView1.Rows.Add(New String() {"Peter", "Parker"})
        DataGridView1.Rows.Add(New String() {"James", "Jameson"})
        DataGridView1.Rows.Add(New String() {"May", "Parker"})
        DataGridView1.Rows.Add(New String() {"Mary", "Watson"})
        DataGridView1.Rows.Add(New String() {"Eddie", "Brock"})
    End Sub

    '<snippet10>
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Button1.Click
        If RadioButton1.Checked = True Then
            DataGridView1.Sort(New RowComparer(SortOrder.Ascending))
        ElseIf RadioButton2.Checked = True Then
            DataGridView1.Sort(New RowComparer(SortOrder.Descending))
        End If
    End Sub

    Private Class RowComparer
        Implements System.Collections.IComparer

        Private sortOrderModifier As Integer = 1

        Public Sub New(ByVal sortOrder As SortOrder)
            If sortOrder = sortOrder.Descending Then
                sortOrderModifier = -1
            ElseIf sortOrder = sortOrder.Ascending Then

                sortOrderModifier = 1
            End If
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
            Implements System.Collections.IComparer.Compare

            Dim DataGridViewRow1 As DataGridViewRow = CType(x, DataGridViewRow)
            Dim DataGridViewRow2 As DataGridViewRow = CType(y, DataGridViewRow)

            ' Try to sort based on the Last Name column.
            Dim CompareResult As Integer = System.String.Compare( _
                DataGridViewRow1.Cells(1).Value.ToString(), _
                DataGridViewRow2.Cells(1).Value.ToString())

            ' If the Last Names are equal, sort based on the First Name.
            If CompareResult = 0 Then
                CompareResult = System.String.Compare( _
                    DataGridViewRow1.Cells(0).Value.ToString(), _
                    DataGridViewRow2.Cells(0).Value.ToString())
            End If
            Return CompareResult * sortOrderModifier
        End Function
    End Class
    '</snippet10>
End Class
'</snippet00>

