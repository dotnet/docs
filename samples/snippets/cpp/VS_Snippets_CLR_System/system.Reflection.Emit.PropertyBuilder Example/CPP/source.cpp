
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
Type^ BuildDynamicTypeWithProperties()
{
   AppDomain^ myDomain = Thread::GetDomain();
   AssemblyName^ myAsmName = gcnew AssemblyName;
   myAsmName->Name = "MyDynamicAssembly";
   
   // To generate a persistable assembly, specify AssemblyBuilderAccess::RunAndSave.
   AssemblyBuilder^ myAsmBuilder = 
       myDomain->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::RunAndSave );
   
   // Generate a persistable single-module assembly.
   ModuleBuilder^ myModBuilder = 
       myAsmBuilder->DefineDynamicModule( myAsmName->Name, myAsmName->Name + ".dll" );
   TypeBuilder^ myTypeBuilder = myModBuilder->DefineType( "CustomerData", TypeAttributes::Public );

   // Define a private field to hold the property value.
   FieldBuilder^ customerNameBldr = myTypeBuilder->DefineField( "customerName", String::typeid, FieldAttributes::Private );
   
   // The last argument of DefineProperty is an empty array of Type
   // objects, because the property has no parameters. (Alternatively,
   // you can specify a null value.)
   PropertyBuilder^ custNamePropBldr = 
       myTypeBuilder->DefineProperty( "CustomerName", PropertyAttributes::HasDefault, String::typeid, gcnew array<Type^>(0) );
   
   // The property set and property get methods require a special
   // set of attributes.
   MethodAttributes getSetAttr = 
       MethodAttributes::Public | MethodAttributes::SpecialName |
           MethodAttributes::HideBySig;

   // Define the "get" accessor method for CustomerName.
   MethodBuilder^ custNameGetPropMthdBldr = 
       myTypeBuilder->DefineMethod( "get_CustomerName", 
                                    getSetAttr,
                                    String::typeid, 
                                    Type::EmptyTypes );

   ILGenerator^ custNameGetIL = custNameGetPropMthdBldr->GetILGenerator();
   custNameGetIL->Emit( OpCodes::Ldarg_0 );
   custNameGetIL->Emit( OpCodes::Ldfld, customerNameBldr );
   custNameGetIL->Emit( OpCodes::Ret );
   
   // Define the "set" accessor method for CustomerName.
   array<Type^>^temp2 = {String::typeid};
   MethodBuilder^ custNameSetPropMthdBldr = 
       myTypeBuilder->DefineMethod( "set_CustomerName", 
                                    getSetAttr,
                                    nullptr, 
                                    temp2 );

   ILGenerator^ custNameSetIL = custNameSetPropMthdBldr->GetILGenerator();
   custNameSetIL->Emit( OpCodes::Ldarg_0 );
   custNameSetIL->Emit( OpCodes::Ldarg_1 );
   custNameSetIL->Emit( OpCodes::Stfld, customerNameBldr );
   custNameSetIL->Emit( OpCodes::Ret );
   
   // Last, we must map the two methods created above to our PropertyBuilder to
   // their corresponding behaviors, "get" and "set" respectively.
   custNamePropBldr->SetGetMethod( custNameGetPropMthdBldr );
   custNamePropBldr->SetSetMethod( custNameSetPropMthdBldr );

   Type^ retval = myTypeBuilder->CreateType();

   // Save the assembly so it can be examined with Ildasm.exe,
   // or referenced by a test program.
   myAsmBuilder->Save(myAsmName->Name + ".dll");
   return retval;
}

int main()
{
   Type^ custDataType = BuildDynamicTypeWithProperties();
   array<PropertyInfo^>^custDataPropInfo = custDataType->GetProperties();
   System::Collections::IEnumerator^ myEnum = custDataPropInfo->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      PropertyInfo^ pInfo = safe_cast<PropertyInfo^>(myEnum->Current);
      Console::WriteLine( "Property '{0}' created!", pInfo );
   }

   Console::WriteLine( "---" );
   
   // Note that when invoking a property, you need to use the proper BindingFlags -
   // BindingFlags::SetProperty when you invoke the "set" behavior, and
   // BindingFlags::GetProperty when you invoke the "get" behavior. Also note that
   // we invoke them based on the name we gave the property, as expected, and not
   // the name of the methods we bound to the specific property behaviors.
   Object^ custData = Activator::CreateInstance( custDataType );
   array<Object^>^temp3 = {"Joe User"};
   custDataType->InvokeMember( "CustomerName", BindingFlags::SetProperty, nullptr, custData, temp3 );
   Console::WriteLine( "The customerName field of instance custData has been set to '{0}'.", custDataType->InvokeMember( "CustomerName", BindingFlags::GetProperty, nullptr, custData, gcnew array<Object^>(0) ) );
}

// --- O U T P U T ---
// The output should be as follows:
// -------------------
// Property 'System.String CustomerName [System.String]' created!
// ---
// The customerName field of instance custData has been set to 'Joe User'.
// -------------------
// </Snippet1>
