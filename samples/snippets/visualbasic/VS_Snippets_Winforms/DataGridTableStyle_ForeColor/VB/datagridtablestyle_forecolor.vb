'System.Windows.Forms.DataGridTableStyle.ForeColor

' The following program demonstrates the property 'ForeColor' of class 'DataGridTableStyle'.
' A table with 2 columns is created and attached to grid.A listbox allows selection of forecolors
' for the grid.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Namespace Datagrid

   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private dataGrid1 As System.Windows.Forms.DataGrid
      Private myComboBox As System.Windows.Forms.ComboBox
        Private WithEvents button2 As System.Windows.Forms.Button
      ' Declare objects of DataSet,DataGrid,DataTable.
      Private myDataSet As DataSet
      Public myCustomerTable As DataTable
      Public myTableStyle As DataGridTableStyle
      Private components As System.ComponentModel.Container = Nothing
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      ' Clean up resources.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (components IsNot Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose

        Private Sub InitializeComponent()
            Me.myComboBox = New System.Windows.Forms.ComboBox()
            Me.dataGrid1 = New System.Windows.Forms.Datagrid()
            Me.button2 = New System.Windows.Forms.Button()
            CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' myComboBox
            ' 
            Me.myComboBox.DropDownWidth = 136
            Me.myComboBox.Items.AddRange(New Object() {"Green", "Red", "Violet"})
            Me.myComboBox.Location = New System.Drawing.Point(64, 160)
            Me.myComboBox.Name = "myComboBox"
            Me.myComboBox.Size = New System.Drawing.Size(136, 21)
            Me.myComboBox.TabIndex = 3
            Me.myComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            ' 
            ' dataGrid1
            ' 
            Me.dataGrid1.CaptionText = "DataGrid"
            Me.dataGrid1.DataMember = ""
            Me.dataGrid1.Location = New System.Drawing.Point(56, 48)
            Me.dataGrid1.Name = "dataGrid1"
            Me.dataGrid1.Size = New System.Drawing.Size(272, 80)
            Me.dataGrid1.TabIndex = 0
            ' 
            ' button2
            ' 
            Me.button2.Location = New System.Drawing.Point(232, 160)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(96, 32)
            Me.button2.TabIndex = 4
            Me.button2.Text = "Change ForeGround"
            ' 
            ' Form1
            ' 
            Me.ClientSize = New System.Drawing.Size(536, 301)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.myComboBox, Me.dataGrid1})
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent


        <STAThread()> Shared Sub Main()
            Application.Run(New Form1())
        End Sub 'Main


        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            myComboBox.SelectedIndex = 0
            Create_Table()
        End Sub 'Form1_Load

' <Snippet1>
        Private Sub Create_Table()
            ' Create a DataSet.
            myDataSet = New DataSet("myDataSet")
            ' Create DataTable.
            Dim myCustomerTable As New DataTable("Customers")
            ' Create two columns, and add to the table.
            Dim CustID As New DataColumn("CustID", GetType(Integer))
            Dim CustName As New DataColumn("CustName")
            myCustomerTable.Columns.Add(CustID)
            myCustomerTable.Columns.Add(CustName)
            Dim newRow1 As DataRow
            ' Create three customers in the Customers Table.
            Dim i As Integer
            For i = 1 To 2
                newRow1 = myCustomerTable.NewRow()
                newRow1("custID") = i
                ' Add row to the Customers table.
                myCustomerTable.Rows.Add(newRow1)
            Next i
            ' Give each customer a distinct name.
            myCustomerTable.Rows(0)("custName") = "Alpha"
            myCustomerTable.Rows(1)("custName") = "Beta"
            ' Add table to DataSet.
            myDataSet.Tables.Add(myCustomerTable)
            dataGrid1.SetDataBinding(myDataSet, "Customers")
            myTableStyle = New DataGridTableStyle()
            myTableStyle.MappingName = "Customers"
            myTableStyle.ForeColor = Color.DarkMagenta
            dataGrid1.TableStyles.Add(myTableStyle)
        End Sub 'Create_Table

        ' Set table's forecolor.
        Private Sub OnForeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button2.Click
            dataGrid1.TableStyles.Clear()
            Select Case myComboBox.SelectedItem.ToString()
                Case "Green"
                    myTableStyle.ForeColor = Color.Green
                Case "Red"
                    myTableStyle.ForeColor = Color.Red
                Case "Violet"
                    myTableStyle.ForeColor = Color.Violet
            End Select
            dataGrid1.TableStyles.Add(myTableStyle)
        End Sub 'OnForeColor_Click
' </Snippet1>
    End Class 'Form1 
End Namespace 'Datagrid
