' System.Windows.Forms.DataGridColumnStyle.WidthChanged

' The following example demonstrates the 'WidthChanged' event of 
' the 'DataGridColumnStyle' class. In the example a message will be 
' displayed whenever the width of the 'Customer ID' column of the 
' data grid is changed.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic

Namespace MyWidthChangedEventExample
 
   Public Class MyForm
      Inherits Form
      Private components As Container = Nothing
      Private myDataGrid As DataGrid
      Private myDataSet As DataSet
      Private myButtonNone As Button
      Private myButtonSolid As Button
      Private myLabel As Label
      
      
      Public Sub New()
         InitializeComponent()
         SetUp()
      End Sub 'New
      
      
      Protected Overloads Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose


      <STAThread()> Shared Sub Main()
         Application.Run(New MyForm())
      End Sub 'Main

      Private Sub InitializeComponent()
         Try
            ' Create a Label.
            myLabel = New Label()
            myLabel.Text = "Change width of 'Customer ID' column to see" + _
                                 "'WidthChanged' event message."
            myLabel.Location = New Point(0, 0)
            myLabel.Size = New System.Drawing.Size(400, 20)
            myLabel.ForeColor = Color.Blue

            ' Create the first button.
            myButtonNone = New Button()
            myButtonNone.Location = New Point(24, 21)
            myButtonNone.Size = New System.Drawing.Size(150, 24)
            myButtonNone.Text = "Apply 'None' Line Style "
            AddHandler myButtonNone.Click, AddressOf OnNoneButtonClick

            ' Create the second button.
            myButtonSolid = New Button()
            myButtonSolid.Location = New Point(180, 21)
            myButtonSolid.Size = New System.Drawing.Size(150, 24)
            myButtonSolid.Text = "Apply 'Solid' Line Style "
            AddHandler myButtonSolid.Click, AddressOf OnSolidButtonClick

            Me.Text = "DataGridColumnStyle Sample"
            ClientSize = New System.Drawing.Size(400, 300)

            ' Create a data grid.
            myDataGrid = New DataGrid()
            myDataGrid.Location = New Point(24, 55)
            myDataGrid.Size = New Size(345, 200)
            myDataGrid.CaptionText = "Microsoft DataGrid Control"

            ' Create a data grid table style.
            Dim myDataGridTableStyle As New DataGridTableStyle()
            myDataGridTableStyle.MappingName = "Customers"
            myDataGridTableStyle.AlternatingBackColor = Color.LightGray

' <Snippet1>
            ' Add the 'Customer ID' column style.
            Dim myIDCol As DataGridTextBoxColumn = New DataGridTextBoxColumn()
            myIDCol.MappingName = "custID"
            myIDCol.HeaderText = "Customer ID"
            myIDCol.Width = 100
            AddHandler myIDCol.WidthChanged, AddressOf MyIDColumnWidthChanged
            myDataGridTableStyle.GridColumnStyles.Add(myIDCol)
' </Snippet1>
            ' Add the 'Customer Name' column style.
            Dim myNameCol = New DataGridTextBoxColumn()
            myNameCol.MappingName = "custName"
            myNameCol.HeaderText = "Customer Name"
            myNameCol.Width = 150
            myDataGridTableStyle.GridColumnStyles.Add(myNameCol)
            myDataGrid.TableStyles.Add(myDataGridTableStyle)

            ' Add the controls.
            Controls.Add(myLabel)
            Controls.Add(myButtonNone)
            Controls.Add(myButtonSolid)
            Controls.Add(myDataGrid)
         Catch exc As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine("Source : " + exc.Source.ToString())
            Console.WriteLine("Message : " + exc.Message.ToString())
         End Try
      End Sub 'InitializeComponent
      Private Sub SetUp()
         Try
            ' Create a DataSet with one table.
            MakeDataSet()
            ' Bind the DataGrid to the DataSet.
            myDataGrid.SetDataBinding(myDataSet, "Customers")
         Catch exc As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine("Source : " + exc.Source.ToString())
            Console.WriteLine("Message : " + exc.Message.ToString())
         End Try
      End Sub 'SetUp


      Private Sub MakeDataSet()
         Try
            ' Create a DataSet.
            myDataSet = New DataSet("myDataSet")
            ' Create a DataTable.
            Dim myCustTable As New DataTable("Customers")
            ' Create two columns and add them to the table.
            Dim cCustID As New DataColumn("CustID", GetType(Integer))
            Dim cCustName As New DataColumn("CustName")

            myCustTable.Columns.Add(cCustID)
            myCustTable.Columns.Add(cCustName)

            myDataSet.Tables.Add(myCustTable)

            Dim newRow1 As DataRow
            Dim i As Integer
            For i = 1 To 3
               newRow1 = myCustTable.NewRow()
               newRow1("custID") = i
               ' Add the row to the Customers table.
               myCustTable.Rows.Add(newRow1)
            Next i
            ' Add the customers to the table.
            myCustTable.Rows(0)("custName") = "Alpha"
            myCustTable.Rows(1)("custName") = "Beta"
            myCustTable.Rows(2)("custName") = "Omega"
         Catch exc As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine("Source : " + exc.Source.ToString())
            Console.WriteLine("Message : " + exc.Message.ToString())
         End Try
      End Sub 'MakeDataSet


        Private Sub MyIDColumnWidthChanged(ByVal obj As Object, ByVal e As EventArgs)
            Try
                ' Get the changed width of the 'Customer ID' column and display.
                Dim myTableStyle As DataGridTableStyle = myDataGrid.TableStyles("Customers")
                Dim myWidth As Integer = myTableStyle.GridColumnStyles("custID").Width
                MessageBox.Show("Width of 'Customer ID' column is changed to :" + _
                                                                    myWidth.ToString() + " pixels")
            Catch exc As Exception
                Console.WriteLine("Exception caught!!!")
                Console.WriteLine("Source : " + exc.Source.ToString())
                Console.WriteLine("Message : " + exc.Message.ToString())
            End Try
        End Sub 'MyIDColumnWidthChanged


        Private Sub OnNoneButtonClick(ByVal obj As Object, ByVal e As EventArgs)
            Try
                Dim myTableStyle As DataGridTableStyle = myDataGrid.TableStyles("Customers")
                myTableStyle.GridLineStyle = DataGridLineStyle.None
            Catch exc As Exception
                Console.WriteLine("Exception caught!!!")
                Console.WriteLine("Source : " + exc.Source.ToString())
                Console.WriteLine("Message : " + exc.Message.ToString())
            End Try
        End Sub 'OnNoneButtonClick


        Private Sub OnSolidButtonClick(ByVal obj As Object, ByVal e As EventArgs)
            Try
                Dim myTableStyle As DataGridTableStyle = myDataGrid.TableStyles("Customers")
                myTableStyle.GridLineStyle = DataGridLineStyle.Solid
            Catch exc As Exception
                Console.WriteLine("Exception caught!!!")
                Console.WriteLine("Source : " + exc.Source.ToString())
                Console.WriteLine("Message : " + exc.Message.ToString())
            End Try
        End Sub 'OnSolidButtonClick
   End Class 'MyForm
End Namespace 'MyWidthChangedEventExample