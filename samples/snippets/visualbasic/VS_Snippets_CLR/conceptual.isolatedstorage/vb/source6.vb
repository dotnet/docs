'<snippet7>
Imports System.IO.IsolatedStorage

Public Class ObtainingAStore
    Public Shared Sub Main()
        ' Get a new isolated store for this assembly and put it into an
        ' isolated store object.

        Dim isoStore As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or
            IsolatedStorageScope.Assembly, Nothing, Nothing)
    End Sub
End Class
'</snippet7>

Public Class ObtainingAStoreWithDomain
    Public Shared Sub Dummy()
        '<snippet6>
        Dim isoStore As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or
            IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)
        '</snippet6>
    End Sub
End Class
