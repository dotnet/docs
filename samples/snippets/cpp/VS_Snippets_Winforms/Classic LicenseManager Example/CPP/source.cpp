

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

// <Snippet1>
// Adds the LicenseProviderAttribute to the control.

[LicenseProvider(LicFileLicenseProvider::typeid)]
public ref class MyControl: public Control
{
   // Creates a new, null license.
private:
   License^ license;

public:
   MyControl()
   {
      
      // Adds Validate to the control's constructor.
      license = LicenseManager::Validate( MyControl::typeid, this );

      // Insert code to perform other instance creation tasks here.
   }

public:
   ~MyControl()
   {
      if ( license != nullptr )
      {
         delete license;
         license = nullptr;
      }
   }
};
// </Snippet1>
