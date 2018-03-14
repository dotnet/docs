Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input

' Interaction logic for Window1.xaml
Namespace WCSamples
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
        '<SnippetKeyDownSample>
        Private Sub OnKeyDownHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
            If (e.Key = Key.Return) Then
                textBlock1.Text = "You Entered: " + textBox1.Text
            End If
        End Sub
        '</SnippetKeyDownSample>

    End Class
End Namespace

