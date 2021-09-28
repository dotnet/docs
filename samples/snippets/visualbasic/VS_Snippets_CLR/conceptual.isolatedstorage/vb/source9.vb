'<snippet10>
Imports System.IO.IsolatedStorage

Class RoamingIsoStorage
    Public Shared Sub Main()
        SnippetA()
        SnippetB()
    End Sub

    Public Shared Sub SnippetA()
        '<snippet11>
        Dim isoFile As IsolatedStorageFile = _
            IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                IsolatedStorageScope.Assembly Or _
                IsolatedStorageScope.Roaming, Nothing, Nothing)
        '</snippet11>
    End Sub

    Public Shared Sub SnippetB()
        '<snippet12>
        Dim isoFile As IsolatedStorageFile = _
            IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain Or _
                IsolatedStorageScope.Roaming, Nothing, Nothing)
        '</snippet12>
    End Sub
End Class
'</snippet10>
