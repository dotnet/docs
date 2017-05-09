
Imports System
Imports System.Data
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected text1 As TextBox
    Protected ds As DataSet
    
    ' <Snippet1>
    Private Sub PrintBoundControls()
        Dim myBindingBase As BindingManagerBase = Me.BindingContext(ds, "customers")
        Dim b As Binding
        For Each b In  myBindingBase.Bindings
            Console.WriteLine(b.Control.ToString())
        Next b
    End Sub 'PrintBoundControls
    ' </Snippet1>
End Class 'Form1 
