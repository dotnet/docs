//<snippet16>
using System;
using System.IO.IsolatedStorage;

class UserAssembly_IsoStorage
{
    public static void Main()
    {
        SnippetA();
        SnippetB();
    }

    public static void SnippetA()
    {
        //<snippet17>
        IsolatedStorageFile isoFile =
            IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Assembly, null, null);
        //</snippet17>
    }

    public static void SnippetB()
    {
        //<snippet18>
        IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForAssembly();
        //</snippet18>
    }
}
//</snippet16>
