
// System.Reflection.Emit.PropertyBuilder.SetGetMethod
// System.Reflection.Emit.PropertyBuilder.SetSetMethod
// System.Reflection.Emit.PropertyBuilder.AddOtherMethod
// System.Reflection.Emit.PropertyBuilder
/*
This following program demonstrates methods 'SetGetMethod','SetSetMethod' and
'AddOtherMethod' of class 'PropertyBuilder'.

A dynamic assembly is generated with  a class having a property 'Greeting'.
Its 'get' and 'set' method are created by returning and setting a string respectively.
This property value is reset with default string using othermethod.
*/
// <Snippet4>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

// Create the callee transient dynamic assembly.
Type^ CreateCallee( AppDomain^ myAppDomain, AssemblyBuilderAccess access )
{
   // Create a simple name for the callee assembly.
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "EmittedAssembly";

   // Create the callee dynamic assembly.
   AssemblyBuilder^ myAssemblyBuilder = myAppDomain->DefineDynamicAssembly( myAssemblyName, access );

   // Create a dynamic module named "EmittedModule" in the callee assembly.
   ModuleBuilder^ myModule;
   if ( access == AssemblyBuilderAccess::Run )
   {
      myModule = myAssemblyBuilder->DefineDynamicModule( "EmittedModule" );
   }
   else
   {
      myModule = myAssemblyBuilder->DefineDynamicModule( "EmittedModule", "EmittedModule.mod" );
   }

   // <Snippet2>
   TypeBuilder^ helloWorldTypeBuilder = myModule->DefineType( "HelloWorld", TypeAttributes::Public );

   // Define a private String field named "m_greeting" in "HelloWorld" class.
   FieldBuilder^ greetingFieldBuilder = helloWorldTypeBuilder->DefineField( "m_greeting", String::typeid, FieldAttributes::Private );

   // Create constructor args and define constructor.
   array<Type^>^constructorArgs = {String::typeid};
   ConstructorBuilder^ constructor = helloWorldTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, constructorArgs );

   // Generate IL code for the method.The constructor stores its argument in the private field.
   ILGenerator^ constructorIL = constructor->GetILGenerator();
   constructorIL->Emit( OpCodes::Ldarg_0 );
   constructorIL->Emit( OpCodes::Ldarg_1 );
   constructorIL->Emit( OpCodes::Stfld, greetingFieldBuilder );
   constructorIL->Emit( OpCodes::Ret );

   // <Snippet1>
   // Define property Greeting.
   PropertyBuilder^ greetingPropertyBuilder = helloWorldTypeBuilder->DefineProperty( "Greeting", PropertyAttributes::None, String::typeid, nullptr );

   // Define the 'get_Greeting' method.
   MethodBuilder^ getGreetingMethod = helloWorldTypeBuilder->DefineMethod( "get_Greeting", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::HideBySig | MethodAttributes::SpecialName), String::typeid, nullptr );

   // Generate IL code for 'get_Greeting' method.
   ILGenerator^ methodIL = getGreetingMethod->GetILGenerator();
   methodIL->Emit( OpCodes::Ldarg_0 );
   methodIL->Emit( OpCodes::Ldfld, greetingFieldBuilder );
   methodIL->Emit( OpCodes::Ret );
   greetingPropertyBuilder->SetGetMethod( getGreetingMethod );
   // </Snippet1>


   // Define the set_Greeting method.
   array<Type^>^methodArgs = {String::typeid};
   MethodBuilder^ setGreetingMethod = helloWorldTypeBuilder->DefineMethod( "set_Greeting", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::HideBySig | MethodAttributes::SpecialName), void::typeid, methodArgs );

   // Generate IL code for set_Greeting method.
   methodIL = setGreetingMethod->GetILGenerator();
   methodIL->Emit( OpCodes::Ldarg_0 );
   methodIL->Emit( OpCodes::Ldarg_1 );
   methodIL->Emit( OpCodes::Stfld, greetingFieldBuilder );
   methodIL->Emit( OpCodes::Ret );
   greetingPropertyBuilder->SetSetMethod( setGreetingMethod );
   // </Snippet2>

   // <Snippet3>
   // Define the reset_Greeting method.
   MethodBuilder^ otherGreetingMethod = helloWorldTypeBuilder->DefineMethod( "reset_Greeting", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::HideBySig), void::typeid, nullptr );

   // Generate IL code for reset_Greeting method.
   methodIL = otherGreetingMethod->GetILGenerator();
   methodIL->Emit( OpCodes::Ldarg_0 );
   methodIL->Emit( OpCodes::Ldstr, "Default String." );
   methodIL->Emit( OpCodes::Stfld, greetingFieldBuilder );
   methodIL->Emit( OpCodes::Ret );
   greetingPropertyBuilder->AddOtherMethod( otherGreetingMethod );
   // </Snippet3>

   // Create the class HelloWorld.
   return (helloWorldTypeBuilder->CreateType());
}

int main()
{
   // Create the "HelloWorld" type in an assembly with mode 'RunAndSave'.
   Type^ helloWorldType = CreateCallee( Thread::GetDomain(), AssemblyBuilderAccess::RunAndSave );

   // Create an instance of the "HelloWorld" class.
   array<Object^>^temp0 = {"HelloWorld"};
   Object^ helloWorld = Activator::CreateInstance( helloWorldType, temp0 );
   Object^ returnValue = helloWorldType->InvokeMember( "Greeting", static_cast<BindingFlags>(BindingFlags::Default | BindingFlags::GetProperty), nullptr, helloWorld, nullptr );
   Console::WriteLine( "HelloWorld.GetGreeting returned: \"{0}\"", returnValue );

   // Set 'Greeting' property with 'NewMessage!!!'.
   array<Object^>^temp1 = {"New Message !!!"};
   helloWorldType->InvokeMember( "Greeting", static_cast<BindingFlags>(BindingFlags::Default | BindingFlags::SetProperty), nullptr, helloWorld, temp1 );
   returnValue = helloWorldType->InvokeMember( "Greeting", static_cast<BindingFlags>(BindingFlags::Default | BindingFlags::GetProperty), nullptr, helloWorld, nullptr );
   Console::WriteLine( "After Set operation HelloWorld.GetGreeting returned: \"{0}\"", returnValue );

   // Reset 'Greeting' property to 'Default String'.
   helloWorldType->InvokeMember( "reset_Greeting", static_cast<BindingFlags>(BindingFlags::Default | BindingFlags::InvokeMethod), nullptr, helloWorld, nullptr );
   returnValue = helloWorldType->InvokeMember( "Greeting", static_cast<BindingFlags>(BindingFlags::Default | BindingFlags::GetProperty), nullptr, helloWorld, nullptr );
   Console::WriteLine( "After Reset operation HelloWorld.GetGreeting returned: \"{0}\"", returnValue );
   AssemblyBuilder^ myAssembly = dynamic_cast<AssemblyBuilder^>(helloWorldType->Assembly);

   // Save to disk.
   myAssembly->Save( "EmittedAssembly.dll" );
}
// </Snippet4>
