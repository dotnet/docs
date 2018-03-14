' <Snippet6>

Imports Microsoft.VisualBasic
Imports System
Namespace LibraryContractsAddInAdapters

Public Class BookInfoAddInAdapter
  Friend Shared Function ContractToViewAdapter(ByVal contract As Library.IBookInfoContract) As LibraryContractsBase.BookInfo
    If (Not System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(contract)) AndAlso _
        CType(contract, Object).GetType().Equals(GetType(BookInfoViewToContractAddInAdapter)) Then
        Return (CType(contract, BookInfoViewToContractAddInAdapter)).GetSourceView()
    Else
        Return New BookInfoContractToViewAddInAdapter(contract)
    End If

  End Function

Friend Shared Function ViewToContractAdapter(ByVal view As LibraryContractsBase.BookInfo) As Library.IBookInfoContract
    If (Not System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(view)) AndAlso _
        view.GetType().Equals(GetType(BookInfoContractToViewAddInAdapter)) Then
        Return (CType(view, BookInfoContractToViewAddInAdapter)).GetSourceContract()
    Else
        Return New BookInfoViewToContractAddInAdapter(view)
    End If
End Function
End Class
End Namespace
' </Snippet6>
