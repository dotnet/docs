// <snippet2>
using namespace System;
using namespace System::Reflection;

ref class AppDomain4
{
public:
    static void Main()
    {
        // Create application domain setup information.
        AppDomainSetup^ domaininfo = gcnew AppDomainSetup();
        domaininfo->ApplicationBase = "f:\\work\\development\\latest";

        // Create the application domain.
        AppDomain^ domain = AppDomain::CreateDomain("MyDomain", nullptr, domaininfo);

        // Write application domain information to the console.
        Console::WriteLine("Host domain: " + AppDomain::CurrentDomain->FriendlyName);
        Console::WriteLine("child domain: " + domain->FriendlyName);
        Console::WriteLine("Application base is: " + domain->SetupInformation->ApplicationBase);

        // Unload the application domain.
        AppDomain::Unload(domain);
    }
};

int main()
{
    AppDomain4::Main();
}
// </snippet2>
