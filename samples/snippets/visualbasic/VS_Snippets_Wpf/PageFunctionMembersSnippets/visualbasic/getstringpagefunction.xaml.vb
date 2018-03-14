Imports System
Imports System.Windows
Imports System.Windows.Navigation

Namespace VisualBasic
    Partial Public Class GetStringPageFunction
        Inherits PageFunction(Of String)
        Public Sub New()
            InitializeComponent()

            ' Retain this PageFunction in navigation history
            ' after it has returned
            Me.RemoveFromJournal = False
        End Sub

        ' Only called the first time a PageFunction is navigated to
        Protected Overrides Sub Start()
            MyBase.Start()

            ' Perform first time initialization
        End Sub

        '<SnippetCallOnReturnCODE>
        Private Sub doneButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Complete the page function and return data of type T
            OnReturn(New ReturnEventArgs(Of String)(Me.pageFunctionData.Text))
        End Sub
        '</SnippetCallOnReturnCODE>
    End Class
End Namespace