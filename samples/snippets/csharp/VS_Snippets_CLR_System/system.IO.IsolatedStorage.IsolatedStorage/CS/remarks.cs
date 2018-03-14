using System;
using System.IO;
using System.IO.IsolatedStorage;

public class IsoFileGetStoreSample
{
    public static void Main()
    {
        IsolatedStorageFile isoFile;

        // remarks for GetMachineStoreForApplication()
        //<Snippet18>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Application |
            IsolatedStorageScope.Machine, null);
        //</Snippet18>
        isoFile.Close();

        // remarks for GetMachineStoreForAssembly()
        //<Snippet19>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly |
            IsolatedStorageScope.Machine, null, null);
        //</Snippet19>
        isoFile.Close();

        // remarks for GetMachineStoreForDomain()
        //<Snippet20>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly |
            IsolatedStorageScope.Domain | IsolatedStorageScope.Machine,
            null, null);
        //</Snippet20>
        isoFile.Close();

        // remarks for GetUserStoreForApplication()
        //<Snippet21>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Application |
            IsolatedStorageScope.User, null);
        //</Snippet21>
        isoFile.Close();

        // remarks for GetUserStoreForAssembly()
        //<Snippet22>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly |
            IsolatedStorageScope.User, null, null);
        //</Snippet22>
        isoFile.Close();

        // remarks for GetUserStoreForDomain()
        //<Snippet23>
        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly |
            IsolatedStorageScope.Domain | IsolatedStorageScope.User,
            null, null);
        //</Snippet23>
        isoFile.Close();
    }

}
