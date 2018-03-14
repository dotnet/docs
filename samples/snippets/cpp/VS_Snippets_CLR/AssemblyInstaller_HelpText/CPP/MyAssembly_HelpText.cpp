/*  The following example creates an assembly which is used to demonstrate
the methods, properties and constructors of the 'AssemblyInstaller' class.
*/
#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;
using namespace System::Collections;

[RunInstallerAttribute(true)]
ref class MyProjectInstaller: public Installer{};

int main()
{
   Console::WriteLine( "Hello World" );
}
