 '<snippet1>
'<snippet2>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
'</snippet2>

'<snippet3>
Public Class Form1
    Inherits Form
    '</snippet3>

    '<snippet4>
    Public Sub New()

    End Sub 'New
    '</snippet4>  
    '<snippet5>
    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub
End Class
'</snippet5>
'</snippet1>