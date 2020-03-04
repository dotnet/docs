
// <Snippet2>
using namespace System;
using namespace System::Reflection;
public ref class t
{
public:
   t(){}

   t( int /*i*/ ){}

   static t(){}

};

int main()
{
   array<ConstructorInfo^>^p = t::typeid->GetConstructors( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static | BindingFlags::NonPublic | BindingFlags::Instance) );
   Console::WriteLine( p->Length );
   for ( int i = 0; i < p->Length; i++ )
   {
      Console::WriteLine( p[ i ]->IsStatic );
   }
}
// </Snippet2>
