Imports System
Imports System.Windows

Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging

Imports System.IO
Imports System.Windows.Resources

Namespace SDKSample
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
            '<SnippetSetWindowIconInCode>
            ' Set an icon using code
            Dim iconUri As New Uri("pack://application:,,,/WPFIcon2.ico", UriKind.RelativeOrAbsolute)
            Me.Icon = BitmapFrame.Create(iconUri)
            '</SnippetSetWindowIconInCode>
        End Sub

    End Class
End Namespace