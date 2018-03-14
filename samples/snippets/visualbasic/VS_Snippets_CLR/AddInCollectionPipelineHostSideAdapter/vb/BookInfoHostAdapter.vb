' <Snippet7>

Imports Microsoft.VisualBasic
Imports System
Namespace LibraryContractsHostAdapters
Public Class BookInfoHostAdapter

Friend Shared Function ContractToViewAdapter(ByVal contract As Library.IBookInfoContract) As LibraryContractsHAV.BookInfo
    If Not System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(contract) AndAlso _
        CType(contract, Object).GetType().Equals(GetType(BookInfoViewToContractHostAdapter)) Then
        Return (CType(contract, BookInfoViewToContractHostAdapter)).GetSourceView()
    Else
        Return New BookInfoContractToViewHostAdapter(contract)
    End If
End Function

Friend Shared Function ViewToContractAdapter(ByVal view As LibraryContractsHAV.BookInfo) As Library.IBookInfoContract
    If Not System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(view) AndAlso _
        view.GetType().Equals(GetType(BookInfoContractToViewHostAdapter)) Then
        Return (CType(view, BookInfoContractToViewHostAdapter)).GetSourceContract()
    Else
        Return New BookInfoViewToContractHostAdapter(view)
    End If
End Function
End Class
End Namespace
' </Snippet7>
