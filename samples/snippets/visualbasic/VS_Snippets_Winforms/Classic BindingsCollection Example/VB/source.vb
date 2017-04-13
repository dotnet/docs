Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Globalization
Public Class Form1
    Inherits Form
    Protected text1 As TextBox
    
' <Snippet1>
Private Sub BindTextBoxControl()
   Dim myDataSet As New DataSet()
   ' Insert code to populate the DataSet with tables, columns, and data.

   ' Creates a new Binding object. 
   Dim myBinding As New Binding("Text", myDataSet, _
   "customers.custToOrders.OrderAmount")
   
   ' Adds event delegates for the Parse and Format events.
   AddHandler myBinding.Parse, AddressOf CurrencyToDecimal
   AddHandler myBinding.Format, AddressOf DecimalToCurrency
     
   ' Adds the new Binding to the BindingsCollection.
   text1.DataBindings.Add(myBinding)
End Sub 
    
Private Sub DecimalToCurrency(sender As Object, _
   cevent As ConvertEventArgs)
   ' This method is the Format event handler. Whenever the
   ' control displays a new value, the value is converted from
   ' its native Decimal type to a string. The ToString method
   ' then formats the value as a Currency, by using the
   ' formatting character "c". 
   cevent.Value = CDec(cevent.Value).ToString("c")
End Sub 
    
Private Sub CurrencyToDecimal(sender As Object, _
cevent As ConvertEventArgs)
   ' This method is the Parse event handler. The Parse event
   ' occurs whenever the displayed value changes. The static
   ' Parse method of the Decimal structure converts the 
   ' string back to its native Decimal type. 
   cevent.Value = Decimal.Parse(cevent.Value.ToString(), _
   NumberStyles.Currency, nothing)
   End Sub 
    ' </Snippet1>
End Class 'Form1
