

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

// <Snippet1>
[LicenseProvider(LicFileLicenseProvider::typeid)]
ref class MyControl: public Control
{
protected:

   // Insert code here.
   ~MyControl()
   {
      /* All components must dispose of the licenses they grant. 
               * Insert code here to dispose of the license. */
   }
};
// </Snippet1>

// <Snippet2>
int main()
{
   // Creates a new component.
   MyControl^ myNewControl = gcnew MyControl;

   // Gets the attributes for the component.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewControl );

   /* Prints the name of the license provider by retrieving the LicenseProviderAttribute 
        * from the AttributeCollection. */
   LicenseProviderAttribute^ myAttribute = dynamic_cast<LicenseProviderAttribute^>(attributes[ LicenseProviderAttribute::typeid ]);
   Console::WriteLine( "The license provider for this class is: {0}", myAttribute->LicenseProvider );
   return 0;
}
// </Snippet2>
