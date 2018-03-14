' System.Windows.Forms.GridColumnStylesCollection.Clear
' System.Windows.Forms.GridColumnStylesCollection.Item [int index]
' System.Windows.Forms.GridColumnStylesCollection.Item [string columnName]

' The following program demonstrates the Clear method , the Item[index] and Item[columnName]
' indexers for the 'GridColumnStylesCollection' class.
' In this program the user can add custom styles and clear them. The information on the styles
' is displayed depending on the option chosen by user.

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class MyForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.Container
    Private myDataGrid As DataGrid
    Private myDataSet As DataSet
    Private myLabel As Label
    Private WithEvents clearButton As Button
    Private WithEvents addStylesButton As Button
    Private WithEvents selectChoiceButton As Button
    Private columnNameRadioButton As System.Windows.Forms.RadioButton
    Private indexRadioButton As System.Windows.Forms.RadioButton
    Private myLabel2 As System.Windows.Forms.Label
    Private TablesAlreadyAdded As Boolean

    Public Sub New()
        InitializeComponent()
        SetUp()
    End Sub 'New


    Private Sub InitializeComponent()
        ' Create the form and its controls.
        components = New System.ComponentModel.Container()

        clearButton = New System.Windows.Forms.Button()
        addStylesButton = New System.Windows.Forms.Button()
        myDataGrid = New System.Windows.Forms.DataGrid()
        myLabel = New System.Windows.Forms.Label()
        selectChoiceButton = New System.Windows.Forms.Button()
        columnNameRadioButton = New System.Windows.Forms.RadioButton()
        indexRadioButton = New System.Windows.Forms.RadioButton()
        myLabel2 = New System.Windows.Forms.Label()

        clearButton.Location = New System.Drawing.Point(24, 16)
        clearButton.Name = "clearButton"
        clearButton.Size = New System.Drawing.Size(120, 24)
        clearButton.Text = "Clear Table Styles"

        addStylesButton.Location = New System.Drawing.Point(150, 16)
        addStylesButton.Name = "addStylesButton"
        addStylesButton.Size = New System.Drawing.Size(120, 24)
        addStylesButton.Text = "Add Custom Styles"

        myDataGrid.Location = New Point(24, 50)
        myDataGrid.Size = New Size(300, 200)
        myDataGrid.CaptionText = "Microsoft DataGrid Control"

        myLabel.Location = New System.Drawing.Point(48, 328)
        myLabel.Name = "myLabel"
        myLabel.Size = New System.Drawing.Size(464, 90)
        myLabel.TabIndex = 7
        myLabel.Text = "Message."

        myLabel2.Location = New System.Drawing.Point(412, 24)
        myLabel2.Size = New System.Drawing.Size(100, 20)
        myLabel2.Text = "Print info using:"

        selectChoiceButton.Location = New System.Drawing.Point(276, 16)
        selectChoiceButton.Name = "selectChoiceButton"
        selectChoiceButton.Size = New System.Drawing.Size(120, 24)
        selectChoiceButton.Text = "Print Info"

        columnNameRadioButton.Location = New System.Drawing.Point(432, 56)
        columnNameRadioButton.Name = "columnNameRadioButton"
        columnNameRadioButton.Text = "ColumnName"

        indexRadioButton.Location = New System.Drawing.Point(432, 88)
        indexRadioButton.Name = "indexRadioButton"
        indexRadioButton.Text = "Index"

        ClientSize = New System.Drawing.Size(600, 500)
        Name = "MyForm"
        [Text] = "DataGrid Control Sample"

        Controls.Add(clearButton)
        Controls.Add(addStylesButton)
        Controls.Add(selectChoiceButton)
        Controls.Add(myDataGrid)
        Controls.Add(columnNameRadioButton)
        Controls.Add(indexRadioButton)
        Controls.Add(myLabel)
        Controls.Add(myLabel2)
    End Sub 'InitializeComponent


    Public Shared Sub Main()
        Application.Run(New MyForm())
    End Sub 'Main


    Private Sub SetUp()
        MakeDataSet()
        myDataGrid.SetDataBinding(myDataSet, "Customers")
    End Sub 'SetUp


    ' Create a DataSet with two tables and populate it.
    Private Sub MakeDataSet()
        myDataSet = New DataSet("myDataSet")

        Dim customerTable As New DataTable("Customers")
        Dim ordersTable As New DataTable("Orders")

        ' Create two columns, add them to the first table.
        Dim customerID As New DataColumn("CustID", GetType(Integer))
        Dim customerName As New DataColumn("CustName")
        Dim current As New DataColumn("Current", GetType(Boolean))
        customerTable.Columns.Add(customerID)
        customerTable.Columns.Add(customerName)
        customerTable.Columns.Add(current)

        ' Create three columns, add them to the second table.
        Dim customerID2 As New DataColumn("CustID", GetType(Integer))
        Dim orderDate As New DataColumn("OrderDate", GetType(DateTime))
        Dim orderAmount As New DataColumn("OrderAmount", GetType(Decimal))
        ordersTable.Columns.Add(orderAmount)
        ordersTable.Columns.Add(customerID2)
        ordersTable.Columns.Add(orderDate)

        ' Add the tables to the DataSet.
        myDataSet.Tables.Add(customerTable)
        myDataSet.Tables.Add(ordersTable)

        ' Create a DataRelation, add it to the DataSet.
        Dim myDataRelation As New DataRelation("custToOrders", customerID, customerID2)
        myDataSet.Relations.Add(myDataRelation)

        Dim newRow1 As DataRow
        Dim newRow2 As DataRow

        ' Create three customers in the Customers Table.
        Dim index As Integer
        For index = 1 To 4
            newRow1 = customerTable.NewRow()
            newRow1("CustID") = index
            newRow1("CustName") = "Item" + index.ToString()
            newRow1("Current") = True
            ' Add the row to the Customers table.
            customerTable.Rows.Add(newRow1)
        Next index

        ' For each customer, create five rows in the Orders table.
        For index = 1 To 4
            Dim j As Integer
            For j = 1 To 5
                newRow2 = ordersTable.NewRow()
                newRow2("CustID") = index
                newRow2("OrderDate") = New DateTime(2001, index, j * 2)
                newRow2("OrderAmount") = index * 10 + j * 0.1
                ' Add the row to the Orders table.
                ordersTable.Rows.Add(newRow2)
            Next j
        Next index
    End Sub 'MakeDataSet


    Private Sub AddStyles_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles addStylesButton.Click
        myLabel.Text = "Styles added to the grid."
        If TablesAlreadyAdded Then
            Return
        End If
        AddCustomDataTableStyle()
    End Sub 'AddStyles_Clicked


    Private Sub AddCustomDataTableStyle()
        Dim tableStyle1 As New DataGridTableStyle()
        tableStyle1.MappingName = "Customers"
        ' Set other properties.
        tableStyle1.AlternatingBackColor = Color.LightGray

        ' Add a second column style.
        Dim textBoxColumnStyle = New DataGridTextBoxColumn()
        textBoxColumnStyle.MappingName = "CustName"
        textBoxColumnStyle.HeaderText = "Customer Name"
        textBoxColumnStyle.Width = 100
        tableStyle1.GridColumnStyles.Add(textBoxColumnStyle)

        ' Add a GridColumnStyle and set its MappingName to the name of a DataColumn in the DataTable.
        Dim gridColumnStyle = New DataGridBoolColumn()
        gridColumnStyle.MappingName = "Current"

        ' Set the HeaderText and Width properties.
        gridColumnStyle.HeaderText = "IsCurrent Customer"
        gridColumnStyle.Width = 125
        tableStyle1.GridColumnStyles.Add(gridColumnStyle)

        ' Create the second table style with columns.
        Dim tableStyle2 As New DataGridTableStyle()
        tableStyle2.MappingName = "Orders"

        ' Set other properties.
        tableStyle2.AlternatingBackColor = Color.LightBlue

        ' Create new ColumnStyle object.
        Dim orderDate = New DataGridTextBoxColumn()
        orderDate.MappingName = "OrderDate"
        orderDate.HeaderText = "Order Date"
        orderDate.Width = 100
        tableStyle2.GridColumnStyles.Add(orderDate)

        ' Create a formatted column using a PropertyDescriptor.
        Dim pcol As PropertyDescriptorCollection = Me.BindingContext(myDataSet, "Customers.custToOrders").GetItemProperties()

        Dim csOrderAmount = New DataGridTextBoxColumn(pcol("OrderAmount"), "c", True)
        csOrderAmount.MappingName = "OrderAmount"
        csOrderAmount.HeaderText = "Total"
        csOrderAmount.Width = 100
        tableStyle2.GridColumnStyles.Add(csOrderAmount)

        ' Add the DataGridTableStyle objects to the GridTableStylesCollection.
        myDataGrid.TableStyles.Add(tableStyle1)
        myDataGrid.TableStyles.Add(tableStyle2)

        ' Set the TablesAlreadyAdded to true so we don't try to do this again.
        TablesAlreadyAdded = True
    End Sub 'AddCustomDataTableStyle


    Private Sub SelectChoice_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectChoiceButton.Click
        If columnNameRadioButton.Checked Then
            PrintColumnInformationUsingColumnName()
        Else
            If indexRadioButton.Checked Then
                PrintColumnInformationUsingIndex()
            End If
        End If
    End Sub 'SelectChoice_Clicked
    ' <Snippet1>
    Private Sub Clear_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles clearButton.Click
        ' TablesAlreadyAdded set to false so that table styles can be added again.
        TablesAlreadyAdded = False
        myLabel.Text = "All Table Styles Cleared."
        ' Clear all the column styles and also table style for the grid.
        Dim myTableStyle As DataGridTableStyle
        For Each myTableStyle In myDataGrid.TableStyles
            Dim myColumns As GridColumnStylesCollection = myTableStyle.GridColumnStyles
            myColumns.Clear()
        Next myTableStyle
        myDataGrid.TableStyles.Clear()
    End Sub 'Clear_Clicked

    ' </Snippet1>
    ' <Snippet2>
    Private Sub PrintColumnInformationUsingColumnName()
        myLabel.Text = "Table Styles info: No of Styles " + myDataGrid.TableStyles.Count.ToString()
        Dim myTableStyle As DataGridTableStyle
        For Each myTableStyle In myDataGrid.TableStyles
            myLabel.Text += ControlChars.Cr + "Table Name : " + myTableStyle.MappingName
            Dim myColumns As GridColumnStylesCollection = myTableStyle.GridColumnStyles
            ' 'myTableStyle.GridColumnStyles[index].MappingName' specifies the column came for the table.
            Dim index As Integer
            For index = 0 To myColumns.Count - 1
                myLabel.Text += ControlChars.Cr + "Mapping Name: " + myColumns(myTableStyle.GridColumnStyles(index).MappingName).MappingName
            Next index
        Next myTableStyle
    End Sub 'PrintColumnInformationUsingColumnName

    ' </Snippet2>
    ' <Snippet3>
    Private Sub PrintColumnInformationUsingIndex()
        myLabel.Text = "Table Styles info: No of Styles " + myDataGrid.TableStyles.Count.ToString()
        Dim myTableStyle As DataGridTableStyle
        For Each myTableStyle In myDataGrid.TableStyles
            myLabel.Text += ControlChars.Cr + "Table Name : " + myTableStyle.MappingName
            Dim myColumns As GridColumnStylesCollection = myTableStyle.GridColumnStyles
            Dim index As Integer
            For index = 0 To myColumns.Count - 1
                myLabel.Text += ControlChars.Cr + "Mapping Name: " + myColumns(index).MappingName
            Next index
        Next myTableStyle
    End Sub 'PrintColumnInformationUsingIndex 
    ' </Snippet3>
End Class 'MyForm