' <SnippetCallingPageDefaultCODEBEHIND1>
' <SnippetPassingDataCODEBEHIND1>
' <SnippetSendDataCODEBEHIND1>
' <SnippetProcessResultCODEBEHIND1>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Navigation

Namespace StructuredNavigationSample

Public Class CallingPage
    Inherits Page
    ' </SnippetProcessResultCODEBEHIND1>
    Public Sub New()
        Me.InitializeComponent()
        ' </SnippetCallingPageDefaultCODEBEHIND1>
        AddHandler Me.pageFunctionHyperlink.Click, New RoutedEventHandler(AddressOf Me.pageFunctionHyperlink_Click)
        ' <SnippetCallingPageDefaultCODEBEHIND2>
    End Sub
    ' <SnippetProcessResultCODEBEHIND2>
    ' </SnippetCallingPageDefaultCODEBEHIND2>
    Private Sub pageFunctionHyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' </SnippetPassingDataCODEBEHIND1>
        ' Instantiate and navigate to page function
        Dim calledPageFunction As New CalledPageFunction("Initial Data Item Value")
        ' </SnippetSendDataCODEBEHIND1>
        AddHandler calledPageFunction.Return, New ReturnEventHandler(Of String)(AddressOf Me.calledPageFunction_Return)
        ' <SnippetSendDataCODEBEHIND2>
        MyBase.NavigationService.Navigate(calledPageFunction)
        ' <SnippetPassingDataCODEBEHIND2>
    End Sub
    ' </SnippetSendDataCODEBEHIND2>
    ' </SnippetPassingDataCODEBEHIND2>
    Private Sub calledPageFunction_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of String))

        Me.pageFunctionResultsTextBlock.Visibility = Windows.Visibility.Visible

        ' Display result
        Me.pageFunctionResultsTextBlock.Text = IIf((Not e Is Nothing), "Accepted", "Canceled")

        ' If page function returned, display result and data
        If (Not e Is Nothing) Then
            Me.pageFunctionResultsTextBlock.Text = (Me.pageFunctionResultsTextBlock.Text & ChrW(10) & e.Result)
        End If

    End Sub
    ' <SnippetSendDataCODEBEHIND3>
    ' <SnippetPassingDataCODEBEHIND3>
    ' <SnippetCallingPageDefaultCODEBEHIND3>
End Class

End Namespace
' </SnippetProcessResultCODEBEHIND2>
' </SnippetSendDataCODEBEHIND3>
' </SnippetPassingDataCODEBEHIND3>
' </SnippetCallingPageDefaultCODEBEHIND3>