Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected myCurrencyManager As CurrencyManager
    
    ' <Snippet1>
    Private Sub BindControl(myTable As DataTable)
        ' Bind A TextBox control to a DataTable column in a DataSet.
        textBox1.DataBindings.Add("Text", myTable, "CompanyName")
        ' Specify the CurrencyManager for the DataTable.
        myCurrencyManager = CType(Me.BindingContext(myTable, ""), CurrencyManager)
        ' Add event handlers.
        AddHandler myCurrencyManager.ItemChanged, AddressOf CurrencyManager_ItemChanged
        AddHandler myCurrencyManager.PositionChanged, AddressOf CurrencyManager_PositionChanged
        ' Set the initial Position of the control.
        myCurrencyManager.Position = 0
    End Sub 'BindControl
    
    
    Private Sub CurrencyManager_PositionChanged(sender As Object, e As System.EventArgs)
        Dim myCurrencyManager As CurrencyManager = CType(sender, CurrencyManager)
        Console.WriteLine(("Position Changed " & myCurrencyManager.Position))
    End Sub 'CurrencyManager_PositionChanged
    
    
    Private Sub CurrencyManager_ItemChanged(sender As Object, e As System.Windows.Forms.ItemChangedEventArgs)
        Dim myCurrencyManager As CurrencyManager = CType(sender, CurrencyManager)
        Console.WriteLine(("Item Changed " & myCurrencyManager.Position))
    End Sub 'CurrencyManager_ItemChanged
    ' </Snippet1>
End Class 'Form1 
