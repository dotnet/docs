
/*
System::Type::GetInterface(String)
System::Type::GetInterface(String, bool)
System::Type::GetInterfaceMap

The following program get the type of Hashtable class and searches for the interface
with the specified name. Then prints the method name of that interface.
*/
using namespace System;
using namespace System::Reflection;
using namespace System::Collections;

// <Snippet1>
// <Snippet2>
// <Snippet3>
int main()
{
   Hashtable^ hashtableObj = gcnew Hashtable;
   Type^ objType = hashtableObj->GetType();
   array<MemberInfo^>^arrayMemberInfo;
   array<MethodInfo^>^arrayMethodInfo;
   try
   {
      // Get the methods implemented in 'IDeserializationCallback' interface.
      arrayMethodInfo = objType->GetInterface( "IDeserializationCallback" )->GetMethods();
      Console::WriteLine( "\nMethods of 'IDeserializationCallback' Interface :" );
      for ( int index = 0; index < arrayMethodInfo->Length; index++ )
         Console::WriteLine( arrayMethodInfo[ index ] );
      
      // Get FullName for interface by using Ignore case search.
      Console::WriteLine( "\nMethods of 'IEnumerable' Interface" );
      arrayMethodInfo = objType->GetInterface( "ienumerable", true )->GetMethods();
      for ( int index = 0; index < arrayMethodInfo->Length; index++ )
         Console::WriteLine( arrayMethodInfo[ index ] );
      
      //Get the Interface methods for 'IDictionary*' interface
      InterfaceMapping interfaceMappingObj;
      interfaceMappingObj = objType->GetInterfaceMap( IDictionary::typeid );
      arrayMemberInfo = interfaceMappingObj.InterfaceMethods;
      Console::WriteLine( "\nHashtable class Implements the following IDictionary Interface methods :" );
      for ( int index = 0; index < arrayMemberInfo->Length; index++ )
         Console::WriteLine( arrayMemberInfo[ index ] );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e );
   }
}
// </Snippet3>
// </Snippet2>
// </Snippet1>
