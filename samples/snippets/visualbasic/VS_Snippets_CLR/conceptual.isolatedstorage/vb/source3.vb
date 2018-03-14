'<snippet3>
Imports System
Imports System.IO.IsolatedStorage

Public Class DeletingStores
    Public Shared Sub Main()
        ' Get a new isolated store for this user, domain, and assembly.
        ' Put the store into an IsolatedStorageFile object.

        Dim isoStore1 As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or
            IsolatedStorageScope.Domain Or IsolatedStorageScope.Assembly, Nothing, Nothing)
        Console.WriteLine("A store isolated by user, assembly, and domain has been obtained.")

        ' Get a new isolated store for user and assembly.
        ' Put that store into a different IsolatedStorageFile object.

        Dim isoStore2 As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or
            IsolatedStorageScope.Assembly, Nothing, Nothing)
        Console.WriteLine("A store isolated by user and assembly has been obtained.")

        ' The Remove method deletes a specific store, in this case the
        ' isoStore1 file.

        isoStore1.Remove()
        Console.WriteLine("The user, domain, and assembly isolated store has been deleted.")

        ' This static method deletes all the isolated stores for this user.

        IsolatedStorageFile.Remove(IsolatedStorageScope.User)
        Console.WriteLine("All isolated stores for this user have been deleted.")

    End Sub ' End of Main.
End Class
'</snippet3>
