//<snippet2>
using namespace System;
using namespace System::Reflection;

ref class AppDomain1
{
public:
    static void Main()
    {
        Console::WriteLine("Creating new AppDomain.");
        AppDomain^ domain = AppDomain::CreateDomain("MyDomain");

        Console::WriteLine("Host domain: " + AppDomain::CurrentDomain->FriendlyName);
        Console::WriteLine("child domain: " + domain->FriendlyName);
    }
};

int main()
{
    AppDomain1::Main();
}
//</snippet2>
