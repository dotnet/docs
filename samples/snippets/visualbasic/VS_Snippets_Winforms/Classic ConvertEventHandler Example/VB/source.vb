Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected text1 As TextBox
    Protected ds As DataSet
    
    ' <Snippet1>
    Private Sub DecimalToCurrency(sender As Object, cevent As ConvertEventArgs)
        ' The method converts only to string type. Test this using the DesiredType.
        If cevent.DesiredType IsNot GetType(String) Then
            Return
        End If 
        ' Use the ToString method to format the value as currency ("c").
        cevent.Value = CDec(cevent.Value).ToString("c")
    End Sub 
    
    
    Private Sub CurrencyToDecimal(sender As Object, cevent As ConvertEventArgs)
        ' The method converts only to decimal type. 
        If cevent.DesiredType IsNot GetType(Decimal) Then
            Return
        End If 
        ' Converts the string back to decimal using the static ToDecimal method.
        cevent.Value = Convert.ToDecimal(cevent.Value.ToString())
    End Sub 
    
    
    Private Sub BindControl()
        ' Creates the binding first. The OrderAmount is typed as Decimal.
        Dim b As New Binding("Text", ds, "customers.custToOrders.OrderAmount")
        ' Adds the delegates to the events.
        AddHandler b.Format, AddressOf DecimalToCurrency
        AddHandler b.Parse, AddressOf CurrencyToDecimal
        text1.DataBindings.Add(b)
    End Sub 
    ' </Snippet1>
End Class 'Form1 

