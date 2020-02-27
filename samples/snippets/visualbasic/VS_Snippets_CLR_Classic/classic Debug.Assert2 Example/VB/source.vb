Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Public Shared Sub MyMethod(type As Type, baseType As Type)
        Debug.Assert( Not (type Is Nothing), "Type parameter is null", "Can't get object for null type")
        ' Perform some processing.
    End Sub
    ' </Snippet1>
End Class

