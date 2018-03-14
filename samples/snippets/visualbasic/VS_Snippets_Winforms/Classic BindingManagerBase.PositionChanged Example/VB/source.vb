Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected text1 As TextBox
    Protected ds As DataSet
    
    ' <Snippet1>
    Protected Sub BindControl()
        ' Create a Binding object for the TextBox control.
        ' The data-bound property for the control is the Text
        ' property. 
        Dim myBinding As New Binding("Text", ds, "customers.custName")
        
        text1.DataBindings.Add(myBinding)
        
        ' Get the BindingManagerBase for the Customers table. 
        Dim bmCustomers As BindingManagerBase = Me.BindingContext(ds, "Customers")
        
        ' Add the delegate for the PositionChanged event.
        AddHandler bmCustomers.PositionChanged, AddressOf Position_Changed
    End Sub 'BindControl
    
    
    Private Sub Position_Changed(sender As Object, e As EventArgs)
        ' Print the Position property value when it changes.
        Console.WriteLine(CType(sender, BindingManagerBase).Position)
    End Sub 'Position_Changed
    ' </Snippet1>
End Class 'Form1 
