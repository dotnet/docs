
// System::Runtime::InteropServices::TypeLibTypeAttribute
// System::Runtime::InteropServices::TypeLibTypeFlags

// <Snippet4>
using namespace System;
using namespace System::Runtime::InteropServices;

ref class ClassB
{
private:
   static bool IsHiddenInterface( Type^ InterfaceType )
   {
      array<Object^>^InterfaceAttributes = InterfaceType->GetCustomAttributes( TypeLibTypeAttribute::typeid, false );
      if ( InterfaceAttributes->Length > 0 )
      {
         TypeLibTypeAttribute^ tlt = dynamic_cast<TypeLibTypeAttribute^>(InterfaceAttributes[ 0 ]);
         TypeLibTypeFlags flags = tlt->Value;
         return (flags & TypeLibTypeFlags::FHidden) != TypeLibTypeFlags(0);
      }

      return false;
   }
};
// </Snippet4>
