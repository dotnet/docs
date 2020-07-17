'<snippet8>
Imports System.IO
Imports System.IO.IsolatedStorage

Public Class CheckingSpace
    Public Shared Sub Main()
        ' Get an isolated store for this assembly and put it into an
        ' IsolatedStoreFile object.
        Dim isoStore As IsolatedStorageFile = _
            IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
            IsolatedStorageScope.Assembly, Nothing, Nothing)

        ' Create a few placeholder files in the isolated store.
        Dim aStream As New IsolatedStorageFileStream("InTheRoot.txt", FileMode.Create, isoStore)
        Dim bStream As New IsolatedStorageFileStream("Another.txt", FileMode.Create, isoStore)
        Dim cStream As New IsolatedStorageFileStream("AThird.txt", FileMode.Create, isoStore)
        Dim dStream As New IsolatedStorageFileStream("AFourth.txt", FileMode.Create, isoStore)
        Dim eStream As New IsolatedStorageFileStream("AFifth.txt", FileMode.Create, isoStore)

        Console.WriteLine(isoStore.AvailableFreeSpace + " bytes of space remain in this isolated store.")
    End Sub
End Class
'</snippet8>
