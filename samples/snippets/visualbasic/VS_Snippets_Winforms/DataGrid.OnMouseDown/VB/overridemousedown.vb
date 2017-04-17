Imports System
Imports System.Threading
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Namespace DataGridSample
    _


    Public Class Singe
        Inherits Form
        Private dataTable As DataTable
        Private grid As New DataGridSample.MyDataGrid()
        Private button1 As New Button()
        Private label1 As New Label()


        Public Sub New()
            InitForm()

            dataTable = New DataTable("name")
            dataTable.Columns.Add(New DataColumn("First"))
            Dim column As New DataColumn("name")
            dataTable.Columns.Add(column)
            dataTable.Columns.Add(New DataColumn("Second", GetType(Boolean)))
            'dataTable.Columns["First"].ReadOnly = true;
            Dim First As New DataSet()
            First.Tables.Add(dataTable)
            grid.DataSource = First
            grid.DataMember = "name"
            AddSomeData()

            ' grid.SetDataBinding(First, "name");
            ' grid.ReadOnly = true;
            ' grid.DataMember = "First";
            AddHandler button1.Click, AddressOf OnButtonClick
        End Sub 'New


        Private Sub OnButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            'combo.Sorted = true;
            ' grid[0,0] = "nou";
            ' grid.SetDataBinding(null, "");
            DataGridSample.SortDataGrid.Sort(grid, "First", True)
        End Sub 'OnButtonClick


        Private Sub grid_Enter(ByVal sender As Object, ByVal e As EventArgs)
            grid.CurrentCell = New DataGridCell(2, 2)
        End Sub 'grid_Enter


        Private Sub AddSomeData()
            Dim dRow As DataRow
            Dim i As Int16

            For i = 0 To 4
                dRow = dataTable.NewRow()

                dRow("First") = String.Format("FirstName {0}", i)
                dRow("name") = String.Format("LastName {0}", i)
                dataTable.Rows.Add(dRow)
            Next
        End Sub



        Private Sub foo(ByVal sender As Object, ByVal e As KeyEventArgs)
            Console.WriteLine("on key down handler called")
        End Sub 'foo


        Private Sub InitForm()
            Me.Size = New Size(700, 500)
            button1.Location = New Point(300, 300)
            button1.Text = "Sort the grid programatically"
            button1.Width = 200
            grid.Size = New Size(350, 250)
            grid.TabStop = True
            grid.TabIndex = 1
            button1.TabStop = True
            button1.TabIndex = 1
            label1.Width = 300
            label1.Height = 100
            label1.Top = grid.Top
            label1.Left = grid.Right + 10
            label1.Text = "The grid on this app overrides the OnMouseDown event, so that when the user clicks anywhere on the grid, the user will select the row beneath the mouse cursor"
            Me.Controls.Add(label1)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Controls.Add(grid)
            Me.Controls.Add(button1)
        End Sub 'InitForm
        'this.SetNewControls(new Control[]{grid, button1});
    End Class 'Singe
    _

    '<snippet1>
    Public Class MyDataGrid
        Inherits DataGrid

        ' Override the OnMouseDown event to select the whole row
        ' when the user clicks anywhere on a row.

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        ' Get the HitTestInfo to return the row and pass
        ' that value to the IsSelected property of the DataGrid.
            Dim hit As DataGrid.HitTestInfo = Me.HitTest(e.X, e.Y)
            If hit.Row < 0 Then
                Return
            End If
            If IsSelected(hit.Row) Then
                UnSelect(hit.Row)
            Else
                [Select](hit.Row)
            End If
        End Sub
    End Class
    '</snippet1>

    _ 
    Public Class SortDataGrid

        Public Shared Sub Sort(ByVal grid As DataGrid, ByVal colName As String, ByVal ascending As Boolean)
            Dim dv As DataView = CType(grid.BindingContext(grid.DataSource, grid.DataMember), CurrencyManager).List '
            'ToDo: Error processing original source shown below

            If dv Is Nothing Then
                Return
            End If
            If ascending Then
                dv.Sort = colName + " ASC"
            Else
                dv.Sort = colName + " DESC"
            End If
        End Sub 'Sort
    End Class 'SortDataGrid
End Namespace 'DataGridSample 

Module Module1
    <STAThreadAttribute()> _
    Sub Main()
        Application.Run(New DataGridSample.Singe())
    End Sub 'Main
End Module
