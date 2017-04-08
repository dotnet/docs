 ' System.Windows.Forms.DataGridTableStyle.PreferredColumnWidth

' The following example demonstrates the property 'PreferredColumnWidth'
' of 'DataGridTableStyle' class.
' It creates a 'Button' a 'TextBox' and 'DataGrid', attaches an employee table to
' DataGrid and applies 'DataGridTableStyle' to it.
' Event Handler has been attached to handle 'PreferredColumnWidthChanged' event.

Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing

Namespace DataGridTableStyle_PreferredColumnWidthChanged
   Public Class Form1
        Inherits Form
      Private components As System.ComponentModel.Container = Nothing
      
      
      Protected Overrides Overloads Sub Dispose(disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose
      

      Private Sub InitializeComponent()

            Me.myButton = New System.Windows.Forms.Button()
         Me.myLabel = New System.Windows.Forms.Label()
         Me.myColWidth = New System.Windows.Forms.TextBox()
         Me.SuspendLayout()
         ' 
         ' myButton
         ' 
         Me.myButton.Location = New System.Drawing.Point(136, 304)
         Me.myButton.Name = "myButton"
         Me.myButton.TabIndex = 1
         Me.myButton.Text = "Apply"
         ' 
         ' myLabel
         ' 
         Me.myLabel.Location = New System.Drawing.Point(96, 264)
         Me.myLabel.Name = "myLabel"
         Me.myLabel.Size = New System.Drawing.Size(80, 16)
         Me.myLabel.TabIndex = 3
         Me.myLabel.Text = "Column width: "
         ' 
         ' myColWidth
         ' 
         Me.myColWidth.Location = New System.Drawing.Point(184, 264)
         Me.myColWidth.Name = "myColWidth"
         Me.myColWidth.TabIndex = 2
         Me.myColWidth.Text = ""
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(400, 397)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.myLabel, Me.myColWidth, Me.myButton})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent

      <STAThread()>  Shared Sub Main() 
         Application.Run(New Form1())
      End Sub 'Main
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      Private Withevents myButton As System.Windows.Forms.Button
      Private myColWidth As System.Windows.Forms.TextBox
      Private myLabel As System.Windows.Forms.Label
        Private myDataGrid = New System.Windows.Forms.DataGrid()
        Private WithEvents myDataGridTableStyle As DataGridTableStyle = New DataGridTableStyle()
      
' <Snippet1>
        Private Sub CreateAndBindDataSet(ByVal myDataGrid As System.Windows.Forms.DataGrid)
            Dim myDataSet As New DataSet("myDataSet")
            Dim myEmpTable As New DataTable("Employee")
            ' Create two columns, and add them to employee table.
            Dim myEmpID As New DataColumn("EmpID", GetType(Integer))
            Dim myEmpName As New DataColumn("EmpName")
            myEmpTable.Columns.Add(myEmpID)
            myEmpTable.Columns.Add(myEmpName)
            ' Add table to DataSet.
            myDataSet.Tables.Add(myEmpTable)
            ' Populate table.
            Dim newRow1 As DataRow
            ' Create employee records in employee Table.
            Dim i As Integer
            For i = 1 To 5
                newRow1 = myEmpTable.NewRow()
                newRow1("EmpID") = i
                ' Add row to Employee table.
                myEmpTable.Rows.Add(newRow1)
            Next i
            ' Give each employee a distinct name.
            myEmpTable.Rows(0)("EmpName") = "Alpha"
            myEmpTable.Rows(1)("EmpName") = "Beta"
            myEmpTable.Rows(2)("EmpName") = "Omega"
            myEmpTable.Rows(3)("EmpName") = "Gamma"
            myEmpTable.Rows(4)("EmpName") = "Delta"
            ' Bind DataGrid to DataSet.
            myDataGrid.SetDataBinding(myDataSet, "Employee")
        End Sub 'CreateAndBindDataSet


        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set and Display myDataGrid.
            myDataGrid.DataMember = ""
            myDataGrid.Location = New System.Drawing.Point(72, 32)
            myDataGrid.Name = "myDataGrid"
            myDataGrid.Size = New System.Drawing.Size(240, 200)
            myDataGrid.TabIndex = 4
            ' Add it to controls.
            Controls.Add(myDataGrid)
            CreateAndBindDataSet(myDataGrid)
            myDataGridTableStyle.MappingName = "Employee"
            ' Set other properties.
            myDataGridTableStyle.AlternatingBackColor = Color.LightGray
            ' Add DataGridTableStyle instances to GridTableStylesCollection.
            myDataGridTableStyle.PreferredColumnWidth = 100
            myColWidth.Text = ""
            myDataGrid.TableStyles.Add(myDataGridTableStyle)
            AddHandler myDataGridTableStyle.PreferredColumnWidthChanged, AddressOf MyDelegatePreferredColWidthChanged
        End Sub 'Form1_Load


        Private Sub MyDelegatePreferredColWidthChanged(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Preferred Column width has changed")
        End Sub 'MyDelegatePreferredColWidthChanged


        Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myButton.Click
            Try
                If myColWidth.Text <> "" Then
                    Dim newwidth As Integer = Integer.Parse(myColWidth.Text)
                    myDataGridTableStyle.PreferredColumnWidth = newwidth
                    ' Dispose datagrid and datagridtablestyle and then create.
                    myDataGrid.Dispose()
                    myDataGridTableStyle.Dispose()
                    myDataGrid = New Windows.Forms.Datagrid()
                    myDataGridTableStyle = New DataGridTableStyle()
                    myDataGrid.DataMember = ""
                    myDataGrid.Location = New System.Drawing.Point(72, 32)
                    myDataGrid.Name = "myDataGrid"
                    myDataGrid.Size = New System.Drawing.Size(240, 200)
                    myDataGrid.TabIndex = 4
                    Controls.Add(myDataGrid)
                    CreateAndBindDataSet(myDataGrid)
                    myDataGridTableStyle.MappingName = "Employee"
                    ' Set other properties.
                    myDataGridTableStyle.AlternatingBackColor = Color.LightGray
                    ' Add DataGridTableStyle instances to GridTableStylesCollection.
                    myDataGridTableStyle.PreferredColumnWidth = newwidth
                    myColWidth.Text = ""
                    myDataGrid.TableStyles.Add(myDataGridTableStyle)
                    AddHandler myDataGridTableStyle.PreferredColumnWidthChanged, AddressOf MyDelegatePreferredColWidthChanged
                Else
                    MessageBox.Show("Please enter a number")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub 'myButton_Click
' </Snippet1>
    End Class 'Form1 
End Namespace 'DataGridTableStyle_PreferredColumnWidthChanged