//<snippet7>
using namespace System;
using namespace System::IO::IsolatedStorage;

public ref class ObtainingAStore
{
public:
    static void Main()
    {
        // Get a new isolated store for this assembly and put it into an
        // isolated store object.

        IsolatedStorageFile^ isoStore = IsolatedStorageFile::GetStore(IsolatedStorageScope::User |
            IsolatedStorageScope::Assembly, (Type ^)nullptr, (Type ^)nullptr);
    }
};
//</snippet7>

public ref class ObtainingAStoreWithDomain
{
public:
    static void Dummy()
    {
        //<snippet6>
        IsolatedStorageFile^ isoStore = IsolatedStorageFile::GetStore(IsolatedStorageScope::User |
            IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain, (Type ^)nullptr, (Type ^)nullptr);
        //</snippet6>
    }
};

int main()
{
    ObtainingAStore::Main();
}