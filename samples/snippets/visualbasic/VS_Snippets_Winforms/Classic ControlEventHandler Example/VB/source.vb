Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected text1 As TextBox
    Protected ds As DataSet
    
    ' <Snippet1>
    Private Sub BindControl()
        ' Create the binding first. The OrderAmount is typed as Decimal.
        Dim b As New Binding("Text", ds, "customers.custToOrders.OrderAmount")
        ' Add the delegates to the events.
        AddHandler b.Format, AddressOf DecimalToCurrencyString
        AddHandler b.Parse, AddressOf CurrencyStringToDecimal
        text1.DataBindings.Add(b)
    End Sub 'BindControl
    
    
    Private Sub DecimalToCurrencyString(sender As Object, cevent As ConvertEventArgs)
        ' Check for the appropriate DesiredType.
        If cevent.DesiredType IsNot GetType(String) Then
            Return
        End If 
        ' Use the ToString method to format the value as currency ("c").
        cevent.Value = CDec(cevent.Value).ToString("c")
    End Sub 'DecimalToCurrencyString
    
    
    Private Sub CurrencyStringToDecimal(sender As Object, cevent As ConvertEventArgs)
        ' Check for the appropriate DesiredType. 
        If cevent.DesiredType IsNot GetType(Decimal) Then
            Return
        End If 
        ' Convert the string back to decimal using the static Parse method.
      cevent.Value = Decimal.Parse(cevent.Value.ToString, _
      NumberStyles.Currency, nothing)

    End Sub 'CurrencyStringToDecimal
    ' </Snippet1>
End Class 'Form1 

