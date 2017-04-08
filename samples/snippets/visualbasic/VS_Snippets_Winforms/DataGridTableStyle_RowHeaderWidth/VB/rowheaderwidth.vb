' System.Windows.Forms.DataGridTableStyle.RowHeaderWidth
' System.Windows.Forms.DataGridTableStyle.RowHeaderWidthChanged

'   The following program demonstrates the 'RowHeaderWidth' 
'   method and 'RowHeaderWidthChanged' event of 'DataGridTableStyle'
'   class. It changes the row header width on button click 
'   and resets the row header width. 
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public Class DataGridTableStyle_RowHeaderWidth
   Inherits Form
   Private components As Container = Nothing
   Private WithEvents button2 As Button
   
   Protected Overrides Overloads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose
   

   Private Sub InitializeComponent()

      Me.myDataGrid = New DataGrid()
      Me.button1 = New Button()
      Me.button2 = New Button()
      CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' myDataGrid
      ' 
      Me.myDataGrid.DataMember = ""
      Me.myDataGrid.LinkColor = SystemColors.Desktop
      Me.myDataGrid.Location = New Point(56, 40)
      Me.myDataGrid.Name = "myDataGrid"
      Me.myDataGrid.Size = New Size(224, 144)
      Me.myDataGrid.TabIndex = 0
      ' 
      ' button1
      ' 
      Me.button1.Location = New Point(168, 208)
      Me.button1.Name = "button1"
      Me.button1.Size = New Size(152, 23)
      Me.button1.TabIndex = 1
      Me.button1.Text = " Change RowHeader Width"
      ' 
      ' button2
      ' 
      Me.button2.Location = New Point(16, 208)
      Me.button2.Name = "button2"
      Me.button2.Size = New Size(152, 23)
      Me.button2.TabIndex = 1
      Me.button2.Text = "Display RowHeader Width"
      ' 
      ' DataGridTableStyle_RowHeaderWidth
      ' 
      Me.ClientSize = New Size(344, 261)
      Me.Controls.AddRange(New Control() {Me.button1, Me.myDataGrid, Me.button2})
      Me.Name = "DataGridTableStyle_RowHeaderWidth"
      Me.Text = "Change Row Width"
      
      CallEventLoader()
      CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent

   Private IdCol = New DataGridTextBoxColumn() 

   Private TextCol = New DataGridTextBoxColumn()
   
   
   <STAThread()> Shared  Sub Main()
      Application.Run(New DataGridTableStyle_RowHeaderWidth())
   End Sub 'Main
   
   Private myDataGridTableStyle As New DataGridTableStyle()
   Private myDataGrid As DataGrid
   Private WithEvents button1 As Button
   
   
   Public Sub New()
      InitializeComponent()
      ' Create and bind DataSet to DataGrid.
      CreateNBindDataSet()
   End Sub 'New
   
   
   Private Sub CreateNBindDataSet()
      ' Create a DataSet with one table.
      Dim myDataSet As New DataSet("myDataSet")
      ' Create a DataTable.
      Dim myEmpTable As New DataTable("Employee")
      ' Create two columns, and add them to the employee table.
      Dim myEmpID As New DataColumn("EmpID", GetType(Integer))
      Dim myEmpName As New DataColumn("EmpName")
      myEmpTable.Columns.Add(myEmpID)
      myEmpTable.Columns.Add(myEmpName)
      ' Add the table to the DataSet.
      myDataSet.Tables.Add(myEmpTable)
      
      ' Populate the table.
      Dim newRow1 As DataRow
      
      ' Create employee records in the employee table.
      Dim i As Integer
      For i = 1 To 5
         newRow1 = myEmpTable.NewRow()
         newRow1("EmpID") = i
         ' Add the row to the Employee table.
         myEmpTable.Rows.Add(newRow1)
      Next i
      
      ' Give each employee a distinct name.
      myEmpTable.Rows(0)("EmpName") = "Gary"
      myEmpTable.Rows(1)("EmpName") = "Harry"
      myEmpTable.Rows(2)("EmpName") = "Mary"
      myEmpTable.Rows(3)("EmpName") = "Larry"
      myEmpTable.Rows(4)("EmpName") = "Robert"
      
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Employee")
   End Sub 'CreateNBindDataSet
   
   
   Private Sub DataGridTableStyle_RowHeaderWidth_Load(sender As Object, e As EventArgs)
      myDataGridTableStyle.MappingName = "Employee"
      ' Set other properties.
      myDataGridTableStyle.AlternatingBackColor = Color.LightGray
      
      ' Set MappingName to the DataColumn name in the DataTable.
      IdCol.MappingName = "EmpID"
      
      ' Set the HeaderText and Width properties.
      IdCol.HeaderText = "Emp ID"
      IdCol.Width = 50
      
      ' Add a GridColumnStyle.
      myDataGridTableStyle.GridColumnStyles.Add(IdCol)
      myDataGridTableStyle.RowHeaderWidth = 10
      
      ' Add a second column style.
      TextCol.MappingName = "EmpName"
      TextCol.HeaderText = "Emp Name"
      TextCol.Width = 100
      myDataGridTableStyle.GridColumnStyles.Add(TextCol)
      
      ' Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myDataGridTableStyle)
      myDataGridTableStyle.GridLineColor = Color.Red
      AttachRowHeaderWidthChanged()
   End Sub 'DataGridTableStyle_RowHeaderWidth_Load
   
   
' <Snippet1>
' <Snippet2>
   Private Sub CallEventLoader()
      AddHandler Load, AddressOf DataGridTableStyle_RowHeaderWidth_Load
   End Sub 'CallEventLoader
   
   
   Public Sub AttachRowHeaderWidthChanged()
      AddHandler myDataGridTableStyle.RowHeaderWidthChanged, AddressOf MyDelegateRowHeaderChanged
   End Sub 'AttachRowHeaderWidthChanged
   
    Private Sub MyDelegateRowHeaderChanged(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Row header width is changed")
    End Sub 'MyDelegateRowHeaderChanged
   
   
   Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
      myDataGridTableStyle.RowHeaderWidth = 30
   End Sub 'button1_Click
   
   
   Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
      MessageBox.Show("Row header width is: " & myDataGridTableStyle.RowHeaderWidth)
   End Sub 'button2_Click
' </Snippet2>
' </Snippet1>
End Class 'DataGridTableStyle_RowHeaderWidth
