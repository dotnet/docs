using namespace System;
using namespace System::Reflection;

// Class added so sample will compile
public ref class Application
{
public:
   void Method(){}
};

public ref class Sample
{
public:
   void Method()
   {
      // <Snippet1>
      // Get the set of methods associated with the type
      array<MemberInfo^>^ mi = Application::typeid->FindMembers(
         (MemberTypes)(MemberTypes::Constructor | MemberTypes::Method),
         (BindingFlags)(BindingFlags::Public | BindingFlags::Static |
            BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::DeclaredOnly),
         Type::FilterName, "*" );
      Console::WriteLine( "Number of methods (includes constructors): {0}", mi->Length );
      // </Snippet1>
   }
};
