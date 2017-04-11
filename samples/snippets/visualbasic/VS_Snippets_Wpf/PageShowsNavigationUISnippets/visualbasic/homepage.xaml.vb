'<SnippetSetPageShowsNavigationUICODEBEHIND>

Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class HomePage
        Inherits Page
        Public Sub New()
            InitializeComponent()

            ' Hide host's navigation UI
            Me.ShowsNavigationUI = False
        End Sub
    End Class
End Namespace
'</SnippetSetPageShowsNavigationUICODEBEHIND>