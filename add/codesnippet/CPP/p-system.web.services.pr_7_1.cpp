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