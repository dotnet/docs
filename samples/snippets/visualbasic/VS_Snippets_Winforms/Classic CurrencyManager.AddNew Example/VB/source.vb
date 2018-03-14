Option Strict
Option Explicit

Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected DataTable1 As DataTable
    
    ' <Snippet1>
    Private Sub AddListItem()
        ' Get the CurrencyManager for a DataTable.
        Dim myCurrencyManager As CurrencyManager = _ 
            CType(Me.BindingContext(DataTable1), CurrencyManager)
        myCurrencyManager.AddNew()
    End Sub 'AddListItem
    ' </Snippet1>
End Class 'Form1 
