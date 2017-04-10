Imports System
Imports System.IO
Imports System.IO.IsolatedStorage

Public Class IsoFileCloseSample
    Public Shared Sub Main()
        Dim isoClose As New IsoFileCloseSample()

        isoClose.RunExample()
    End Sub

    Dim userName As String = "JoeUser"

    Public Sub RunExample()
        Dim isoFile As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForDomain()
        '<Snippet17>
        Dim source As New IsolatedStorageFileStream(MyClass.userName,FileMode.Open,isoFile)
        ' This stream is the one that data will be read from
        If source.CanRead Then
            Console.WriteLine("Source can read ? true")
        Else
            Console.WriteLine("Source can read ? false")
        End If
        Dim target As new IsolatedStorageFileStream("Archive\\ " + MyClass.userName,
            FileMode.OpenOrCreate,isoFile)
        ' This stream is the one that data will be written to
        If target.CanWrite Then
            Console.WriteLine("Target is writable? true")
        Else
            Console.WriteLine("Target is writable? false")
        End If
        ' Do work...
        ' After you have read and written to the streams, close them
        source.Close()
        target.Close()
        '</Snippet17>
    End Sub
End Class
