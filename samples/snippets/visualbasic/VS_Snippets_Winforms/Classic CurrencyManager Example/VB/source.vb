Option Explicit
Option Strict

imports System
imports System.Data
imports System.Windows.Forms

Public Class Form1
Inherits Form
    
Protected textBox1 As TextBox
' <Snippet1>
' Place the next line into the Declarations section of the form.
 Private myCurrencyManager As CurrencyManager
 
 Private Sub BindControl(myTable As DataTable)
    ' Bind a TextBox control to a DataTable column in a DataSet.
    TextBox1.DataBindings.Add("Text", myTable, "CompanyName")
    ' Specify the CurrencyManager for the DataTable.
    myCurrencyManager = CType(me.BindingContext(myTable), CurrencyManager)
    ' Set the initial Position of the control.
    myCurrencyManager.Position = 0
 End Sub
 
 Private Sub MoveNext(myCurrencyManager As CurrencyManager)
    If myCurrencyManager.Position = myCurrencyManager.Count - 1 Then 
       MessageBox.Show("You're at end of the records")
    Else
       myCurrencyManager.Position += 1
    End If
 End Sub
 
 Private Sub MoveFirst(myCurrencyManager As CurrencyManager)
    myCurrencyManager.Position = 0
 End Sub
 
 Private Sub MovePrevious(myCurrencyManager As CurrencyManager)
    If myCurrencyManager.Position = 0 Then
       MessageBox.Show("You're at the beginning of the records.")
    Else
       myCurrencyManager.Position -= 1
    End if
 End Sub
 
 Private Sub MoveLast(myCurrencyManager As CurrencyManager)
    myCurrencyManager.Position = myCurrencyManager.Count - 1
 End Sub

' </Snippet1>
End Class
