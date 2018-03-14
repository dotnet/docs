' <Snippet1>

Imports Microsoft.VisualBasic
Imports System.AddIn.Pipeline
Imports System.AddIn.Contract
Imports System.Collections.Generic
Namespace LibraryContractsAddInAdapters
'<Snippet2>
' The AddInAdapterAttribute
' identifes this pipeline
' segment as an add-in-side adapter.
<AddInAdapter> _
Public Class LibraryManagerViewToContractAddInAdapter
	Inherits System.AddIn.Pipeline.ContractBase
	Implements Library.ILibraryManagerContract
'</Snippet2>
	Private _view As LibraryContractsBase.LibraryManager
	Public Sub New(ByVal view As LibraryContractsBase.LibraryManager)
		_view = view
	End Sub
	' <Snippet3>
	Public Overridable Sub ProcessBooks(ByVal books As IListContract(Of Library.IBookInfoContract)) Implements Library.ILibraryManagerContract.ProcessBooks
		_view.ProcessBooks(CollectionAdapters.ToIList(Of Library.IBookInfoContract, _
		LibraryContractsBase.BookInfo)(books, _
		AddressOf LibraryContractsAddInAdapters.BookInfoAddInAdapter.ContractToViewAdapter, _
		AddressOf LibraryContractsAddInAdapters.BookInfoAddInAdapter.ViewToContractAdapter))
	End Sub
	' </Snippet3>
	Public Overridable Function GetBestSeller() As Library.IBookInfoContract Implements Library.ILibraryManagerContract.GetBestSeller
		Return BookInfoAddInAdapter.ViewToContractAdapter(_view.GetBestSeller())
	End Function

	Public Overridable Function Data(ByVal txt As String) As String Implements Library.ILibraryManagerContract.Data
		Dim rtxt As String = _view.Data(txt)
		Return rtxt
	End Function

	Friend Function GetSourceView() As LibraryContractsBase.LibraryManager
		Return _view
	End Function
End Class
End Namespace
'</Snippet1>