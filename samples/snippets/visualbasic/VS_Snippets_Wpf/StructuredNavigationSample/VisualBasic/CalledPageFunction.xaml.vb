'<SnippetCalledPageFunctionCODEBEHIND1>
'<SnippetAcceptsInitialDataCODEBEHIND1>
'<SnippetReturnCODEBEHIND1>
Imports System.Windows
Imports System.Windows.Navigation

Namespace StructuredNavigationSample

Public Class CalledPageFunction
    Inherits PageFunction(Of String)
    '</SnippetReturnCODEBEHIND1>
    '</SnippetAcceptsInitialDataCODEBEHIND1>
    Public Sub New()
        Me.InitializeComponent()
    End Sub
    '<SnippetAcceptsInitialDataCODEBEHIND2>
    '</SnippetCalledPageFunctionCODEBEHIND1>
    Public Sub New(ByVal initialDataItem1Value As String)
        Me.InitializeComponent()
        '</SnippetAcceptsInitialDataCODEBEHIND2>
        AddHandler Me.okButton.Click, New RoutedEventHandler(AddressOf Me.okButton_Click)
        AddHandler Me.cancelButton.Click, New RoutedEventHandler(AddressOf Me.cancelButton_Click)
        '<SnippetAcceptsInitialDataCODEBEHIND3>
        ' Set initial value
        Me.dataItem1TextBox.Text = initialDataItem1Value
    End Sub
    '<SnippetReturnCODEBEHIND2>
    '</SnippetAcceptsInitialDataCODEBEHIND3>
    Private Sub okButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Accept when Ok button is clicked
        Me.OnReturn(New ReturnEventArgs(Of String)(Me.dataItem1TextBox.Text))
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Cancel
        Me.OnReturn(Nothing)
    End Sub
    '<SnippetAcceptsInitialDataCODEBEHIND4>
    '<SnippetCalledPageFunctionCODEBEHIND2>
End Class

End Namespace
'</SnippetReturnCODEBEHIND2>
'</SnippetAcceptsInitialDataCODEBEHIND4>
'</SnippetCalledPageFunctionCODEBEHIND2>