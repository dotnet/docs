
// <Snippet1>
// The following example uses instances of classes in
// the System::Reflection namespace to discover an event argument type.
using namespace System;
using namespace System::Reflection;

public delegate void MyDelegate( int i );
public ref class MainClass
{
public:
   event MyDelegate^ ev;
};

int main()
{
   Type^ delegateType = MainClass::typeid->GetEvent( "ev" )->EventHandlerType;
   MethodInfo^ invoke = delegateType->GetMethod( "Invoke" );
   array<ParameterInfo^>^pars = invoke->GetParameters();
   System::Collections::IEnumerator^ myEnum = pars->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      ParameterInfo^ p = safe_cast<ParameterInfo^>(myEnum->Current);
      Console::WriteLine( p->ParameterType );
   }
}
// The example displays the following output:
//       System.Int32
// </Snippet1>
