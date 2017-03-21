// The following class is an example of code that exposes external process management.
// Add the LicenseProviderAttribute to the control.

[LicenseProvider(LicFileLicenseProvider::typeid)]
public ref class MyControl: public System::Windows::Forms::Control
{
private:

   // Create a new, null license.
   License^ license;

public:
   [HostProtection(ExternalProcessMgmt=true)]
   MyControl()
   {
      license = nullptr;
      
      // Determine if a valid license can be granted.
      bool isValid = LicenseManager::IsValid( MyControl::typeid );
      Console::WriteLine( "The result of the IsValid method call is {0}", isValid );
   }

};