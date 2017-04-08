imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1

 Protected Text1 As TextBox
 Protected Label1 As Label
' <Snippet1>

 Private Sub BindControl()
    Dim ds As DataSet
    ' Not shown: code to populate DataSet with tables.
    Text1.DataBindings.Add("Text", ds.Tables("Products"), "ProductName")
    Label1.DataBindings.Add("Text", ds.Tables("Suppliers"), "CompanyName")
    
 End Sub
       
' </Snippet1>
End Class
