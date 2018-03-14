Imports System
Imports System.Data
Imports System.Windows.Forms


Public Class Form1
    Inherits Form
    
    Protected textBox1 As TextBox
    Protected ds As DataSet    
    
' <Snippet1>
 Protected Sub BindControls()
     ' Create a new Binding using the DataSet and a 
     ' navigation path(TableName.RelationName.ColumnName).
     ' Add event delegates for the Parse and Format events to 
     ' the Binding object, and add the object to the third 
     ' TextBox control's BindingsCollection. The delegates 
     ' must be added before adding the Binding to the 
     ' collection; otherwise, no formatting occurs until 
     ' the Current object of the BindingManagerBase for 
     ' the data source changes. 
     Dim b As New Binding("Text", ds, "customers.custToOrders.OrderAmount")
     AddHandler b.Parse, AddressOf CurrencyStringToDecimal
     AddHandler b.Format, AddressOf DecimalToCurrencyString
     textBox1.DataBindings.Add(b)
 End Sub    
' </Snippet1>

    ' method added so sample will compile
    Private Sub CurrencyStringToDecimal(sender As Object, e As ConvertEventArgs)
    End Sub 'CurrencyStringToDecimal
     
    ' method added so sample will compile
    Private Sub DecimalToCurrencyString(sender As Object, e As ConvertEventArgs)
    End Sub 'DecimalToCurrencyString 
End Class 'Form1
