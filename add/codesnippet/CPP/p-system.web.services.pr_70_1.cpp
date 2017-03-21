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