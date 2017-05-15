' <Snippet6>

Imports Microsoft.VisualBasic
Imports System.AddIn.Pipeline
Namespace LibraryContractsHostAdapters
Public Class BookInfoViewToContractHostAdapter
    Inherits ContractBase
    Implements Library.IBookInfoContract
    Private _view As LibraryContractsHAV.BookInfo

    Public Sub New(ByVal view As LibraryContractsHAV.BookInfo)
        _view = view
    End Sub

    Public Overridable Function ID() As String Implements Library.IBookInfoContract.ID
        Return _view.ID()
    End Function
    Public Overridable Function Author() As String Implements Library.IBookInfoContract.Author
        Return _view.Author()
    End Function
    Public Overridable Function Title() As String Implements Library.IBookInfoContract.Title
        Return _view.Title()
    End Function
    Public Overridable Function Genre() As String Implements Library.IBookInfoContract.Genre
        Return _view.Genre()
    End Function
    Public Overridable Function Price() As String Implements Library.IBookInfoContract.Price
        Return _view.Price()
    End Function
    Public Overridable Function Publish_Date() As String Implements Library.IBookInfoContract.Publish_Date
        Return _view.Publish_Date()
    End Function
    Public Overridable Function Description() As String Implements Library.IBookInfoContract.Description
        Return _view.Description()
    End Function
    Friend Function GetSourceView() As LibraryContractsHAV.BookInfo
        Return _view
    End Function
End Class
End Namespace
' </Snippet6>