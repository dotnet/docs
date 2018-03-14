Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
 <MergableProperty(True)> _    
 Public Property MyProperty() As Integer
     Get
         ' Insert code here.
         Return 0
     End Get
     Set
         ' Insert code here.
     End Set 
 End Property

' </Snippet1>
End Class


