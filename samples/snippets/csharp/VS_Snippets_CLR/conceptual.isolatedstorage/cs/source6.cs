//<snippet7>
using System;
using System.IO.IsolatedStorage;

public class ObtainingAStore
{
    public static void Main()
    {
        // Get a new isolated store for this assembly and put it into an
        // isolated store object.

        IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Assembly, null, null);
    }
}
//</snippet7>

public class ObtainingAStoreWithDomain
{
    public static void Dummy()
    {
        //<snippet6>
        IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null);
        //</snippet6>
    }
}
