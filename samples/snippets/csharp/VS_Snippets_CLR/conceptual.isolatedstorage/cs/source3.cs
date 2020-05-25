//<snippet3>
using System;
using System.IO.IsolatedStorage;

public class DeletingStores
{
    public static void Main()
    {
        // Get a new isolated store for this user, domain, and assembly.
        // Put the store into an IsolatedStorageFile object.

        IsolatedStorageFile isoStore1 =  IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null);
        Console.WriteLine("A store isolated by user, assembly, and domain has been obtained.");

        // Get a new isolated store for user and assembly.
        // Put that store into a different IsolatedStorageFile object.

        IsolatedStorageFile isoStore2 = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Assembly, null, null);
        Console.WriteLine("A store isolated by user and assembly has been obtained.");

        // The Remove method deletes a specific store, in this case the
        // isoStore1 file.

        isoStore1.Remove();
        Console.WriteLine("The user, domain, and assembly isolated store has been deleted.");

        // This static method deletes all the isolated stores for this user.

        IsolatedStorageFile.Remove(IsolatedStorageScope.User);
        Console.WriteLine("All isolated stores for this user have been deleted.");
    } // End of Main.
}
//</snippet3>
