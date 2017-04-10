 ' System.Windows.Forms.DataGridTableStyle.SelectionBackColorChanged
' System.Windows.Forms.DataGridTableStyle.SelectionBackColor
' System.Windows.Forms.DataGridTableStyle.ResetSelectionBackColor

' The following program demonstrates the 'SelectionBackColorChanged'
' event, 'SelectionBackColor' property and 'ResetSelectionBackColor'
' method of the'DataGridTableStyle'class. It changes the BackColor
' of the selected cells by raising the 'SelectionBackColorChanged'
' event. The SelectionBackColor is reset to its default value with
' the 'ResetSelectionBackColor' button.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public Class MyForm
   Inherits System.Windows.Forms.Form
   Private components As System.ComponentModel.Container = Nothing
   Private WithEvents myBackColorButton As System.Windows.Forms.Button
   Private WithEvents myResetButton As System.Windows.Forms.Button
   Private myGridTableStyle As DataGridTableStyle
   
   
   Public Sub New()
      InitializeComponent()
   End Sub 'New
   
   
   Protected Overrides Overloads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose
   

   ' <summary>
   ' </summary>
   Private Sub InitializeComponent()
      Me.myBackColorButton = New System.Windows.Forms.Button()
      Me.myResetButton = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' myBackColorButton
      ' 
      Me.myBackColorButton.Location = New System.Drawing.Point(0, 352)
      Me.myBackColorButton.Name = "myBackColorButton"
      Me.myBackColorButton.Size = New System.Drawing.Size(160, 23)
      Me.myBackColorButton.TabIndex = 0
      Me.myBackColorButton.Text = "Change SelectionBackColor"
      ' 
      ' myResetButton
      ' 
      Me.myResetButton.Location = New System.Drawing.Point(160, 352)
      Me.myResetButton.Name = "myResetButton"
      Me.myResetButton.Size = New System.Drawing.Size(152, 23)
      Me.myResetButton.TabIndex = 1
      Me.myResetButton.Text = "Reset SelectionBackColor"

      ' MyForm
      Me.ClientSize = New System.Drawing.Size(316, 411)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.myResetButton, Me.myBackColorButton})
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "MyForm"
      Me.Text = "MyForm"
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent 

   Private myDataGrid As New DataGrid()
   
   <STAThread()> Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
   Private Sub MyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      myDataGrid.CaptionText = "My Data Grid"
      myDataGrid.Height = 300
      myDataGrid.Width = 300
      myDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      myDataGrid.SetDataBinding(MakeDataSet(), "Orders")
      Controls.Add(myDataGrid)
      myGridTableStyle = New DataGridTableStyle()
      myGridTableStyle.MappingName = "Orders"
      myGridTableStyle.SelectionForeColor = Color.Coral
      myDataGrid.TableStyles.Add(myGridTableStyle)
      AttachSelectionBackColorChanged()
   End Sub 'MyForm_Load
   
' <Snippet1>   
   Public Sub AttachSelectionBackColorChanged()
      ' Handle the 'SelectionBackColorChanged' event.
      AddHandler myGridTableStyle.SelectionBackColorChanged, AddressOf MyDataGrid_SelectedBackColorChanged
   End Sub 'AttachSelectionBackColorChanged
   
   
    Private Sub MyDataGrid_SelectedBackColorChanged(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("SelectionBackColorChanged event was raised, Color changed to " & myGridTableStyle.SelectionBackColor.ToString())
    End Sub 'MyDataGrid_SelectedBackColorChanged
   
' </Snippet1>    
   Private Sub MyBackColorButton_Click(sender As Object, e As EventArgs) Handles myBackColorButton.Click
' <Snippet2>   
      ' Allow the user to select a Color.
      Dim myColorDialog As New ColorDialog()
      myColorDialog.AllowFullOpen = False
      myColorDialog.ShowHelp = True
      ' Set the initial color select to the current color.
      myColorDialog.Color = myGridTableStyle.SelectionBackColor
      ' Show color dialog box.
      myColorDialog.ShowDialog()
      ' Set the backcolor for the selected cells. 
      myGridTableStyle.SelectionBackColor = myColorDialog.Color
' </Snippet2>      
      myDataGrid.Invalidate()
   End Sub 'MyBackColorButton_Click
   
   
   Private Sub MyResetButton_Click(sender As Object, e As EventArgs) Handles myResetButton.Click
' <Snippet3> 
      ' Set the SelectionBackColor to the default color.
      myGridTableStyle.ResetSelectionBackColor()
' </Snippet3>       
   End Sub 'MyResetButton_Click

   
   Private Function MakeDataSet() As DataSet
      ' Create a DataSet.
      Dim myDataSet As New DataSet("myDataSet")
      
      ' Create two DataTables.
      Dim myDataGrid As New DataTable("Customers")
      Dim tOrders As New DataTable("Orders")
      
      ' Create two columns, and add them to the first table.
      Dim cCustID As New DataColumn("CustID", GetType(Integer))
      Dim cCustName As New DataColumn("CustName")
      Dim cCurrent As New DataColumn("Current", GetType(Boolean))
      myDataGrid.Columns.Add(cCustID)
      myDataGrid.Columns.Add(cCustName)
      myDataGrid.Columns.Add(cCurrent)
      
      ' Create three columns, and add them to the second table.
      Dim cID As New DataColumn("CustID", GetType(Integer))
      Dim cOrderDate As New DataColumn("OrderDate", GetType(DateTime))
      Dim cOrderAmount As New DataColumn("OrderAmount", GetType(Decimal))
      tOrders.Columns.Add(cOrderAmount)
      tOrders.Columns.Add(cID)
      tOrders.Columns.Add(cOrderDate)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(myDataGrid)
      myDataSet.Tables.Add(tOrders)
      
      ' Create a DataRelation, and add it to the DataSet.
      Dim dr As New DataRelation("custToOrders", cCustID, cID)
      myDataSet.Relations.Add(dr)
      
      ' Populate the tables. 
      ' Create for each customer and order two DataRow variables.
      Dim newRow1 As DataRow
      Dim newRow2 As DataRow
      
      ' Create three customers in the Customers Table.
      Dim i As Integer
      For i = 1 To 3
         newRow1 = myDataGrid.NewRow()
         newRow1("custID") = i
         ' Add the row to the Customers table.
         myDataGrid.Rows.Add(newRow1)
      Next i
      ' Give each customer a distinct name.
      myDataGrid.Rows(0)("custName") = "Customer 1"
      myDataGrid.Rows(1)("custName") = "Customer 2"
      myDataGrid.Rows(2)("custName") = "Customer 3"
      
      ' Give the Current column a value.
      myDataGrid.Rows(0)("Current") = True
      myDataGrid.Rows(1)("Current") = True
      myDataGrid.Rows(2)("Current") = False
      
      ' For each customer, create five rows in the Orders table.
      For i = 1 To 3
         Dim j As Integer
         For j = 1 To 5
            newRow2 = tOrders.NewRow()
            newRow2("CustID") = i
            newRow2("orderDate") = New DateTime(2001, i, j * 2)
            newRow2("OrderAmount") = i * 10 + j * 0.1
            ' Add the row to the Orders table.
            tOrders.Rows.Add(newRow2)
         Next j
      Next i
      Return myDataSet
   End Function 'MakeDataSet
End Class 'MyForm
