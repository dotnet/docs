' <Snippet1>
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Public Class Form1
   Inherits Form

   Private components As Container
   Private button1 As Button
   Private button2 As Button
   Private button3 As Button
   Private button4 As Button
   Private text1 As TextBox
   Private text2 As TextBox
   Private text3 As TextBox

   Private bmCustomers As BindingManagerBase
   Private bmOrders As BindingManagerBase
   Private ds As DataSet
   Private DateTimePicker1 As DateTimePicker
   
   Public Sub New
      ' Required for Windows Form Designer support.
      InitializeComponent
      ' Call SetUp to bind the controls.
      SetUp
   End Sub

   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
    End Sub


   Private Sub InitializeComponent
      ' Create the form and its controls.
      With Me
         .components = New Container
         .button1 = New Button
         .button2 = New Button
         .button3 = New Button
         .button4 = New Button
         .text1 = New TextBox
         .text2 = New TextBox
         .text3 = New TextBox

         .DateTimePicker1 = New DateTimePicker
         
         .Text = "Binding Sample"
         .ClientSize = New Size(450, 200)

         With .button1
            .Location = New Point(24, 16)
            .Size = New Size(64, 24)
            .Text = "<"
            AddHandler button1.click, AddressOf button1_Click
         End With
         
         
         With .button2
            .Location = New Point(90, 16)
            .Size = New Size(64, 24)
            .Text = ">"
            AddHandler button2.click, AddressOf button2_Click
         End With
         
         With .button3
            .Location = New Point(90, 100)
            .Size = New Size(64, 24)
            .Text = ">"
            AddHandler button3.click, AddressOf button3_Click
         End With

         With .button4
            .Location = New Point(150, 100)
            .Size = New Size(64, 24)
            .Text = ">"
            AddHandler button4.click, AddressOf button4_Click
         End With

         With .text1
            .Location = New Point(24, 50)
            .Size = New Size(150, 24)
         End With

         With .text2
            .Location = New Point(190, 50)
            .Size = New Size(150, 24)
         End With

         With .text3
            .Location = New Point(290, 150)
            .Size = New Size(150, 24)
         End With

            With .DateTimePicker1
               .Location = New Point(90, 150)
               .Size = New Size(200, 800)
            End With

            With .Controls
            .Add(button1)
            .Add(button2)
            .Add(button3)
            .Add(button4)
            .Add(text1)
            .Add(text2)
            .Add(text3)
            .Add(DateTimePicker1)
            End With
      End With
   End Sub
      
   Public Shared Sub Main
      Application.Run(new Form1)
   End Sub

   Private Sub SetUp
      ' Create a DataSet with two tables and one relation.
      MakeDataSet
      BindControls
   End Sub

   Private Sub BindControls
      ' Create two Binding objects for the first two TextBox
      ' controls. The data-bound property for both controls
      ' is the Text property.  The data source is a DataSet
      ' (ds). The data member is the 
      ' TableName.ColumnName" string.

      text1.DataBindings.Add(New _
         Binding("Text", ds, "customers.custName"))
      text2.DataBindings.Add(New _
         Binding("Text", ds, "customers.custID"))
      ' Bind the DateTimePicker control by adding a new Binding.
      ' The data member of the DateTimePicker is a
      ' TableName.RelationName.ColumnName string
      DateTimePicker1.DataBindings.Add(New _
         Binding("Value", ds, "customers.CustToOrders.OrderDate"))
      ' Add event delegates for the Parse and Format events to a
      ' new Binding object, and add the object to the third
      ' TextBox control's BindingsCollection. The delegates
      ' must be added before adding the Binding to the
      ' collection; otherwise, no formatting occurs until
      ' the Current object of the BindingManagerBase for
      ' the data source changes.
      Dim b As Binding = New _
         Binding("Text", ds, "customers.custToOrders.OrderAmount")
      AddHandler b.Parse, AddressOf CurrencyStringToDecimal
      AddHandler b.Format, AddressOf DecimalToCurrencyString
      text3.DataBindings.Add(b)
      
         ' Get the BindingManagerBase for the Customers table.
         bmCustomers = Me.BindingContext(ds, "Customers")

         ' Get the BindingManagerBase for the Orders table using the
         ' RelationName.
         bmOrders = Me.BindingContext(ds, "customers.CustToOrders")
   End Sub

   Private Sub DecimalToCurrencyString(sender As Object, cevent As ConvertEventArgs)
      ' This method is the Format event handler. Whenever the 
      ' control displays a new value, the value is converted from 
      ' its native Decimal type to a string. The ToString method 
      ' then formats the value as a Currency, by using the 
      ' formatting character "c".

      ' The application can only convert to string type. 
   
      If cevent.DesiredType IsNot GetType(String) Then
         Exit Sub
      End If 
   
      cevent.Value = CType(cevent.Value, decimal).ToString("c")
   End Sub

   Private Sub CurrencyStringToDecimal(sender As Object, cevent As ConvertEventArgs)
      ' This method is the Parse event handler. The Parse event 
      ' occurs whenever the displayed value changes. The static 
      ' ToDecimal method of the Convert class converts the 
      ' value back to its native Decimal type.

      ' Can only convert to decimal type.
      If cevent.DesiredType IsNot GetType(decimal) Then
         Exit Sub
      End If

      cevent.Value = Decimal.Parse(cevent.Value.ToString, _
      NumberStyles.Currency, nothing)
      
      ' To see that no precision is lost, print the unformatted 
      ' value. For example, changing a value to "10.0001" 
      ' causes the control to display "10.00", but the 
      ' unformatted value remains "10.0001".
      Console.WriteLine(cevent.Value)
   End Sub

   Private Sub button1_Click(sender As Object, e As System.EventArgs)
      ' Go to the previous item in the Customer list.
      bmCustomers.Position -= 1
   End Sub

   Private Sub button2_Click(sender As Object, e As System.EventArgs)
      ' Go to the next item in the Customer list.
      bmCustomers.Position += 1
   End Sub

   Private Sub button3_Click(sender As Object, e As System.EventArgs)
      ' Go to the previous item in the Order list.
      bmOrders.Position -= 1
   End Sub

   Private Sub button4_Click(sender As Object, e As System.EventArgs)
      ' Go to the next item in the Orders list.
      bmOrders.Position += 1
   End Sub

   ' Creates a DataSet with two tables and populates it.
   Private Sub MakeDataSet
      ' Create a DataSet.
      ds = New DataSet("myDataSet")

      ' Creates two DataTables.
      Dim tCust As DataTable = New DataTable("Customers")
      Dim tOrders As DataTable = New DataTable("Orders")

      ' Create two columns, and add them to the first table.
      Dim cCustID As DataColumn = New DataColumn("CustID", _
      System.Type.GetType("System.Int32"))
      Dim cCustName As DataColumn = New DataColumn("CustName")
      tCust.Columns.Add(cCustID)
      tCust.Columns.Add(cCustName)

      ' Create three columns, and add them to the second table.
      Dim cID As DataColumn = _
         New DataColumn("CustID", System.Type.GetType("System.Int32"))
      Dim cOrderDate As DataColumn = _
         New DataColumn("orderDate", System.Type.GetType("System.DateTime"))
      Dim cOrderAmount As DataColumn = _
         New DataColumn("OrderAmount", System.Type.GetType("System.Decimal"))
      tOrders.Columns.Add(cOrderAmount)
      tOrders.Columns.Add(cID)
      tOrders.Columns.Add(cOrderDate)

      ' Add the tables to the DataSet.
      ds.Tables.Add(tCust)
      ds.Tables.Add(tOrders)

      ' Create a DataRelation, and add it to the DataSet.
      Dim dr As DataRelation = New _
         DataRelation("custToOrders", cCustID, cID)
      ds.Relations.Add(dr)
      
      ' Populate the tables. For each customer and orders,
      ' create two DataRow variables.
      Dim newRow1 As DataRow
      Dim newRow2 As DataRow

         ' Create three customers in the Customers Table.
         Dim i As Integer
         For i = 1 to 3
            newRow1 = tCust.NewRow
            newRow1("custID") = i
            ' Adds the row to the Customers table.
            tCust.Rows.Add(newRow1)
         Next

         ' Give each customer a distinct name.
         tCust.Rows(0)("custName") = "Alpha"
         tCust.Rows(1)("custName") = "Beta"
         tCust.Rows(2)("custName") = "Omega"

         ' For each customer, create five rows in the Orders table.
         Dim j As Integer
         For i = 1 to 3
         For j = 1 to 5
            newRow2 = tOrders.NewRow
            newRow2("CustID") = i
            newRow2("orderDate") = New DateTime(2001, i, j * 2)
            newRow2("OrderAmount") = i * 10 + j * .1
            ' Add the row to the Orders table.
            tOrders.Rows.Add(newRow2)
         Next
         Next
   End Sub
End Class
' </Snippet1>


