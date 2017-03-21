#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;
using namespace System::Reflection;

[assembly:AssemblyKeyFile("..\\common\\key.snk")];
[assembly:ApplicationName("ReceiptNumberGenerator")];
[assembly:ApplicationActivation(ActivationOption::Library)];

public ref class ReceiptNumberGeneratorClass
{
public:

   // Generates a new receipt number based on the receipt number
   // stored by the Shared Property Manager (SPM)
   int GetNextReceiptNumber()
   {
      bool groupExists;
      bool propertyExists;
      int nextReceiptNumber = 0;
      PropertyLockMode lockMode = PropertyLockMode::SetGet;
      PropertyReleaseMode releaseMode = PropertyReleaseMode::Standard;
      
      // Create a shared property group manager.
      SharedPropertyGroupManager^ groupManager = gcnew SharedPropertyGroupManager;

      // Create a shared property group.
      SharedPropertyGroup^ group =
         groupManager->CreatePropertyGroup( "Receipts",  lockMode,  releaseMode,  groupExists );

      // Create a shared property.
      SharedProperty^ ReceiptNumber;
      ReceiptNumber = group->CreateProperty( "ReceiptNumber",  propertyExists );

      // Retrieve the value from shared property, and increment the shared 
      // property value.
      nextReceiptNumber =  safe_cast<int>(ReceiptNumber->Value);
      ReceiptNumber->Value = nextReceiptNumber + 1;

      // Return nextReceiptNumber
      return nextReceiptNumber;
   }
};