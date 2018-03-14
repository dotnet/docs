
// System.Runtime.InteropServices.TypeLibVarAttribute
// System.Runtime.InteropServices.TypeLibVarFlags
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

ref class ClassD
{
public:
   static bool IsHiddenField( FieldInfo^ fi )
   {
      array<Object^>^FieldAttributes = fi->GetCustomAttributes( TypeLibVarAttribute::typeid, true );
      if ( FieldAttributes->Length > 0 )
      {
         TypeLibVarAttribute^ tlv = dynamic_cast<TypeLibVarAttribute^>(FieldAttributes[ 0 ]);
         TypeLibVarFlags flags = tlv->Value;
         return (flags & TypeLibVarFlags::FHidden) != (TypeLibVarFlags)0;
      }

      return false;
   }
};
// </Snippet1>
