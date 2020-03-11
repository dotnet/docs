

// All the following have been marked as 1 snippet : Snippet1
// System::Web::Services::Protocols.LogicalMethodInfo::LogicalMethodInfo(MethodInfo)
// System::Web::Services::Protocols.LogicalMethodInfo::DeclaringType
// System::Web::Services::Protocols.LogicalMethodInfo::Parameters
// System::Web::Services::Protocols.LogicalMethodInfo::ReturnType
// System::Web::Services::Protocols.LogicalMethodInfo::Invoke(Object*, Object*->Item[])
// System::Web::Services::Protocols.LogicalMethodInfo
/*
This following example demonstrates the constructor, 'DeclaringType',
'Parameters', 'ReturnType' properties and 'Invoke(Object*, Object*->Item[])',
'ToString()' methods of the 'LogicalMethodInfo' class. This example
displays the declaring type, parameters, return type of a method
named 'Add' in the class named 'MyService'.

Note : The 'LogicalMethodInfo' class should only be used with
'SoapMessage'. 'SoapClientMessage' and 'SoapServerMessage' contain
a property named 'MethodInfo' which provides for an instance of
'LogicalMethodInfo'. If you are interested only in the reflection
of a type then use the 'System::Reflection' namespace and not this
class. This class gives information ab->Item[Out] the* method invoked for
a web service and hence should only be used as such. For example
purposes it is being showed in a more simplified scenario.
*/
// <Snippet1>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Web::Services::Protocols;

public ref class MyService
{
public:
   int Add( int xValue, int yValue )
   {
      return (xValue + yValue);
   }

};

int main()
{
   Type^ myType = MyService::typeid;
   MethodInfo^ myMethodInfo = myType->GetMethod( "Add" );
   LogicalMethodInfo^ myLogicalMethodInfo = gcnew LogicalMethodInfo( myMethodInfo );
   Console::WriteLine( "\nPrinting properties of method : {0}\n", myLogicalMethodInfo );
   Console::WriteLine( "\nThe declaring type of the method {0} is :\n", myLogicalMethodInfo->Name );
   Console::WriteLine( "\t {0}", myLogicalMethodInfo->DeclaringType );
   Console::WriteLine( "\nThe parameters of the method {0} are :\n", myLogicalMethodInfo->Name );
   array<ParameterInfo^>^myParameters = myLogicalMethodInfo->Parameters;
   for ( int i = 0; i < myParameters->Length; i++ )
   {
      Console::WriteLine( "\t {0}", String::Concat( myParameters[ i ]->Name, " : ", myParameters[ i ]->ParameterType ) );
   }
   Console::WriteLine( "\nThe return type of the method {0} is :\n", myLogicalMethodInfo->Name );
   Console::WriteLine( "\t {0}", myLogicalMethodInfo->ReturnType );
   MyService^ service = gcnew MyService;
   Console::WriteLine( "\nInvoking the method {0}\n", myLogicalMethodInfo->Name );
   array<Object^>^values = gcnew array<Object^>(2);
   values[ 0 ] = 10;
   values[ 1 ] = 10;
   Console::WriteLine( "\tThe sum of 10 and 10 is : {0}", myLogicalMethodInfo->Invoke( service, values ) );
}
// </Snippet1>
