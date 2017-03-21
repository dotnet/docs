#using <System.Web.Services.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Web::Services::Protocols;

// Define a custom attribute with one named parameter.

[AttributeUsage(AttributeTargets::Method|AttributeTargets::ReturnValue,
AllowMultiple=true)]
public ref class MyAttribute: public Attribute
{
private:
   String^ myName;

public:
   MyAttribute( String^ name )
   {
      myName = name;
   }

   property String^ Name 
   {
      String^ get()
      {
         return myName;
      }
   }
};

public ref class MyService
{
public:

   [MyAttribute("This is the first sample attribute")]
   [MyAttribute("This is the second sample attribute")]
   [returnvalue:MyAttribute("This is the return sample attribute")]
   int Add( int xValue, int yValue )
   {
      return (xValue + yValue);
   }
};

int main()
{
   Type^ myType = MyService::typeid;
   MethodInfo^ myMethodInfo = myType->GetMethod( "Add" );

   // Create a synchronous 'LogicalMethodInfo' instance.
   array<MethodInfo^>^temparray = {myMethodInfo};
   LogicalMethodInfo^ myLogicalMethodInfo = (LogicalMethodInfo::Create( temparray, LogicalMethodTypes::Sync ))[ 0 ];

   // Display the method for which the attributes are being displayed.
   Console::WriteLine( "\nDisplaying the attributes for the method : {0}\n", myLogicalMethodInfo->MethodInfo );

   // Displaying a custom attribute of type 'MyAttribute'
   Console::WriteLine( "\nDisplaying attribute of type 'MyAttribute'\n" );
   Object^ attribute = myLogicalMethodInfo->GetCustomAttribute( MyAttribute::typeid );
   Console::WriteLine( (dynamic_cast<MyAttribute^>(attribute))->Name );

   // Display all custom attribute of type 'MyAttribute'.
   Console::WriteLine( "\nDisplaying all attributes of type 'MyAttribute'\n" );
   array<Object^>^attributes = myLogicalMethodInfo->GetCustomAttributes( MyAttribute::typeid );
   for ( int i = 0; i < attributes->Length; i++ )
      Console::WriteLine( (dynamic_cast<MyAttribute^>(attributes[ i ]))->Name );

   // Display all return attributes of type 'MyAttribute'.
   Console::WriteLine( "\nDisplaying all return attributes of type 'MyAttribute'\n" );
   ICustomAttributeProvider^ myCustomAttributeProvider = myLogicalMethodInfo->ReturnTypeCustomAttributeProvider;
   if ( myCustomAttributeProvider->IsDefined( MyAttribute::typeid, true ) )
   {
      attributes = myCustomAttributeProvider->GetCustomAttributes( true );
      for ( int i = 0; i < attributes->Length; i++ )
         if ( attributes[ i ]->GetType()->Equals( MyAttribute::typeid ) )
                  Console::WriteLine( (dynamic_cast<MyAttribute^>(attributes[ i ]))->Name );
   }

   // Display all the custom attributes of type 'MyAttribute'.
   Console::WriteLine( "\nDisplaying all attributes of type 'MyAttribute'\n" );
   myCustomAttributeProvider = myLogicalMethodInfo->CustomAttributeProvider;
   if ( myCustomAttributeProvider->IsDefined( MyAttribute::typeid, true ) )
   {
      attributes = myCustomAttributeProvider->GetCustomAttributes( true );
      for ( int i = 0; i < attributes->Length; i++ )
         if ( attributes[ i ]->GetType()->Equals( MyAttribute::typeid ) )
                  Console::WriteLine( (dynamic_cast<MyAttribute^>(attributes[ i ]))->Name );
   }
}