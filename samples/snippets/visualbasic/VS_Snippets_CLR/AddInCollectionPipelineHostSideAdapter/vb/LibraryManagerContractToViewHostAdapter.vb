' <Snippet1>

Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.AddIn.Pipeline
Namespace LibraryContractsHostAdapters
    ' <Snippet2>
    <HostAdapterAttribute()> _
    Public Class LibraryManagerContractToViewHostAdapter
        Inherits LibraryContractsHAV.LibraryManager
    ' </Snippet2>

        ' <Snippet3>
        Private _contract As Library.ILibraryManagerContract
        Private _handle As System.AddIn.Pipeline.ContractHandle

        Public Sub New(ByVal contract As Library.ILibraryManagerContract)
            _contract = contract
            _handle = New System.AddIn.Pipeline.ContractHandle(contract)
        End Sub
        ' </Snippet3>

        ' <Snippet4>
        Public Overrides Sub ProcessBooks(ByVal books As IList(Of LibraryContractsHAV.BookInfo))
            _contract.ProcessBooks(CollectionAdapters.ToIListContract(Of LibraryContractsHAV.BookInfo, _
            Library.IBookInfoContract)(books, _
            AddressOf LibraryContractsHostAdapters.BookInfoHostAdapter.ViewToContractAdapter, _
            AddressOf LibraryContractsHostAdapters.BookInfoHostAdapter.ContractToViewAdapter))
        End Sub
        ' </Snippet4>

        Public Overrides Function GetBestSeller() As LibraryContractsHAV.BookInfo
            Return BookInfoHostAdapter.ContractToViewAdapter(_contract.GetBestSeller())
        End Function

        Friend Function GetSourceContract() As Library.ILibraryManagerContract
            Return _contract
        End Function
        Public Overrides Function Data(ByVal txt As String) As String
            Dim rtxt As String = _contract.Data(txt)
            Return rtxt
        End Function
    End Class
End Namespace
' </Snippet1>
