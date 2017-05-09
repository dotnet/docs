Imports System
Imports System.IO
Imports System.IO.IsolatedStorage

Public Class IsoFileGetStoreSample
    Public Shared Sub Main()
        Dim isoFile As IsolatedStorageFile

        ' remarks for GetMachineStoreForApplication()
        '<Snippet18>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Application Or _
            IsolatedStorageScope.Machine,  Nothing)
        '</Snippet18>
        isoFile.Close()

        ' remarks for GetMachineStoreForAssembly()
        '<Snippet19>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly Or _
            IsolatedStorageScope.Machine, Nothing, Nothing)
        '</Snippet19>
        isoFile.Close()

        ' remarks for GetMachineStoreForDomain()
        '<Snippet20>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly Or _
            IsolatedStorageScope.Domain Or IsolatedStorageScope.Machine, _
            Nothing, Nothing)
        '</Snippet20>
        isoFile.Close()

        ' remarks for GetUserStoreForApplication()
        '<Snippet21>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Application Or _
            IsolatedStorageScope.User, Nothing)
        '</Snippet21>
        isoFile.Close()

        ' remarks for GetUserStoreForAssembly()
        '<Snippet22>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly Or _
            IsolatedStorageScope.User, Nothing, Nothing)
        '</Snippet22>
        isoFile.Close()

        ' remarks for GetUserStoreForDomain()
        '<Snippet23>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly Or _
            IsolatedStorageScope.Domain Or IsolatedStorageScope.User, _
             Nothing, Nothing)
        '</Snippet23>
        isoFile.Close()
    End Sub
End Class
