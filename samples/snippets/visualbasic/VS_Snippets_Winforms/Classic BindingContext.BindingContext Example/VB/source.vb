Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected groupBox1 As GroupBox
    Protected groupBox2 As GroupBox
    Protected textBox1 As TextBox
    Protected textBox2 As TextBox
    Protected WithEvents Button1 As Button
    Protected WithEvents Button2 As Button
    
    Protected ds As DataSet    
    
' <Snippet1>
 Private Sub BindControls()
     Dim bcG1 As New BindingContext()
     Dim bcG2 As New BindingContext()
        
     groupBox1.BindingContext = bcG1
     groupBox2.BindingContext = bcG2
        
     textBox1.DataBindings.Add("Text", ds, "Customers.CustName")
     textBox2.DataBindings.Add("Text", ds, "Customers.CustName")
 End Sub    
    
 Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
     groupBox1.BindingContext(ds, "Customers").Position += 1
 End Sub    
    
 Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
     groupBox2.BindingContext(ds, "Customers").Position += 1
 End Sub

' </Snippet1>
End Class
