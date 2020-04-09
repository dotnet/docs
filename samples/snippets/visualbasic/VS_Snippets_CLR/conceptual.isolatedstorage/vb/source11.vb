'<snippet16>
Imports System.IO.IsolatedStorage

Class UserDomainAssembly_IsoStorage
    Public Shared Sub Main()
        SnippetA()
        SnippetB()
    End Sub

    Public Shared Sub SnippetA()
        '<snippet17>
        Dim isoFile As IsolatedStorageFile = _
            IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                IsolatedStorageScope.Assembly, Nothing, Nothing)
        '</snippet17>
    End Sub

    Public Shared Sub SnippetB()
        '<snippet18>
        Dim isoFile As IsolatedStorageFile = _
            IsolatedStorageFile.GetUserStoreForAssembly()
        '</snippet18>
    End Sub
End Class
'</snippet16>
