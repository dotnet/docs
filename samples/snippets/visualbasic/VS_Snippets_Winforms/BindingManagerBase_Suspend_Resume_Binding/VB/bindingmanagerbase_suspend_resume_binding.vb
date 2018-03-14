' System.BindingManagerBase.SuspendBinding
' System.BindingManagerBase.ResumeBinding

' The following example demonstrates 'SuspendBinding' and 'ResumeBinding' methomyDataSet of'
' 'BindingManagerBase'class. It creates a 'DataTable'and two 'TextBox' controls. 
' The 'Text' property of the two 'TextBox' controls are bound with the two columns of the 
' 'DataTable'. If 'SuspendBinding' button is pressed it suspenmyDataSet the Data Binding between 
' TextBoxes and the 'DataTable' and if the ResumeButton is pressed it resumes the Data Binding.

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class Form1
   Inherits Form
   Private button1 As Button
   Private button2 As Button
   Private text1 As TextBox
   Private text2 As TextBox
   Private myBindingManager As BindingManagerBase
   Private button3 As Button
   Private button4 As Button
   Private label1 As Label
   Private label2 As Label
   Private myDataSet As DataSet
   
   
   Public Sub New()
      InitializeComponent()
      ' Call SetUp to bind the controls.
      SetUp()
   End Sub 'New
   
   
   Private Sub InitializeComponent()
      button1 = New Button()
      button2 = New Button()
      button3 = New Button()
      text2 = New TextBox()
      text1 = New TextBox()
      button4 = New Button()
      label1 = New Label()
      label2 = New Label()
      SuspendLayout()
      
      button1.Location = New Point(120, 8)
      button1.Name = "button1"
      button1.Size = New Size(64, 24)
      button1.TabIndex = 0
      button1.Text = "<"
      AddHandler button1.Click, AddressOf button1_Click
      
      button2.Location = New Point(184, 8)
      button2.Name = "button2"
      button2.Size = New Size(64, 24)
      button2.TabIndex = 1
      button2.Text = ">"
      AddHandler button2.Click, AddressOf button2_Click
      
      button3.Location = New Point(96, 112)
      button3.Name = "button3"
      button3.TabIndex = 4
      button3.Text = "Suspend"
      AddHandler button3.Click, AddressOf button3_Click
      
      text2.Location = New Point(200, 72)
      text2.Name = "text2"
      text2.Size = New Size(150, 20)
      text2.TabIndex = 3
      text2.Text = ""
      
      text1.Location = New Point(40, 72)
      text1.Name = "text1"
      text1.Size = New Size(150, 20)
      text1.TabIndex = 2
      text1.Text = ""
      
      button4.Location = New Point(192, 112)
      button4.Name = "button4"
      button4.TabIndex = 5
      button4.Text = "Resume"
      AddHandler button4.Click, AddressOf button4_Click
      
      label1.Location = New Point(48, 48)
      label1.Name = "label1"
      label1.TabIndex = 6
      label1.Text = "Customer Name"
      
      label2.Location = New Point(216, 48)
      label2.Name = "label2"
      label2.TabIndex = 7
      label2.Text = "CustomerID"
      
      ClientSize = New Size(450, 200)
      Controls.AddRange(New Control() {label2, label1, button4, button3, button1, button2, text1, text2})
      Name = "Form1"
      [Text] = "Binding Sample"
      ResumeLayout(False)
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New Form1())
   End Sub 'Main
   
   
   Private Sub SetUp()
      MakeDataSet()
      BindControls()
   End Sub 'SetUp
   
   
   Protected Sub BindControls()
      text1.DataBindings.Add(New Binding("Text", myDataSet, "customers.custName"))
      text2.DataBindings.Add(New Binding("Text", myDataSet, "customers.custID"))
      
      myBindingManager = BindingContext(myDataSet, "Customers")
   End Sub 'BindControls
   
   
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Go to the previous item in the Customer list.
        myBindingManager.Position -= 1
    End Sub 'button1_Click
   
   
    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Go to the next item in the Customer list.
        myBindingManager.Position += 1
    End Sub 'button2_Click
   
   
   ' Create a DataSet with two tables and populate it.
   Private Sub MakeDataSet()
      ' Create a DataSet.
      myDataSet = New DataSet("myDataSet")
      
      ' Create a DataTable.
      Dim myCustomerTable As New DataTable("Customers")
      
      ' Create two columns, and add them to the first table.
      Dim myCustomerColumnID As New DataColumn("CustID", GetType(Integer))
      Dim myCustomerName As New DataColumn("CustName")
      myCustomerTable.Columns.Add(myCustomerColumnID)
      myCustomerTable.Columns.Add(myCustomerName)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(myCustomerTable)
      
      Dim newRow1 As DataRow
      ' Create three customers in the Customers Table.
      Dim i As Integer
      For i = 1 To 3
         newRow1 = myCustomerTable.NewRow()
         newRow1("custID") = i
         ' Add the row to the Customers table.
         myCustomerTable.Rows.Add(newRow1)
      Next i
      ' Give each customer a distinct name.
      myCustomerTable.Rows(0)("custName") = "Alpha"
      myCustomerTable.Rows(1)("custName") = "Beta"
      myCustomerTable.Rows(2)("custName") = "Omega"
      
      Dim idKeyRestraint As New UniqueConstraint(myCustomerColumnID)
      myCustomerTable.Constraints.Add(idKeyRestraint)
      myDataSet.EnforceConstraints = True
   End Sub 'MakeDataSet
   
   
' <Snippet1>
   Private Sub button3_Click(sender As Object, e As EventArgs)
      Try
         Dim myBindingManager1 As BindingManagerBase = BindingContext(myDataSet, "Customers")
         myBindingManager1.SuspendBinding()
      Catch ex As Exception
         MessageBox.Show(ex.Source.ToString())
         MessageBox.Show(ex.Message.ToString())
      End Try
   End Sub 'button3_Click
   
' </Snippet1>
' <Snippet2>
   Private Sub button4_Click(sender As Object, e As EventArgs)
      Try
         Dim myBindingManager2 As BindingManagerBase = BindingContext(myDataSet, "Customers")
         myBindingManager2.ResumeBinding()
      Catch ex As Exception
         MessageBox.Show(ex.Source.ToString())
         MessageBox.Show(ex.Message.ToString())
      End Try
   End Sub 'button4_Click
' </Snippet2>
End Class 'Form1

