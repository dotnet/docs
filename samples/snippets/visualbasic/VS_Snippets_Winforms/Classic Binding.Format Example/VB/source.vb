Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Globalization
Imports System.Windows.Forms

Public Class Form1
   Inherits Form

   Protected text1 As TextBox
   Protected ds As DataSet
   ' <Snippet1>
   Private Sub DecimalToCurrencyString(sender As Object, cevent As _
   ConvertEventArgs)
      ' The method converts only to string type. Test this using the DesiredType.
      If cevent.DesiredType IsNot GetType(String) Then
         Exit Sub
      End If

      ' Use the ToString method to format the value as currency ("c").
      cevent.Value = CType(cevent.Value, Decimal).ToString("c")
   End Sub

   Private Sub CurrencyStringToDecimal(sender As Object, cevent As _
   ConvertEventArgs)
      ' The method converts back to decimal type only.
      If cevent.DesiredType IsNot GetType(Decimal) Then
         Exit Sub
      End If

      ' Converts the string back to decimal using the static ToDecimal method.
      cevent.Value = Decimal.Parse(cevent.Value.ToString, _
      NumberStyles.Currency, nothing)
   End Sub
   
   Private Sub BindControl
      ' Creates the binding first. The OrderAmount is a Decimal type.
      Dim b As Binding = New Binding _
         ("Text", ds, "customers.custToOrders.OrderAmount")
      ' Add the delegates to the event
      AddHandler b.Format, AddressOf DecimalToCurrencyString
      AddHandler b.Parse, AddressOf CurrencyStringToDecimal
      text1.DataBindings.Add(b)
   End Sub
   ' </Snippet1>
End Class
