'<SnippetMainWindowGetPropertyCODEBEHIND>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As EventArgs)
            ' Check for safe mode
            If CBool(Application.Current.Properties("SafeMode")) = True Then
                Me.Title &= " [SafeMode]"
            End If
        End Sub
    End Class
End Namespace
'</SnippetMainWindowGetPropertyCODEBEHIND>