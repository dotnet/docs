Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Windows.Forms



Public Class Form1
    Inherits Form

    '<Snippet1>
    Private Sub Current_Changed(sender As Object, e As EventArgs)
        Dim bm As BindingManagerBase = CType(sender, BindingManagerBase)
        ' Check the type of the Current object. If it is not a
        ' DataRowView, exit the method. 
        If bm.Current.GetType() IsNot GetType(DataRowView) Then
            Return
        End If 
        ' Otherwise, print the value of the column named "CustName".
        Dim drv As DataRowView = CType(bm.Current, DataRowView)
        Console.Write("CurrentChanged): ")
        Console.Write(drv("CustName"))
        Console.WriteLine()
    End Sub 'Current_Changed
    '</Snippet1>
End Class 'Form1 ' 