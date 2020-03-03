
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class t
{
public:
   t(){}

   static t(){}

   t( int /*i*/ ){}

};

int main()
{
   array<ConstructorInfo^>^p = t::typeid->GetConstructors();
   Console::WriteLine( p->Length );
   for ( int i = 0; i < p->Length; i++ )
   {
      Console::WriteLine( p[ i ]->IsStatic );

   }
}
// </Snippet1>
