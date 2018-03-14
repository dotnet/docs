' System.Windows.Forms.DataGrid.ReadOnlyChanged
' System.Windows.Forms.DataGrid.FlatModeChanged

' The following program demonstrates the methods 'ReadOnlyChanged' and 
' 'FlatModeChanged' of the 'DataGrid' class. It creates a 
' 'GridControl' and checks the properties 'ReadOnly' and 'FlatMode'
' of data grid, depending on the selection of buttons.
'


Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace MyDataGridClass
   Public Class MyDataGridClass_FlatMode_ReadOnly
      Inherits Form
        Private WithEvents myDataGrid As DataGrid
        Private WithEvents button1 As Button
        Private WithEvents button2 As Button
      Private myDataSet As DataSet
      Private components As Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
         SetUp()
      End Sub 'New
       
      
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (components IsNot Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose

        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.myDataGrid = New DataGrid()
            Me.button1 = New Button()
            Me.button2 = New Button()
            CType(Me.myDataGrid, ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' myDataGrid
            ' 
            Me.myDataGrid.CaptionText = "My Grid Control"
            Me.myDataGrid.DataMember = ""
            Me.myDataGrid.Location = New Point(16, 16)
            Me.myDataGrid.Name = "myDataGrid"
            Me.myDataGrid.Size = New Size(168, 112)
            Me.myDataGrid.TabIndex = 0

            ' 
            ' button1
            ' 
            Me.button1.Location = New Point(24, 160)
            Me.button1.Name = "button1"
            Me.button1.Size = New Size(72, 40)
            Me.button1.TabIndex = 1
            Me.button1.Text = "Toggle Flat Mode"
            ' 
            ' button2
            ' 
            Me.button2.Location = New Point(96, 160)
            Me.button2.Name = "button2"
            Me.button2.Size = New Size(72, 40)
            Me.button2.TabIndex = 1
            Me.button2.Text = "Toggle Read Only"
            ' 
            ' MyDataGridClass_FlatMode_ReadOnly
            ' 
            Me.ClientSize = New Size(208, 205)
            Me.Controls.AddRange(New Control() {Me.button1, Me.myDataGrid, Me.button2})
            Me.MaximizeBox = False
            Me.Name = "MyDataGridClass_FlatMode_ReadOnly"
            Me.Text = "Grid Control"
            CType(Me.myDataGrid, ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent

        ' <summary>
        ' The main entry point for the application.
        ' </summary>
        <STAThread()> Shared Sub Main()
            Application.Run(New MyDataGridClass_FlatMode_ReadOnly())
        End Sub 'Main

        Private Sub SetUp()
            MakeDataSet()
            myDataGrid.SetDataBinding(myDataSet, "Customers")
        End Sub 'SetUp


        Private Sub MakeDataSet()
            ' Create a DataSet.
            myDataSet = New DataSet("myDataSet")
            ' Create a DataTable.
            Dim myTable As New DataTable("Customers")
            ' Create two columns, and add them to the table.
            Dim myColumn1 As New DataColumn("CustID", GetType(Integer))
            Dim myColumn2 As New DataColumn("CustName")
            myTable.Columns.Add(myColumn1)
            myTable.Columns.Add(myColumn2)
            ' Add the table to the DataSet.
            myDataSet.Tables.Add(myTable)
            ' For the customer, create a 'DataRow' variable. 
            Dim newRow As DataRow
            ' Create one customer in the customers table.
            Dim i As Integer
            For i = 1 To 1
                newRow = myTable.NewRow()
                newRow("custID") = i
                ' Add the row to the 'Customers' table.
                myTable.Rows.Add(newRow)
            Next i
            ' Give the customer a name.
            myTable.Rows(0)("custName") = "Customer"
        End Sub 'MakeDataSet


' <Snippet1> 
        ' Check if the 'FlatMode' property is changed.
        Private Sub myDataGrid_FlatModeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles myDataGrid.FlatModeChanged
            Dim strMessage As String = "false"
            If myDataGrid.FlatMode = True Then
                strMessage = "true"
            End If
            MessageBox.Show("Flat mode changed to " + strMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub 'myDataGrid_FlatModeChanged


        ' Toggle the 'FlatMode'.
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            If myDataGrid.FlatMode = True Then
                myDataGrid.FlatMode = False
            Else
                myDataGrid.FlatMode = True
            End If
        End Sub 'button1_Click
' </Snippet1>
' <Snippet2>
        ' Check if the 'ReadOnly' property is changed.
        Private Sub myDataGrid_ReadOnlyChanged(ByVal sender As Object, ByVal e As EventArgs) Handles myDataGrid.ReadOnlyChanged
            Dim strMessage As String = "false"
            If myDataGrid.ReadOnly = True Then
                strMessage = "true"
            End If
            MessageBox.Show("Read only changed to " + strMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub 'myDataGrid_ReadOnlyChanged

        ' Toggle the 'ReadOnly' property.
        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            If myDataGrid.ReadOnly = True Then
                myDataGrid.ReadOnly = False
            Else
                myDataGrid.ReadOnly = True
            End If
        End Sub 'button2_Click
' </Snippet2>
    End Class 'MyDataGridClass_FlatMode_ReadOnly
End Namespace 'MyDataGridClass