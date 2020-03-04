
// System::Runtime::InteropServices::TypeLibFuncAttribute
// System::Runtime::InteropServices::TypeLibFuncFlags

// <Snippet5>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

ref class ClassC
{
private:
   static bool IsHiddenMethod( MethodInfo^ mi )
   {
      array<Object^>^MethodAttributes = mi->GetCustomAttributes( TypeLibFuncAttribute::typeid, true );
      if ( MethodAttributes->Length > 0 )
      {
         TypeLibFuncAttribute^ tlf = dynamic_cast<TypeLibFuncAttribute^>(MethodAttributes[ 0 ]);
         TypeLibFuncFlags flags = tlf->Value;
         return (flags & TypeLibFuncFlags::FHidden) != (TypeLibFuncFlags)0;
      }

      return false;
   }
};
// </Snippet5>
