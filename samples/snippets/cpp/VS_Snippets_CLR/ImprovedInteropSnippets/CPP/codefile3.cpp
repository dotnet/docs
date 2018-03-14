
// System::Assembly::GetCustomAttributes
// System::Runtime::InteropServices::ImportedFromTypeLibAttribute

// <Snippet3>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

class ClassA
{
private:
   static bool IsCOMAssembly( Assembly^ a )
   {
      array<Object^>^AsmAttributes = a->GetCustomAttributes( ImportedFromTypeLibAttribute::typeid, true );
      if ( AsmAttributes->Length > 0 )
      {
         ImportedFromTypeLibAttribute^ imptlb = dynamic_cast<ImportedFromTypeLibAttribute^>(AsmAttributes[ 0 ]);
         String^ strImportedFrom = imptlb->Value;
         
         // Print out the name of the DLL from which the assembly is imported.
         Console::WriteLine( "Assembly {0} is imported from {1}", a->FullName, strImportedFrom );
         return true;
      }

      // This is not a COM assembly.
      Console::WriteLine( "Assembly {0} is not imported from COM", a->FullName );
      return false;
   }
};
// </Snippet3>
