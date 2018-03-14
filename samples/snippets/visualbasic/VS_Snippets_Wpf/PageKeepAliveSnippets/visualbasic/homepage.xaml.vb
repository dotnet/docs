'<SnippetSetPageKeepAliveCODEBEHIND>

Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class HomePage
        Inherits Page
        Public Sub New()
            InitializeComponent()

            ' Keep this page in navigation history
            Me.KeepAlive = True
        End Sub

    End Class
End Namespace
'</SnippetSetPageKeepAliveCODEBEHIND>