#using <System.dll>
#using <System.Web.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Web::Services::Protocols;

public ref class MyService: public SoapHttpClientProtocol
{
public:
   IAsyncResult^ BeginAdd( int xValue, int yValue, AsyncCallback^ callback, Object^ asyncState )
   {
      array<Object^>^temp0 = {xValue,yValue};
      return this->BeginInvoke( "Add", temp0, callback, asyncState );
   }

   int EndAdd( System::IAsyncResult^ asyncResult )
   {
      array<Object^>^results = this->EndInvoke( asyncResult );
      return  *dynamic_cast<int^>(results[ 0 ]);
   }
};

int main()
{
   Type^ myType = MyService::typeid;
   MethodInfo^ myBeginMethod = myType->GetMethod( "BeginAdd" );
   MethodInfo^ myEndMethod = myType->GetMethod( "EndAdd" );
   array<MethodInfo^>^temp0 = {myBeginMethod,myEndMethod};
   LogicalMethodInfo^ myLogicalMethodInfo = LogicalMethodInfo::Create( temp0, LogicalMethodTypes::Async )[ 0 ];
   Console::WriteLine( "\nThe asynchronous callback parameter of method {0} is :\n", myLogicalMethodInfo->Name );
   Console::WriteLine( "\t {0} : {1}", myLogicalMethodInfo->AsyncCallbackParameter->Name, myLogicalMethodInfo->AsyncCallbackParameter->ParameterType );
   Console::WriteLine( "\nThe asynchronous state parameter of method {0} is :\n", myLogicalMethodInfo->Name );
   Console::WriteLine( "\t {0} : {1}", myLogicalMethodInfo->AsyncStateParameter->Name, myLogicalMethodInfo->AsyncStateParameter->ParameterType );
   Console::WriteLine( "\nThe asynchronous result parameter of method {0} is :\n", myLogicalMethodInfo->Name );
   Console::WriteLine( "\t {0} : {1}", myLogicalMethodInfo->AsyncResultParameter->Name, myLogicalMethodInfo->AsyncResultParameter->ParameterType );
   Console::WriteLine( "\nThe begin method of the asynchronous method {0} is :\n", myLogicalMethodInfo->Name );
   Console::WriteLine( "\t {0}", myLogicalMethodInfo->BeginMethodInfo );
   Console::WriteLine( "\nThe end method of the asynchronous method {0} is :\n", myLogicalMethodInfo->Name );
   Console::WriteLine( "\t {0}", myLogicalMethodInfo->EndMethodInfo );
   if ( myLogicalMethodInfo->IsAsync )
      Console::WriteLine( "\n {0} is asynchronous", myLogicalMethodInfo->Name );
   else
      Console::WriteLine( "\n {0} is synchronous", myLogicalMethodInfo->Name );
}