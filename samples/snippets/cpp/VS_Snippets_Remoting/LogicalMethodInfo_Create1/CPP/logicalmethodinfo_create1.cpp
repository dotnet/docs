

// All the following have been marked as 1 snippet : Snippet1
// System::Web::Services::Protocols.LogicalMethodInfo::Create(MethodInfo)
// System::Web::Services::Protocols.LogicalMethodInfo::Name
// System::Web::Services::Protocols.LogicalMethodInfo::InParameters
// System::Web::Services::Protocols.LogicalMethodInfo::OutParameters
// System::Web::Services::Protocols.LogicalMethodInfo::IsVoid
/*
This following example demonstrates the 'Name',
'InParameters', 'OutParameters', 'IsVoid' properties and
'Create(MethodInfo)' method of the 'LogicalMethodInfo' class.
This example displays the parameters, the in parameters and
[Out] parameters.


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
using namespace System::Runtime::InteropServices;
using namespace System::Reflection;
using namespace System::Web::Services::Protocols;

public ref class MyService
{
public:
   void MyMethod( int inParameter, [Out]interior_ptr<int> outParameter )
   {
       *outParameter = inParameter;
   }
};

int main()
{
   Type^ myType = MyService::typeid;
   MethodInfo^ myMethodInfo = myType->GetMethod( "MyMethod" );
   array<MethodInfo^>^temparray = {myMethodInfo};
   LogicalMethodInfo^ myLogicalMethodInfo = (LogicalMethodInfo::Create( temparray ))[ 0 ];
   Console::WriteLine( "\nPrinting parameters for the method : {0}", myLogicalMethodInfo->Name );
   Console::WriteLine( "\nThe parameters of the method {0} are :\n", myLogicalMethodInfo->Name );
   array<ParameterInfo^>^myParameters = myLogicalMethodInfo->Parameters;
   for ( int i = 0; i < myParameters->Length; i++ )
   {
      Console::WriteLine( String::Concat( "\t ", myParameters[ i ]->Name, " : ", myParameters[ i ]->ParameterType ) );

   }
   Console::WriteLine( "\nThe in parameters of the method {0} are :\n", myLogicalMethodInfo->Name );
   myParameters = myLogicalMethodInfo->InParameters;
   for ( int i = 0; i < myParameters->Length; i++ )
   {
      Console::WriteLine( String::Concat( "\t ", myParameters[ i ]->Name, " : ", myParameters[ i ]->ParameterType ) );

   }
   Console::WriteLine( "\nThe out parameters of the method {0} are :\n", myLogicalMethodInfo->Name );
   myParameters = myLogicalMethodInfo->OutParameters;
   for ( int i = 0; i < myParameters->Length; i++ )
   {
      Console::WriteLine( String::Concat( "\t ", myParameters[ i ]->Name, " : ", myParameters[ i ]->ParameterType ) );

   }
   if ( myLogicalMethodInfo->IsVoid )
      Console::WriteLine( "\nThe return type is void" );
   else
      Console::WriteLine( "\nThe return type is {0}", myLogicalMethodInfo->ReturnType );
}
// </Snippet1>
