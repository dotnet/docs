Imports System
Imports System.Windows.Forms
Imports System.Data



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub PrintListItems()
        ' Get the CurrencyManager of a TextBox control.
        Dim myCurrencyManager As CurrencyManager = CType(textBox1.BindingContext(0), CurrencyManager)
        ' Presuming the list is a DataView, create a DataRowView variable.
        Dim drv As DataRowView
        Dim i As Integer
        For i = 0 To myCurrencyManager.Count - 1
            myCurrencyManager.Position = i
            drv = CType(myCurrencyManager.Current, DataRowView)
            ' Presuming a column named CompanyName exists.
            Console.WriteLine(drv("CompanyName"))
        Next i
    End Sub 'PrintListItems
    ' </Snippet1>
End Class 'Form1 

