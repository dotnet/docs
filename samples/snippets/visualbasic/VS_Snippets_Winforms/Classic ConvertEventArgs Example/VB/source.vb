Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows.Forms
Public Class Form1
   Inherits Form
   Protected text1 As TextBox
   Protected ds As DataSet
    
   ' <Snippet1>
   Private Sub DecimalToCurrencyString(sender As Object, cevent As ConvertEventArgs)
      ' The method converts only to string type. Test this using the DesiredType.
      If Not cevent.DesiredType Is GetType(String) Then
         Return
      End If 
      ' Use the ToString method to format the value as currency ("c").
      cevent.Value = CDec(cevent.Value).ToString("c")
   End Sub 'DecimalToCurrencyString
    
    
   Private Sub CurrencyStringToDecimal(sender As Object, cevent As ConvertEventArgs)
      ' The method converts back to decimal type only. 
      If Not cevent.DesiredType Is GetType(Decimal) Then
         Return
      End If 
      ' Converts the string back to decimal using the shared Parse method.
      cevent.Value = Decimal.Parse(cevent.Value.ToString, _
      NumberStyles.Currency, nothing)

   End Sub 'CurrencyStringToDecimal
    
    
   Private Sub BindControl()
      ' Creates the binding first. The OrderAmount is typed as Decimal.
      Dim b As New Binding("Text", ds, "customers.custToOrders.OrderAmount")
      ' Adds the delegates to the events.
      AddHandler b.Format, AddressOf DecimalToCurrencyString
      AddHandler b.Parse, AddressOf CurrencyStringToDecimal
      text1.DataBindings.Add(b)
   End Sub 'BindControl
    ' </Snippet1>
End Class 'Form1 

