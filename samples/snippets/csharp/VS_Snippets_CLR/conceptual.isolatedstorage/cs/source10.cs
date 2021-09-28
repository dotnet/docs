//<snippet13>
using System;
using System.IO.IsolatedStorage;

class UserDomainAssembly_IsoStorage
{
    public static void Main()
    {
        SnippetA();
        SnippetB();
    }

    public static void SnippetA()
    {
        //<snippet14>
        IsolatedStorageFile isoFile =
            IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Domain |
                IsolatedStorageScope.Assembly, null, null);
        //</snippet14>
    }

    public static void SnippetB()
    {
        //<snippet15>
        IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForDomain();
        //</snippet15>
    }
}
//</snippet13>
