//<snippet10>
using System;
using System.IO.IsolatedStorage;

class RoamingIsoStorage
{
    public static void Main()
    {
        SnippetA();
        SnippetB();
    }

    public static void SnippetA()
    {
        //<snippet11>
        IsolatedStorageFile isoFile =
            IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Roaming, null, null);
        //</snippet11>
    }

    public static void SnippetB()
    {
        //<snippet12>
        IsolatedStorageFile isoFile =
            IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain |
                IsolatedStorageScope.Roaming, null, null);
        //</snippet12>
    }
}
//</snippet10>
