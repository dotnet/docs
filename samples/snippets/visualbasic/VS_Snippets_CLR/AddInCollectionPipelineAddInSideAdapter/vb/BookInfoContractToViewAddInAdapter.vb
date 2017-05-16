' <Snippet4>

Imports Microsoft.VisualBasic
Imports System
Imports System.AddIn.Pipeline
Namespace LibraryContractsAddInAdapters

Public Class BookInfoContractToViewAddInAdapter
    Inherits LibraryContractsBase.BookInfo
    Private _contract As Library.IBookInfoContract
    Private _handle As System.AddIn.Pipeline.ContractHandle
    Public Sub New(ByVal contract As Library.IBookInfoContract)
        _contract = contract
        _handle = New ContractHandle(contract)
    End Sub

    Public Overrides Function ID() As String
        Return _contract.ID()
    End Function
    Public Overrides Function Author() As String
        Return _contract.Author()
    End Function
    Public Overrides Function Title() As String
        Return _contract.Title()
    End Function
    Public Overrides Function Genre() As String
        Return _contract.Genre()
    End Function
    Public Overrides Function Price() As String
        Return _contract.Price()
    End Function
    Public Overrides Function Publish_Date() As String
        Return _contract.Publish_Date()
    End Function
    Public Overrides Function Description() As String
        Return _contract.Description()
    End Function

    Friend Function GetSourceContract() As Library.IBookInfoContract
        Return _contract
    End Function
End Class
End Namespace
' </Snippet4>
