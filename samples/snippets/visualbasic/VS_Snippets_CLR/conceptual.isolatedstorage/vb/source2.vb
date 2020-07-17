'<snippet2>
Imports System.IO
Imports System.IO.IsolatedStorage

Module Module1
    Sub Main()
        Using isoStore As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing, Nothing)
            isoStore.CreateFile("TestFileA.Txt")
            isoStore.CreateFile("TestFileB.Txt")
            isoStore.CreateFile("TestFileC.Txt")
            isoStore.CreateFile("TestFileD.Txt")
        End Using

        Dim allFiles As IEnumerator = IsolatedStorageFile.GetEnumerator(IsolatedStorageScope.User)
        Dim totalsize As Long = 0

        While (allFiles.MoveNext())
            Dim storeFile As IsolatedStorageFile = CType(allFiles.Current, IsolatedStorageFile)
            totalsize += CType(storeFile.UsedSize, Long)
        End While

        Console.WriteLine("The total size = " + totalsize.ToString())

    End Sub
End Module
'</snippet2>
