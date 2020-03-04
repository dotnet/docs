using namespace System;
using namespace System::Reflection;

public ref class Sample
{
public:
   void Method( Type^ t, MemberInfo^ mi )
   {
      // <Snippet1>
      array<MemberInfo^>^ others = t->GetMember( mi->Name, mi->MemberType,
         (BindingFlags)(BindingFlags::Public | BindingFlags::Static |
            BindingFlags::NonPublic | BindingFlags::Instance) );
      // </Snippet1>
   }
};
