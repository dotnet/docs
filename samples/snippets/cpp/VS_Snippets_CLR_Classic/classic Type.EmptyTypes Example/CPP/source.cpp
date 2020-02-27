using namespace System;
using namespace System::IO;
using namespace System::Reflection;

public ref class Sample
{
public:
   void Method( Type^ type )
   {
      ConstructorInfo^ cInfo;
      
      // <Snippet1>
      cInfo = type->GetConstructor( BindingFlags::ExactBinding, nullptr,
         Type::EmptyTypes, nullptr );
      // </Snippet1>
   }
};
