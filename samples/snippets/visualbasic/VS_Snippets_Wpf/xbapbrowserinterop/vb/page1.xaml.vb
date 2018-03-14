Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Interop

Namespace WpfBrowserApplication1VB
    ''' <summary>
    ''' Interaction logic for Page  xaml
    ''' </summary>
    Partial Public Class Page1
        Inherits Page
        Public Sub New()
            InitializeComponent()
        End Sub
        '<snippet10>
        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Retrieve the script object  The XBAP must be hosted in a frame or
            ' the HostScript object will be null.
            Dim scriptObject = BrowserInteropHelper.HostScript

            ' Call close to close the browser window.
            scriptObject.Close()
        End Sub
        '</snippet10>

    End Class
End Namespace
