'<SnippetWindowMenuItemCODE>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    ' Custom menu item that stores a reference to a window
    Public Class WindowMenuItem
        Inherits MenuItem
        Public Window As Window = Nothing
    End Class
End Namespace
'</SnippetWindowMenuItemCODE>