

// <Snippet1>
#using <System.dll>
#using <System.ServiceProcess.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Configuration::Install;
using namespace System::ServiceProcess;
using namespace System::ComponentModel;

[RunInstaller(true)]
public ref class MyProjectInstaller : public Installer
{
private:
    ServiceInstaller^ serviceInstaller1;
    ServiceInstaller^ serviceInstaller2;
    ServiceProcessInstaller^ processInstaller;

public:
    MyProjectInstaller()
    {
        // Instantiate installers for process and services.
        processInstaller = gcnew ServiceProcessInstaller;
        serviceInstaller1 = gcnew ServiceInstaller;
        serviceInstaller2 = gcnew ServiceInstaller;

        // The services run under the system account.
        processInstaller->Account = ServiceAccount::LocalSystem;

        // The services are started manually.
        serviceInstaller1->StartType = ServiceStartMode::Manual;
        serviceInstaller2->StartType = ServiceStartMode::Manual;

        // ServiceName must equal those on ServiceBase derived classes.
        serviceInstaller1->ServiceName = "Hello-World Service 1";
        serviceInstaller2->ServiceName = "Hello-World Service 2";

        // Add installers to collection. Order is not important.
        Installers->Add( serviceInstaller1 );
        Installers->Add( serviceInstaller2 );
        Installers->Add( processInstaller );
    }

    static void Main()
    {
        Console::WriteLine("Usage: InstallUtil.exe [<service>.exe]");
    }
};

int main()
{
    MyProjectInstaller::Main();
}
// </Snippet1>
