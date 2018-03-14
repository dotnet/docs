

#using <System.Configuration.Install.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Configuration::Install;

// <Snippet1>
[RunInstallerAttribute(true)]
ref class MyProjectInstaller: public Installer{
   // Insert code here.
};
// </Snippet1>

// <Snippet2>
int main()
{
   // Creates a new installer.
   MyProjectInstaller^ myNewProjectInstaller = gcnew MyProjectInstaller;

   // Gets the attributes for the collection.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewProjectInstaller );

   /* Prints whether to run the installer by retrieving the 
       * RunInstallerAttribute from the AttributeCollection. */
   RunInstallerAttribute^ myAttribute = dynamic_cast<RunInstallerAttribute^>(attributes[ RunInstallerAttribute::typeid ]);
   Console::WriteLine( "Run the installer? {0}", myAttribute->RunInstaller );
   return 0;
}
// </Snippet2>
