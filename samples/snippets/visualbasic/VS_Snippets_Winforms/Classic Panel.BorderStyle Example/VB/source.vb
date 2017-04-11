Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
 Public Sub CreateMyPanel()
     Dim panel1 As New Panel()
        
     ' Initialize the Panel control.
     panel1.Location = New Point(56, 72)
     panel1.Size = New Size(264, 152)
     ' Set the Borderstyle for the Panel to three-dimensional.
     panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
 End Sub

' </Snippet1>
End Class

