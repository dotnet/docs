Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected text1 As TextBox
 Protected text2 As TextBox
 Protected text3 As TextBox
 Protected text4 As TextBox
 Protected ds As DataSet
 Protected DateTimePicker1 As DateTimePicker
 Protected bmCustomers As BindingManagerBase
 Protected bmOrders As BindingManagerBase

' <Snippet1>
   Protected Sub BindControls()

      ' Create two Binding objects for the first two TextBox 
      '   controls. The data-bound property for both controls 
      '   is the Text property. The data source is a DataSet 
      '   (ds). The data member is the string 
      '   "TableName.ColumnName".
      text1.DataBindings.Add(New Binding _
         ("Text", ds, "customers.custName"))
      text2.DataBindings.Add(New Binding _
         ("Text", ds, "customers.custID"))
      
      ' Bind the DateTimePicker control by adding a new Binding. 
      '   The data member of the DateTimePicker is a 
      '   TableName.RelationName.ColumnName string.
      DateTimePicker1.DataBindings.Add(New Binding _
         ("Value", ds, "customers.CustToOrders.OrderDate"))

      ' Add event delegates for the Parse and Format events to a 
      '   new Binding object, and add the object to the third 
      '   TextBox control's BindingsCollection. The delegates 
      '   must be added before adding the Binding to the 
      '   collection; otherwise, no formatting occurs until 
      '   the Current object of the BindingManagerBase for 
      '   the data source changes.
      Dim b As Binding = New Binding _
         ("Text", ds, "customers.custToOrders.OrderAmount")
      AddHandler b.Parse,  New ConvertEventHandler(AddressOf CurrencyStringToDecimal)      
      AddHandler b.Format, New ConvertEventHandler(AddressOf DecimalToCurrencyString)
      text3.DataBindings.Add(b)

      ' Get the BindingManagerBase for the Customers table.
      bmCustomers = Me.BindingContext(ds, "Customers")

      ' Get the BindingManagerBase for the Orders table using the 
      '   RelationName.
      bmOrders = Me.BindingContext(ds, "customers.CustToOrders")

      ' Bind the fourth TextBox control's Text property to the
      ' third control's Text property.
      text4.DataBindings.Add("Text", text3, "Text")

   End Sub

' </Snippet1>


    Private Sub CurrencyStringToDecimal(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        ' does nothing
    End Sub

    Private Sub DecimalToCurrencyString(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        ' does nothing
    End Sub

End Class
