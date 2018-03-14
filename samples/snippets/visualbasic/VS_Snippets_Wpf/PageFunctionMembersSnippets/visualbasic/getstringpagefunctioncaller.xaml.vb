Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Navigation

Namespace VisualBasic
    Partial Public Class GetStringPageFunctionCaller
        Inherits Page
        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetHandlePageFunctionReturnCODE>
        Private Sub callPageFunctionButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Create page function object
            Dim pageFunction As New GetStringPageFunction()

            ' Detect when page function returns
            AddHandler pageFunction.Return, AddressOf PageFunction_Return

            ' Call page function
            Me.NavigationService.Navigate(pageFunction)
        End Sub

        Private Sub PageFunction_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of String))
            ' Retrieve page function return value
            Dim returnValue As String = e.Result
        End Sub
        '</SnippetHandlePageFunctionReturnCODE>
    End Class
End Namespace