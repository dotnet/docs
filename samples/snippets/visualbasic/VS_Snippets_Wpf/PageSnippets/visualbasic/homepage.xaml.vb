'<SnippetSetPageWindowXxxCODEBEHIND>

Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class HomePage
        Inherits Page
        Public Sub New()
            InitializeComponent()

            Me.WindowTitle = "Hello, Page!"
            Me.WindowWidth = 500
            Me.WindowHeight = 300
        End Sub

    End Class
End Namespace
'</SnippetSetPageWindowXxxCODEBEHIND>