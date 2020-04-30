// <snippet0>
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
      
      // <snippet1>
      // Create a shared property group manager.
      SharedPropertyGroupManager^ groupManager = gcnew SharedPropertyGroupManager;
      // </snippet1>

      // <snippet21>
      // <snippet2>
      // Create a shared property group.
      SharedPropertyGroup^ group =
         groupManager->CreatePropertyGroup( "Receipts",  lockMode,  releaseMode,  groupExists );
      // </snippet2>

      // Create a shared property.
      SharedProperty^ ReceiptNumber;
      ReceiptNumber = group->CreateProperty( "ReceiptNumber",  propertyExists );
      // </snippet21>

      // <snippet3>
      // Retrieve the value from shared property, and increment the shared 
      // property value.
      nextReceiptNumber =  safe_cast<int>(ReceiptNumber->Value);
      ReceiptNumber->Value = nextReceiptNumber + 1;
      // </snippet3>

      // Return nextReceiptNumber
      return nextReceiptNumber;
   }
};
// </snippet0>
